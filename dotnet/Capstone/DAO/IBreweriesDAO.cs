using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IBreweriesDAO
    {
        IList<Brewery> GetBreweriesBrewer(int userId);
        IList<Brewery> GetBreweriesAdmin();
        IList<Brewery> GetBreweriesUser();

        Brewery GetBreweryById(int id);

        Brewery AddBrewery(Brewery brewery);

        Brewery UpdateBrewery(Brewery updatedBrewery);
    }
}
