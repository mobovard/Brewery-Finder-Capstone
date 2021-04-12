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
        public Ratings GetRatingById(int id)
        {
            Ratings rating = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT rating_id,title,review,rating,user_id,beer_id,(SELECT username FROM users WHERE user_id = ratings.user_id)AS username FROM ratings";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@beer_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rating = ratingFromReader(reader);
                        

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rating;
        }
        public Ratings AddRating(Ratings rating)
        {
            int myId = 0;

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO ratings(title, review, rating, user_id, beer_id) VALUES(@title, @review, @rating, @user_id, @beer_id); SELECT @@IDENTITY;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                 

                    cmd.Parameters.AddWithValue("@title", rating.Title);
                    cmd.Parameters.AddWithValue("@review", rating.Review);
                    cmd.Parameters.AddWithValue("@rating", rating.Rating);
                    cmd.Parameters.AddWithValue("@user_id", rating.User_id);
                    cmd.Parameters.AddWithValue("@beer_id", rating.Beer_id);
                    



                    myId = Convert.ToInt32(cmd.ExecuteScalar());


                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return GetRatingById(myId);
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
