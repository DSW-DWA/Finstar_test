using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Finstar_test.Utils
{
    class AppConfig
    {
        public static string ConnectionString { get; private set; }

        public static void Load()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        }
    }
}
