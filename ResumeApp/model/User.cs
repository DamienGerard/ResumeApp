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
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public UserType usertype { get; set; }
        public string password { get; set; }
        public string description { get; set; }
        public Dictionary<String, Experience> experiences { get; set; }
        public Dictionary<String, Education> education { get; set; }
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
            this.education = education;
            this.skills = skills;
            this.contact = contact;
        }

        public Dictionary<String, User> fetchAll()
        {
            Dictionary<String, Experience> retreivedExperiences = Experience.fetchAll();
            Dictionary<String, Education> retreivedEducation = Education.fetchAll();
            Dictionary<String, Skill> retreivedSkills = Skill.fetchAll();

            var userData = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\users.csv", ',');
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
                        (from experience in retreivedExperiences where experience.Key == userDataRow[0] select experience.Value).ToDictionary(experience => experience.id, experience => experience),
                        (from education in retreivedEducation where education.Key == userDataRow[0] select education.Value).ToDictionary(education => education.id, education => education),
                        (from skill in retreivedSkills where skill.Key == userDataRow[0] select skill.Value).ToDictionary(skill => skill.id, skill => skill),
                        (from contact in retreivedContacts where contact.Key == userDataRow[0] select contact.Value).ElementAt(0)
                    ));
            }
            return users;
        }
    }
}
