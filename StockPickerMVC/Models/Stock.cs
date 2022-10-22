// Caleb Smith
// 10/21/2022
namespace StockPickerMVC.Models
{
    public class Stock
    {
        // Class variables
        private string companyName = "na";
        private string ticker = "na";
        private string marketCap = "na";

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
        public string MarketCap
        {
            get { return marketCap; }
            set { marketCap = value; }
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
        public Stock(string CompanyName, string Ticker, string MarketCap)
        {
            this.CompanyName = CompanyName;
            this.Ticker = Ticker;
            this.MarketCap = MarketCap;
        }

        // methods
        public override string ToString()
        {
            string message = $"Company Name: {CompanyName}  Ticker: {Ticker}  Market Cap: {MarketCap}";
            return message;
        }   
    }
}
