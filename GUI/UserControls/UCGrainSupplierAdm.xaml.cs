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

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCGrainSupplierAdm.xaml
    /// </summary>
    public partial class UCGrainSupplierAdm : UserControl
    {
        private ClassBIZ _CB;
        private ClassLogIn _CL;

        Grid gridMain;

        public UCGrainSupplierAdm(Grid inGrid, ClassBIZ inCB, ClassLogIn inCL)
        {            
            InitializeComponent();
            CL = inCL;
            CB = inCB;
            gridMain = inGrid;
            gridMain.DataContext = CB;
            if (CB.buttonNewState == "0")
            {
                CB.ClearGrainSupplierData();
            }            
        }
        
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

        private void Button_Click(object sender, RoutedEventArgs e) // Save or update
        {
            if (CB.buttonNewState == "0")
            {
                if (CB.CheckInput() == true)
                {
                    CB.NewSupplierAndSalesAssistant();
                    CB.ClearGrainSupplierData();
                    UCGrainSupplier UCGS = new UCGrainSupplier(gridMain, CB, CL);
                    gridMain.Children.Clear();
                    gridMain.Children.Add(UCGS);
                }
                else
                {
                    MessageBox.Show("Du mangler at indtaste data.", "Datacheck", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                if (CB.CheckInput() == true)
                {
                    CB.UpdateSupplierAndSalesAssistant();
                    CB.ClearGrainSupplierData();
                    UCGrainSupplier UCGS = new UCGrainSupplier(gridMain, CB, CL);
                    gridMain.Children.Clear();
                    gridMain.Children.Add(UCGS);
                }
                else
                {
                    MessageBox.Show("Du mangler at indtaste data.", "Datacheck", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Cancel
        {
            CB.ClearGrainSupplierData();
            UCGrainSupplier UCGS = new UCGrainSupplier(gridMain, CB, CL);
            gridMain.Children.Clear();
            gridMain.Children.Add(UCGS);
        }
    }
}
