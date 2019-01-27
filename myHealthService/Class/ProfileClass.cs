using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineHealthService.models
{
    public class Profile
    {
        [XmlElement("circledByCount")]
        public string circle;

        public string displayName;
        public string id;
        public string picture;
        public string tagline;
        public string url;
        public image image;
        public emails emails;
    }
    public class emails
    {
        [XmlElement("value")]
        public string myemail;
    }
    public class image
    {
        [XmlElement("url")]
        public string imageurl;
    }
}
