// Caleb Smith
// 10/04/2022
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPicker
{
    public class Stock
    {
        // Class Variables
        private string companyName = "na";
        private string ticker = "na";
        private double pE = double.MinValue;
        private double pricePerShare = double.MinValue;

        // gets and sets
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        public string Ticker
        {
            get { return ticker; }
            set { ticker = value; }
        }
        public double PE
        {
            get { return pE; }
            set { pE = value; }
        }
        public double PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }

        // Constructors
        public Stock()
        {

        }
        public Stock(string CompanyName, string Ticker, double PE, double PricePerShare)
        {
            this.CompanyName = CompanyName;
            this.Ticker = Ticker;
            this.PE = PE;
            this.PricePerShare = PricePerShare;
        }
        // Methods
        public override string ToString()
        {
            string message = "";
            message += $"Company Name: {CompanyName}\nTicker: {Ticker}\nP/E: {PE}\nPrice/Share: {PricePerShare}";
            return message;
        }
    }
}
