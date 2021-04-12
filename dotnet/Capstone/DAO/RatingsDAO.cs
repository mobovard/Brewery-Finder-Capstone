using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public List<Ratings> GetRatingsByBeerId(int id)
        {
            List<Ratings> ratingList = new List<Ratings>();
            Ratings rating = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT rating_id,title,review,rating,user_id,beer_id,(SELECT username FROM users WHERE user_id = ratings.user_id)AS username FROM ratings WHERE beer_id = @beer_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@beer_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rating = ratingFromReader(reader);
                        ratingList.Add(rating);

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ratingList;
        }
        private Ratings ratingFromReader(SqlDataReader reader)
        {
            Ratings rating = new Ratings();

            rating.Rating = Convert.ToInt32(reader["rating"]);
            rating.Rating_id = Convert.ToInt32(reader["rating_id"]);
            rating.Review = Convert.ToString(reader["review"]);
            rating.Title = Convert.ToString(reader["title"]);
            rating.User_id = Convert.ToInt32(reader["user_id"]);
            rating.Beer_id = Convert.ToInt32(reader["beer_id"]);
            rating.Username = Convert.ToString(reader["username"]);
            

            //if (!(reader["active_beer"] is DBNull))
            //{
             //   beer.Active = Convert.ToBoolean(reader["active_beer"]);
            //}

            return rating;

        }
    }
}
