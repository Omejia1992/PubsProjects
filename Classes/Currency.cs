using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsProjects.Classes
{
    public class Currency
    {
        /// <summary>
        /// Currency Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Currency Code or Abbreviation
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Currency recognized Symbol
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// From Dolar to curren currency, exchange rate
        /// </summary>
        public double ExchangeRate { get; set; }

        /// <summary>
        /// Empty Constructor (just to create an object)
        /// </summary>
        public Currency() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="currencyCode"></param>
        /// <param name="symbol"></param>
        /// <param name="exchangeRate"></param>
        public Currency(string name, string currencyCode, char symbol, double exchangeRate)
        {
            Name = name;
            CurrencyCode = currencyCode;
            Symbol = symbol;
            ExchangeRate = exchangeRate;
        }

        /// <summary>
        /// Method to create a List of Currency Objects
        /// </summary>
        /// <returns>A list of Currency Objects</returns>
        public List<Currency> GetCurrencies()
        {
            List<Currency> currencies = new List<Currency>();

            Currency eur = new Currency("Euro", "eur", '€', 0.92);
            Currency pound = new Currency("Pound", "pnd", '£', 0.79);
            Currency usd = new Currency("Dollar", "usd", '$', 1);

            currencies.Add(eur);                
            currencies.Add(pound);
            currencies.Add(usd);

            return currencies;
        }
    }
}