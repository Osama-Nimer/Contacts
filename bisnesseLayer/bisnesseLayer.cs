﻿using System;
using System.Data;
using DataLayer;
namespace bisnesseLayer
{
    public class clsContactBisnesseLayer
    {
        public enum enMode
        {
            Addnew = 0, 
            Update = 1
        }

        public enMode Mode= enMode.Addnew;

        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public DateTime BirthDate { get; set; }
        public String ImagePath{ get; set; }
        public int CountryID { get; set; }

        public clsContactBisnesseLayer()
        {
            ID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            BirthDate = DateTime.Now;
            ImagePath = "";
            CountryID = -1;
            Mode = enMode.Addnew;
        }
        private clsContactBisnesseLayer(int id , String FirstName ,String LastName , String Email ,String Phone ,String Address
            , DateTime BirthDate , String ImagePath ,int CountryId )
        {
            this.ID = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.BirthDate = BirthDate;
            this.ImagePath = ImagePath;
            this.CountryID = CountryId;
            Mode = enMode.Update;
        }

        public static clsContactBisnesseLayer Find(int id)
        {
            String FirstName = "", LastName = "", Email = "", Phone = "", Address = ""
            , ImagePath = "";
            int CountryId = -1;
            DateTime BirthDate = DateTime.Now;
            if (clsContactDataLayer.GetContactById(id, ref FirstName, ref LastName, ref Email, ref Phone, ref Address
                , ref BirthDate, ref ImagePath, ref CountryId))
            {
                return new clsContactBisnesseLayer(id, FirstName, LastName, Email, Phone, Address
                    , BirthDate, ImagePath, CountryId);
            }   
            else
                return null; 
        }


        private bool _AddNewContact()
        {
            this.ID = clsContactDataLayer.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.ImagePath, this.BirthDate , this.CountryID);
            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return clsContactDataLayer.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.BirthDate,  this.ImagePath ,this.CountryID);
        }

        public static bool _DeleteContact(int id) 
        {
            return clsContactDataLayer.DeleteContact(id);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewContact())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateContact();

            }

            return false;
        }

        public static DataTable GetAllContacts()
        {
            return clsContactDataLayer.GetAllContact();
        }

        public static bool IsExist(int id) {
            return clsContactDataLayer.IsExist(id);
        }
    }
}
