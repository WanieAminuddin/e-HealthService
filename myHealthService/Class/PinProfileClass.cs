using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace PinterestAPI.models
{
    public class PinProfile
    {
        public string access_token;
        public data data;
    }
    public class data
    {
        [XmlElement("first_name")]
        public string Fname;
        [XmlElement("last_name")]

        public string username;
        public string bio;
        public string url;
        public string Lname;

        public image image;
        public counts counts;
    }
    public class image
    {
        public _x0036_0x60 _x0036_0x60;
    }
    public class _x0036_0x60
    {
        [XmlElement("url")]
        public string pinDP;
        public string width;
    }
    public class counts
    {
        public string pins;
        public string following;
        public string followers;
        public string boards;
    }
}
