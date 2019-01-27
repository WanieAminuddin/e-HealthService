using PinterestAPI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace myHealthService
{
    public partial class PinterestSignin : Form
    {
        public const string clientId = "4974685938167856020";
        public const string clientSecret = "25801c12a182ed49f187f4e108401ea89caeec03b18d449601d9eb45102dcabc";
        public const string redirectUri = "https://localhost/pinauth/auth/pin/callback/";
        public static string state = randomDataBase64url(32);

        public AuthResponse access;
        public static readonly string redirectURI;

        #region State Generator
        public static string randomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return base64urlencodeNoPadding(bytes);
        }
        public static string base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            // Strips padding.
            base64 = base64.Replace("=", "");

            return base64;
        }
        #endregion


        public PinterestSignin()
        {
            InitializeComponent();
            webBrowser1.Navigate(AuthResponse.GetAutenticationURI(clientId, redirectUri, state));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = "";
            if (webBrowser1.Url != null)
            {
                url = webBrowser1.Url.AbsoluteUri;
            }

            if (url.ToString().Contains(redirectUri))
            {

                string queryParams = e.Url.Query;
                if (queryParams.Length > 0)
                {
                    NameValueCollection qs = HttpUtility.ParseQueryString(queryParams);
                    if (qs["code"] != null)
                    {
                        string authCode = qs["code"];
                        access = AuthResponse.Exchange(authCode, clientId, clientSecret, redirectUri);
                        this.Close();
                    }
                }

                string[] theCookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
                foreach (string currentFile in theCookies)
                {
                    try
                    {
                        System.IO.File.Delete(currentFile);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}
