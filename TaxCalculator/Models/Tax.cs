using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Models
{
    public class Tax
    {
        public Guid Id { get; set; }
        public string Municipality { get; set; }
        public ETaxType TaxType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
