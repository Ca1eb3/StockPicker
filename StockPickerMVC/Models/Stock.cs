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
        private double netProfitMargin = double.NaN;
        private double netIncome = double.NaN; // billions
        private double revenueGrowth = double.NaN;
        private double returnEV = double.NaN;
        private double sharePrice = double.NaN;

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
        public double NetProfitMargin
        {
            get { return netProfitMargin; }
            set { netProfitMargin = value; }
        }
        public double NetIncome
        {
            get { return netIncome; }
            set { netIncome = value; }
        }
        public double RevenueGrowth
        {
            get { return revenueGrowth; }
            set { revenueGrowth = value;}
        }
        public double ReturnEV
        {
            get { return returnEV; }
            set { returnEV = value; }
        }
        public double SharePrice
        {
            get { return sharePrice; }
            set { sharePrice = value; }
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
        public Stock(string CompanyName, string Ticker, string Exchange, double EnterpriseValue, double MarketCap, double Cash, double TotalLiabilities, double NetProfitMargin, double NetIncome, double RevenueGrowth, double ReturnEV, double SharePrice)
        {
            this.CompanyName = CompanyName;
            this.Ticker = Ticker;
            this.Exchange = Exchange;
            this.EnterpriseValue = EnterpriseValue;
            this.MarketCap = MarketCap;
            this.Cash = Cash;
            this.TotalLiabilities = TotalLiabilities;
            this.NetProfitMargin = NetProfitMargin;
            this.NetIncome = NetIncome;
            this.RevenueGrowth = RevenueGrowth;
            this.ReturnEV = ReturnEV;
            this.SharePrice = SharePrice;
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

            // return on EV = Net Income / EV
            this.ReturnEV = this.NetIncome / this.EnterpriseValue;
        }
    }
}
