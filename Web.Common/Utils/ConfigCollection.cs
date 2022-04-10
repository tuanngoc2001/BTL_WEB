using Microsoft.Extensions.Configuration;
using System.IO;

namespace Web_Common
{
    class ConfigCollection
    {
        private readonly IConfigurationRoot configuration;
        public static ConfigCollection Instance { get; } = new ConfigCollection();
        protected ConfigCollection()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                                                             .Build();
        }
        public IConfigurationRoot GetConfiguration()
        {
            return configuration;
        }
    }
}
