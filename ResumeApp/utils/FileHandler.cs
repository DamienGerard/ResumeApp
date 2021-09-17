using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ResumeApp.utils
{
    class FileHandler
    {
        public static List<List<string>> CsvFileReader(string filename, char delimeter)
        {
            var data = new List<List<string>>();

            // By using StreamReader
            if (File.Exists(filename))
            {
                // Reads file line by line
                StreamReader sr = new StreamReader(filename);
                string line;
                var stringList = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    stringList = line.Split(delimeter).ToList();

                    data.Add(stringList);
                }

                sr.Close();
            }

            return data;
        }

        public static void CsvFileWriter(List<List<string>> data, string filename, char delimeter)
        {
            StreamWriter sw = new StreamWriter(filename);

            foreach (var line in data) {
                foreach (var cellEntry in line) {
                    sw.Write($"{cellEntry}{delimeter}");
                }
                sw.WriteLine("");
            }

            sw.Close();
        }
    }
}
