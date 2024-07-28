namespace ExchangeRatesAPI.Modelos
{
    public class Currency
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        public string Name { get; set; } = null!;

        public ICollection<ExchangeRate> ExchangeRatesAsBaseCurrency { get; set; }
        public ICollection<ExchangeRate> ExchangeRatesAsTargetCurrency { get; set; }
    }
}
