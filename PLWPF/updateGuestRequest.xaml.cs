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
using static BE.Enums;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for updateGuestRequest.xaml
    /// </summary>
    public partial class updateGuestRequest : Window
    {
        IBL myBL;
        GuestRequest guestRequest = new GuestRequest();
        public updateGuestRequest(IBL bl, GuestRequest gr)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = bl;
            guestRequest = gr;


            cmbArea.ItemsSource = Enum.GetValues(typeof(Enums.Area));
            cmbPool.ItemsSource = Enum.GetValues(typeof(Enums.Pool));
            cmbJacuzzi.ItemsSource = Enum.GetValues(typeof(Enums.Jacuzzi));
            cmbAttractions.ItemsSource = Enum.GetValues(typeof(Enums.ChildrensAttractions));
            cmbType.ItemsSource = Enum.GetValues(typeof(Enums.Type));
            cmbGarden.ItemsSource = Enum.GetValues(typeof(Enums.Garden));


            txbArea.Text =gr.Area.ToString();
            txbPool.Text = gr.Pool.ToString();
            txbJaccuzi.Text = gr.Jacuzzi.ToString();
            txbGarden.Text = gr.Garden.ToString();
            txbChildrenAtractions.Text = gr.ChildrensAttractions.ToString();
            txbType.Text = gr.Type.ToString();
            txbChildren.Text = Convert.ToString(gr.Children);
            txbAdults.Text = Convert.ToString(gr.Adults);
            txbCity.Text = gr.SubArea.ToString();
            txbFamilyName.Text = gr.FamilyName.ToString();
            txbPrivateName.Text = gr.PrivateName.ToString();
            txbMail.Text = gr.MailAddress.ToString();
            cbBreakfast.IsChecked = gr.Breakfast;
            cbCradle.IsChecked = gr.Cradle;
            cbWiFi.IsChecked = gr.Wifi;
            dateOfEntry.SelectedDate = gr.EntryDate;
            DateOfRelease.SelectedDate = gr.ReleaseDate;




        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (
             //cmbArea.SelectedValue == null ||
             //cmbPool.SelectedValue == null ||
             //cmbJacuzzi.SelectedValue == null ||
             //cmbGarden.SelectedValue == null ||
             //cmbAttractions.SelectedValue == null ||
             //cmbType.SelectedValue == null ||
             //dateOfEntry.SelectedDate == null ||
             //DateOfRelease.SelectedDate == null ||
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


            try
            {
                guestRequest.EntryDate = (DateTime)dateOfEntry.SelectedDate;
                guestRequest.ReleaseDate = (DateTime)DateOfRelease.SelectedDate;
                guestRequest.Adults = uint.Parse(txbAdults.Text);
                guestRequest.Children = uint.Parse(txbChildren.Text);
                guestRequest.SubArea = txbCity.Text;
                guestRequest.FamilyName = txbFamilyName.Text;
                guestRequest.MailAddress = txbMail.Text;
                guestRequest.PrivateName = txbPrivateName.Text;
                guestRequest.Breakfast = (bool)cbBreakfast.IsChecked;
                guestRequest.Wifi = (bool)cbWiFi.IsChecked;
                guestRequest.Cradle = (bool)cbCradle.IsChecked;
                myBL._UpDateGuestRequest(guestRequest);
                MessageBox.Show("עדכונך נקלטה בהצלחה");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txbArea.Visibility = Visibility.Hidden;
            guestRequest.Area = (Enums.Area)cmbArea.SelectedItem;
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txbType.Visibility = Visibility.Hidden;
            guestRequest.Type = (Enums.Type)cmbType.SelectedItem;

        }

        private void cmbPool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txbPool.Visibility = Visibility.Hidden;
            guestRequest.Pool = (Enums.Pool)cmbPool.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new GuestOptions(myBL, guestRequest.MailAddress).ShowDialog();
        }

        private void CmbGarden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txbGarden.Visibility = Visibility.Hidden;
            guestRequest.Garden = (Enums.Garden)cmbGarden.SelectedItem;
        }

        private void CmbJacuzzi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txbJaccuzi.Visibility = Visibility.Hidden;
            guestRequest.Jacuzzi = (Enums.Jacuzzi)cmbJacuzzi.SelectedItem;
        }

        private void CmbAttractions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txbChildrenAtractions.Visibility = Visibility.Hidden;
            guestRequest.ChildrensAttractions = (Enums.ChildrensAttractions)cmbAttractions.SelectedItem;
        }
    }
}
