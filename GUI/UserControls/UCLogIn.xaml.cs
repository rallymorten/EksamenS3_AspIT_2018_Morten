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
    /// Interaction logic for UCLogIn.xaml
    /// </summary>
    public partial class UCLogIn : UserControl
    {
        ClassLogIn CL;
        Grid gridMain;
        ClassBIZ CB;
        ClassRegEx CRE = new ClassRegEx();
        bool checkRegEx;
        public UCLogIn(ClassLogIn inCL, Grid inGrid, ClassBIZ inCB)
        {
            InitializeComponent();
            CL = inCL;
            CB = inCB;
            gridMain = inGrid;
            gridMain.DataContext = CL;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            checkRegEx = CRE.IsValidDkSocialSecurityNumber(CL.cprNr);
            if (checkRegEx == false)
            {
                MessageBox.Show("Please enter a valid security number.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                CL.GetUserData();
                if (CL.CU.id == 0)
                {
                    MessageBox.Show("You've entered a wrong userId or password", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    UCGrainSupplier UCGS = new UCGrainSupplier(gridMain, CB, CL);
                    gridMain.Children.Clear();
                    gridMain.Children.Add(UCGS);
                }
            }            
        }
    }
}
