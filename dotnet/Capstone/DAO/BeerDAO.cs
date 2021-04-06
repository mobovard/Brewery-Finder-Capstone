using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BeerDAO : IBeerDAO
    {
        private readonly string connectionString;

        public BeerDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }
        public IList<Beer> GetBeersByBrewery(int id)
        {
            List<Beer> beers = new List<Beer>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM beers WHERE brewery_id = @brewery_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("brewery_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        beers.Add(beerFromReader(reader));

                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return beers;
        }
        private Beer beerFromReader(SqlDataReader reader)
        {
            Beer beer = new Beer();

            beer.Name = Convert.ToString(reader["name"]);
            beer.Brewery_id = Convert.ToInt32(reader["brewery_id"]);
            beer.Image = Convert.ToString(reader["img"]);
            beer.Description = Convert.ToString(reader["description"]);
            beer.Beer_id = Convert.ToInt32(reader["beer_id"]);
            beer.Abv = Convert.ToDecimal(reader["abv"]);
     
            return beer;

        }
        public Beer GetBeerById(int id)
        {
            Beer beer = new Beer();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM beer WHERE beer_id = @beer_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("beer_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        beer = beerFromReader(reader);

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return beer;
        }
    }
    
}
