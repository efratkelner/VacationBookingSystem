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
    /// Interaction logic for AllHosts.xaml
    /// </summary>
    public partial class AllHosts : Window
    {
        IBL myBL;
        public AllHosts(IBL b)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = b;

            List<HostingUnit> hul = myBL._HostingUnitsList();
            List<Host> hl = new List<Host>();
            foreach (var item in hul)
            {
                hl.Add(item.Owner);
            }
            hl.Distinct();
            lvHosts.ItemsSource = hl;
            List<string> lsOptions = new List<string>
            {
                "שם פרטי",
                "שם משפחה",
                "מספר טלפון",
                "מספר זהות"
            };
            cbxSort.ItemsSource = lsOptions;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txbSortByLable.Visibility = Visibility.Hidden;
            if (cbxSort.SelectedIndex == 0)
            {
                lvHosts.ItemsSource = myBL.hostsByPrivateName();
            }
            if (cbxSort.SelectedIndex == 1)
            {
                lvHosts.ItemsSource = myBL.hostsByFamilyeName();
            }
            if (cbxSort.SelectedIndex == 2)
            {
                lvHosts.ItemsSource = myBL.hostsByPhoneNumber();
            }
            if (cbxSort.SelectedIndex == 3)
            {
                lvHosts.ItemsSource = myBL.hostsByID();
            }
        }
    }
}
