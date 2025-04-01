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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for managerOptions.xaml
    /// </summary>
    public partial class managerOptions : Window
    {

        IBL myBL;
        public bool IsClosedByButton { get; set; }
        public managerOptions(IBL bL)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = bL;
            IsClosedByButton = false;
            FlowDirection = FlowDirection.RightToLeft;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            lblCurCommission.Content = Configuration.GetCommission();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Configuration.SetCommission(Convert.ToUInt32(txtNewCommission.Text));
            MessageBox.Show("העמלה שונתה בהצלחה");
            lblCurCommission.Content = Configuration.GetCommission();
            txtNewCommission.Text = " ";
        }

        private void btnHosts_Click(object sender, RoutedEventArgs e)
        {
           new AllHosts(myBL).ShowDialog();

        }

        private void btnGuests_Click(object sender, RoutedEventArgs e)
        {
            new AllRequests(myBL).ShowDialog();
        }

        private void btnrders_Click(object sender, RoutedEventArgs e)
        {
             new AllOrders(myBL).ShowDialog();
        }

        private void BtnOthers_Click(object sender, RoutedEventArgs e)
        {
             new OthersOpManager(myBL).ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new managerPassword().ShowDialog();
        }
    }
}
