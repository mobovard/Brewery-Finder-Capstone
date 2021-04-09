using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]

    public class BeersController : ControllerBase
    {

        private readonly IBeerDAO beerDAO;

        public BeersController(IBeerDAO _beerDAO)
        {
            
            beerDAO = _beerDAO;
        }
    
        [HttpGet("/beers/{id}")]

        public ActionResult<Beer> GetBeerById(int id)
        {
            Beer beer = beerDAO.GetBeerById(id);

            if (beer != null)
            {
                return Ok(beer);
            }
            else
            {
                return NoContent();
            }
        }
        [Authorize(Roles ="Admin,Brewer")]
        [HttpPost("/beers")]
        public ActionResult<Beer> CreateBeer(Beer beer)
        {
            Beer beer1 = beerDAO.AddBeer(beer);
            if(beer1 != null)
            {
                return Ok(beer1);
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize(Roles = "Admin,Brewer")]
        [HttpPut("/beers")]
        public ActionResult<Beer> BeerActive(Beer updated)
        {
            Beer beer1 = beerDAO.UpdateBeer(updated);
            if(beer1 != null)
            {
                return Ok(beer1);

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
