namespace ExchangeRatesAPI.Modelos
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public string BaseCurrency { get; set; } 
        public string TargetCurrency { get; set; } 
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }

        public Currency BaseCurrencyNavigation { get; set; }
        public Currency TargetCurrencyNavigation { get; set; }
    }
}
