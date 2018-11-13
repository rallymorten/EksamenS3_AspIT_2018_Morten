using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class ClassOrder
    {
        private int _id;
        private int _weight;
        private DateTime _orderDate;
        private decimal _orderPrice;
        private string _grainName;
        private string _userName;
        private string _businessName;
        private string _valutaName;
        private int _exchangeRate;

        public ClassOrder()
        {
            id = 0;
            weight = 0;
            orderDate = DateTime.Now;
            orderPrice = 0;
            grainName = "";
            userName = "";
            businessName = "";
            valutaName = "";
            exchangeRate = 0;
        }
        
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public int weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
       
        public DateTime orderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }
  
        public decimal orderPrice
        {
            get { return _orderPrice; }
            set { _orderPrice = value; }
        }

        public string grainName
        {
            get { return _grainName; }
            set { _grainName = value; }
        }

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string businessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }

        public string valutaName
        {
            get { return _valutaName; }
            set { _valutaName = value; }
        }

        public int exchangeRate
        {
            get { return _exchangeRate; }
            set { _exchangeRate = value; }
        }

    }
}
