// Caleb Smith
// 10/21/2022
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;

[Table(name: "StocksCurrent")]
public class Stock
{
    // Class variables
    private string ticker = "na";
    private string companyName = "na";
    private double enterpriseValue = double.NaN; // millions
    private double marketCap = double.NaN; // millions
    private double cash = double.NaN; // millions
    private double totalLiabilities = double.NaN; // millions
    private string exchange = "na";
    private double netProfitMargin = double.NaN;
    private double netIncome = double.NaN; // millions
    private double revenueGrowth = double.NaN;
    private double returnEV = double.NaN;
    private double sharePrice = double.NaN;
    private double shareGainsPrediction = double.NaN;

    // gets and sets
    [Column]
    public string Ticker
    {
        get { return ticker; }
        set { ticker = value; }
    }
    [Column]
    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }
    [Column]
    public double EnterpriseValue
    {
        get { return enterpriseValue; }
        set { enterpriseValue = value; }
    }
    [Column]
    public double MarketCap
    {
        get { return marketCap; }
        set { marketCap = value; }
    }
    [Column]
    public double Cash
    {
        get { return cash; }
        set { cash = value; }
    }
    [Column]
    public double TotalLiabilities
    {
        get { return totalLiabilities; }
        set { totalLiabilities = value; }
    }
    [Column]
    public string Exchange
    {
        get { return exchange; }
        set { exchange = value; }
    }
    [Column]
    public double NetProfitMargin
    {
        get { return netProfitMargin; }
        set { netProfitMargin = value; }
    }
    [Column]
    public double NetIncome
    {
        get { return netIncome; }
        set { netIncome = value; }
    }
    [Column]
    public double RevenueGrowth
    {
        get { return revenueGrowth; }
        set { revenueGrowth = value; }
    }
    [Column]
    public double ReturnEV
    {
        get { return returnEV; }
        set { returnEV = value; }
    }
    [Column]
    public double SharePrice
    {
        get { return sharePrice; }
        set { sharePrice = value; }
    }
    [Column]
    public double ShareGainsPrediction
    {
        get { return shareGainsPrediction; }
        set { shareGainsPrediction = value; }
    }

    // Constructors
    public Stock()
    {

    }
    public Stock(string Ticker, string CompanyName)
    {
        this.CompanyName = CompanyName;
        this.Ticker = Ticker;
    }
    public Stock(string Ticker, string CompanyName, string Exchange)
    {
        this.CompanyName = CompanyName;
        this.Ticker = Ticker;
        this.Exchange = Exchange;
    }
    public Stock(string Ticker, string CompanyName, double EnterpriseValue, double MarketCap, double Cash, double TotalLiabilities, string Exchange)
    {
        this.CompanyName = CompanyName;
        this.Ticker = Ticker;
        this.Exchange = Exchange;
        this.EnterpriseValue = EnterpriseValue;
        this.MarketCap = MarketCap;
        this.Cash = Cash;
        this.TotalLiabilities = TotalLiabilities;
    }
    public Stock(string Ticker, string CompanyName, double EnterpriseValue, double MarketCap, double Cash, double TotalLiabilities, string Exchange, double NetProfitMargin, double NetIncome, double RevenueGrowth, double ReturnEV, double SharePrice)
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
    public Stock(string Ticker, string CompanyName, double EnterpriseValue, double MarketCap, double Cash, double TotalLiabilities, string Exchange, double NetProfitMargin, double NetIncome, double RevenueGrowth, double ReturnEV, double SharePrice, double ShareGainsPrediction)
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
        this.ShareGainsPrediction = ShareGainsPrediction;
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
        this.ReturnEV = (this.NetIncome / this.EnterpriseValue) * 100;
    }
}
