﻿using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace PWCore.WebDriver
{
    public class BrowserConfig
    {
        public string BaseUrl { get; set; }
        public string Browser { get; set; }
        public bool Headless { get; set; }
        public int SlowMo { get; set; }
        public int Timeout { get; set; }
        public BrowserSettings Browsers { get; set; }

        public static BrowserConfig Load()
        {
            // Путь относительно bin (где запускаются тесты)
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configs/appsettings.json")
                .Build();

            string configPath = config["BrowserConfigPath"];
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), configPath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Config file not found: {fullPath}");

            var configJson = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<BrowserConfig>(configJson);
        }
    }

    public class BrowserSettings
    {
        public BrowserTypeConfig Chromium { get; set; }
        public BrowserTypeConfig Firefox { get; set; }
        public BrowserTypeConfig Webkit { get; set; }
    }

    public class BrowserTypeConfig
    {
        public string ExecutablePath { get; set; }
        public string[] Args { get; set; }
    }
}
