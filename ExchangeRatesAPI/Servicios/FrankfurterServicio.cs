using ExchangeRatesAPI.Modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;


namespace ExchangeRatesAPI.Servicios
{
    public class FrankfurterServicio
    {

        private readonly HttpClient _httpClient;
        private readonly AppDbContext _context;

        public FrankfurterServicio(HttpClient httpClient, AppDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task<FrankfurterResponse> GetLatestRatesAsync()
        {
            var response = await _httpClient.GetAsync($"https://api.frankfurter.app/latest");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<FrankfurterResponse>(apiResponse);
            return data;
        }

        public async Task<FrankfurterResponse> GetHistoricalRateAsync(string date)
        {
            string newFormat = DateTime.ParseExact(date, "dd'-'MM'-'yyyy", CultureInfo.InvariantCulture).ToString("yyyy'-'MM'-'dd");
            Console.WriteLine("Today is " + newFormat);
            var response = await _httpClient.GetAsync($"https://api.frankfurter.app/{newFormat}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<FrankfurterResponse>(apiResponse);
            return data;
        }

        public async Task<FrankfurterHistoricaResponse> GetHistoricalRatesAsync(string startDate, string endDate)
        {
            string startDateFormat = DateTime.ParseExact(startDate, "dd'-'MM'-'yyyy", CultureInfo.InvariantCulture).ToString("yyyy'-'MM'-'dd");
            string endDateFormat = DateTime.ParseExact(endDate, "dd'-'MM'-'yyyy", CultureInfo.InvariantCulture).ToString("yyyy'-'MM'-'dd");
            var response = await _httpClient.GetAsync($"https://api.frankfurter.app/{startDateFormat}..{endDateFormat}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<FrankfurterHistoricaResponse>(apiResponse);
            return data;
        }
    }
}
    

