using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BreweriesDAO : IBreweriesDAO
    {
        private readonly string connectionString;

        public BreweriesDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }


        public IList<Brewery> GetBreweries()
        {
            List<Brewery> breweries = new List<Brewery>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT *  FROM brewery JOIN operation ON operation.brewery_id = brewery.brewery_id WHERE brewery.active =1";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        breweries.Add(breweryFromReader(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return breweries;
        }

        private Brewery breweryFromReader(SqlDataReader reader)
        {
            Brewery brewery = new Brewery();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();


            brewery.Name = Convert.ToString(reader["name"]);
            brewery.Brewery_id = Convert.ToInt32(reader["brewery_id"]);
            brewery.Address = Convert.ToString(reader["address"]);
            brewery.Brewery_img = Convert.ToString(reader["brewery_img"]);
            brewery.Active = Convert.ToBoolean(reader["active"]);
            brewery.History = Convert.ToString(reader["history"]);
            brewery.Phone_number = Convert.ToString(reader["phone_number"]);
            brewery.User_id = Convert.ToInt32(reader["user_id"]);
            brewery.Email = Convert.ToString(reader["brewery_email"]);

            string monday = Convert.ToString(reader["monday"]);
            string tuesday= Convert.ToString(reader["tuesday"]);
            string wednesday = Convert.ToString(reader["wednesday"]);
            string thursday  = Convert.ToString(reader["thursday"]);
            string friday = Convert.ToString(reader["friday"]);
            string saturday = Convert.ToString(reader["saturday"]);
            string sunday = Convert.ToString(reader["sunday"]);
            dictionary.Add("Monday", monday);
            dictionary.Add("Tuesday", tuesday);
            dictionary.Add("Wednesday", wednesday);
            dictionary.Add("Thursday", thursday);
            dictionary.Add("Friday", friday);
            dictionary.Add("Saturday", saturday);
            dictionary.Add("Sunday", sunday);
            brewery.HoursOfOperation = dictionary;
            return brewery;

        }

        public Brewery GetBreweryById(int id)
        {
            Brewery brewery = new Brewery();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT *  FROM brewery JOIN operation ON operation.brewery_id = brewery.brewery_id WHERE brewery.brewery_id =  @brewery_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("brewery_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                       brewery = breweryFromReader(reader);

                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return brewery;
        }
    }
}
