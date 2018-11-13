using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassUser
    {
        private int _id;
        private string _name;
        private string _country;
        private string _userType;
        private string _mail;
        private string _userPhone;
        private string _userAddress;
        private string _zip;
        private string _city;

        public ClassUser()
        {
            id = 0;
            name = "";
            country = "";
            userType = "";
            mail = "";
            userPhone = "";
            userAddress = "";
            zip = "";
        }
        
        public ClassUser(int inId, string inName, string inCountry, string inUserType, string inMail, string inUserPhone, string inUserAddress, string inZip)
        {
            id = inId;
            name = inName;
            country = inCountry;
            userType = inUserType;
            mail = inMail;
            userPhone = inUserPhone;
            userAddress = inUserAddress;
            zip = inZip;
        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string userType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }   

        public string userPhone
        {
            get { return _userPhone; }
            set { _userPhone = value; }
        }

        public string userAddress
        {
            get { return _userAddress; }
            set { _userAddress = value; }
        }

        public string zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
    }
}
