using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApplication10.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public List<KeyValuePair<string, string>> ConfigList { get; set; }

        public string Message { get; set; }
        public string Url { get; set; }
        public int Year { get; set; }
        public void OnGet()
        {
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
