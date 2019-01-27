using OnlineHealthService.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myHealthService
{
    public partial class SociaLogin : Form
    {
        public const string clientId = "722378169881-saaju7ndromsdko3g5u6eno182u77vui.apps.googleusercontent.com";
        public const string clientSecret = "ZTRHI5mtlM63oiH2aML2xqT8";
        public const string redirectURI = "urn:ietf:wg:oauth:2.0:oob";

        public GoogleAuth access;

        public SociaLogin()
        {
            InitializeComponent();
            socialBrowser.Navigate(OnlineHealthService.models.GoogleAuth.GetAutenticationURI(clientId, redirectURI));
        }

        private void socialBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string Mytitle = ((WebBrowser)sender).DocumentTitle.ToLower();
            if (Mytitle.IndexOf("success code=") > -1)
            {
                socialBrowser.Visible = false;

                string authCode = socialBrowser.DocumentTitle.Replace("Success code=", "");
                string webText = ((WebBrowser)sender).DocumentText;

                access = GoogleAuth.Exchange(authCode, clientId, clientSecret, redirectURI);

                processAccess();
            }
        }
        public void processAccess()
        {
            if (access.Access_token != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
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
