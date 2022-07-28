using la_mia_pizzeria_static.Database;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.API
{
    [Route("api/pizze")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            using (PizzaContext db = new PizzaContext())
            {
                IQueryable<Pizza> pizzaList = db.Pizza;

                if(search != null && search != "")
                {
                    pizzaList = pizzaList.Where(p => p.Name.Contains(search));
                }

                return Ok(pizzaList.ToList());
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.Pizza.Where(p => p.Id == id).Include("Category").Include("ingredients").FirstOrDefault();

                if(pizza == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(pizza);
                }
            }
        }
    }
}