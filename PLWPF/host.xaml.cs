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
using BL;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for host.xaml
    /// </summary>
    public partial class host : Window
    {
        IBL bl;
        Host H;
        string id;
        Order o;
        // List<HostingUnit> listH;
        public host(IBL b, Host h, string d)
        {
            H = h;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = b;
            id = d;
            txbHi.Text = " שלום " + H.PrivateName + "!";
            lblOrders.Visibility = Visibility.Hidden;
            lblStatus.Visibility = Visibility.Hidden;
            cmbOrders.Visibility = Visibility.Hidden;
            cmbStatus.Visibility = Visibility.Hidden;
            btnOK.Visibility = Visibility.Hidden;

            string hKey = H.HostKey;
            List<Order> orders = new List<Order>();
            orders = bl.oListBy(hKey);
            cmbOrders.ItemsSource = orders;
            cmbStatus.ItemsSource = Enum.GetValues(typeof(Enums.orderStatus));
            //listH = bl.hostsList(id);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddhOstingUnit(bl, H).ShowDialog();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            new ViewHostingUnits(bl, id).ShowDialog();

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            new UpdateHostingUnit(bl, H, id).ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            new RemoveHostingUnit(bl, H, id).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new updateHostDetails(H, bl).ShowDialog();
        }

        private void btnOtherOptions_Click(object sender, RoutedEventArgs e)
        {
            new RequestsForHost(H, bl).ShowDialog();
        }

        private void BtnOrdersStatus_Click(object sender, RoutedEventArgs e)
        {
            lblOrders.Visibility = Visibility.Visible;
            lblStatus.Visibility = Visibility.Visible;
            cmbOrders.Visibility = Visibility.Visible;
            cmbStatus.Visibility = Visibility.Visible;
            btnOK.Visibility = Visibility.Visible;
        }

        private void CmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbStatus.Visibility = Visibility.Hidden;


        }

        private void CmbOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            o = (Order)cmbOrders.SelectedItem;
            tbStatus.Text = o.Status.ToString();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            o.Status = (Enums.orderStatus)cmbStatus.SelectedItem;
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show($"בבקשה בחר/י סטטוס לשינוי!", "שינוי סטטוס", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                bl._UpDateOrder(o);
                MessageBox.Show("סטטוס הזמנה עודכנה בהצלחה!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "תקלה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            lblOrders.Visibility = Visibility.Hidden;
            lblStatus.Visibility = Visibility.Hidden;
            cmbOrders.Visibility = Visibility.Hidden;
            cmbStatus.Visibility = Visibility.Hidden;
            btnOK.Visibility = Visibility.Hidden;

        }
    }
}
