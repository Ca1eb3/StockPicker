// Caleb Smith
// 10/04/2022
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;

namespace StockPicker
{
    // class to retrieve excel data
    public class ConnexionExcel
    {
        private string pathExcelFile;
        private ExcelQueryFactory urlConnexion;
        public ConnexionExcel(string Path)
        {
            this.pathExcelFile = Path;
            this.urlConnexion = new ExcelQueryFactory(pathExcelFile);
        }
        public string PathExcelFile
        {
            get { return this.pathExcelFile; }
        }
        public ExcelQueryFactory UrlConnexion
        {
            get { return this.urlConnexion; }
        }
    }
}
