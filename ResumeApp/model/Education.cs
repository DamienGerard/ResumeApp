using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResumeApp.model
{
    public enum EducationType { university, professional }
    abstract class Education
    {
        public string id { get; set; }
        public string institution { get; set; }
        public string certification { get; set; }
        public  EducationType educationType;

        public String username { get; private set; }

        public Education(string id, string institution, string certification, EducationType educationType, string username)
        {
            this.id = id;
            this.institution = institution;
            this.certification = certification;
            this.educationType = educationType;
            this.username = username;
        }

        public EducationType getType() => educationType;

        internal static Dictionary<String, Education> fetchAll()
        {
            var educationData = FileHandler.CsvFileReader(@"pseudoDatabase\education.csv", ',');

            Dictionary<String, University> retreivedUniversities = University.fetchAll(educationData);
            Dictionary<String, ProfTrain> retreivedProfTrains = ProfTrain.fetchAll(educationData);

            Dictionary<String, Education> educations = new Dictionary<String, Education>();

            //you'd use covariant and contravariance if you were smarter T_T
            foreach (var university in retreivedUniversities)
            {
                educations.Add(university.Key, university.Value);
            }

            //you'd use covariant and contravariance if you were smarter T_T
            foreach (var profTrain in retreivedProfTrains)
            {
                educations.Add(profTrain.Key, profTrain.Value);
            }

            return educations;
        }

        internal void save()
        {
            var educations = fetchAll();
            if (educations.ContainsKey(id))
            {
                educations[id] = this;
            }
            else
            {
                educations.Add(id, this);
            }

            FileHandler.CsvFileWriter(ToDataset(educations.Values.ToList()), @"pseudoDatabase\education.csv", ',');
        }


        public List<String> ToStringList() => new List<String>() { username, id, institution, certification, (educationType == EducationType.professional) ? "professional" : "university"};

        public static List<List<String>> ToDataset(List<Education> educations)
        {
            var dataset = new List<List<String>>();
            foreach (var education in educations)
            {
                dataset.Add(education.ToStringList());
            }
            return dataset;
        }

        internal void delete()
        {
            var educations = fetchAll();
            if (educations.ContainsKey(id))
            {
                educations.Remove(id);
            }

            FileHandler.CsvFileWriter(ToDataset(educations.Values.ToList()), @"pseudoDatabase\education.csv", ',');
        }
    }
}
