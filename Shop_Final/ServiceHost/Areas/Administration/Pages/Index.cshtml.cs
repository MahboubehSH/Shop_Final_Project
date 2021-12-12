using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ServiceHost.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        public Chart DoughnutDataSet { get; set; }
        public List<Chart> BarLineDataSet { get; set; }

        public void OnGet()
        {
            BarLineDataSet = new List<Chart>
            {
                new Chart
                {
                    Label = "—»«  „Ê—çÂ",
                    Data = new List<int> {100, 200, 250, 170, 50 , 90 , 120 , 110 , 150 , 70 , 130 , 200},
                    BackgroundColor = new[] {"#ffcdb2"},
                    BorderColor = "#b5838d"
                },
                new Chart
                {
                    Label = "⁄‰ò»Ê ",
                    Data = new List<int> {200, 300, 350, 270, 100, 90 , 230 , 170 , 320 , 200 , 165, 95},
                    BackgroundColor = new[] {"#ffc8dd"},
                    BorderColor = "#ffafcc"
                },
                new Chart
                {
                    Label = "“‰»Ê— ⁄”·",
                    Data = new List<int> {300, 500, 600, 440, 150, 200, 250, 170, 50 , 90 , 120, 400},
                    BackgroundColor = new[] {"#0077b6"},
                    BorderColor = "#023e8a"
                },
                new Chart
                {
                    Label = "Œ—ç‰ê",
                    Data = new List<int> {300, 500, 600, 440, 150, 300, 350, 270, 100, 90 , 230 , 170},
                    BackgroundColor = new[] {"#0077b6"},
                    BorderColor = "#023e8a"
                }
            };
            DoughnutDataSet = new Chart
            {
                Label = "—»«  „Ê—çÂ",
                Data = new List<int> { 100, 200, 250, 170, 50, 90, 120, 110, 150, 70, 130, 200},
                BorderColor = "#ffcdb2",
                BackgroundColor = new[] { "#b5838d", "#ffd166", "#7f4f24", "#ef233c", "#003049" }
            };
        }
    }

    public class Chart
    {
        [JsonProperty(PropertyName = "label")] 
        public string Label { get; set; }

        [JsonProperty(PropertyName = "data")] 
        public List<int> Data { get; set; }

        [JsonProperty(PropertyName = "backgroundColor")]
        public string[] BackgroundColor { get; set; }

        [JsonProperty(PropertyName = "borderColor")]
        public string BorderColor { get; set; }
    }
}