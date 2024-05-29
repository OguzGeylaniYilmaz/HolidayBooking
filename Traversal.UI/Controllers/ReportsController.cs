using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Traversal.UI.Models;

namespace Traversal.UI.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
           List<DestinationModel> destinations = new List<DestinationModel>();
            using (var context = new Context())
            {
                destinations = context.Destinations.Select(x => new DestinationModel
                {
                    Capacity = x.Capacity,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    City = x.City,
                }).ToList();
            }
            return destinations;
        }
        public IActionResult ExcelReport()
        {
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tour List");
                workSheet.Cell(1, 1).Value = "City";
                workSheet.Cell(1, 2).Value = "Day&Night";
                workSheet.Cell(1, 3).Value = "Price";
                workSheet.Cell(1, 4).Value = "Capacity";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Newlist.xlsx");
                }
            }
        }

        public IActionResult PdfReport()
        {
            return View();
        }
    }
}
