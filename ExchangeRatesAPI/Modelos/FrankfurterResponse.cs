namespace ExchangeRatesAPI.Modelos
{
    public class FrankfurterResponse
    {
        public string Base { get; set; } = null!;
        public string Date { get; set; } = null!;
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
