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
        }
    }
}
