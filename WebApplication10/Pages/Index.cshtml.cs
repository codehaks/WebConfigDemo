using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace WebApplication10.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<MyAppOptions> _options;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IOptionsMonitor<MyAppOptions> options)
        {
            _logger = logger;
            _configuration = configuration;
            _options = options;
        }

        public List<KeyValuePair<string, string>> ConfigList { get; set; }

        public string Message { get; set; }
        public string Url { get; set; }
        public int Year { get; set; }

        public long SmsNumber { get; set; }
        public int PageLength { get; set; }
        public string DocPath { get; set; }

        public void OnGet()
        {
            SmsNumber = _options.CurrentValue.SmsNumber;
            Message = _configuration["Message"];

            Url = _configuration["app:url"];
            Year = int.Parse(_configuration["app:year"]);

            var configs = _configuration.GetChildren();
            ConfigList = new List<KeyValuePair<string, string>>();

            foreach (var config in configs)
            {
                ConfigList.Add(new KeyValuePair<string, string>(config.Key, config.Value));
            }
        }
    }
}
