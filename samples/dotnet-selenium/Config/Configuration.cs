using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Testing.Foo.Config 
{
    public class Configuration
    {
        private static IConfiguration _configuration = null;
        private Configuration() {}

        public static IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                var environ = Environment.GetEnvironmentVariable("APP_ENV");
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Config/Env/default.json", optional: false, reloadOnChange: true);

                if (!string.IsNullOrEmpty(environ))
                {
                    builder.AddJsonFile($"Config/Env/{environ}.json", optional: true);
                }
                builder.AddEnvironmentVariables("AUT_");
                _configuration = builder.Build();
            }
            return _configuration;
        }
    }
}