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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class HostEntrance : Window
    {
        IBL myBL;

        public HostEntrance(IBL bl)
        {
            myBL = bl;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Host h = new Host();
            string id = txtUserID.Text;
            string p = pBox.Password;
            List<HostingUnit> list = myBL.hostsList(id);
            if (txtUserID.Text.Length != txtUserID.MaxLength || !txtUserID.Text.All(char.IsDigit) || !CheckIDNo(txtUserID.Text))
            {
                txtUserID.Background = Brushes.Red;
                MessageBox.Show("מספר תעודת הזהות צריך להיות 9 ספרות בדיוק, ולייצג מספר ת.ז. אמיתי.", "קלט שגוי", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            }
            else if (list.Count == 0)
            {
                MessageBox.Show("מספר זהות שגוי", "תקלה!");
            }
            else
            {
                h = list[0].Owner;
                if (h.Password == p)
                {
                    new host(myBL, h, id).ShowDialog();
                    //host Host = new host(list, h, myBL);
                    //Host.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("סיסמא שגויה", "תקלה!");
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("כדי להתווסף למאגר המארחים צור קשר עם הנהלת האתר", "vacation4u- האתר המוביל לאירוח");
            new AddNewHost(myBL).ShowDialog();
        }

        private void TxtUserID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        static bool CheckIDNo(string strID)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;

            if (strID == null)
                return false;

            strID = strID.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }
    }
}
