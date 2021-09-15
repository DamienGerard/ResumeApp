using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeApp.model
{
    class University: Education
    {
        public Dictionary<String, Module> modules;
        public University(string id, string institution, string certification, Dictionary<String, Module> modules): base(id, institution, certification, EducationType.university) {
            this.modules = modules;
        }


        internal static Dictionary<String, University> fetchAll(List<List<String>> rawEducation = null)
        {
            if (rawEducation == null)
            {
                rawEducation = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\education.csv", ',');
            }
            var rawUniversities = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\universityDetails.csv", ',');

            Dictionary<String, Module> retreivedModule = Module.fetchAll();
            var universities = new Dictionary<String, University>();
            Dictionary<String, Module> modules = new Dictionary<String, Module>();

            foreach (var educationRow in rawEducation)
            {
                if (educationRow[4] != "university") continue;

                var moduleIds = (from educationModule in rawUniversities where educationModule[0] == educationRow[0] select educationModule[1]).ToList();

                foreach (var moduleId in moduleIds) {
                    modules.Add(moduleId, retreivedModule[moduleId]);
                }

                universities.Add(educationRow[0], new University(educationRow[0], educationRow[1], educationRow[2], modules));
                modules.Clear();
            }
            return universities;
        }
    }
}
