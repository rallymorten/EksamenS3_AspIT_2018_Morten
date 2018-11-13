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
    /// Interaction logic for UCGrainDeal.xaml
    /// </summary>
    public partial class UCGrainDeal : UserControl
    {
        Grid gridMain;

        private ClassBIZ _CB;
        private ClassLogIn _CL;

        public UCGrainDeal(Grid inGrid, ClassBIZ inCB, ClassLogIn inCL)
        {
            InitializeComponent();
            CB = inCB;
            CL = inCL;
            gridMain = inGrid;
            gridMain.DataContext = CB;
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

        private void Button_Click(object sender, RoutedEventArgs e) // Refrain from purchase
        {
            UCGrainSupplier UCGS = new UCGrainSupplier(gridMain, CB, CL);
            gridMain.Children.Clear();
            gridMain.Children.Add(UCGS);
            CB.ClearGrainSupplierData();
        }
    }
}
