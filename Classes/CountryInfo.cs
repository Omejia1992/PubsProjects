using PubsProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsProjects.Classes
{
    /// <summary>
    /// Country Information to handle
    /// the Orders information
    /// </summary>
    public class CountryInfo
    {
        /// <summary>
        /// Land (Country) object
        /// </summary>
        public Land Country{ get; set; }

        /// <summary>
        /// Currency Object
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Orders Amount per Country
        /// </summary>
        public int Orders { get; set; }

        /// <summary>
        /// Average Cost of the Orders
        /// </summary>
        public double OrderAverage { get; set; }

        /// <summary>
        /// Order Average converted 
        /// to another Currency
        /// </summary>
        public double OrderAverageConvert { get; set; }

        /// <summary>
        /// Freight Average Cost
        /// </summary>
        public double FreightAvg { get; set; }

        /// <summary>
        ///  Freight Average Cost Converted 
        ///  to another Currency
        /// </summary>
        public double FreightAvgConvert { get; set; }

        /// <summary>
        /// Empty Constructor (just to create an object)
        /// </summary>
        public CountryInfo() { }

        /// <summary>
        /// Constructor 
        /// </summary>
        public CountryInfo(Land country, Currency currency, view_CountryOrdersInfo ordInfo)
        {
            Country = country;
            Currency = currency;
            Orders = (int)ordInfo.CountryOrders;
            OrderAverage = Math.Round((double)ordInfo.CountryAvgDiscount,2);
            OrderAverageConvert = Math.Round(OrderAverage * currency.ExchangeRate,2);
            FreightAvg = Math.Round((double)ordInfo.FreightAvg, 2);
            FreightAvgConvert = Math.Round(FreightAvg * currency.ExchangeRate, 2);
        }
    }
}