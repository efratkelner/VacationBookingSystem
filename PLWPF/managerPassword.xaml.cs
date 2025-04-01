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
    /// Interaction logic for managerPassword.xaml
    /// </summary>
    public partial class managerPassword : Window
    {
        public managerPassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Configuration.SetManagerP(txtP.Text);
            MessageBox.Show("הסיסמא שונתה בהצלחה");
            txtP.Text = " ";
        }
    }
}
