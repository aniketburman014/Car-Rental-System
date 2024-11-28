using CarRentalSystem.Data;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext context;

        public AuthController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/auth
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public IActionResult GetCars()
        {
            var res = context.CarsDbContext.ToList();
            return Ok(res);
        }

        // POST: api/auth
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.CarsDbContext.Add(car);
            context.SaveChanges();
            return Ok();
        }

        // PUT: api/auth/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = context.CarsDbContext.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }

            // Update the properties
            car.Make = updatedCar.Make;
            car.Model = updatedCar.Model;
            car.Year = updatedCar.Year;
            car.PricePerDay = updatedCar.PricePerDay;
            car.IsAvailable = updatedCar.IsAvailable;

            context.CarsDbContext.Update(car);
            context.SaveChanges();
            return Ok(car);
        }

        // DELETE: api/auth/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCar(int id)
        {
            var car = context.CarsDbContext.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }

            context.CarsDbContext.Remove(car);
            context.SaveChanges();
            return Ok($"Car with ID {id} has been deleted.");
        }
    }
}
