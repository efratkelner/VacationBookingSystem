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
    /// Interaction logic for AddRequest.xaml
    /// </summary>
    public partial class AddRequest : Window
    {
        IBL myBL;
        GuestRequest guestRequest=new GuestRequest();
        List<GuestRequest> temp = new List<GuestRequest>();
        GuestRequest gr = new GuestRequest();
        public AddRequest(IBL bl, string mail)
        {
            string Cmail = mail;
            myBL = bl;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            temp= myBL.guestsList(Cmail);
            if (temp.Count!=0)
            {
                gr = temp.ElementAt(0);
                txbPrivateName.Text = gr.PrivateName;
                txbFamilyName.Text = gr.FamilyName;
                txbMail.Text = gr.MailAddress;
            }
            cmbArea.ItemsSource = Enum.GetValues(typeof(Enums.Area));
            cmbPool.ItemsSource = Enum.GetValues(typeof(Enums.Pool));
            cmbJacuzzi.ItemsSource = Enum.GetValues(typeof(Enums.Jacuzzi));
            cmbAttractions.ItemsSource = Enum.GetValues(typeof(Enums.ChildrensAttractions)); 
            cmbType.ItemsSource = Enum.GetValues(typeof(Enums.Type));
            cmbGarden.ItemsSource = Enum.GetValues(typeof(Enums.Garden));

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbArea.SelectedValue == null ||
               cmbPool.SelectedValue == null ||
               cmbJacuzzi.SelectedValue == null ||
               cmbGarden.SelectedValue == null ||
               cmbAttractions.SelectedValue == null ||
               cmbType.SelectedValue == null ||
               dateOfEntry.SelectedDate == null ||
               DateOfRelease.SelectedDate == null ||
               txbAdults.Text == null ||
               txbChildren.Text == null ||
               txbCity.Text == null ||
               txbFamilyName.Text == null ||
               txbMail.Text == null ||
               txbPrivateName.Text == null)
            {
                MessageBox.Show("יש למלא את כל הפרטים");
                return;
            }
            guestRequest.Area = (Enums.Area)cmbArea.SelectedItem;
            guestRequest.Pool = (Enums.Pool)cmbPool.SelectedItem;
            guestRequest.Jacuzzi = (Enums.Jacuzzi)cmbJacuzzi.SelectedItem;
            guestRequest.Garden = (Enums.Garden)cmbGarden.SelectedItem;
            guestRequest.ChildrensAttractions = (Enums.ChildrensAttractions)cmbAttractions.SelectedItem;
            guestRequest.Type = (Enums.Type)cmbType.SelectedItem;
            try
            {
                Configuration.SetGuestRequestKey(1);
                guestRequest.GuestRequestKey = Configuration.GetGuestRequestKey();
                guestRequest.Adults = uint.Parse(txbAdults.Text);
                guestRequest.Children = uint.Parse(txbChildren.Text);
                guestRequest.EntryDate = (DateTime)dateOfEntry.SelectedDate;
                guestRequest.ReleaseDate = (DateTime)DateOfRelease.SelectedDate;
                guestRequest.SubArea = txbCity.Text;
                guestRequest.FamilyName = txbFamilyName.Text;
                guestRequest.MailAddress = txbMail.Text;
                guestRequest.PrivateName = txbPrivateName.Text;
                guestRequest.Breakfast = (bool)cbBreakfast.IsChecked;
                guestRequest.Wifi = (bool)cbWiFi.IsChecked;
                guestRequest.Cradle = (bool)cbCradle.IsChecked;

                myBL._AddGuestRequest(guestRequest);
                MessageBox.Show("בקשתך נקלטה בהצלחה");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "תקלה", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new GuestOptions(myBL, guestRequest.MailAddress).ShowDialog();
        }
    }
}
