using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Models;
using TaxCalculator.Persistence.Services;

namespace TaxCalculator.Controllers
{
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;
        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpGet("tax")]
        public async Task<IActionResult> Get(string name, DateTime date)
        {
            try
            {
                var tax = await _taxService.Search(name, date);
                if (tax != null)
                {
                    return Ok(tax);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("tax")]
        public IActionResult Post([FromBody]Tax tax)
        {
            try
            {
                if (!IsValidTax(tax))
                {
                    return BadRequest();
                }
                _taxService.SaveAsync(new Tax
                {
                    Id = Guid.NewGuid(),
                    Municipality = tax.Municipality,
                    TaxType = tax.TaxType,
                    StartDate = tax.StartDate, 
                    EndDate = tax.EndDate
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("tax/upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            try
            {
                string fName = file.FileName;
                string path = @"../upload.csv";// + file.FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<TaxMap>();
                    var taxRows = csv.GetRecords<Tax>();

                    List<Tax> taxes = new List<Tax>();

                    foreach (var taxrow in taxRows)
                    {
                        Tax tax = new Tax
                        {
                            Id = Guid.NewGuid(),
                            Municipality = taxrow.Municipality,
                            TaxType = taxrow.TaxType,
                            StartDate = taxrow.StartDate,
                            EndDate = taxrow.EndDate
                        };
                        if (IsValidTax(tax))
                        {
                            taxes.Add(tax);
                        }
                    }

                    await _taxService.SaveAsync(taxes);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        private bool IsValidTax(Tax tax)
        {
            //Todo: month and year check
            switch (tax.TaxType)
            {
                case ETaxType.DAILY:
                    return tax.StartDate.Date == tax.EndDate.Date;
                case ETaxType.WEEKLY:
                    return (tax.EndDate.Date - tax.StartDate.Date).Days == 7;
                case ETaxType.MONTHLY:
                    return (tax.EndDate.Date - tax.StartDate.Date).Days == 30
                        || (tax.EndDate.Date - tax.StartDate.Date).Days == 31;
                case ETaxType.YEARLY:
                    return (tax.EndDate.Date - tax.StartDate.Date).Days == 365
                        || (tax.EndDate.Date - tax.StartDate.Date).Days == 366;
                default:
                    return false;
            }
        }

    }
    public class TaxMap : ClassMap<Tax>
    {
        public TaxMap()
        {
            Map(m => m.Municipality).Name("Municipality");
            Map(m => m.TaxType).Name("TaxType");
            Map(m => m.StartDate).Name("StartDate");
            Map(m => m.EndDate).Name("EndDate");
        }
    }
}
