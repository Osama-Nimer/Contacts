using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bisnesseLayer
{
    public class clsCountriesBusiness
    {
        enum enMode
        {
            AddNew = 0,
            Update = 1
        }
        enMode Mode = enMode.AddNew;
        public int CountryID{ get; set; }
        public String CountryName{ get; set; }
        public String Code{ get; set; }
        public String PhoneCode{ get; set; }

        public clsCountriesBusiness()
        {
            this.CountryID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";

            Mode = enMode.AddNew;
        }

        private clsCountriesBusiness(int CountryID ,String CountryName ,String Code , String PhoneCode)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.Update;
        }
        
        public static clsCountriesBusiness _GetConutryByID(int ID) {
            String CountryName = "";
            String Code = "";
            String PhoneCode = "d";

            if (clsCountriesDataAccess.GetCountryByID(ID, ref CountryName, ref Code, ref PhoneCode))
            {
                return new clsCountriesBusiness(ID, CountryName, Code, PhoneCode);
            }
            else
                return null;
        }           

        public static bool _IsExist(int ID)
        {
            return clsCountriesDataAccess.IsExist(ID);
        }

        private bool _AddNewCountry(String CountryName, String Code, String PhoneCode)
        {
            this.CountryID = clsCountriesDataAccess.AddNewCountry(this.CountryName,this.Code, this.PhoneCode);
            return (this.CountryID != -1);
        }

        public  bool _Save()
        {
            switch (Mode) {
                case  enMode.AddNew :
                    if (_AddNewCountry(this.CountryName, this.Code, this.PhoneCode))
                        return true;
                    else 
                        return false;
                //case  enMode.Update :
                //    return _UpdateCountry();
                        
            }
            return false;
        }


    }
}
