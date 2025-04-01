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
    /// Interaction logic for ViewHostingUnits.xaml
    /// </summary>
    public partial class ViewHostingUnits : Window
    {
        IBL bl;
        string ID;
        //List<HostingUnit> huList = new List<HostingUnit>();


        public ViewHostingUnits(IBL b, string id)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = b;
            ID = id;
            // List<HostingUnit> huList = bl.hostsList(ID);
            // lvHostingUnit.ItemsSource = huList;
            lvHostingUnit.ItemsSource = bl.hostsList(id);
        }

        private void lvHostingUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;

        }
    }
}
