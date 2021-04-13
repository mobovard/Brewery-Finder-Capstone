using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class FavoriteDAO: IFavoriteDAO
    {
        private readonly string connectionString;

        public FavoriteDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }
        public List<int> GetFavoriteBreweriesByUserId(int id)
        {
            List<int> breweryIds = new List<int>();
            Favorite favorite = new Favorite();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT brewery_id FROM favorites WHERE user_id = @user_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                         favorite.Brewery_id= Convert.ToInt32(reader["brewery_id"]);
                        breweryIds.Add(favorite.Brewery_id);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return breweryIds;
        }


    }
}
