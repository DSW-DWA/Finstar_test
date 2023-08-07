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
        public static string InputFilePath { get; private set; }
        public static string OutputFilePath { get; private set; }

        public static void Load()
        {
            string currentProject = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            ConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            /*InputFilePath = Path.Combine(currentProject, ConfigurationManager.AppSettings["InputFileName"]);
            OutputFilePath = Path.Combine(currentProject, ConfigurationManager.AppSettings["OutputFileName"]);*/
            InputFilePath = ConfigurationManager.AppSettings["InputFilePath"];
            OutputFilePath = ConfigurationManager.AppSettings["OutputFilePath"];
        }
    }
}
