using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DotNETInternshipTasksApp.Task08_CountryDataGenerator.Models;

namespace DotNETInternshipTasksApp.Task08_CountryDataGenerator
{
    public class CountryService
    {
        private const string ApiUrl = "https://restcountries.com/v3.1/all?fields=name,region,subregion,latlng,area,population";

        public async Task<bool> GenerateCountryDataFiles()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(ApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"❌ Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return false;
                }

                string content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var countries = JsonSerializer.Deserialize<List<CountryModel>>(content, options);

                if (countries == null || countries.Count == 0)
                {
                    Console.WriteLine("❌ Failed to deserialize country data or no data received.");
                    return false;
                }

                Directory.CreateDirectory("Countries");

                int createdFilesCount = 0;

                foreach (var country in countries.OrderBy(c => c.Name?.Common))
                {
                    string fileName = SanitizeFileName(country.Name?.Common ?? "Unknown");

                    string txtPath = Path.Combine("Countries", $"{fileName}.txt");
                    string jsonPath = Path.Combine("Countries", $"{fileName}.json");

                    string info = $"Region: {country.Region ?? "N/A"}\n" +
                                  $"Subregion: {country.Subregion ?? "N/A"}\n" +
                                  $"LatLng: {string.Join(", ", country.LatLng ?? new List<double> { 0.0, 0.0 })}\n" +
                                  $"Area: {country.Area}\n" +
                                  $"Population: {country.Population}";

                    await File.WriteAllTextAsync(txtPath, info);

                    var jsonOptions = new JsonSerializerOptions
                    {
                        WriteIndented = true 
                    };
                    string jsonContent = JsonSerializer.Serialize(country, jsonOptions);
                    await File.WriteAllTextAsync(jsonPath, jsonContent);

                    createdFilesCount++;
                }


                return createdFilesCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception occurred: {ex.Message}");
                return false;
            }
        }

        private string SanitizeFileName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Unknown";

            var invalidChars = Path.GetInvalidFileNameChars();
            return new string(name.Where(c => !invalidChars.Contains(c)).ToArray());
        }
    }
}
