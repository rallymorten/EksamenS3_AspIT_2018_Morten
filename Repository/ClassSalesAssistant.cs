using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassSalesAssistant
    {
        private int _id;
        private string _saName;
        private string _saDirectMail;
        private string _saDirectPhone;
        private string _saPhone;

        public ClassSalesAssistant()
        {
            id = 0;
            saName = "";
            saDirectMail = "";
            saDirectPhone = "";
            saPhone = "";
        }
        
        public ClassSalesAssistant(int inId, string inSaName, string inSaDirectMail, string inSaDirectPhone, string inSaPhone)
        {
            id = inId;
            saName = inSaName;
            saDirectMail = inSaDirectMail;
            saDirectPhone = inSaDirectPhone;
            saPhone = inSaPhone;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string saName
        {
            get { return _saName; }
            set { _saName = value; }
        }
       
        public string saPhone
        {
            get { return _saPhone; }
            set { _saPhone = value; }
        }

        public string saDirectPhone
        {
            get { return _saDirectPhone; }
            set { _saDirectPhone = value; }
        }
        
        public string saDirectMail
        {
            get { return _saDirectMail; }
            set { _saDirectMail = value; }
        }

    }
}
