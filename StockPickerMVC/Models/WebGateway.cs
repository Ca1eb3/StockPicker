// Caleb Smith
// 01/20/2023
using HtmlAgilityPack;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StockPickerMVC.Models
{
    public static class WebGateway
    {
        // class variables
        private static HtmlWeb web = new HtmlWeb();

        // methods
        public static Stock GetStockData(Stock stock)
        {
            // Create web driver and navigate google finance
            IWebDriver driver = new ChromeDriver("C:\\Users\\caleb\\Documents\\GitHub\\StockPicker");
            driver.Navigate().GoToUrl($"https://www.google.com/finance/quote/{stock.Ticker}:{stock.Exchange}?hl=en");

            // Find the button and click it
            IWebElement button = driver.FindElement(By.XPath("//*[@id=\"annual3\"]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", button);

            // retrieve Html from google finance
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(driver.PageSource);

            // get market data from html doc
            stock = GetMarketCap(stock, doc);
            stock = GetCash(stock, doc);
            stock = GetTotalLiabilities(stock, doc);

            // close driver and return stock
            driver.Quit();
            return stock;
        }
        private static Stock GetMarketCap(Stock stock, HtmlDocument doc)
        { 
            // get node containing market cap
            var node = doc.DocumentNode.Descendants("div")
                .Where(d => d.GetAttributeValue("class", "") == "P6K39c")
                .ElementAtOrDefault(3);

            // set market cap
            if (node != null)
            {
                string temp = node.InnerText;
                string tempNew = "";
                foreach (char c in temp)
                {
                    if (char.IsDigit(c) || c.Equals('.') || c.Equals('-'))
                    {
                        tempNew += c;
                    }
                }
                if (double.TryParse(tempNew, out double result))
                {
                    stock.MarketCap = result;
                }
            }
            return stock;
        }

        private static Stock GetCash(Stock stock, HtmlDocument doc)
        {
            // get node containing market cap
            var node = doc.DocumentNode.Descendants("td")
                .Where(d => d.GetAttributeValue("class", "") == "QXDnM")
                .ElementAtOrDefault(7);

            // set market cap
            if (node != null)
            {
                string temp = node.InnerText;
                string tempNew = "";
                foreach (char c in temp)
                {
                    if (char.IsDigit(c) || c.Equals('.') || c.Equals('-'))
                    {
                        tempNew += c;
                    }
                }
                if (double.TryParse(tempNew, out double result))
                {
                    stock.Cash = result;
                }
            }
            return stock;
        }

        private static Stock GetTotalLiabilities(Stock stock, HtmlDocument doc)
        {
            // get node containing market cap
            var node = doc.DocumentNode.Descendants("td")
                .Where(d => d.GetAttributeValue("class", "") == "QXDnM")
                .ElementAtOrDefault(9);

            // set market cap
            if (node != null)
            {
                string temp = node.InnerText;
                string tempNew = "";
                foreach (char c in temp)
                {
                    if (char.IsDigit(c) || c.Equals('.') || c.Equals('-'))
                    {
                        tempNew += c;
                    }
                }
                if (double.TryParse(tempNew, out double result))
                {
                    stock.TotalLiabilities = result;
                }
            }
            return stock;
        }

    }
}
