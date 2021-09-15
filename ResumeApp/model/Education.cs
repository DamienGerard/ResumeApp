using ResumeApp.utils;
using System;
using System.Collections.Generic;

namespace ResumeApp.model
{
    public enum EducationType { university, professional }
    abstract class Education
    {
        public string id { get; set; }
        public string institution { get; set; }
        public string certification { get; set; }
        private EducationType educationType;

        public Education(string id, string institution, string certification, EducationType educationType)
        {
            this.id = id;
            this.institution = institution;
            this.certification = certification;
            this.educationType = educationType;
        }

        public EducationType getType() => educationType;

        internal static Dictionary<String, Education> fetchAll()
        {
            var educationData = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\education.csv", ',');

            Dictionary<String, University> retreivedUniversities = University.fetchAll(educationData);
            Dictionary<String, ProfTrain> retreivedProfTrains = ProfTrain.fetchAll();

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
    }
}
