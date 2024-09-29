using System;
using System.Data;
using bisnesseLayer;
namespace PresentationLayer
{
    internal class Program
    {


        static void testFindContact(int ID)
        {
            clsContactBisnesseLayer c = clsContactBisnesseLayer.Find(ID);
            if (c != null)
            {
                Console.WriteLine(c.ID);
                Console.WriteLine(c.FirstName);
                Console.WriteLine(c.LastName);
                Console.WriteLine(c.Phone);
                Console.WriteLine(c.Email);
                Console.WriteLine(c.Address);
                Console.WriteLine(c.ImagePath);
                Console.WriteLine(c.BirthDate + "");
                Console.WriteLine(c.CountryID);
            }
        }

        static void testAddNewContact() 
        {
            clsContactBisnesseLayer contact = new clsContactBisnesseLayer();
            contact.FirstName = "Osama";
            contact.LastName = "Nimer";
            contact.Email = "osamafares23@yahoo.com";
            contact.Phone = "0782536729";
            contact.Address= "jawa";
            contact.BirthDate= new DateTime(2004,01,27,10,30,0);
            contact.CountryID = 2;
            contact.ImagePath= "C:osama.jpg";

            if (contact.Save())
            {
                Console.WriteLine("Contact Added Successfully by ID = "+contact.ID);
            }


        }

        static void testUpdateContact(int id) 
        {
            clsContactBisnesseLayer newContact = clsContactBisnesseLayer.Find(id);
            if (newContact != null)
            {
                newContact.FirstName = "Osama";
                newContact.LastName = "Nimer";
                newContact.Email = "qqqq@gmail.com";
                newContact.Phone = "111111";
                newContact.Address = "dfgh";
                newContact.BirthDate= DateTime.Now;
                newContact.CountryID = 2;
                newContact.ImagePath = "wertyui";
                
                if (newContact.Save())
                {
                    Console.WriteLine("Contact Updated Successfuly");
                }
                
            }
            else
                    Console.WriteLine("Not Found");

        }

        static void testDeleteContact(int id)
        {
            if (clsContactBisnesseLayer._DeleteContact(id))
                Console.WriteLine("Contact Deleted Successfully");
            else Console.WriteLine("Contact not Found");
        }

        static void testDataTable()
        {
            DataTable dt = clsContactBisnesseLayer.GetAllContacts();
            Console.WriteLine("Contacts Data");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["ContactID"]} , {row["FirstName"]} ,{row["LastName"]} ,{row["Phone"]}");
            }
        }

        static void testIsContactExist(int id)
        {
            if (clsContactBisnesseLayer.IsExist(id))
                Console.WriteLine("The Contact Is Exist");
            else
                Console.WriteLine("The Contact Is not Exist");
            
        }

        /*---------------------------------         Country        ---------------------------------------*/
        
        static void testFindCountry(int ID)
        {
            clsCountriesBusiness Country = clsCountriesBusiness._GetConutryByID(ID);
            if (Country != null)
            {
                Console.WriteLine($"ID = {Country.CountryID}");
                Console.WriteLine($"Country Name = {Country.CountryName}");
                Console.WriteLine($"Code = {Country.Code}");
                Console.WriteLine($"Phone Code = {Country.PhoneCode}");
            }
            else
                Console.WriteLine("Country is not Found !!");
        }

        static void testIsCountryExist(int ID)
        {
            if (clsCountriesBusiness._IsExist(ID))
            {
                Console.WriteLine("The Country Is Exist ");
            }
            else
                Console.WriteLine("The Country Is not Exist !! ");
        }

        static void testAddNewCountry()
        {
            clsCountriesBusiness country = new clsCountriesBusiness()
            {
                CountryName = "Jordan",
                Code = "962",
                PhoneCode = "962",
            };

            if(country._Save())
                Console.WriteLine($"Country Added Successfully by ID = {country.CountryID}");

        }
        
        static void Main(string[] args)
            {
            //testFindContact(2);
            //testAddNewContact();
            //testUpdateContact(2);
            //testDeleteContact(8);
            //testDataTable();
            //testIsContactExist(20);
            //testFindCountry(1);    
            //testIsCountryExist(20);
            testAddNewCountry();
        }
        } 
    }

