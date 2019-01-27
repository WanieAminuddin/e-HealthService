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

namespace myHealthService
{
    /// <summary>
    /// Interaction logic for PagePortal.xaml
    /// </summary>
    public partial class PagePortal : Page
    {
        public PagePortal()
        {
            InitializeComponent();
        }

        public string GPname;
        public string RPname;
        public string userData;

        public void getuserinfo(string allInfo)
        {
            userData = allInfo;
        }

        private void Btnuserinfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your Details" + "\r\n" + userData);
        }

        private void BtnQR_Click(object sender, RoutedEventArgs e)
        {
            QRcodeDisplay QRcode = new QRcodeDisplay();
            QRcode.ShowDialog();
        }

        private void BtnOpp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnlogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Windows.Forms.Application.Restart();
        }

        public void getGooglePlusUser(string userName)
        {
            
            GPname = userName;
            userP.Text = GPname;
          
        }

        
    }
}
