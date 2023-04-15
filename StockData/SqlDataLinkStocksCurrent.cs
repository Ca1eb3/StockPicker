// Caleb Smith
// 03/23/2003

using StockData.StocksCurrentTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData
{
    public static class SqlDataLinkStocksCurrent
    {
        public static List<Stock> GetStocks()
        {
            List<Stock> stocks = new List<Stock>();

            StocksCurrentTableAdapter adapter = new StocksCurrentTableAdapter();
            StocksCurrent.StocksCurrentDataTable stocksCurrentTable = adapter.GetData();

            DataRow[] rows = stocksCurrentTable.Select();

            foreach (DataRow row in rows)
            {
                if (!(row.ItemArray.Contains(DBNull.Value)))
                {
                    Stock stock = new Stock(Convert.ToString(row.ItemArray[0]), Convert.ToString(row.ItemArray[1]), Convert.ToDouble(row.ItemArray[2]), Convert.ToDouble(row.ItemArray[3]), Convert.ToDouble(row.ItemArray[4]), Convert.ToDouble(row.ItemArray[5]), Convert.ToString(row.ItemArray[6]), Convert.ToDouble(row.ItemArray[7]), Convert.ToDouble(row.ItemArray[8]), Convert.ToDouble(row.ItemArray[9]), Convert.ToDouble(row.ItemArray[10]), Convert.ToDouble(row.ItemArray[11]), Convert.ToDouble(row.ItemArray[12]));
                    stocks.Add(stock);
                }
            }
            return stocks;
        }

        public static void UpdateStocks(List<Stock> stocks)
        {
            StocksCurrentTableAdapter adapter = new StocksCurrentTableAdapter();
            StocksCurrent.StocksCurrentDataTable stocksCurrentTable = adapter.GetData();
            stocksCurrentTable.Clear();
            adapter.Connection.Open();

            foreach (Stock stock in stocks)
            {
                using (var command = new SqlCommand("UPDATE StocksCurrent SET [Company Name]=@CompanyName, [Enterprise Value]=@EnterpriseValue, [Market Cap]=@MarketCap, [Cash]=@Cash, [Total Liabilities]=@TotalLiabilities, [Exchange]=@Exchange, [Net Profit Margin]=@NetProfitMargin, [Net Income]=@NetIncome, [Revenue Growth]=@RevenueGrowth, [Return EV]=@ReturnEV, [Share Price]=@SharePrice WHERE [Ticker]=@Ticker", adapter.Connection))
                {
                    command.Parameters.AddWithValue("@CompanyName", stock.CompanyName);
                    command.Parameters.AddWithValue("@EnterpriseValue", stock.EnterpriseValue);
                    command.Parameters.AddWithValue("@MarketCap", stock.MarketCap);
                    command.Parameters.AddWithValue("@Cash", stock.Cash);
                    command.Parameters.AddWithValue("@TotalLiabilities", stock.TotalLiabilities);
                    command.Parameters.AddWithValue("@Exchange", stock.Exchange);
                    command.Parameters.AddWithValue("@NetProfitMargin", stock.NetProfitMargin);
                    command.Parameters.AddWithValue("@NetIncome", stock.NetIncome);
                    command.Parameters.AddWithValue("@RevenueGrowth", stock.RevenueGrowth);
                    command.Parameters.AddWithValue("@ReturnEV", stock.ReturnEV);
                    command.Parameters.AddWithValue("@SharePrice", stock.SharePrice);
                    command.Parameters.AddWithValue("@Ticker", stock.Ticker);

                    command.ExecuteNonQuery();
                }
            }

            adapter.Connection.Close();
        }
    }
}
