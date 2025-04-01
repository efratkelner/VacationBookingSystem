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
    /// Interaction logic for OthersOpManager.xaml
    /// </summary>
    public partial class OthersOpManager : Window
    {
        IBL myBL;
        public OthersOpManager(IBL bL)
        {
            myBL = bL;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BtnDoneOrders_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnPopularHost_Click(object sender, RoutedEventArgs e)
        {
            string h = myBL.popularHost();
            MessageBox.Show(h +"  "+ "המארח הפופולרי ביותר הוא-");//אם עוד לא נסגרו הזמנות סופית באתר- אין מארח פופולרי
        }

        private void BtnPopularArea_Click(object sender, RoutedEventArgs e)
        {
            string a = myBL.popularArea();
            MessageBox.Show(a+"  "+ " האיזור הפופולרי ביותר הוא-");
        }
    }
}
