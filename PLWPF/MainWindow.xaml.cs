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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL myBL = BL.FactoryBL.GetBL();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Manually alter window height and width
            this.SizeToContent = SizeToContent.Manual;

            // Automatically resize width relative to content
            this.SizeToContent = SizeToContent.Width;

            // Automatically resize height relative to content
            this.SizeToContent = SizeToContent.Height;

            // Automatically resize height and width relative to content
            this.SizeToContent = SizeToContent.WidthAndHeight;

        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            managerSecurity _managerSecurity = new managerSecurity(myBL);
           _managerSecurity.ShowDialog();

        }

        private void btnHost_Copy_Click(object sender, RoutedEventArgs e)
        {
            HostEntrance hostEntrance = new HostEntrance(myBL);
            hostEntrance.ShowDialog();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestEntrance guestEntrance = new GuestEntrance(myBL);
            guestEntrance.ShowDialog();
        }

        private void TheMainWindow_Closed(object sender, EventArgs e)//Closing app
        {
            Environment.Exit(0);
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // Manually alter window height and width


    }
}
