using Microsoft.AspNetCore.Mvc;
using StockPickerMVC.Models;

namespace StockPickerMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            FileGateway gateway = new FileGateway();
            List<Stock> stocks = gateway.GetStocks("C:\\Users\\caleb\\OneDrive\\Documents\\Computer Science Classes\\GitHub\\StockPicker\\constituents-financials_csv.csv");

            ViewBag.Stocks = stocks;

            return View();
        }
    }
}
