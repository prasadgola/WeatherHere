using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "b38f7e2c39fad9cf12b4df9d728a40c0";
            string city = "London";
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic weatherData = JsonConvert.DeserializeObject(json);

                    string cityName = weatherData.name;
                    double temperature = weatherData.main.temp - 273.15; // Convert temperature from Kelvin to Celsius
                    string weatherDescription = weatherData.weather[0].description;

                    Console.WriteLine($"City: {cityName}");
                    Console.WriteLine($"Temperature: {temperature:F2} °C"); // Display temperature with two decimal places
                    Console.WriteLine($"Weather: {weatherDescription}");
                }
                else
                {
                    Console.WriteLine("Failed to fetch weather data.");
                }
            }
        }
    }
}
