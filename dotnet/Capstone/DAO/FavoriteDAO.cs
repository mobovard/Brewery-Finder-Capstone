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
        public Favorite GetFavoriteById(int id)
        {

            Favorite favorite = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM favorites WHERE favorite_id = @favorite_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@favorite_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        favorite = favoriteFromReader(reader);
                      

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return favorite;
        }
        private Favorite favoriteFromReader(SqlDataReader reader)
        {
            Favorite favorite = new Favorite();

            favorite.Brewery_id = Convert.ToInt32(reader["brewery_id"]);
            favorite.Favorite_id = Convert.ToInt32(reader["favorite_id"]);
            favorite.User_id = Convert.ToInt32(reader["user_id"]);

            return favorite;
        }
        public Favorite AddFavorite(int user_id,int brewery_id)
        {
            int id = 0;
            Favorite favorite = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO favorites(user_id,brewery_id) VALUES (@user_id,@brewery_id); SELECT @@IDENTITY";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id",user_id);
                    cmd.Parameters.AddWithValue("@brewery_id", brewery_id);

                    id =Convert.ToInt32(cmd.ExecuteScalar());
                    favorite = GetFavoriteById(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return favorite;
        }
        public int DeleteFavorite(int user_id, int brewery_id)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE  FROM favorites WHERE user_id =@user_id AND brewery_id = @brewery_id;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@brewery_id", brewery_id);

                    rowsAffected = Convert.ToInt32(cmd.ExecuteNonQuery());
                 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rowsAffected;
        }
    }

}
