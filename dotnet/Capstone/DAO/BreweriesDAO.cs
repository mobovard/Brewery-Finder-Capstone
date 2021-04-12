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
            brewery.User_id = Convert.ToInt32(reader["user_id"]);

            if (!(reader["address"] is DBNull))
            {
                brewery.Address = Convert.ToString(reader["address"]);
            }

            if (!(reader["brewery_img"] is DBNull))
            {
                brewery.Brewery_img = Convert.ToString(reader["brewery_img"]);
            }

            if (!(reader["active"] is DBNull))
            {
                brewery.Active = Convert.ToBoolean(reader["active"]);
            }

            if (!(reader["history"] is DBNull))
            {
                brewery.History = Convert.ToString(reader["history"]);
            }

            if (!(reader["phone_number"] is DBNull))
            {
                brewery.Phone_number = Convert.ToString(reader["phone_number"]);
            }

            if (!(reader["brewery_email"] is DBNull))
            {
                brewery.Email = Convert.ToString(reader["brewery_email"]);
            }

            if (!(reader["logo"] is DBNull))
            {
                brewery.Logo = Convert.ToString(reader["logo"]);
            }

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
            Brewery brewery = null;
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

        public Brewery AddBrewery(Brewery brewery)
        {
            int id = 0;
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = "INSERT INTO brewery(name,phone_number,brewery_email,address,history,active,user_id,brewery_img,logo,zipcode,city,state) VALUES(@name,@phoneNumber,@brewery_email,@address,@history,@active,@user_id,@brewery_img,@logo,@zipcode,@city,@state);SELECT @@IDENTITY;";
                  

                    SqlCommand cmd = new SqlCommand(sql,conn);
                    cmd.Parameters.AddWithValue("@name", brewery.Name);
                    cmd.Parameters.AddWithNullableValue("@phoneNumber", brewery.Phone_number);
                    cmd.Parameters.AddWithNullableValue("@brewery_email", brewery.Email);
                    cmd.Parameters.AddWithNullableValue("@address", brewery.Address);
                    cmd.Parameters.AddWithNullableValue("@history", brewery.History);
                    cmd.Parameters.AddWithNullableValue("@active", brewery.Active);
                    cmd.Parameters.AddWithNullableValue("@logo", brewery.Logo);
                    cmd.Parameters.AddWithValue("@user_id", brewery.User_id);
                    cmd.Parameters.AddWithNullableValue("@brewery_img", brewery.Brewery_img);
                    cmd.Parameters.AddWithNullableValue("@zipcode", brewery.Zipcode);
                    cmd.Parameters.AddWithNullableValue("@city", brewery.City);
                    cmd.Parameters.AddWithNullableValue("@state", brewery.State);


                    
                    id = Convert.ToInt32(cmd.ExecuteScalar());


                    string sql2 = "INSERT INTO operation(monday,tuesday,wednesday,thursday,friday,saturday,sunday,brewery_id) VALUES(@monday,@tuesday,@wednesday,@thursday,@friday,@saturday,@sunday,@brewery_id)";
                    SqlCommand cmd2= new SqlCommand(sql2, conn);
                    brewery.HoursOfOperation.TryGetValue("Monday", out string monday);
                    brewery.HoursOfOperation.TryGetValue("Tuesday", out string tuesday);
                    brewery.HoursOfOperation.TryGetValue("Wednesday", out string wednesday);
                    brewery.HoursOfOperation.TryGetValue("Thursday", out string thursday);
                    brewery.HoursOfOperation.TryGetValue("Friday", out string friday);
                    brewery.HoursOfOperation.TryGetValue("Saturday", out string saturday);
                    brewery.HoursOfOperation.TryGetValue("Sunday", out string sunday);

                    cmd2.Parameters.AddWithValue("@monday", monday);
                    cmd2.Parameters.AddWithValue("@tuesday", tuesday);
                    cmd2.Parameters.AddWithValue("@wednesday", wednesday);
                    cmd2.Parameters.AddWithValue("@thursday", thursday);
                    cmd2.Parameters.AddWithValue("@friday", friday);
                    cmd2.Parameters.AddWithValue("@saturday", saturday);
                    cmd2.Parameters.AddWithValue("@sunday", sunday);
                    cmd2.Parameters.AddWithValue("@brewery_id", id);

                    cmd2.ExecuteNonQuery();
                    

                    
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return GetBreweryById(id);



        }
        public Brewery UpdateBrewery(Brewery updatedBrewery)
        {
            int totalRows = 0;
            Brewery brewery = new Brewery();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    string sql = "UPDATE brewery SET name = @name, phone_number = @phone_number,brewery_email=@brewery_email,address = @address,history = @history,active =@active,brewery_img=@brewery_img,user_id=@user_id,logo=@logo,zipcode=@zipcode,city=@city,state=@state WHERE brewery_id = @brewery_id;";


                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", updatedBrewery.Name);
                    cmd.Parameters.AddWithNullableValue("@phone_number", updatedBrewery.Phone_number);
                    cmd.Parameters.AddWithNullableValue("@brewery_email", updatedBrewery.Email);
                    cmd.Parameters.AddWithNullableValue("@address", updatedBrewery.Address);
                    cmd.Parameters.AddWithNullableValue("@history", updatedBrewery.History);
                    cmd.Parameters.AddWithNullableValue("@active", updatedBrewery.Active);
                    cmd.Parameters.AddWithNullableValue("@logo", updatedBrewery.Logo);
                    cmd.Parameters.AddWithValue("@user_id", updatedBrewery.User_id);
                    cmd.Parameters.AddWithNullableValue("@brewery_img", updatedBrewery.Brewery_img);
                    cmd.Parameters.AddWithNullableValue("@zipcode", brewery.Zipcode);
                    cmd.Parameters.AddWithNullableValue("@city", brewery.City);
                    cmd.Parameters.AddWithNullableValue("@state", brewery.State);

                    cmd.Parameters.AddWithValue("@brewery_id", updatedBrewery.Brewery_id);

                    int numberOfRowsBrewery = cmd.ExecuteNonQuery();
             



                    string sql2 = "UPDATE operation SET monday = @monday, tuesday = @tuesday, wednesday = @wednesday, thursday = @thursday, friday = @friday, saturday = @saturday, sunday = @sunday WHERE brewery_id = @brewery_id;";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    updatedBrewery.HoursOfOperation.TryGetValue("Monday", out string monday);
                    updatedBrewery.HoursOfOperation.TryGetValue("Tuesday", out string tuesday);
                    updatedBrewery.HoursOfOperation.TryGetValue("Wednesday", out string wednesday);
                    updatedBrewery.HoursOfOperation.TryGetValue("Thursday", out string thursday);
                    updatedBrewery.HoursOfOperation.TryGetValue("Friday", out string friday);
                    updatedBrewery.HoursOfOperation.TryGetValue("Saturday", out string saturday);
                    updatedBrewery.HoursOfOperation.TryGetValue("Sunday", out string sunday);

                    cmd2.Parameters.AddWithValue("@monday", monday);
                    cmd2.Parameters.AddWithValue("@tuesday", tuesday);
                    cmd2.Parameters.AddWithValue("@wednesday", wednesday);
                    cmd2.Parameters.AddWithValue("@thursday", thursday);
                    cmd2.Parameters.AddWithValue("@friday", friday);
                    cmd2.Parameters.AddWithValue("@saturday", saturday);
                    cmd2.Parameters.AddWithValue("@sunday", sunday);
                    cmd2.Parameters.AddWithValue("@brewery_id", updatedBrewery.Brewery_id);

                    int numberOfRowsOperation = cmd2.ExecuteNonQuery();
                    totalRows = numberOfRowsBrewery + numberOfRowsOperation;

                   
                    if (totalRows == 2)
                    {
                        brewery = updatedBrewery;
                    }
                    else
                    {
                        brewery = null;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return brewery;
        }
    }
}
