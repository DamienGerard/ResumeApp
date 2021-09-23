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
        public University(string id, string institution, string certification, Dictionary<String, Module> modules, String username): base(id, institution, certification, EducationType.university, username) {
            this.modules = modules;
        }


        internal static Dictionary<String, University> fetchAll(List<List<String>> rawEducation = null)
        {
            if (rawEducation == null)
            {
                rawEducation = FileHandler.CsvFileReader(@"pseudoDatabase\education.csv", ',');
            }
            var rawUniversities = FileHandler.CsvFileReader(@"pseudoDatabase\universityDetails.csv", ',');

            Dictionary<String, Module> retreivedModule = Module.fetchAll();
            var universities = new Dictionary<String, University>();
            Dictionary<String, Module> modules = new Dictionary<String, Module>();

            foreach (var educationRow in rawEducation)
            {
                if (educationRow[4] != "university") continue;

                var moduleIds = (from educationModule in rawUniversities where educationModule[0] == educationRow[1] select educationModule[1]).ToList();

                foreach (var moduleId in moduleIds) {
                    modules.Add(moduleId, retreivedModule[moduleId]);
                }

                universities.Add(educationRow[1], new University(educationRow[1], educationRow[2], educationRow[3], modules.ToDictionary(entry => entry.Key, entry => entry.Value), educationRow[0]));
                modules.Clear();
            }
            return universities;
        }

        internal new void save()
        {
            base.save();
            var universitiesDetails = fetchAll();

            if (universitiesDetails.ContainsKey(id))
            {
                universitiesDetails[id] = this;
            }
            else
            {
                universitiesDetails.Add(id, this);
            }

            foreach (var module in modules) module.Value.save();

            FileHandler.CsvFileWriter(ToDataset(universitiesDetails.Values.ToList()), @"pseudoDatabase\universityDetails.csv", ',');
        }

        public static List<List<String>> ToDataset(List<University> universitiesDetails)
        {
            var dataset = new List<List<String>>();
            foreach (var universityDetails in universitiesDetails)
            {
                foreach (var module in universityDetails.modules) { 
                    dataset.Add(new List<String>() { universityDetails.id, module.Value.id });
                }
                
            }
            return dataset;
        }

        public override void display() {
            base.display();
            Console.WriteLine("{0,-20}: {1,20}", "Type", "University Training");
            Console.WriteLine("Module");
            Console.WriteLine("{0,20} {1,20}", "Module Id", "Module name");
            foreach (var module in modules.Values)
            {
                Console.WriteLine("{0,20} {1,20}", module.id, module.name);
            }
            Console.WriteLine("\n\nEnter a command to proceed(e.g., edit certification, delete <module_id>, <module_id>, etc...)");
        }
    }
}
