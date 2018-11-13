using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using IO;

namespace BIZ
{
    public class ClassLogIn : ClassNotify
    {
        /// <summary>
        /// Instans af ClassPurchaseDB til senere brug
        /// </summary>
        ClassPurchaseDB CPDB = new ClassPurchaseDB();


        #region Fields

        private string _cprNr;
        private string _passWord;
        private ClassUser _CU;
        #endregion

        /// <summary>
        /// initiliaserer alle properties, så de ikke er null
        /// </summary>
        public ClassLogIn()
        {
            cprNr = "";
            passWord = "";
        }


        #region Properties

        public string cprNr
        {
            get { return _cprNr; }
            set
            {
                if (value != _cprNr)
                {
                    _cprNr = value;
                    Notify("cprNr");
                }
            }
        }

        public string passWord
        {
            get { return _passWord; }
            set
            {
                if (value != _passWord)
                {
                    _passWord = value;
                    Notify("passWord");
                }
            }
        }

        public ClassUser CU
        {
            get { return _CU; }
            set
            {
                if (_CU != value)
                {
                    _CU = value;
                    Notify("CU");
                }                
            }
        }
        #endregion


        /// <summary>
        /// Kalder til en metode i ClassPurchaseDB, der checker om der er indtastet korrekt brugernavn og adgangskode, og derefter henter brugeren
        /// </summary>
        /// <returns></returns>
        public ClassUser GetUserData()
        {
            return CU = CPDB.GetUser(cprNr, passWord);
        }
    }
}
