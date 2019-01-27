using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace myHealthService
{
    /// <summary>
    /// Interaction logic for PageRegister.xaml
    /// </summary>
    public partial class PageRegister : Page
    {
        public PageRegister()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            PageLogin pageLog = new PageLogin();
            this.NavigationService.Navigate(pageLog);
        }

        private void Btnregister_Click(object sender, RoutedEventArgs e)
        {
            if (emailR.Text.Length == 0)
            {
                MessageBox.Show("Error: Enter Your Email");
                emailR.Text = "";
                emailR.Focus();
            }
            else if (!Regex.IsMatch(emailR.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Error: Enter a valid email");
                emailR.Text = "";
                emailR.Select(0, emailR.Text.Length);
                emailR.Focus();
            }
            else
            {
                string firstname = Fname.Text;
                string lastname = Lname.Text;
                string email = emailR.Text;
                string Genders = gender.Text;
                string phoneNum = phoneNo.Text;
                string birthdayU = birthday.Text;
                string password = password1.Password;
                if (password1.Password.Length == 0)
                {
                    MessageBox.Show("Error: Enter password");
                    password1.Focus();
                }
                else if (confirmPassword.Password.Length == 0)
                {
                    MessageBox.Show("Error: Enter Confirm password");
                    confirmPassword.Focus();
                }
                else if (password1.Password != confirmPassword.Password)
                {
                    MessageBox.Show("Error: Confirm password must be same as password.");
                    confirmPassword.Focus();
                }
                else
                {
                    string addressL = address1.Text;
                    string addressLL = address2.Text;
                    string location = state.Text;
                    string locID = postcode.Text;
                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PatientDB;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Registration (FirstName,LastName,Email,Password,Gender,Birthday,PhoneNo,Address1,Address2,Postcode,State) values('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + Genders + "','" + birthdayU + "','" + phoneNum + "','" + addressL + "','" + addressLL + "','" + locID + "','" + location + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("You have Registered successfully");
                    PagePortal pagepor = new PagePortal();

                    pagepor.getuserinfo(firstname + " " + lastname + "\r\n" + email + "\r\n" + Genders + "\r\n" + birthdayU + "\r\n" + phoneNum + "\r\n" + addressL + "\r\n" + addressLL + "\r\n" + locID + "\r\n" + location);
                    pagepor.getGooglePlusUser(firstname +" "+ lastname);
                    this.NavigationService.Navigate(pagepor);
                    Reset();
                }
            }
        }

        private void Btnreset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            PageLogin pageLog = new PageLogin();
            this.NavigationService.Navigate(pageLog);
        }

        public void Reset()
        {
            Fname.Text = "";
            Lname.Text = "";
            address1.Text = "";
            address2.Text = "";
            state.Text = "";
            postcode.Text = "";
            phoneNo.Text = "";
            emailR.Text = "";
            gender.Text = "";
            birthday.Text = "";
            password1.Password = "";
            confirmPassword.Password = "";
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
