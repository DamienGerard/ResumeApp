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
                StreamReader Textfile = new StreamReader(filename);
                string line;
                var stringList = new List<string>();
                while ((line = Textfile.ReadLine()) != null)
                {
                    stringList = line.Split(delimeter).ToList();

                    data.Add(stringList);
                }

                Textfile.Close();
            }

            return data;
        }
    }
}
