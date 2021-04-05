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
                    string sql = "SELECT * FROM brewery";

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

            brewery.Name = Convert.ToString(reader["name"]);
            brewery.Brewery_id = Convert.ToInt32(reader["brewery_id"]);
            brewery.Address = Convert.ToString(reader["address"]);
            brewery.Brewery_img = Convert.ToString(reader["brewery_img"]);
            brewery.Active = Convert.ToBoolean(reader["active"]);
            brewery.History = Convert.ToString(reader["history"]);
            brewery.Phone_number = Convert.ToString(reader["phone_number"]);
            brewery.Hours_of_operation = Convert.ToString(reader["hours_of_operation"]);
            brewery.User_id = Convert.ToInt32(reader["user_id"]);
            brewery.Email = Convert.ToString(reader["brewery_email"]);

            return brewery;

        }
    }
}
