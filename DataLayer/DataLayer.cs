using System.Data;
using System.Data.SqlClient;
using System.Numerics;
namespace DataLayer
{
    public class clsContactDataLayer
    {
        public static bool GetContactById(int Id , ref String FirstName, ref String LastName, ref String Email, ref String Phone, ref String Address
            , ref DateTime BirthDate, ref String ImagePath, ref int CountryId)
        {
            bool IsFound=false;
            SqlConnection conn = new SqlConnection(ConnString.ConnectionString);
            String Query = "select * from Contacts where ContactID = @ID";
            SqlCommand cmd = new SqlCommand(Query , conn);
            cmd.Parameters.AddWithValue ("ID", Id); 
            try
            {
                conn.Open ();
                SqlDataReader reader = cmd.ExecuteReader ();
                if (reader.Read()) 
                {
                    IsFound = true;
                    FirstName = (String)reader   ["FirstName"];
                    LastName = (String)reader    ["LastName"];
                    Email = (String)reader       ["Email"];
                    Phone = (String)reader       ["Phone"];
                    Address = (String)reader     ["Address"];
                    BirthDate = (DateTime)reader ["DateOfBirth"];
                    ImagePath = Convert.ToString(reader["ImagePath"]);
                    CountryId = (int)reader      ["CountryID"];

                    reader.Close ();
                }
                else
                    IsFound = false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                
                conn.Close ();
            }
            return IsFound;
        }
        public static int AddNewContact(string FirstName, string LastName,String Email ,String Phone 
            , String Address , String ImagePath, DateTime BirthDate , int CountryID)
        {
            int ContactID = -1;  
            SqlConnection conn = new SqlConnection(ConnString.ConnectionString);
            String Query = "INSERT INTO Contacts  (FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath)" +
                           "VALUES(@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath);" +
                           "Select SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(Query , conn);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", BirthDate);
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            try
            {
                conn.Open();
                Object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ContactID = InsertedID;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { conn.Close(); }

            return ContactID;

        }
    
        public static bool UpdateContact(int id  ,String FirstName ,String LastName , String Email ,String Phone
            , string Address , DateTime Birthdate , String ImagePath , int CountryID)
        {
            int rowAffected= 0;
            SqlConnection sqlConnection = new SqlConnection(ConnString.ConnectionString);
            String Query = "Update Contacts " +
                           "set FirstName = @FirstName," +
                           "LastName =@LastName," +
                           "Email = @Email," +
                           "Phone = @Phone," +
                           "Address =@Address," +
                           "DateOfBirth =@BirthDate," +
                           "ImagePath=@ImagePath," +
                           "CountryID =@CountryID " +
                           "where ContactID = @ContactID";
            SqlCommand Command = new SqlCommand(Query, sqlConnection); 
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName",LastName);
            Command.Parameters.AddWithValue("@Email", id);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@BirthDate", Birthdate);
            Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            Command.Parameters.AddWithValue("@ContactID", id);
            try
            {
                sqlConnection.Open();
                rowAffected= Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { sqlConnection.Close(); }
            return (rowAffected > 0);
        }
    
        public  static bool DeleteContact(int id )
        {
            int rows = 0;   
            SqlConnection conn =new SqlConnection(ConnString.ConnectionString);
            String Query = "Delete Contacts where ContactID = @id";
            SqlCommand cmd = new SqlCommand(Query,conn);
            cmd.Parameters.AddWithValue ("id", id);
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

        public static DataTable GetAllContact()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConnString.ConnectionString);
            String Query = "Select * From Contacts";
            SqlCommand command = new SqlCommand(Query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            
            return dt;
        }

        
        public static bool IsExist(int id)
        {
            bool IsExist= false;
            SqlConnection connection= new SqlConnection(ConnString.ConnectionString);
            string Query = "Select ContactID From Contacts where ContactID = @id";
            SqlCommand command= new SqlCommand(Query,connection);
            command.Parameters.AddWithValue ("id", id); 
            try
            {
                connection.Open ();
                SqlDataReader reader = command.ExecuteReader();

                IsExist = reader.HasRows;

                reader.Close ();
            }
            catch (Exception)
            {

                throw;
            }
            finally {connection.Close(); }  
            
            return IsExist;
        }

    }
}
