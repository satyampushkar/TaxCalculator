using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Topshelf;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {            
            HostFactory.Run(x => x.Service<AppService>());

            //using(var db = new MunicipaltyTaxContext())
            //{
            //    var municipality1 = new Municipality
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Copenhagen"
            //    };
            //    db.Municipalities.Add(municipality1);

            //    var tax1 = new Tax
            //    {
            //        Id = Guid.NewGuid(),
            //        TaxType = TaxType.YEARLY,
            //        StartDate = new DateTime(2016, 1, 1),
            //        EndDate = new DateTime(2016, 12, 31),

            //        Municipality = municipality1,
            //        MunicipalityId = municipality1.Id
            //    };
            //    db.Taxes.Add(tax1);

            //    var tax2 = new Tax
            //    {
            //        Id = Guid.NewGuid(),
            //        TaxType = TaxType.MONTHLY,
            //        StartDate = new DateTime(2016, 5, 1),
            //        EndDate = new DateTime(2016, 5, 31),

            //        Municipality = municipality1,
            //        MunicipalityId = municipality1.Id
            //    };
            //    db.Taxes.Add(tax2);

            //    var tax3 = new Tax
            //    {
            //        Id = Guid.NewGuid(),
            //        TaxType = TaxType.DAILY,
            //        StartDate = new DateTime(2016, 12, 25),
            //        EndDate = new DateTime(2016, 12, 25),

            //        Municipality = municipality1,
            //        MunicipalityId = municipality1.Id
            //    };
            //    db.Taxes.Add(tax3);

            //    var tax4 = new Tax
            //    {
            //        Id = Guid.NewGuid(),
            //        TaxType = TaxType.DAILY,
            //        StartDate = new DateTime(2016, 1, 1),
            //        EndDate = new DateTime(2016, 1, 1),

            //        Municipality = municipality1,
            //        MunicipalityId = municipality1.Id
            //    };
            //    db.Taxes.Add(tax4);
            //    db.SaveChanges();

            //    //from csv
            //    using (var reader = new StreamReader(@"C:\temp\sample.csv"))
            //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //    {
            //        csv.Configuration.RegisterClassMap<TaxMap>();
            //        var taxes = csv.GetRecords<Tax>().ToList();

            //        var taxesGroupedByMunicipality = taxes.GroupBy(item => item.Municipality.Name)
            //            .Select(group => new { name = group.Key, Items = group.ToList() })
            //            .ToList();

            //        foreach (var item in taxesGroupedByMunicipality)
            //        {
            //            var municipality = new Municipality
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = item.name
            //            };
            //            db.Municipalities.Add(municipality);

            //            foreach (var it in item.Items)
            //            {
            //                db.Taxes.Add(
            //                    new Tax
            //                    {
            //                        Id = Guid.NewGuid(),
            //                        TaxType = it.TaxType,
            //                        StartDate = it.StartDate,
            //                        EndDate = it.EndDate,

            //                        Municipality = municipality,
            //                        MunicipalityId = municipality.Id
            //                    });
            //            }
            //        }
            //        db.SaveChanges();
            //    }
            //    //

            //    var municipalities = db.Municipalities;
            //    foreach (var municipality in municipalities)
            //    {
            //        foreach (var tax in municipality.Taxes)
            //        {
            //            Console.WriteLine($"{municipality.Name}\t{tax.TaxType}\t{tax.StartDate}\t{tax.EndDate}");
            //        }
            //    }
            //}

            //Console.ReadLine();
        }
    }

    //public class TaxMap : ClassMap<Tax>
    //{
    //    public TaxMap()
    //    {
    //        Map(m => m.Municipality.Name).Name("Municipality");
    //        Map(m => m.TaxType).Name("TaxType");
    //        Map(m => m.StartDate).Name("StartDate");
    //        Map(m => m.EndDate).Name("EndDate");
    //    }
    //}
}
