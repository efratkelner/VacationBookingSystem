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
    /// Interaction logic for GuestOptions.xaml
    /// </summary>
    public partial class GuestOptions : Window
    {
        IBL myBL;
        string mail;
        public GuestOptions(IBL bl, string email)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = bl;
            mail = email;
            List<GuestRequest> list = myBL.guestsList(mail);
            lvGuestRequest.ItemsSource = list;
            btnUpdateRequest.IsEnabled = false;
        }

        private void btnAddRequest_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new AddRequest(myBL, mail).ShowDialog();
            
        }

        private void BtnUpdateRequest_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new updateGuestRequest(myBL, gr).ShowDialog();
            
        }

        private void lvHostingUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }
        GuestRequest gr;

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new MainWindow().ShowDialog();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LvGuestRequest_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                btnUpdateRequest.IsEnabled = true;
                gr = (GuestRequest)item;
            }

        }

        private void BtnExtraFunctions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
