using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeApp.model
{
    class Experience
    {
        public string id { get;}
        public string compName { get; set; }
        public string jobTitle { get; set; }
        public DateTime start { get; set; }
        public DateTime? end { get; set; }
        public string desc { get; set; }

        public Experience(string id, string compName, string jobTitle, DateTime start, DateTime? end, string desc) {
            this.id = id;
            this.compName = compName;
            this.jobTitle = jobTitle;
            this.start = start;
            this.end = end;
            this.desc = desc;
        }

        internal static Dictionary<String, Experience> fetchAll()
        {
            Dictionary<String, Experience> experiences = new Dictionary<String, Experience>();

            var rawExperiences = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\experiences.csv", ',');

            foreach (var rawExperience in rawExperiences)
            {
                experiences.Add(rawExperience[0], new Experience(rawExperience[1],
                    rawExperience[2],
                    rawExperience[3],
                    DateTime.Parse(rawExperience[4]),
                    DateTime.Parse(rawExperience[5]),
                    rawExperience[6]
                    ));
            }
            return experiences;
        }
    }
}
