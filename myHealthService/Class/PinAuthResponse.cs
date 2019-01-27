using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PinterestAPI
{
    public class AuthResponse
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

        public string state { get; set; } 

        

        public static AuthResponse get(string response)
        {
            AuthResponse result = JsonConvert.DeserializeObject<AuthResponse>(response);
            return result;
        }

        public static AuthResponse Exchange(string authCode, string clientid, string secret, string redirectUri)
        {

            var request = (HttpWebRequest)WebRequest.Create("https://api.pinterest.com/v1/oauth/token");

            string postData = string.Format("code={0}&redirect_uri={1}&client_id={2}&client_secret={3}&scope=&grant_type=authorization_code", authCode, redirectUri, clientid, secret);
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
            var x = AuthResponse.get(responseString);

            x.clientId = clientid;
            x.secret = secret;

            return x;
        }

        public static Uri GetAutenticationURI(string clientId, string redirectUri, string state)
        {
            if (string.IsNullOrEmpty(redirectUri))
            {
                redirectUri = string.Format("https://localhost/pinauth/auth/pin/callback/");
            }
            string oauth = string.Format("https://api.pinterest.com/oauth/?response_type=code&redirect_uri={0}&client_id={1}&scope=read_public,write_public&state={2}", redirectUri, clientId, state);
            return new Uri(oauth);
        }
    }
}
