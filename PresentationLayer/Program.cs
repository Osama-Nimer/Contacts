using System;
using System.Data;
using bisnesseLayer;
namespace PresentationLayer
{
    internal class Program
    {


        static void testFindContact(int ID)
        {
            clsbisnesseLayer c = clsbisnesseLayer.Find(ID);
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
            clsbisnesseLayer contact = new clsbisnesseLayer();
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
            clsbisnesseLayer newContact = clsbisnesseLayer.Find(id);
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
            if (clsbisnesseLayer._DeleteContact(id))
                Console.WriteLine("Contact Deleted Successfully");
            else Console.WriteLine("Contact not Found");
        }
            static void Main(string[] args)
            {
                //testFindContact(2);
                //testAddNewContact();
                //testUpdateContact(2);
                testDeleteContact(8);
            }
        } 
    }

