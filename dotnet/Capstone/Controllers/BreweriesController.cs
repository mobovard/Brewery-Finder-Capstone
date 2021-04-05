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

        public BreweriesController(IBreweriesDAO _breweriesDAO)
        {
            breweriesDAO = _breweriesDAO;
        }

        [HttpGet("/breweries")]

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


    }



}

