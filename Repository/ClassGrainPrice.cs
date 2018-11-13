using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassGrainPrice
    {
        private decimal _oatsPrice;
        private decimal _barleyPrice;
        private decimal _wheatPrice;
        private decimal _milletPrice;
        private decimal _cornPrice;
        private decimal _ricePrice;
        
        public ClassGrainPrice()
        {
            oatsPrice = 0;
            barleyPrice = 0;
            wheatPrice = 0;
            milletPrice = 0;
            cornPrice = 0;
            ricePrice = 0;
        }

        public ClassGrainPrice(string inData)
        {
            UpdatePrice(inData);
        }
        
        public decimal oatsPrice
        {
            get { return _oatsPrice; }
            set { _oatsPrice = value; }
        }
        
        public decimal barleyPrice
        {
            get { return _barleyPrice; }
            set { _barleyPrice = value; }
        }
        
        public decimal wheatPrice
        {
            get { return _wheatPrice; }
            set { _wheatPrice = value; }
        }

        public decimal milletPrice
        {
            get { return _milletPrice; }
            set { _milletPrice = value; }
        }

        public decimal cornPrice
        {
            get { return _cornPrice; }
            set { _cornPrice = value; }
        }

        public decimal ricePrice
        {
            get { return _ricePrice; }
            set { _ricePrice = value; }
        }

        private void UpdatePrice(string data)
        {
            data = data.Replace("<EOF>", "");
            string[] sa1 = data.Split(';');
            foreach (string item in sa1)
            {
                string[] sa2 = item.Split(':');
                switch (sa2[0])
                {
                    case "Oats":
                        _oatsPrice = Convert.ToDecimal(sa2[1]);
                        break;
                    case "Barley":
                        _barleyPrice = Convert.ToDecimal(sa2[1]);
                        break;
                    case "Wheat":
                        _wheatPrice = Convert.ToDecimal(sa2[1]);
                        break;
                    case "Millet":
                        _milletPrice = Convert.ToDecimal(sa2[1]);
                        break;
                    case "Corn":
                        _cornPrice = Convert.ToDecimal(sa2[1]);
                        break;
                    case "Rice":
                        _ricePrice = Convert.ToDecimal(sa2[1]);
                        break;
                    default:
                        break;
                }
            }            
        }       
    }
}
