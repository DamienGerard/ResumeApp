using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeApp.model
{
    class ProfTrain : Education
    {
        public string desc { get; set; }

        public ProfTrain(string id, string institution, string certification, String desc) : base(id, institution, certification, EducationType.professional) {
            this.desc = desc;
        }

        internal static Dictionary<String, ProfTrain> fetchAll(List<List<String>> rawEducation = null)
        {
            if (rawEducation == null)
            {
                rawEducation = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\education.csv", ',');
            }
            var rawProftrain = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\professionalTraining.csv", ',');

            Dictionary<String, String> profTrainDictionary = new Dictionary<String, String>();
            foreach (var profTrainRow in rawProftrain) {
                profTrainDictionary.Add(profTrainRow[0], profTrainRow[1]);
            }

            Dictionary<String, ProfTrain> profTrains = new Dictionary<String, ProfTrain>();

            foreach (var educationRow in rawEducation)
            {
                if (educationRow[4] != "prof_train") continue;

                profTrains.Add(educationRow[0], new ProfTrain(educationRow[0], educationRow[0], educationRow[0], profTrainDictionary[educationRow[0]]));
            }

            return profTrains;
        }
    }
}
