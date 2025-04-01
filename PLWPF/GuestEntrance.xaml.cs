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
    /// Interaction logic for GuestEntrance.xaml
    /// </summary>
    public partial class GuestEntrance : Window
    {
        IBL bl;
        public GuestEntrance(IBL b)
        {
            bl = b;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            string mail = txtUserMail.Text;
            List<GuestRequest> list = bl.guestsList(mail);
            if (list.Count == 0)
            {
                MessageBox.Show("מייל שגוי", "תקלה!");
                return;
            }
            else
            {
                Close();
                new GuestOptions(bl, mail).ShowDialog();
            }

            this.Close();//this would be closed when the user would do X to the guestOptions window 
        }

        private void btnNewGuest_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new GuestOptions(bl, null).ShowDialog();
        }

        private void txtUserMail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
