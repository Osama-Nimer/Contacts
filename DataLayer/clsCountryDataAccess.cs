using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsCountriesDataAccess
    {
        public static bool GetCountryByID(int CountryID, ref String CountryName, ref String Code, ref String PhoneCode)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(ConnString.ConnectionString);
            String Query = "select * from Countries where CountryID = @ID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("ID", CountryID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    CountryName = (String)reader["CountryName"];
                    Code = Convert.ToString(reader["Code"]);
                    PhoneCode = Convert.ToString(reader["PhoneCode"]);
                    reader.Close();
                }
                else
                    isFound = false;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return isFound;
        }

        public static bool IsExist(int ID)
        {
            bool IsExist = false;
            SqlConnection conn = new SqlConnection(ConnString.ConnectionString);
            String Query = "select CountryID from Countries where CountryID = @ID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("ID", ID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    IsExist = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsExist;

        }

        public static int AddNewCountry(String CountryName, String Code, String PhoneCode)
        {
            int CountryID = -1;
            SqlConnection connection = new SqlConnection(ConnString.ConnectionString);
            String Query = "Insert into Countries (CountryName , Code , PhoneCode )" +
                "values(@CountryName ,@Code,@PhoneCode);" +
                "Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@phoneCode", PhoneCode);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    CountryID = InsertedID;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { connection.Close(); }
            Console.WriteLine(CountryID);
            return CountryID;
        }

        public static bool DeleteCountryByID(int ID)
        {
            int rows = 0;
            SqlConnection conn = new SqlConnection(ConnString.ConnectionString);
            String Qurry = "Delete Countries where CountryID= @ID ";
            SqlCommand cmd = new SqlCommand(Qurry, conn);
            cmd.Parameters.AddWithValue("ID", ID);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return (rows > 0);
        }

        public static bool UpdateCountryByID(int ID, String CountryName, String Code, String PhoneCode)
        {
            int rows = 0;
            SqlConnection conn = new SqlConnection(ConnString.ConnectionString);
            String Query = "UPDATE Countries SET CountryName = @CountryName, code= @code ,PhoneCode = @PhoneCode" +
                " WHERE CountryID= @ID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("ID", ID);
            cmd.Parameters.AddWithValue("CountryName", CountryName);
            cmd.Parameters.AddWithValue("code", Code);
            cmd.Parameters.AddWithValue("PhoneCode", PhoneCode);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { conn.Close(); }
            return (rows > 0);
        }


        public static DataTable GetAllCountries()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(ConnString.ConnectionString);
            String Query = "Select * from Countries";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    table.Load(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { connection.Close(); }
            return table;
        }
    }
}

