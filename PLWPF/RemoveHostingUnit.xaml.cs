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
    /// Interaction logic for RemoveHostingUnit.xaml
    /// </summary>
    public partial class RemoveHostingUnit : Window
    {
        IBL myBL;
        string id;
        Host host;
        HostingUnit hostingUnit = new HostingUnit();

        List<string> errorMessages = new List<string>();
        public RemoveHostingUnit(IBL bl, Host h, string d)
        {
            myBL = bl;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            id = d;
            host = h;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cboxName.ItemsSource = myBL.hostsList(id);

        }
        private List<HostingUnit> theHostsUnits()
        {
            return new List<HostingUnit>(myBL.hostsList(id));

        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added && e.Error.Exception != null)
                errorMessages.Add(e.Error.Exception.Message);
            else errorMessages.Remove(e.Error.Exception.Message);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //if (errorMessages.Any())
            //{
            //    string err = "קלטים לא חוקיים";
            //    foreach (var item in errorMessages)
            //        err += "\n" + item;
            //    MessageBox.Show(err);
            //    return;
            //}
            if (cboxName.SelectedItem == null)
            {

                MessageBox.Show($"יש לבחור יחידת אירוח להסרה!", "הסרת יחידת אערוי", MessageBoxButton.OK, MessageBoxImage.Error);
                return;     // can not remove a hosting unit without a name

            }

            MessageBoxResult result = MessageBox.Show("האם אתה בטוח שברצונך למחוק??", "מחיקה סופית", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        try
                        {
                            myBL._DeleteHostingUnit(hostingUnit);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "תקלה", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        MessageBox.Show("יחידת האירוח נמחקה בהצלחה!", "אישור מחיקה");
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }

            txbPriceForAdult.Text = " ";
            txbPriceForChild.Text = " ";
            cboxName.SelectedItem = null;
            hostingUnitDetailsStack.DataContext = hostingUnit = null;
            cboxName.ItemsSource = theHostsUnits();

        }

        private void CboxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxName.SelectedItem is HostingUnit)
            {
                hostingUnit = (HostingUnit)cboxName.SelectedItem;
                setHostingUnitFields();
            }
        }

        private void setHostingUnitFields()
        {
            hostingUnitDetailsStack.DataContext = hostingUnit;
            txbPriceForChild.Text = hostingUnit.PriceForChild.ToString();
            txbPriceForAdult.Text = hostingUnit.PriceForAdult.ToString();
            txbArea.Text = hostingUnit.area.ToString();
        }
    }
}


