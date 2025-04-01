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
    public partial class updateHostDetails : Window
    {
        IBL myBL;
        Host H;
        string id;
        List<HostingUnit> hostingUnits = new List<HostingUnit>();
        public updateHostDetails(Host h, IBL b)
        {
            myBL = b;
            H = h;
            id = h.HostKey;
            InitializeComponent();
            hostingUnits = myBL.hostsList(id);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            txtAdress.Visibility = Visibility.Hidden;
            txtBankNum.Visibility = Visibility.Hidden;
            txtCity.Visibility = Visibility.Hidden;
            txtNumB.Visibility = Visibility.Hidden;
            txtName.Visibility = Visibility.Hidden;
            txtNum.Visibility = Visibility.Hidden;
            lblN.Visibility = Visibility.Hidden;
            lblNA.Visibility = Visibility.Hidden;
            lblNAD.Visibility = Visibility.Hidden;
            lblNB.Visibility = Visibility.Hidden;
            lblNC.Visibility = Visibility.Hidden;
            txtPrivate.Text = H.PrivateName;
            txtFamily.Text = H.FamilyName;
            txtMail.Text = H.MailAddress;
            txtBankNum.Text = H.BankAccountNumber.ToString();
            txtAdress.Text = H.BankBranchDetails.BranchAddress;
            txtCity.Text = H.BankBranchDetails.BranchCity;
            txtNumB.Text = H.BankBranchDetails.BranchNumber.ToString();
            txtName.Text = H.BankBranchDetails.BankName;
            txtPassword.Text = H.Password;
            txtPhone.Text = H.PhoneNumber.ToString();
            txtNum.Text = H.BankBranchDetails.BankNumber.ToString();
        }

        private void btnBankBranch_Click(object sender, RoutedEventArgs e)
        {
            txtAdress.Visibility = Visibility.Visible;
            txtBankNum.Visibility = Visibility.Visible;
            txtCity.Visibility = Visibility.Visible;
            txtNumB.Visibility = Visibility.Visible;
            txtName.Visibility = Visibility.Visible;
            lblN.Visibility = Visibility.Visible;
            lblNA.Visibility = Visibility.Visible;
            lblNAD.Visibility = Visibility.Visible;
            lblNB.Visibility = Visibility.Visible;
            lblNC.Visibility = Visibility.Visible;
            txtNum.Visibility = Visibility.Visible;

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
                txtNum.Text == null)
            {
                MessageBox.Show("יש למלא את כל הפרטים");
                return;
            }
            try
            {
                H.PrivateName = txtPrivate.Text;
                H.FamilyName = txtFamily.Text;
                H.MailAddress = txtMail.Text;
                H.Password = txtPassword.Text;
                H.BankAccountNumber = long.Parse(txtBankNum.Text);
                foreach(var hostingUnit in hostingUnits)
                {
                    hostingUnit.Owner = H;
                    myBL._UpDateHostingUnit(hostingUnit);
                }
                MessageBox.Show("העדכון הושלם בהצלחה");

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
    }
}
