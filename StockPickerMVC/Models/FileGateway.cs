// Caleb Smith
// 10/21/2022
namespace StockPickerMVC.Models
{
    public class FileGateway
    {
        public List<Stock> GetStocks(string path)
        {
            List<Stock> stocks = new List<Stock>();
            string[] allRows;
            int index = 1;
            string[] aRow;
            Stock stock;

            allRows = File.ReadAllLines(path);

            while (index < allRows.Length)
            {
                aRow = allRows[index].Split(',');
                stock = new Stock(aRow[1], aRow[0], aRow[2], Convert.ToDouble(aRow[3]), Convert.ToDouble(aRow[4]), Convert.ToDouble(aRow[5]), Convert.ToDouble(aRow[6]), Convert.ToDouble(aRow[7]), Convert.ToDouble(aRow[8]), Convert.ToDouble(aRow[9]), Convert.ToDouble(aRow[10]), Convert.ToDouble(aRow[11]));
                stocks.Add(stock);
                index++;
            }

            return stocks;
        }

        public void SetStockData(string path, List<Stock> stocks)
        {
            List<string> csvalltext = new List<string>();
            string headerrow = "Symbol,Name,Exchange,Enterprise Value,Market Cap,Cash,Total Liabilities,Net Profit Margin,Net Income,Revenue Growth,Return on EV,Share Price";
            csvalltext.Add(headerrow);

            foreach (Stock stock in stocks)
            {
                string csvtext = $"{stock.Ticker},{stock.CompanyName},{stock.Exchange},{stock.EnterpriseValue},{stock.MarketCap},{stock.Cash},{stock.TotalLiabilities},{stock.NetProfitMargin},{stock.NetIncome},{stock.RevenueGrowth},{stock.ReturnEV},{stock.SharePrice}";
                csvalltext.Add(csvtext);
            }

            FileStream update = File.Create(path);
            update.Close();
            File.AppendAllLines(path, csvalltext);
        }
    }
}
