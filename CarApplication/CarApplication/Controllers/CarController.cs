using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarApplication.Data;
using CarApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApplication.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] int year = 0, [FromQuery] string make = "",
            [FromQuery] string model = "", [FromQuery] string color = "")
        {
            List<string> options = new List<string>();
            if (year != 0)
            {
                options.Add("year");
                options.Add(year.ToString());
            }

            if (!string.IsNullOrEmpty(make))
            {
                options.Add("make");
                options.Add(make);
            }

            if (!string.IsNullOrEmpty(model))
            {
                options.Add("model");
                options.Add(model);
            }

            if (!string.IsNullOrEmpty(color))
            {
                options.Add("color");
                options.Add(color);
            }

            List<Car> cars =
                await Utilities.GetApiResponse<Car>("Car", "Search", "https://localhost:5003", options.ToArray());
            ViewBag.Make = make;
            ViewBag.Model = model;
            ViewBag.Color = color;
            ViewBag.Year = year;

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> CarListing([FromQuery] int id = 0)
        {
            Car car =
                (await Utilities.GetApiResponse<Car>("Car", "GetCar", "https://localhost:5003", "id", id.ToString())).FirstOrDefault();

            return View(car);
        }
    }
}