using Microsoft.AspNetCore.Mvc;
using StockPickerMVC.Models;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockData;

namespace StockPickerMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult StockDataTable()
        {
            List<Stock> stocks = SqlDataLinkStocksCurrent.GetStocks();
            ViewBag.Stocks = stocks;
            return View();
        }

        public void UpdateStockData()
        {
            List<Stock> stocks = SqlDataLinkStocksCurrent.GetStocks();

            for (int i = 0; i < stocks.Count; i++)
            {
                stocks[i] = WebGateway.GetStockData(stocks[i]);
                stocks[i].CalculateEnterpriseValue();
            }

            SqlDataLinkStocksCurrent.UpdateStocks(stocks);
        }
    }
}
