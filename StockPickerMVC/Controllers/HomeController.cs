using Microsoft.AspNetCore.Mvc;
using StockPickerMVC.Models;
using System;
using System.Diagnostics;
using Newtonsoft.Json;

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
            FileGateway gateway = new FileGateway();
            List<Stock> stocks = gateway.GetStocks("C:\\Users\\caleb\\Documents\\GitHub\\StockPicker\\constituents-financials_csv.csv");
            ViewBag.Stocks = stocks;
            return View();
        }

        public void UpdateStockData()
        {
            FileGateway gateway = new FileGateway();
            List<Stock> stocks = gateway.GetStocks("C:\\Users\\caleb\\Documents\\GitHub\\StockPicker\\constituents-financials_csv.csv");


            for (int i = 0; i < stocks.Count; i++)
            {
                stocks[i] = WebGateway.GetStockData(stocks[i]);
                stocks[i].CalculateEnterpriseValue();
            }

            gateway.SetStockData("C:\\Users\\caleb\\Documents\\GitHub\\StockPicker\\constituents-financials_csv.csv", stocks);
        }
    }
}
