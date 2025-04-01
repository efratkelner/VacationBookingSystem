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
using System.Net;
using System.Net.Mail;
using System.Net.Http;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for RequestsForHost.xaml
    /// </summary>
    public partial class RequestsForHost : Window
    {
        IBL myBL;
        Host host;
        GuestRequest g = new GuestRequest();
        HostingUnit hu = new HostingUnit();
        public RequestsForHost(Host h, IBL b)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            host = h;
            myBL = b;
            List<GuestRequest> gl = new List<GuestRequest>();
            gl = myBL._GuestRequestsList();
            lvGuestsRequests.ItemsSource = gl;
            cmbHU.ItemsSource = myBL.hostsList(host.HostKey);
        }


        private void LvGuestsRequests_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void lvGuestsRequests_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void CmbHU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LvGuestsRequests_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null && cmbHU.SelectedItem != null)
            {
                hu = (HostingUnit)cmbHU.SelectedItem;
                g = (GuestRequest)item;
                MessageBoxResult result = MessageBox.Show("לשלוח הצעת אירוח ללקוח?", "!הצע ללקוח את יחידת האירוח שלך", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            Order order = new Order();
                            Configuration.SetOrderKey(1);
                            order.OrderKey = Configuration.GetOrderKey();
                            order.HostingUnitKey = hu.HostingUnitKey;
                            order.OrderDate = DateTime.Today;
                            order.GuestRequestKey = g.GuestRequestKey;
                            order.Status = Enums.orderStatus.נשלח_מייל;
                            MailMessage mail = new MailMessage();
                            string gmail = g.MailAddress;
                            mail.To.Add(gmail);
                            mail.From = new MailAddress("efratkelner@gmail.com");
                            mail.Subject = "!הצעת אירוח חדשה לבקשה שלך";
                            mail.Body = " שלום " + g.PrivateName +" "+ g.FamilyName +
                            " :)יש לנו יחידת אירוח שבטוח תאהב" +
                            +host.PhoneNumber+
                            "...מצורף מספר פלאפון לתיאום." +
                             "!מקווים שתהיה לך חופשה מושלמת";
                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Credentials = new System.Net.NetworkCredential("vacationu443@gmail.com", "123456v!");
                            smtp.EnableSsl = true;
                            try
                            {

                                smtp.Send(mail);

                            }
                            catch (Exception)
                            {

                                MessageBox.Show("המייל לא נשלח!", "תקלה");
                                return;
                            }
                            smtp.Dispose();
                            MessageBox.Show("הצעת האירוח שלך נשלחה במייל ללקוח!", "מייל נשלח");
                            try
                            {
                                myBL._AddOrder(order);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }

            }

        }

        private void lvGuestsRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
