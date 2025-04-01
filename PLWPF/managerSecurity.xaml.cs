using BL;
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
using System.Windows.Shapes;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for managerSecurity.xaml
    /// </summary>
    public partial class managerSecurity : Window
    {
        IBL myBL;
        public managerSecurity(IBL bL)
        {
            this.FlowDirection = FlowDirection.RightToLeft;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = bL;
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TxtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void BtnEnter_Click_1(object sender, RoutedEventArgs e)
        {
            if (pBox.Password==Configuration.GetmPassword())
            {
                managerOptions guestEntrance = new managerOptions(myBL);
                guestEntrance.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("סיסמא שגויה!","תקלה");
            }
            
        }
    }
}

