using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App_Center
{

    public class Weather
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("tz_id")]
        public string TimeZoneId { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocalTimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
    }

    public class Current
    {
        [JsonPropertyName("last_updated_epoch")]
        public long LastUpdatedEpoch { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public double TemperatureCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public double TemperatureFahrenheit { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }

        [JsonPropertyName("wind_kph")]
        public double WindKph { get; set; }

        [JsonPropertyName("wind_degree")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("pressure_mb")]
        public double PressureMb { get; set; }

        [JsonPropertyName("pressure_in")]
        public double PressureIn { get; set; }

        [JsonPropertyName("precip_mm")]
        public double PrecipitationMm { get; set; }

        [JsonPropertyName("precip_in")]
        public double PrecipitationIn { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int CloudCover { get; set; }

        [JsonPropertyName("feelslike_c")]
        public double FeelsLikeCelsius { get; set; }

        [JsonPropertyName("feelslike_f")]
        public double FeelsLikeFahrenheit { get; set; }

        [JsonPropertyName("windchill_c")]
        public double WindChillCelsius { get; set; }

        [JsonPropertyName("windchill_f")]
        public double WindChillFahrenheit { get; set; }

        [JsonPropertyName("heatindex_c")]
        public double HeatIndexCelsius { get; set; }

        [JsonPropertyName("heatindex_f")]
        public double HeatIndexFahrenheit { get; set; }

        [JsonPropertyName("dewpoint_c")]
        public double DewPointCelsius { get; set; }

        [JsonPropertyName("dewpoint_f")]
        public double DewPointFahrenheit { get; set; }

        [JsonPropertyName("vis_km")]
        public double VisibilityKm { get; set; }

        [JsonPropertyName("vis_miles")]
        public double VisibilityMiles { get; set; }

        [JsonPropertyName("uv")]
        public double UvIndex { get; set; }

        [JsonPropertyName("gust_mph")]
        public double GustMph { get; set; }

        [JsonPropertyName("gust_kph")]
        public double GustKph { get; set; }
    }

    public class Condition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}

