// Caleb Smith
// 10/21/2022
namespace StockPickerMVC.Models
{
    public class FileGateway
    {
        public List<Stock> GetStocks(string path)
        {
            // In this case path includes filename
            // C:\\MyDocuments\data.csv
            List<Stock> stocks = new List<Stock>();
            string[] allRows;
            int index = 1;
            string[] aRow;
            Stock stock;

            allRows = File.ReadAllLines(path);

            while (index < allRows.Length)
            {
                aRow = allRows[index].Split(',');
                stock = new Stock(aRow[1], aRow[0], aRow[9]);
                stocks.Add(stock);
                index++;
            }

            return stocks;
        }
    }
}
