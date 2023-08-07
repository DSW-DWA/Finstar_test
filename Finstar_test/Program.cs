using System;
using System.Configuration;
using CommandLine;
using Finstar_test.DataAccess;
using Finstar_test.Models;
using Finstar_test.Services;
using Finstar_test.Utils;
using log4net;
using log4net.Config;

namespace HelloWorld
{
    public class Program
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            try
            {
                CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                    .WithParsed<CommandLineOptions>(o =>
                    {
                        ValidateArguments(o);
                        var sqlQuery = FileService.ReadQueryFromFile(o.InputPath);
                        var connectionString = GetConnectionStringFromConfig();
                        var result = QueryExecutor.ExecuteQuery(sqlQuery, connectionString);
                        FileService.WriteResultToCsv(result, o.OutputPath);
                        Console.WriteLine("Query executed successfully.");
                        _log.Info("Query executed successfully.");

                    });
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
                _log.Error("File not found: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid argument: " + ex.Message);
                _log.Error("Invalid argument: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                _log.Error("An error occurred: " + ex.Message);
            }

            static void ValidateArguments(CommandLineOptions options)
            {
                if (options.InputPath == null || options.OutputPath == null)
                {
                    throw new ArgumentException("Arguments input and output must not be null.");
                }

                if (!File.Exists(options.InputPath))
                {
                    throw new FileNotFoundException("Input file doesn't exist.", options.InputPath);
                }

                if (!Path.GetExtension(options.InputPath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Input file must have the extension '.txt'.", nameof(options.InputPath));
                }
            }

            static string GetConnectionStringFromConfig()
            {
                return ConfigurationManager.ConnectionStrings["SqlConnection"]?.ConnectionString ?? throw new ConfigurationException("Connection string not found in the configuration.");
            }
        }
    }
}