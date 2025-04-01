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
    /// Interaction logic for updateHostDetails.xaml
    /// </summary>
    public partial class AddNewHost : Window
    {
        static long temp = 900000; 
        IBL myBL;
        Host h = new Host();
        public AddNewHost(IBL b)
        {
            myBL = b;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnBankBranch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtMail.Text == null ||
                txtFamily.Text == null ||
                txtPassword.Text == null ||
                txtPrivate.Text == null ||
                txtPhone.Text == null ||
                txtCity.Text == null ||
                txtBankNum.Text == null ||
                txtAdress.Text == null ||
                txtNumB.Text == null ||
                txtName.Text == null ||
                txbId.Text==null||
                txtNum.Text == null)
            {
                MessageBox.Show("יש למלא את כל הפרטים");
                return;
            }
            try
            {
                h.HostKey = txbId.Text;
                h.PrivateName = txtPrivate.Text;
                h.FamilyName = txtFamily.Text;
                h.MailAddress = txtMail.Text;
                h.Password = txtPassword.Text;
                h.PhoneNumber = long.Parse(txtPhone.Text);
                h.BankAccountNumber = long.Parse(txtBankNum.Text);
                HostingUnit hostingUnit = new HostingUnit();
                hostingUnit.HostingUnitKey = ++temp;
                hostingUnit.Owner = h;
                myBL._AddHostingUnit(hostingUnit);
                MessageBox.Show("פרטי מארח נוספו בהצלחה");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "תקלה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Close();
        }

        private void CmbBankThread_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxbId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
