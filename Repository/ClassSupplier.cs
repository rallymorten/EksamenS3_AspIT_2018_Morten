using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassSupplier
    {
        private int _id;
        private string _businessName;
        private string _address;
        private string _zip;
        private string _city;
        private string _zipAndCity;
        private string _country;
        private string _mail;
        private string _phone;
        private int _salesAssistantId;
        private bool _status;

        public ClassSupplier()
        {
            id = 0;
            businessName = "";
            address = "";
            zip = "";
            city = "";
            zipAndCity = "";
            country = "";
            mail = "";
            phone = "";
            salesAssistantId = 0;
            status = true;
        }

        public ClassSupplier(int inId, string inBusinessName, string inAddress, string inZip, string inCity, string inCountry, string inPhone, string inMail, int inSalesAssistantId, bool inStatus)
        {
            id = inId;
            businessName = inBusinessName;
            address = inAddress;
            zip = inZip;
            city = inCity;
            country = inCountry;
            mail = inMail;
            phone = inPhone;
            salesAssistantId = inSalesAssistantId;
            status = inStatus;
            zipAndCity = zip + " - " + city;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string businessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }
        
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        public string zipAndCity
        {
            get { return _zipAndCity; }
            set { _zipAndCity = value; }
        }
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public int salesAssistantId
        {
            get { return _salesAssistantId; }
            set { _salesAssistantId = value; }
        }

        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
