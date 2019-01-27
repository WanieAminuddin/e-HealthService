using InstagramAPI.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Collections.Specialized;

namespace myHealthService
{
    public partial class IGsignin : Form
    {
        public const string clientId = "1dbac81bf55143e48a592f34fb82ee8c";
        public const string clientSecret = "4dcfb910b5d0459a9032161ccb0b164a";
        public const string redirectURI = "http://localhost/igauth/auth/ig/callback/";

        public AuthResponse access;

        public IGsignin()
        {
            InitializeComponent();
            webBrowser1.Navigate(AuthResponse.GetAutenticationURI(clientId, redirectURI));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = "";
            if (webBrowser1.Url != null)
            {
                url = webBrowser1.Url.AbsoluteUri;
            }

            if (url.ToString().Contains(redirectURI))
            {
                this.Close();
                string queryParams = e.Url.Query;
                if (queryParams.Length > 0)
                {
                    NameValueCollection qs = HttpUtility.ParseQueryString(queryParams);
                    if (qs["code"] != null)
                    {
                        string authCode = qs["code"];
                        access = AuthResponse.Exchange(authCode, clientId, clientSecret, redirectURI);
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
