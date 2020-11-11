using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Topshelf;

namespace TaxCalculator
{
    public class AppService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost:5000")
                .UseStartup<Startup>()
                .Build();

            host.Run();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }
    }
}
