using System;
using System.Collections.Generic;
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
            bool isFound =false;
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
            bool IsExist=false;
            SqlConnection conn = new SqlConnection(ConnString.ConnectionString);
            String Query = "select CountryID from Countries where CountryID = @ID";
            SqlCommand cmd = new SqlCommand(Query ,conn);
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
    }
}
