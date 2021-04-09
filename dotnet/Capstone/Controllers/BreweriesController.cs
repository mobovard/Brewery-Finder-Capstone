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

    public class BreweriesController : ControllerBase
    {
        private readonly IBreweriesDAO breweriesDAO;

        private readonly IBeerDAO beerDAO;

        public BreweriesController(IBreweriesDAO _breweriesDAO, IBeerDAO _beerDAO)
        {
            breweriesDAO = _breweriesDAO;
            beerDAO = _beerDAO;
        }

        [HttpGet]

        public ActionResult<List<Brewery>> BreweryList()
        {

            IList<Brewery> breweries = breweriesDAO.GetBreweries();
            if (breweries != null)
            {
                return Ok(breweries);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("/breweries/{id}")]

        public ActionResult<Brewery> GetBreweryById(int id)
        {
            Brewery brewery = breweriesDAO.GetBreweryById(id);

            if (brewery != null)
            {
                return Ok(brewery);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("/breweries/{id}/beers")]

        public ActionResult<List<Beer>> BeersByBrewery(int id)
        {
            IList<Beer> beers = beerDAO.GetBeersByBrewery(id);

            if (beers != null)
            {
                return Ok(beers);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("/breweries/add")]

        public ActionResult<Brewery>  CreateBrewery(Brewery brewery)
        {
            Brewery brewery1 = breweriesDAO.AddBrewery(brewery);
            if(brewery1 != null)
            {
                return Ok(brewery1);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("/breweries/update")]

        public ActionResult<Brewery> UpdatedBrewery(Brewery updatedBrewery)
        {
            Brewery brewery1 = breweriesDAO.UpdateBrewery(updatedBrewery);
            if(brewery1 != null)
            {
                return Ok(brewery1);
            }
            else
            {
                return NoContent();
            }

        }
        


        


    }
}