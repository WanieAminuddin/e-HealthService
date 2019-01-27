using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHealthService.models
{
    public class GoogleAuth
    {
        private string access_token;
        public string Access_token
        {
            get
            {
                return access_token;
            }
            set { access_token = value; }
        }
        public string refresh_token { get; set; }
        public string clientId { get; set; }
        public string secret { get; set; }

        public static GoogleAuth get(string response)
        {
            GoogleAuth result = JsonConvert.DeserializeObject<GoogleAuth>(response);
            return result;
        }

        public static GoogleAuth Exchange(string authCode, string clientid, string secret, string redirectURI)
        {

            var request = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");

            string postData = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code", authCode, clientid, secret, redirectURI);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var x = GoogleAuth.get(responseString);

            x.clientId = clientid;
            x.secret = secret;

            return x;
        }

        public static Uri GetAutenticationURI(string clientId, string redirectUri)
        {
            string scopes = "https://www.googleapis.com/auth/plus.login email";

            if (string.IsNullOrEmpty(redirectUri))
            {
                redirectUri = "urn:ietf:wg:oauth:2.0:oob";
            }

            string oauth = string.Format("https://accounts.google.com/o/oauth2/auth?client_id={0}&redirect_uri={1}&scope={2}&response_type=code", clientId, redirectUri, scopes);

            return new Uri(oauth);
        }
    }
}
