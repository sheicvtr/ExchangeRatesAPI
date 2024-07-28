using ExchangeRatesAPI.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ExchangeRatesAPI
{
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Currency>()
                .HasMany<ExchangeRate>()
                .WithOne()
                .HasForeignKey(er => er.BaseCurrency)
                .HasForeignKey(er => er.TargetCurrency);*/

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.BaseCurrencyNavigation)
                .WithMany(c => c.ExchangeRatesAsBaseCurrency)
                .HasForeignKey(er => er.BaseCurrency)
                .HasPrincipalKey(c => c.Symbol)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.TargetCurrencyNavigation)
                .WithMany(c => c.ExchangeRatesAsTargetCurrency)
                .HasForeignKey(er => er.TargetCurrency)
                .HasPrincipalKey(c => c.Symbol)
                .OnDelete(DeleteBehavior.Restrict);

          
        }
    }
}