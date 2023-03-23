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
        private static readonly HtmlWeb web = new HtmlWeb();

        // methods
        public static Stock GetStockData(Stock stock)
        {
            // Create web driver and navigate google finance
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver("C:\\Users\\caleb\\Documents\\GitHub\\StockPicker", options);
            driver.Navigate().GoToUrl($"https://www.google.com/finance/quote/{stock.Ticker}:{stock.Exchange}?hl=en");

            // Find the button and click it
            if (driver.FindElements(By.XPath("//*[@id=\"annual3\"]")).Count == 0)
            {
                driver.Quit();
                return stock;
            }
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
            stock = GetNetProfitMargin(stock, doc);
            stock = GetNetIncome(stock, doc);
            stock = GetRevenueGrowth(stock, doc);
            stock = GetSharePrice(stock, doc);

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
                bool isBillions = false;
                if (temp.Contains('B'))
                {
                    isBillions = true;
                }
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
                    if (isBillions == true)
                    {
                        stock.MarketCap = result * 1000;
                    }
                    else
                    {
                        stock.MarketCap = result;
                    }
                }
            }
            return stock;
        }

        private static Stock GetCash(Stock stock, HtmlDocument doc)
        {
            // get node containing cash
            var node = doc.DocumentNode.Descendants("td")
                .Where(d => d.GetAttributeValue("class", "") == "QXDnM")
                .ElementAtOrDefault(7);

            // set cash
            if (node != null)
            {
                string temp = node.InnerText;
                bool isBillions = false;
                if (temp.Contains('B'))
                {
                    isBillions = true;
                }
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
                    if (isBillions == true)
                    {
                        stock.Cash = result * 1000;
                    }
                    else
                    {
                        stock.Cash = result;
                    }
                }
            }
            return stock;
        }

        private static Stock GetTotalLiabilities(Stock stock, HtmlDocument doc)
        {
            // get node containing total liabilities
            var node = doc.DocumentNode.Descendants("td")
                .Where(d => d.GetAttributeValue("class", "") == "QXDnM")
                .ElementAtOrDefault(9);

            // set total liabilities
            if (node != null)
            {
                string temp = node.InnerText;
                bool isBillions = false;
                if (temp.Contains('B'))
                {
                    isBillions = true;
                }
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
                    if (isBillions == true)
                    {
                        stock.TotalLiabilities = result * 1000;
                    }
                    else
                    {
                        stock.TotalLiabilities = result;
                    }
                }
            }
            return stock;
        }

        private static Stock GetNetProfitMargin(Stock stock, HtmlDocument doc)
        {
            // get node containing Net Profit Margin
            var node = doc.DocumentNode.Descendants("td")
                .Where(d => d.GetAttributeValue("class", "") == "QXDnM")
                .ElementAtOrDefault(3);

            // set net profit margin
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
                    stock.NetProfitMargin = result;
                }
            }
            return stock;
        }

        private static Stock GetNetIncome(Stock stock, HtmlDocument doc)
        {
            // get node containing net income
            var node = doc.DocumentNode.Descendants("td")
                .Where(d => d.GetAttributeValue("class", "") == "QXDnM")
                .ElementAtOrDefault(2);

            // set net income
            if (node != null)
            {
                string temp = node.InnerText;
                bool isBillions = false;
                if (temp.Contains('B'))
                {
                    isBillions = true;
                }
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
                    if (isBillions == true)
                    {
                        stock.NetIncome = result * 1000;
                    }
                    else
                    {
                        stock.NetIncome = result;
                    }
                }
            }
            return stock;
        }

        private static Stock GetRevenueGrowth(Stock stock, HtmlDocument doc)
        {
            // get node containing revenue growth
            var node = doc.DocumentNode.Descendants("td")
                .Where(d => d.GetAttributeValue("class", "") == "gEUVJe")
                .ElementAtOrDefault(0);

            // set revenue growth
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
                    stock.RevenueGrowth = result;
                }
            }
            return stock;
        }

        private static Stock GetSharePrice(Stock stock, HtmlDocument doc)
        {
            // get node containing share price
            var node = doc.DocumentNode.Descendants("div")
                .Where(d => d.GetAttributeValue("class", "") == "P6K39c")
                .ElementAtOrDefault(0);

            // set share price
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
                    stock.SharePrice = result;
                }
            }
            return stock;
        }
    }
}
