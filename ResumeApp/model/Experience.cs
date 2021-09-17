using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeApp.model
{
    class Experience
    {
        public string id { get;}
        public string companyName { get; set; }
        public string jobTitle { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string description { get; set; }
        public string username { get; private set; }

        public Experience(string id, string compName, string jobTitle, DateTime start, DateTime end, string desc, string username) {
            this.id = id;
            this.companyName = compName;
            this.jobTitle = jobTitle;
            this.start = start;
            this.end = end;
            this.description = desc;
            this.username = username;
        }

        internal static Dictionary<String, Experience> fetchAll()
        {
            Dictionary<String, Experience> experiences = new Dictionary<String, Experience>();

            var rawExperiences = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\experiences.csv", ',');

            foreach (var rawExperience in rawExperiences)
            {
                experiences.Add(rawExperience[1], new Experience(rawExperience[1],
                    rawExperience[2],
                    rawExperience[3],
                    DateTime.Parse(rawExperience[4]),
                    DateTime.Parse(rawExperience[5]),
                    rawExperience[6],
                    rawExperience[0]
                    ));
            }
            return experiences;
        }

        internal void save()
        {
            var experiences = fetchAll();

            if (experiences.ContainsKey(id))
            {
                experiences[id] = this;
            }
            else
            {
                experiences.Add(id, this);
            }

            FileHandler.CsvFileWriter(ToDataset(experiences.Values.ToList()), @"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\experiences.csv", ',');
        }

        internal void delete()
        {
            var experiences = fetchAll();

            if (experiences.ContainsKey(id))
            {
                experiences.Remove(id);
            }

            FileHandler.CsvFileWriter(ToDataset(experiences.Values.ToList()), @"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\experiences.csv", ',');
        }


        public List<String> ToStringList() => new List<String>() { username, id, companyName, jobTitle, start.ToShortDateString(), ((DateTime)end).ToShortDateString() };

        public static List<List<String>> ToDataset(List<Experience> experiences)
        {
            var dataset = new List<List<String>>();
            foreach (var experience in experiences)
            {
                dataset.Add(experience.ToStringList());
            }
            return dataset;
        }
    }
}
