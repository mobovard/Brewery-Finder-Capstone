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
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteDAO favoriteDAO;

        public FavoriteController(IFavoriteDAO _favoriteDAO)
        {
            favoriteDAO = _favoriteDAO;
        }
        [HttpGet("/favorite/{id}")]

        public ActionResult<List<int>> GetFavoriteBreweries(int id)
        {
            List<int> favorites = favoriteDAO.GetFavoriteBreweriesByUserId(id);

            if(favorites != null)
            {
                return Ok(favorites);
            }
            else
            {
                return NoContent();
            }
            
        }
        [HttpPost("/favorite/{id}")]

        public ActionResult<Favorite> AddAFavorite(int id, int brewery_id)
        {
            Favorite favorite = favoriteDAO.AddFavorite(id, brewery_id);

            if(favorite != null)
            {
                return Ok(favorite);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
