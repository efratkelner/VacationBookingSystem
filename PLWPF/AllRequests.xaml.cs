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
    /// Interaction logic for RequestsForHost.xaml
    /// </summary>
    public partial class AllRequests : Window
    {
        IBL myBL;
        GuestRequest g = new GuestRequest();
        public AllRequests(IBL b)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = b;
            List<GuestRequest> gl = new List<GuestRequest>();
            gl = myBL._GuestRequestsList();
            lvGQ.ItemsSource = gl;
            //List<string> lsOptions = new List<string>
            //{
            //    "בקשות לדרום",
            //    "בקשות לירושלים",
            //    "בקשות למרכז",
            //    "בקשות לצפון",
            //    "בקשה לזוג",
            //    "מספר ילדים גדול מ5",
            //    "חופשה יותר משבוע"
            //};
            //cbxSort.ItemsSource = lsOptions;
        }

        private void lvGQ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lvGQ_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        //private void cbxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    txbSortByLable.Visibility = Visibility.Hidden;
        //    if (cbxSort.SelectedIndex == 0)
        //    {
        //        this.lvGQ.ItemsSource = myBL.areaGrouping(Enums.Area.דרום);
        //    }
        //    if (cbxSort.SelectedIndex == 1)
        //    {
        //        lvGQ.ItemsSource = myBL.areaGrouping(Enums.Area.ירושלים);
        //    }
        //    if (cbxSort.SelectedIndex == 2)
        //    {
        //        lvGQ.ItemsSource = myBL.areaGrouping(Enums.Area.מרכז);
        //    }
        //    if (cbxSort.SelectedIndex == 3)
        //    {
        //        lvGQ.ItemsSource = myBL.areaGrouping(Enums.Area.צפון);
        //    }
        //    if (cbxSort.SelectedIndex == 4)
        //    {
        //        lvGQ.ItemsSource = myBL.requestByAdults();
        //    }
        //    if (cbxSort.SelectedIndex == 5)
        //    {
        //        lvGQ.ItemsSource = myBL.requestByChildren();
        //    }
        //    if (cbxSort.SelectedIndex == 6)
        //    {
        //        lvGQ.ItemsSource = myBL.requestByLengthOfVacation();
        //    }
        //}
    }
}
