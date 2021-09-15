using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeApp.model
{
    class Contact
    {
        public string email { get; set; }
        public string phoneNum { get; set; }
        public Dictionary<String, String> links;
        public Contact(String email, String phoneNum, Dictionary<String, String> links) {
            this.email = email;
            this.phoneNum = phoneNum;
            this.links = links;
        }

        public Dictionary<String, String> getAllLinks() {
            return links;
        }

        public void editLink(String key, String url) {
            if (links.ContainsKey(key))
            {
                links[key] = url;
            }
            else {
                links.Add(key, url);
            }
        }

        internal static Dictionary<String, Contact> fetchAll(List<List<String>> rawUsers=null)
        {
            if (rawUsers==null) {
                rawUsers= FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\users.csv", ',');
            }
            var rawLinks = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\userLinks.csv", ',');

            var contacts = new Dictionary<String, Contact>();
            foreach (var rawUser in rawUsers) {
                contacts.Add(rawUser[0], new Contact(rawUser[6], rawUser[7], (from rawLink in rawLinks where rawLink[0] == rawUser[0] select rawLink).ToDictionary(link => link[1], link => link[2])));
            }
            return contacts;
        }
    }
}
