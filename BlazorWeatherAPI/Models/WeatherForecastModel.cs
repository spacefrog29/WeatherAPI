using System;
using System.Collections.Generic;

namespace BlazorWeatherApp.Model
{
    public class WeatherForecastModel
    {
        public ForecastModel[] Consolidated_weather { get; set; }
        public DateTime Time { get; set; }
        public DateTime Sun_rise { get; set; }
        public DateTime Sun_set { get; set; }
        public string Title { get; set; }
        public int Woeid { get; set; }
    }

    public class ForecastModel
    {
        public string Weather_state_name { get; set; }
        public string Weather_state_abbr { get; set; }
        public string Applicable_date { get; set; }
        public float Min_temp { get; set; }
        public float Max_temp { get; set; }
        public float The_temp { get; set; }
    }
}
