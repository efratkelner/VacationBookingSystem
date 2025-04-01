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
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnit : Window
    {
        IBL myBL;
        Area _area = new Area();
        Host host;
        string id;
        HostingUnit hostingUnit = new HostingUnit();
        bool[,] MyDiary = new bool[12,30];
        List<string> errorMessages = new List<string>();
        public UpdateHostingUnit(IBL bl, Host H, string d)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myBL = bl;
            id = d;
            host = H;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cboxName.ItemsSource = myBL.hostsList(id);
            AreaComboBox.ItemsSource = Enum.GetValues(typeof(Area));
            MyDiary = hostingUnit.Diary;

        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added && e.Error.Exception != null)
                errorMessages.Add(e.Error.Exception.Message);
            else errorMessages.Remove(e.Error.Exception.Message);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (errorMessages.Any())
            {
                string err = "קלטים לא חוקיים";
                foreach (var item in errorMessages)
                    err += "\n" + item;
                MessageBox.Show(err);
                return;
            }
            if (cboxName.SelectedItem == null)
            {
                MessageBox.Show($"בבקשה בחר/י יחידת אירוח לעדכן!", "עידכון יחדת אירוח", MessageBoxButton.OK, MessageBoxImage.Error);
                return;     // can not update a hosting unit without a name...
            }
            hostingUnit.Owner = host;

            if (AreaComboBox.SelectedItem != null)
            {
                hostingUnit.area = (Enums.Area)AreaComboBox.SelectedItem;
            }

            //DateTime d = (DateTime)diary.SelectedDate;
            //DateTime d2 = new DateTime();
            //d2 = d;
            //int numOfDates = diary.SelectedDates.Count;
            //d2.AddDays(numOfDates);
            //int day = d.Day;
            //int mounth = d.Month;
            //int i = 0;
            //while(i<numOfDates)
            //{
            //    MyDiary[day, mounth] = true;
            //    i++;
            //}


            //DateTime[] dates = new DateTime[numOfDates];
            //for (int j = 0; j < dates.Length; j++)
            //{
            //    dates[j] = d2.AddDays(j);
            //}

            //for (int k = 0; k < dates.Length; k++)
            //{
            //    diary.BlackoutDates.Add(new CalendarDateRange(dates[k]));
            //}


            try
            {
                hostingUnit.PriceForAdult = Convert.ToUInt32(txbPriceForAdult.Text);
                hostingUnit.PriceForChild = Convert.ToUInt32(txbPriceForChild.Text);
                myBL._UpDateHostingUnit(hostingUnit);
                MessageBox.Show("יחידת האירוח עודכנה בהצלחה!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"תקלה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
            txbPriceForAdult.Text = " ";
            txbPriceForChild.Text = " ";
            cboxName.SelectedItem = null;
            hostingUnitDetailsStack.DataContext = hostingUnit = null;
            cboxName.ItemsSource = myBL.hostsList(id);
            tbArea.Text = " ";
            tbArea.Visibility = Visibility.Visible;

        }

    

        private void AreaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbArea.Visibility = Visibility.Hidden;
        }

        private void CboxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxName.SelectedItem is HostingUnit)
            {
                hostingUnit = (HostingUnit)cboxName.SelectedItem;
                _area = hostingUnit.area;
                setHostingUnitFields();
            }
        }

        private void setHostingUnitFields()
        {
            hostingUnitDetailsStack.DataContext = hostingUnit;
            txbPriceForChild.Text = hostingUnit.PriceForChild.ToString();
            txbPriceForAdult.Text = hostingUnit.PriceForAdult.ToString();
            tbArea.Text =hostingUnit.area.ToString();
            MyDiary = hostingUnit.Diary;
            GuestRequest tmp;
            HostingUnit tmp2;
            List<Order> closedorder = new List<Order>();
            closedorder = myBL._OrdersList().FindAll(x => (Enums.orderStatus)x.Status == orderStatus.נשלח_מייל);
            if(closedorder.Count!=0)
            {
                foreach (Order order in closedorder)
                {
                    tmp = myBL._GuestRequestsList().Find(x => x.GuestRequestKey == order.GuestRequestKey);
                    tmp2 = myBL._HostingUnitsList().Find(x => x.HostingUnitKey == order.HostingUnitKey);
                    if (tmp != null && tmp2 != null)
                    {
                        if (tmp2.HostingUnitKey == hostingUnit.HostingUnitKey)
                        {
                            DateTime[] dates = new DateTime[myBL._DaysGap(tmp.EntryDate, tmp.ReleaseDate)];
                            for (int i = 0; i < dates.Length; i++)
                            {
                                dates[i] = tmp.EntryDate.AddDays(i);
                            }

                            for (int i = 0; i < dates.Length; i++)
                            {
                                //diary.BlackoutDates.Add(new CalendarDateRange(dates[i]));
                            }
                        }


                    }
                }

            }

            
            //DateTime first = new DateTime(2020, 01, 01);
            //int counter = 0;
            //int i = 0;
            //int j = 0;
            //while (!MyDiary[i,j] && i<12 && j<30)
            //{
            //    first.AddDays(1);

            //}

            //while (MyDiary[i, j])
            //{
            //    counter++;
            //}
            //if((j==31&&(i==1||i==3||i==5||i==7||i==8||i==10||i==12))||(j==30&&(i==2||i==4||i==6||i==9||i==11))//Last day of the mounth.
            //diary.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1)));



            //for (int i = 0; i < 30; i++)
            //{
            //    for (int j = 0; j < 12; j++)
            //    {
            //        if (MyDiary[i, j] == true)
            //        {
            //            diary.BlackoutDates.Add(new CalendarDateRange(new DateTime(2020, j, i)));
            //        }

            //    }
            //}





            //string s= hostingUnit.area.ToString();
            //AreaComboBox.Text = myBL.enumTrans(s);

        }

        private void txbPriceForChild_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
