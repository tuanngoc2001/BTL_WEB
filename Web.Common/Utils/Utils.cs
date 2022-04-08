using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Utils
{
    public class Utils
    {
        public static string GetConfig(string code)
        {
            IConfigurationRoot configuration = ConfigCollection.Instance.GetConfiguration();
            var value = configuration[code];
            return value;
        }
    }
}
