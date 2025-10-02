using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotNETInternshipTasksApp.Task08_CountryDataGenerator.Models
{
    public class CountryModel
    {
        [JsonPropertyName("name")]
        public NameModel Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string Subregion { get; set; }

        [JsonPropertyName("latlng")]
        public List<double> LatLng { get; set; }

        [JsonPropertyName("area")]
        public double Area { get; set; }

        [JsonPropertyName("population")]
        public long Population { get; set; }
    }

    public class NameModel
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }
    }
}
