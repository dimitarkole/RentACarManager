using RentCar.Web.Tests.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Web.Tests
{
    public class TestStartup : Startup
    {
        private const string configurationFileName = "appsettings.Tests.json";

        public TestStartup(IConfiguration configuration) : base(configuration)
        {
            configuration = new ConfigurationBuilder()
               .AddJsonFile(configurationFileName)
               .Build();
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            //base.configureServices(services);
        }
    }
}
