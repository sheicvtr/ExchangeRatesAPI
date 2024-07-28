namespace ExchangeRatesAPI.Modelos
{
    public class FrankfurterHistoricaResponse
    {
        public string Base { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public Dictionary<string, Dictionary<string, decimal>> Rates { get; set; }
    }
}
