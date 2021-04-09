using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RatingsDAO : IRatingsDAO
    {
        private readonly string connectionString;

        public RatingsDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }
    }
}
