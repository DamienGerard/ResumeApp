using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResumeApp.utils;

namespace ResumeApp.model
{
    enum UserType { admin, simple }
    class User
    {
        public String username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public UserType usertype { get; set; }
        public string password { get; set; }
        public string description { get; set; }
        public Dictionary<String, Experience> experiences { get; set; }
        public Dictionary<String, Education> educations { get; set; }
        public Dictionary<String, Skill> skills { get; set; }
        public Contact contact { get; set; }


        public User(string username, string fName, string lName, UserType usertype, string password, string description, Dictionary<String, Experience> experiences, Dictionary<String, Education> education, Dictionary<String, Skill> skills, Contact contact)
        {
            this.username = username;
            this.firstName = fName;
            this.lastName = lName;
            this.usertype = usertype;
            this.password = password;
            this.description = description;
            this.experiences = experiences;
            this.educations = education;
            this.skills = skills;
            this.contact = contact;
        }

        public static Dictionary<String, User> fetchAll()
        {
            Dictionary<String, Experience> retreivedExperiences = Experience.fetchAll();
            Dictionary<String, Education> retreivedEducation = Education.fetchAll();
            Dictionary<String, Skill> retreivedSkills = Skill.fetchAll();

            var userData = FileHandler.CsvFileReader(@"pseudoDatabase\users.csv", ',');
            Dictionary<String, Contact> retreivedContacts = Contact.fetchAll(userData);

            var users = new Dictionary<String, User>();
            foreach (var userDataRow in userData) {
                users.Add(userDataRow[0], 
                    new User(
                        userDataRow[0], 
                        userDataRow[1], 
                        userDataRow[2], 
                        userDataRow[3]=="admin" ? UserType.admin : UserType.simple, 
                        userDataRow[4], 
                        userDataRow[5],
                        (from experience in retreivedExperiences where experience.Value.username == userDataRow[0] select experience.Value).ToDictionary(experience => experience.id, experience => experience),
                        (from education in retreivedEducation where education.Value.username == userDataRow[0] select education.Value).ToDictionary(education => education.id, education => education),
                        (from skill in retreivedSkills where skill.Value.username == userDataRow[0] select skill.Value).ToDictionary(skill => skill.id, skill => skill),
                        (from contact in retreivedContacts where contact.Key == userDataRow[0] select contact.Value).ElementAt(0)
                    ));
            }
            return users;
        }

        public void save()
        {
            var users = fetchAll();
            if (users.ContainsKey(username))
            {
                users[username] = this;
            } else
            {
                users.Add(username, this);
            }

            foreach (var experience in experiences) experience.Value.save();
            foreach (var education in educations) education.Value.save();
            foreach (var skill in skills) skill.Value.save();
            contact.save();

            FileHandler.CsvFileWriter(ToDataset(users.Values.ToList()), @"pseudoDatabase\users.csv", ',');
        }


        public List<String> ToStringList() => new List<String>() { username, firstName, lastName, (usertype == UserType.admin)? "admin" : "guest", password, description, contact.email, contact.phoneNum};

        public static List<List<String>> ToDataset(List<User> users) {
            var dataset = new List<List<String>>();
            foreach (var user in users) {
                dataset.Add(user.ToStringList());
            }
            return dataset;
        }
    }
}
