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
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsDAO ratingsDAO;

        public RatingsController(IRatingsDAO _ratingsDAO)
        {
            ratingsDAO = _ratingsDAO;
        }
        [HttpGet("/ratings/{id}")]

        public ActionResult<List<Ratings>> GetRatingsByBeerId(int id)
        {
            List<Ratings> ratings = ratingsDAO.GetRatingsByBeerId(id);

            if (ratings != null)
            {
                return Ok(ratings);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost("/ratings")]
        public ActionResult<Ratings> CreateRating(Ratings rating)
        {
            Ratings rating1 = ratingsDAO.AddRating(rating);
            if (rating1 != null)
            {
                return Ok(rating1);
            }
            else
            {
                return BadRequest();
            }
        }
    }
 
}
