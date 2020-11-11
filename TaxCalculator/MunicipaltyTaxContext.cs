//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace TaxCalculator
//{
//    public class MunicipaltyTaxContext : DbContext
//    {
//        public DbSet<Municipality> Municipalities { get; set; }
//        public DbSet<Tax> Taxes { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseInMemoryDatabase("MunicipalityRaxes");
//        }
//    }

//    public class Municipality
//    {
//        public Guid Id { get; set; }
//        public string Name { get; set; }
//        public List<Tax> Taxes { get; set; }

//    }
//    public class Tax
//    {
//        public Guid Id { get; set; }
//        public TaxType TaxType { get; set; }
//        public DateTime StartDate { get; set; }
//        public DateTime EndDate { get; set; }

//        public Guid MunicipalityId { get; set; }
//        public Municipality Municipality { get; set; }
//    }
//    public enum TaxType
//    {
//        DAILY = 1,
//        WEEKLY = 2,
//        MONTHLY = 3,
//        YEARLY = 4
//    }
//}
