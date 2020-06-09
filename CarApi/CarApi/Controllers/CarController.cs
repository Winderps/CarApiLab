using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CarApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext _context;

        public CarController(CarDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetCar")]
        public async Task<ActionResult<Car>> GetCar([FromQuery] int id = 0)
        {
            Car c = _context.Car.FirstOrDefault(x => x.Id.Equals(id));
            return c;
        }

        [HttpGet("Search")]
        public async Task<ActionResult<List<Car>>> SearchByMake([FromQuery] int? year = null, [FromQuery] string make = "", [FromQuery] string model = "", [FromQuery] string color = "")
        {
            IQueryable<Car> cars = _context.Car;
            
            if (!string.IsNullOrEmpty(make))
            {
                cars = cars.Where(x => x.Make.ToLower().Contains(make.ToLower()));
            }
            if (!string.IsNullOrEmpty(model))
            {
                cars = cars.Where(x => x.Model.ToLower().Contains(model.ToLower()));
            }
            if (!string.IsNullOrEmpty(color))
            {
                cars = cars.Where(x => x.Color.ToLower().Contains(color.ToLower()));
            }
            if (year != null)
            {
                cars = cars.Where(x => x.Year.Equals(year));
            }
            
            return cars.ToList();
        }
    }
}