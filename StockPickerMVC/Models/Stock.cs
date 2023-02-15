// Caleb Smith
// 10/21/2022
namespace StockPickerMVC.Models
{
    public class Stock
    {
        // Class variables
        private string companyName = "na";
        private string ticker = "na";
        private double enterpriseValue = double.NaN; // billions
        private double marketCap = double.NaN; // billions
        private double cash = double.NaN; // billions
        private double totalLiabilities = double.NaN; // billions
        private string exchange = "na";

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
        public double EnterpriseValue
        {
            get { return enterpriseValue; }
            set { enterpriseValue = value; }
        }
        public double MarketCap
        {
            get { return marketCap; }
            set { marketCap = value; }
        }
        public double Cash
        {
            get { return cash; }
            set { cash = value; }
        }
        public double TotalLiabilities
        {
            get { return totalLiabilities; }
            set { totalLiabilities = value; }
        }
        public string Exchange
        {
            get { return exchange; }
            set { exchange = value; }
        }

        // Constructors
        public Stock()
        {

        }
        public Stock(string CompanyName, string Ticker)
        {
            this.CompanyName = CompanyName;
            this.Ticker = Ticker;
        }
        public Stock(string CompanyName, string Ticker, string Exchange)
        {
            this.CompanyName = CompanyName;
            this.Ticker = Ticker;
            this.Exchange = Exchange;
        }
        public Stock(string CompanyName, string Ticker, string Exchange, double EnterpriseValue, double MarketCap, double Cash, double TotalLiabilities)
        {
            this.CompanyName = CompanyName;
            this.Ticker = Ticker;
            this.Exchange = Exchange;
            this.EnterpriseValue = EnterpriseValue;
            this.MarketCap = MarketCap;
            this.Cash = Cash;
            this.TotalLiabilities = TotalLiabilities;
        }

        // methods
        public override string ToString()
        {
            string message = $"Company Name: {CompanyName}  Ticker: {Ticker} Exchange: {Exchange} Enterprise Value: {EnterpriseValue} Market Cap: {MarketCap} Cash: {Cash} Total Liabilities: {TotalLiabilities}";
            return message;
        }   
        public void CalculateEnterpriseValue()
        {
            // EV = MC + TL - C
            this.EnterpriseValue = this.MarketCap + this.TotalLiabilities - this.Cash;
        }
    }
}
