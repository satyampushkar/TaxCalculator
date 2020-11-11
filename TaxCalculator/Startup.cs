using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Persistence.Contexts;
using TaxCalculator.Persistence.Repositories;
using TaxCalculator.Persistence.Services;

namespace TaxCalculator
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            
            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("MunicipalityTaxes");
            });
            services.AddTransient<ITaxRepository, TaxRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITaxService, TaxService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
