
using iS3.Core.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;


namespace iS3.Core.Client
{
        public class UserViewModel
    {
        public List<Useraccount> Users { get; set; }

        public UserViewModel()
        {
            Users = new List<Useraccount>();
        }
        public void Load(string projectID)
        {
            var doc = new XmlDocument();
            try
            {
                doc.Load(Runtime.dataPath + "//" + projectID + "//Users.xml");
            }
            catch (Exception ex)
            {

            }

            var xn = doc.SelectSingleNode("Users");
            var tabs = xn.ChildNodes;
            foreach (var tabnode in tabs)
            {
                var useraccountElement = (XmlElement)tabnode;
                Useraccount _useraccount = new Useraccount(useraccountElement.GetAttribute("Username"), useraccountElement.GetAttribute("Password"), useraccountElement.GetAttribute("filtercontent"));
                Users.Add(_useraccount);
            }
        }

       


    }
    public class Useraccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string filtercontent { get; set; }

        public Useraccount(string t1, string t2, string t3)
        {
            Username = t1;
            Password = t2;
            filtercontent = t3;
        }
    }
}
