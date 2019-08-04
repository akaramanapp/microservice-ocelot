using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace customerapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) => {
                    
                    var hostingEnvironment = webHostBuilderContext.HostingEnvironment;
                    configurationBuilder.AddConfigServer(hostingEnvironment.EnvironmentName);
                })
                .UseStartup<Startup>()
                //.UseUrls("http://localhost:7001/")
                .Build();
    }
}
