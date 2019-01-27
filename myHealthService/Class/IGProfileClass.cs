using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InstagramAPI.models
{
    public class ProfileIG
    {
        public string access_token;
        public data data;

    }
    public class data
    {
        public string username;
        public string bio;

        [XmlElement("full_name")]
        public string name;
        [XmlElement("profile_picture")]
        public string profileImage;

        public counts counts;
    }
    public class counts
    {
        public int follows;

        [XmlElement("followed_by")]
        public int followers;
    }
}
