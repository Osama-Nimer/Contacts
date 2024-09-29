using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bisnesseLayer
{
    internal class clsCountriesBusiness
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

        public clsCountriesBusiness(int CountryID ,String CountryName ,String Code , String PhoneCode)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.Update;
        }
        /*---------------------------------         Country        ---------------------------------------*/
        public 

    }
}
