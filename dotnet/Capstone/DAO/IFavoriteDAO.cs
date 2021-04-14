using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IFavoriteDAO
    {
        List<int> GetFavoriteBreweriesByUserId(int id);
        Favorite AddFavorite(int user_id, int brewery_id);
        int DeleteFavorite(int user_id, int brewery_id);
    }
}
