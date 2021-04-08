using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IBreweriesDAO
    {
        IList<Brewery> GetBreweries();

        Brewery GetBreweryById(int id);

        Brewery AddBrewery(Brewery brewery, string monday, string tuesday, string wednesday, string thursday, string friday, string saturday, string sunday);
    }
}
