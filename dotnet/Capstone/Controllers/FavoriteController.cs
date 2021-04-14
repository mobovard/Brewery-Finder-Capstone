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
        [HttpGet("/favorite")]

        public ActionResult<List<int>> GetFavoriteBreweries()
        {
            int.TryParse(User.FindFirst("sub")?.Value, out int wtfId);
            List<int> favorites = favoriteDAO.GetFavoriteBreweriesByUserId(wtfId);
            if (favorites.Count > 0)
            {
                return Ok(favorites);
            }
            else
            {
                return NoContent();
            }
            
        }
        [HttpPost("/favorite/{brewery_id}")]

        public ActionResult<Favorite> AddAFavorite(int brewery_id)
        {
            int.TryParse(User.FindFirst("sub")?.Value, out int myId);
            Favorite favorite = favoriteDAO.AddFavorite(myId, brewery_id);

            if(favorite != null)
            {
                return Ok(favorite);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("/favorite/{brewery_id}")]

        public ActionResult DeleteAFavorite(int brewery_id)
        {
            int.TryParse(User.FindFirst("sub")?.Value, out int myId);
            int nmbOfRows = favoriteDAO.DeleteFavorite(myId, brewery_id);

            if (nmbOfRows == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
