using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BIZ;
using Repository;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCGrainSupplier.xaml
    /// </summary>
    public partial class UCGrainSupplier : UserControl
    {
        /// <summary>
        /// Grid til brug af usercontrols
        /// </summary>
        Grid gridMain;


        #region Fields

        private ClassBIZ _CB;
        private ClassLogIn _CL;
        #endregion

        
        public UCGrainSupplier(Grid inGrid, ClassBIZ inCB, ClassLogIn inCL)
        {
            InitializeComponent();
            CB = inCB;
            CL = inCL;
            gridMain = inGrid;
            gridMain.DataContext = CB;
            CB.SetEditButtonContext("0");
            CB.SetNewButtonContext("0");
            MakeTextBoxesReadOnly();
        }


        #region Properties

        public ClassBIZ CB
        {
            get { return _CB; }
            set { _CB = value; }
        }

        public ClassLogIn CL
        {
            get { return _CL; }
            set { _CL = value; }
        }
        #endregion


        #region Event Handlers
        /// <summary>
        /// Eventhandler til den listview der er på brugerfladen. 
        /// Når der bliver valgt en supplier skal dens data dukke op i tekstboksene til højre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB.SetSupplierData(sender);
            CB.GetSalesAssistant();
            MakeTextBoxesReadOnly();            
        }

       /// <summary>
       /// Eventhandler til knappen 'create new supplier'.
       /// Bliver ændret til en annuler knap når der trykkes på denne eller når der trykkes på 'edit supplier'
       /// Styres via en switch
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void ButtonCreateNew(object sender, RoutedEventArgs e)
        {
            switch (buttonNew.Tag.ToString())
            {
                case "0": // "Create New Supplier"
                    if (lvSuppliers.SelectedItems.Count > 0)
                    {
                        if (CL.CU.userType == "Leder") 
                        {
                            CB.ClearGrainSupplierData();
                            MakeTexboxesEditable();
                            CB.SetEditButtonContext("1");
                            CB.SetNewButtonContext("1");
                            this.lvSuppliers.IsEnabled = false;
                            buttonChoose.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            UCGrainSupplierAdm UCGSA = new UCGrainSupplierAdm(gridMain, CB, CL);
                            gridMain.Children.Clear();
                            gridMain.Children.Add(UCGSA);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please choose the supplier you want to edit.");
                    }
                    break;
                case "1": //"Cancel" - Gemmer ikke data.
                        var answer = MessageBox.Show("Are you sure you want to cancel? - Data won't be saved.", "Cancel", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (answer.ToString() == "Yes")
                    {
                        CB.ClearGrainSupplierData();
                        CB.SetEditButtonContext("0");
                        CB.SetNewButtonContext("0");
                        this.lvSuppliers.IsEnabled = true;
                        MakeTextBoxesReadOnly();
                        buttonChoose.Visibility = Visibility.Visible;
                    }                        
                    break;
            }            
        }

        /// <summary>
        /// Eventhandler til knappen 'edit supplier'.
        /// Bliver ændret til enten at skulle opdatere i DB eller gemme ny data i DB,
        /// alt efter hvilken knap der bliver trykket på
        /// styres via en switch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (buttonEdit.Tag.ToString())
            {
                case "0": //"Edit Supplier"
                    if (CL.CU.userType == "Leder")
                    {                        
                        CB.SetEditButtonContext("2");
                        CB.SetNewButtonContext("1");
                        this.lvSuppliers.IsEnabled = false;
                        MakeTexboxesEditable();
                        buttonChoose.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        CB.SetNewButtonContext("1");
                        UCGrainSupplierAdm UCGSA = new UCGrainSupplierAdm(gridMain, CB, CL);
                        gridMain.Children.Clear();
                        gridMain.Children.Add(UCGSA);
                    }
                    break;
                case "1": //"Save" - gemmer en ny supplier og sales assistant i DB 
                    if (CB.CheckInput() == true)
                    {
                        CB.NewSupplierAndSalesAssistant();
                        CB.ClearGrainSupplierData();
                        CB.SetEditButtonContext("0");
                        CB.SetNewButtonContext("0");
                        this.lvSuppliers.IsEnabled = true;
                        MakeTextBoxesReadOnly();
                        buttonChoose.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Du mangler at indtaste data.", "Datacheck", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    break;
                case "2": //"Update" - opdaterer en eksisterende supplier og sales assistant i DB
                    if (CB.CheckInput() == true)
                    {
                        CB.UpdateSupplierAndSalesAssistant();
                        CB.SetEditButtonContext("0");
                        CB.SetNewButtonContext("0");
                        this.lvSuppliers.IsEnabled = true;
                        MakeTextBoxesReadOnly();
                        buttonChoose.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Du mangler at indtaste data.", "Datacheck", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    break;
            }
        }

        private void buttonChoose_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {

            }
            UCGrainDeal UCGD = new UCGrainDeal(gridMain, CB, CL);
            gridMain.Children.Clear();
            gridMain.Children.Add(UCGD);
        }
        #endregion


        #region Metoder

        /// <summary>
        /// Metode til at man kan skrive i tekstboksene til højre 
        /// - Der er sikkert en lettere måde at gøre dette på. 
        /// </summary>
        private void MakeTexboxesEditable()
        {
            this.tbSADMail.IsReadOnly = false;
            this.tbSADPhone.IsReadOnly = false;
            this.tbSAName.IsReadOnly = false;
            this.tbSAPhone.IsReadOnly = false;
            this.tbsupplierAddress.IsReadOnly = false;
            this.tbsupplierCountry.IsReadOnly = false;
            this.tbsupplierMail.IsReadOnly = false;
            this.tbsupplierName.IsReadOnly = false;
            this.tbsupplierPhone.IsReadOnly = false;
            this.tbsupplierZipAndCity.IsReadOnly = false;
        }

        /// <summary>
        /// Metode til at man IKKE kan skrive i tekstboksene til højre 
        /// - Der er sikkert en lettere måde at gøre dette på.
        /// </summary>
        private void MakeTextBoxesReadOnly()
        {
            this.tbSADMail.IsReadOnly = true;
            this.tbSADPhone.IsReadOnly = true;
            this.tbSAName.IsReadOnly = true;
            this.tbSAPhone.IsReadOnly = true;
            this.tbsupplierAddress.IsReadOnly = true;
            this.tbsupplierCountry.IsReadOnly = true;
            this.tbsupplierMail.IsReadOnly = true;
            this.tbsupplierName.IsReadOnly = true;
            this.tbsupplierPhone.IsReadOnly = true;
            this.tbsupplierZipAndCity.IsReadOnly = true;
        }
        #endregion
    }
}
