using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.Collections.ObjectModel;
using IO;
using System.Windows.Controls;
using System.Windows;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        /// <summary>
        /// Instanser af classes til senere brug
        /// </summary>
        ClassPurchaseDB CPDB = new ClassPurchaseDB();
        ClassAsynchronousClient CAC = new ClassAsynchronousClient();        

        #region Fields

        private ObservableCollection<ClassSupplier> _suppliers;
        private ObservableCollection<ClassGrainSort> _grainSorts;
        private ClassSupplier _CS;
        private ClassSalesAssistant _CSA;
        private ClassGrainSort _CGS;
        private ClassGrainPrice _CGP;
        private string _search;
        private string _buttonEditContext;
        private string _buttonEditState;
        private string _buttonNewState;
        private string _buttonNewContext;
        #endregion


        public ClassBIZ()
        {
            GetSuppliers();
            GetAllGrainSorts();
            GetGrainRates();
        }


        #region Properties

        public ObservableCollection<ClassSupplier> suppliers
        {
            get { return _suppliers; }
            set
            {
                if (value != _suppliers)
                {
                    _suppliers = value;
                    Notify("suppliers");
                }
            }
        }
        
        public ObservableCollection<ClassGrainSort> grainSorts
        {
            get { return _grainSorts; }
            set
            {
                if (value != _grainSorts)
                {

                    _grainSorts = value;
                    Notify("grainSorts");

                }
            }
        }

        public string search
        {
            get { return _search; }
            set
            {
                if (value != _search)
                {
                    _search = value;
                    if (_search != "")
                    {
                        suppliers = GetAllSuppliersUsingSearch(_search);
                    }
                    else
                    {
                        GetSuppliers();
                    }
                    Notify("search");
                }
            }
        }

        public ClassSalesAssistant CSA
        {
            get { return _CSA; }
            set
            {
                if (value != _CSA)
                {
                    _CSA = value;
                    Notify("CSA");
                }
            }
        }

        public ClassSupplier CS
        {
            get { return _CS; }
            set
            {
                if (value != _CS)
                {
                    _CS = value;
                    Notify("CS");
                }
            }
        }
        
        public ClassGrainSort CGS
        {
            get { return _CGS; }
            set { _CGS = value; }
        }

        public ClassGrainPrice CGP
        {
            get { return _CGP; }
            set
            {
                if (value != _CGP)
                {
                    _CGP = value;
                    Notify("CGP");
                }
            }
        }
        
        public string buttonEditState
        {
            get { return _buttonEditState; }
            set
            {
                if (value != _buttonEditState)
                {
                    _buttonEditState = value;
                    Notify("buttonEditState");
                }
            }
        }

        public string buttonEditContext
        {
            get { return _buttonEditContext; }
            set
            {
                _buttonEditContext = value;
                Notify("buttonEditContext");
            }
        }

        public string buttonNewState
        {
            get { return _buttonNewState; }
            set
            {
                if (value != _buttonNewState)
                {
                    _buttonNewState = value;
                    Notify("buttonNewState");
                }
            }
        }

        public string buttonNewContext
        {
            get { return _buttonNewContext; }
            set
            {
                _buttonNewContext = value;
                Notify("buttonNewContext");
            }
        }
        #endregion


        #region Metoder

        /// <summary>
        /// Kalder en metode i ClassPurchaseDB, der henter alle suppliers fra databasen
        /// </summary>
        /// <returns>en Observablecollection nu fyldt med data</returns>
        public ObservableCollection<ClassSupplier> GetSuppliers()
        {
            return suppliers = CPDB.GetAllSuppliers();
        }

        /// <summary>
        /// Kalder en metode i ClassPurchaseDB, der henter alle suppliers med et specifikt navn eller land fra databasen
        /// </summary>
        /// <returns>en Observablecollection nu fyldt med data</returns>
        public ObservableCollection<ClassSupplier> GetAllSuppliersUsingSearch(string search)
        {
            return suppliers = CPDB.GetAllSuppliersLike(search);
        }

        /// <summary>
        /// Gør så at ClassSupplier bliver fyldt med data fra den valgte Supplier ude på brugerfladen
        /// </summary>
        /// <param name="inObj"></param>
        public void SetSupplierData(object inObj)
        {
            ListView LV = inObj as ListView;
            if (LV.SelectedItem != null)
            {
                CS = (ClassSupplier)LV.SelectedItem;
            }
        }

        /// <summary>
        /// Resetter ClassSupplier og ClassSalesAssistant, så de er klar til at få ny data ind
        /// </summary>
        public void ClearGrainSupplierData()
        {
            CS = new ClassSupplier();
            CSA = new ClassSalesAssistant();
        }

        /// <summary>
        /// Kalder til en metode i ClassPurchaseDB, der henter en specifik 'salesassistant' der knytter sig til den valgte supplier
        /// </summary>
        /// <returns> En ClassSalesAssistant nu fyldt med data</returns>
        public ClassSalesAssistant GetSalesAssistant()
        {
            return CSA = CPDB.GetSalesAssistant(CS.salesAssistantId.ToString());
        }

        /// <summary>
        /// Tjekker om der er indtastet data i alle felter, før at databasen kan blive opdateret
        /// </summary>
        /// <returns></returns>
        public bool CheckInput()
        {
            bool resBool = true;

            if (CS.businessName == "") resBool = false;
            if (CS.address == "") resBool = false;
            if (CS.country == "") resBool = false;
            if (CS.mail == "") resBool = false;
            if (CS.phone == "") resBool = false;
            if (CSA.saDirectMail == "") resBool = false;
            if (CSA.saDirectPhone == "") resBool = false;
            if (CSA.saName == "") resBool = false;
            if (CSA.saPhone == "") resBool = false;

            return resBool;
        }

        /// <summary>
        /// Ændre hvad knappen gør og hvad der står på den via switch
        /// </summary>
        /// <param name="state"></param>
        public void SetEditButtonContext(string state)
        {
            switch (state)
            {
                case "0":
                    buttonEditContext = "Edit Supplier";
                    buttonEditState = "0";
                    break;
                case "1":
                    buttonEditContext = "Save";
                    buttonEditState = "1";
                    break;
                case "2":
                    buttonEditContext = "Update";
                    buttonEditState = "2";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Ændre hvad knappen gør og hvad der står på den via switch
        /// </summary>
        /// <param name="state"></param>
        public void SetNewButtonContext(string state)
        {
            switch (state)
            {
                case "0":
                    buttonNewContext = "Create New Supplier";
                    buttonNewState = "0";
                    break;
                case "1":
                    buttonNewContext = "Cancel";
                    buttonNewState = "1";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Kalder til en metode i ClassPurchaseDB, der gemmer en ny supplier og en ny sales assistant i databasen
        /// </summary>
        public void NewSupplierAndSalesAssistant()
        {
            CPDB.SaveNewSupplierAndSalesAssistant(CS, CSA);
            suppliers = GetSuppliers();
            ClearGrainSupplierData();
        }

        /// <summary>
        /// Kalder til en metode i ClassPurchaseDB, der opdaterer en specifik supplier og sales assistant i databasen
        /// </summary>
        public void UpdateSupplierAndSalesAssistant()
        {
            CPDB.UpdateSupplierAndSalesAssistantInDB(CS, CSA);
            suppliers = GetSuppliers();
            ClearGrainSupplierData();
        }

        /// <summary>
        /// Klader til en metode i ClassPurchaseDB, der henter alle korntyperne.
        /// </summary>
        public ObservableCollection<ClassGrainSort> GetAllGrainSorts()
        {
            return grainSorts = CPDB.GetGrainSortsFromDB();
        }

        public void GetGrainRates()
        {            
            CGP = new ClassGrainPrice(CAC.StartClient());            
        }
        #endregion
    }
}
