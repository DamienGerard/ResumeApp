using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeApp.model
{
    class ProfTrain : Education
    {
        public string description { get; set; }

        public ProfTrain(string id, string institution, string certification, String desc, string username) : base(id, institution, certification, EducationType.professional, username) {
            this.description = desc;
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
                if (educationRow[4] != "professional") continue;

                profTrains.Add(educationRow[1], new ProfTrain(educationRow[1], educationRow[2], educationRow[3], profTrainDictionary[educationRow[1]], educationRow[0]));
            }

            return profTrains;
        }

        internal new void save()
        {
            base.save();
            var profTrains = fetchAll();

            if (profTrains.ContainsKey(id))
            {
                profTrains[id] = this;
            }
            else
            {
                profTrains.Add(id, this);
            }

            FileHandler.CsvFileWriter(ToDataset(profTrains.Values.ToList()), @"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\professionalTraining.csv", ',');
        }


        public new List<String> ToStringList() => new List<String>() { id, description };

        public static List<List<String>> ToDataset(List<ProfTrain> profTrains)
        {
            var dataset = new List<List<String>>();
            foreach (var profTrain in profTrains)
            {
                dataset.Add(profTrain.ToStringList());
            }
            return dataset;
        }
    }
}
