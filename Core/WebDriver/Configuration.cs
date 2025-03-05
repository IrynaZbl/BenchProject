using Microsoft.Extensions.Configuration;

namespace Core.WebDriver
{
    public class Configuration
    {
        public static BrowserType BrowserType;
        public static string AppUrl { get; private set; }
        private static string Type { get; set; }

        static Configuration()
        {
            Init();
        }

        public static void Init()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            Type = configuration["AppSettings:BrowserType"] ?? "Chrome";
            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), Type);
            AppUrl = configuration["AppSettings:ApplicationUrl"] ?? string.Empty;
        }
    }
}
