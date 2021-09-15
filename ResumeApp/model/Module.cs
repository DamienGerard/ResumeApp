using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResumeApp.model
{
    public class Module
    {
        public String id { get; set; }
        public String name { get; set; }
        public String desc { get; set; }
        public Dictionary<String, String> projects { get; set; }

        public Module(String id, String name, String desc, Dictionary<String, String> projects) {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.projects = projects;
        }

        public static Dictionary<String, Module> fetchAll()
        {
            Dictionary<String, Module> modules = new Dictionary<String, Module>();

            var rawModules = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\modules.csv", ',');
            var rawProjects = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\projects.csv", ',');
            Dictionary<String, List<String>> projectsDictionary = new Dictionary<string, List<string>>();

            foreach (var projectRow in rawProjects) {
                projectsDictionary.Add(projectRow[1], projectRow);
            }

            Dictionary<String, String> projects = new Dictionary<String, String>();

            foreach (var moduleRow in rawModules)
            {
                var projectsOfModule = (from projectRow in rawProjects where projectRow[0] == moduleRow[0] select projectRow).ToList();
                foreach (var project in projectsOfModule) {
                    projects.Add(project[1], project[2]);
                }
                modules.Add(moduleRow[0], new Module(moduleRow[0], moduleRow[1], moduleRow[2], projects));
                projects.Clear();
            }
            return modules;
        }
    }
}