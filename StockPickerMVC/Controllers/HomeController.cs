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

        public void UpdatePredictions()
        {
            var process = new Process();

            // Set the filename and arguments for the Python script
            process.StartInfo.FileName = "C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\Python39_64\\python.exe";
            process.StartInfo.Arguments = "C:\\Users\\caleb\\Documents\\GitHub\\StockPicker\\SAGE\\SAGEPrediction.py";

            process.StartInfo.UseShellExecute = false;

            // Redirect the standard output and error streams
            process.StartInfo.RedirectStandardError = true;

            // Start the process
            process.Start();

            // Read the standard output and error streams
            string error = process.StandardError.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            Console.WriteLine(error);

        }
    }
}
