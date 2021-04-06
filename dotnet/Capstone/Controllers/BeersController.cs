using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

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
    }
}
