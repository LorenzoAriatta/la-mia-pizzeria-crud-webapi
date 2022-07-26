using la_mia_pizzeria_static.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.API
{
    [Route("api/pizze")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizze()
        {
            using (PizzaContext db = new PizzaContext())
            {
                IQueryable<Pizza> pizzaList = db.Pizza;

                return Ok(pizzaList.ToList());
            }
        }
    }
}
