using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Testing.Web.Config
{
    public class Configuration
    {
        private static IConfiguration _config = null;

        public static void Initialize(TestConfig testConfig)
        {
            if (_config != null)
                return;
            
            var environ = Environment.GetEnvironmentVariable("APP_ENV");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/Env/default.json", optional: false, reloadOnChange: true);

            if (!string.IsNullOrEmpty(environ))
            {
                builder.AddJsonFile($"Config/Env/{environ}.json", optional: true);
            }
            builder.AddEnvironmentVariables("AUT_");
            _config = builder.Build();
            _config.Bind(testConfig);
        }
    }
}