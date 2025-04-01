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
    /// Interaction logic for AllOrders.xaml
    /// </summary>
    public partial class AllOrders : Window
    {
        IBL myBL;
        public AllOrders(IBL b)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = b;
            List<Order> orders = new List<Order>();
            orders = myBL._OrdersList();
            lvOrders.ItemsSource = orders;
            //List<string> lsOptions = new List<string>
            //{
            //    "מספר הזמנה",
            //    "עמלה",
            //    "מספר יחידה",
            //   "תאריך רישום למערכת"
            //};
            //cbxSort.ItemsSource = lsOptions;
        }

        private void lvOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void cbxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    txbSortByLable.Visibility = Visibility.Hidden;
        //    if (cbxSort.SelectedIndex == 0)
        //    {
        //        this.lvOrders.ItemsSource = myBL.ordersByOrderKey();
        //    }
        //    if (cbxSort.SelectedIndex == 1)
        //    {
        //        lvOrders.ItemsSource = myBL.ordersByCommision();
        //    }
        //    if (cbxSort.SelectedIndex == 2)
        //    {
        //        lvOrders.ItemsSource = myBL.ordersByHostingUnitKey();
        //    }
        //    if (cbxSort.SelectedIndex == 3)
        //    {
        //        lvOrders.ItemsSource = myBL.ordersByCreatDate();
        //    }
        //}
    }
}
