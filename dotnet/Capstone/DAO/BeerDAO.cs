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
            beer.Beer_type = Convert.ToString(reader["beer_type"]);
            beer.Active = Convert.ToBoolean(reader["active_beer"]);
     
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
                    string sql = "SELECT * FROM beers WHERE beer_id = @beer_id";
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

        public Beer AddBeer(Beer beer)
        {
            int myId = 0;
        
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO beers(name,description,img,abv,brewery_id,beer_type,active_beer) VALUES(@name,@description,@img,@abv,@brewery_id,@beer_type,@active_beer);SELECT @@IDENTITY;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", beer.Name);
                    cmd.Parameters.AddWithValue("@description", beer.Description);
                    cmd.Parameters.AddWithValue("@img", beer.Image);
                    cmd.Parameters.AddWithValue("@abv", beer.Abv);
                    cmd.Parameters.AddWithValue("@brewery_id", beer.Brewery_id);
                    cmd.Parameters.AddWithValue("@beer_type", beer.Beer_type);
                    cmd.Parameters.AddWithValue("@active_beer", beer.Active);

                    cmd.ExecuteNonQuery();
                    myId = Convert.ToInt32(cmd.ExecuteScalar());
                    
                   
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return GetBeerById(myId);
        }
        public Beer UpdateBeer(Beer updated)
        {
            Beer beer = new Beer();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "UPDATE beers SET active_beer = @active WHERE beers.beer_id = @beer_id";
                    SqlCommand cmd = new SqlCommand(sql,conn);
                    cmd.Parameters.AddWithValue("@active", updated.Active);
                    cmd.Parameters.AddWithValue("@beer_id", updated.Beer_id);
                    int numberOfRows =cmd.ExecuteNonQuery();
                    if(numberOfRows==1)
                    {
                        beer = updated;
                    }
                    else
                    {
                        beer = null;
                    }

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return beer;
        }
    }
    
}
