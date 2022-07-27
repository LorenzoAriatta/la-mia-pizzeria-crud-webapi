﻿using la_mia_pizzeria_static.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}

//creare partial e leggerlo istanziare dati e restituire html in response Ok(string"responsehtml")
// API RESPONSE HTML

/*[HttpGet]
        public ContentResult HTMLcards(string name, string image)
        {
            var html = HTML(name, image);

            return base.Content(html, "text/html");
        }

        [HttpGet]
        public IActionResult Get()
        {
            using (PizzaContext db = new PizzaContext())
            {
                IQueryable<Pizza> pizzaList = db.Pizza;

                foreach(Pizza p in pizzaList)
                {
                    string name = p.Name;
                    string image = p.Image;
                    //double price = p.Price;
                    //int id = p.Id;

                    HTMLcards(name, image);
                }
                
                return Ok(pizzaList);
            }
        }*/