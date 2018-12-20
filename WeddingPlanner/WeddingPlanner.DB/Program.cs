using System;
using System.IO;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;

namespace WeddingPlanner.DB
{
    public class Program
    {
        static IConfiguration _configuration;

        public static int  Main(string[] args)
        {
            var connectionString = Configuration["ConnectionStrings:WeddingPlanner"];

            EnsureDatabase.For.SqlDatabase( connectionString );

            var upgrader =
                DeployChanges.To
                    .SqlDatabase( connectionString )
                    .WithScriptsEmbeddedInAssembly( Assembly.GetExecutingAssembly() )
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if( !result.Successful )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine( result.Error );
                Console.ResetColor();
                Console.ReadKey();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "Success!" );
            Console.ResetColor();
            Console.ReadKey();

            return 0;
        }

        static IConfiguration Configuration
        {
            get
            {
                if( _configuration == null )
                {
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath( Directory.GetCurrentDirectory() )
                        .AddJsonFile( "appsettings.json", optional: false )
                        .AddEnvironmentVariables()
                        .Build();
                }

                return _configuration;
            }
        }
    }
}
