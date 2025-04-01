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
    /// Interaction logic for AddhOstingUnit.xaml
    /// </summary>
    public partial class AddhOstingUnit : Window
    {
        IBL myBL;
        HostingUnit hostingUnit = new HostingUnit();
        Host thisOwner;
        //HostingUnit hu;
        List<string> errorMessages = new List<string>();
        public AddhOstingUnit(IBL bl,Host h)
        {
            myBL = bl;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = hostingUnit;
            thisOwner = h;
            cmbArea.ItemsSource = Enum.GetValues(typeof(BE.Enums.Area));

        }


        private void cboxArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (errorMessages.Any())
            {
                string err = "קלטים לא חוקיים";
                foreach (var item in errorMessages)
                    err += "\n" + item;
                MessageBox.Show(err);
                return;
            }
            try
            {
                Configuration.SetHostingUnitKey(1);
                hostingUnit.HostingUnitKey = Configuration.GetHostingUnitKey();
                hostingUnit.HostingUnitName = txbHostingUnitName.Text;
                hostingUnit.PriceForAdult = UInt32.Parse(txbPriceForAdult.Text);
                hostingUnit.PriceForChild = UInt32.Parse(txbPriceForChild.Text);
                hostingUnit.area = (Enums.Area)cmbArea.SelectedItem;
                hostingUnit.Owner = thisOwner;
                myBL._AddHostingUnit(hostingUnit);
                Closing -= Window_Closing;
                DialogResult = true;
                MessageBox.Show("יחידת אירוח נוספה בהצלחה");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added && e.Error.Exception != null)
                errorMessages.Add(e.Error.Exception.Message);
            else errorMessages.Remove(e.Error.Exception.Message);
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.hostingUnit.ToString() != new BE.HostingUnit().ToString())
            {
                MessageBoxResult result = MessageBox.Show(" השינויים לא ישמרו...לצאת??", "", MessageBoxButton.YesNo,
                                              MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign);
                if (result == MessageBoxResult.No)
                    e.Cancel = true;
            }
        }

        private void CmbArea_MouseEnter(object sender, MouseEventArgs e)
        {
            cmbArea.Background = Brushes.Blue;
        }

      
    }
}
