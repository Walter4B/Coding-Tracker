using Microsoft.Extensions.Configuration;

namespace Coding_Tracker
{
    internal class StringOutputClass
    {
        private readonly IConfiguration Configuration = GetConfig();

        internal void OutputString(string stringKey)
        {
            Console.WriteLine(Configuration[stringKey]);
        }

        internal void OutputString(string stringKey, DateTime time)
        {
            Console.WriteLine(Configuration[stringKey] +" "+ time.ToString());
        }

        internal static IConfigurationRoot GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Coding Tracker/appsettings.json");
            return (builder.Build());
        }

    }
}
