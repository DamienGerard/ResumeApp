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
        public String description { get; set; }
        public Dictionary<String, String> projects { get; set; }

        public Module(String id, String name, String description, Dictionary<String, String> projects) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.projects = projects;
        }

        public static Dictionary<String, Module> fetchAll()
        {
            Dictionary<String, Module> modules = new Dictionary<String, Module>();

            var rawModules = FileHandler.CsvFileReader(@"pseudoDatabase\modules.csv", ',');
            var projectsDictionary = fetchAllProject();

            Dictionary<String, String> projects = new Dictionary<String, String>();

            foreach (var moduleRow in rawModules)
            {
                var projectsOfModule = (from projectRow in projectsDictionary where projectRow.Key.StartsWith(moduleRow[0]) select projectRow.Value).ToList();
                foreach (var project in projectsOfModule) {
                    projects.Add(project[1], project[2]);
                }
                modules.Add(moduleRow[0], new Module(moduleRow[0], moduleRow[1], moduleRow[2], projects.ToDictionary(entry => entry.Key, entry => entry.Value)));
                projects.Clear();
            }
            return modules;
        }

        private static Dictionary<String, List<String>> fetchAllProject() {
            var rawProjects = FileHandler.CsvFileReader(@"pseudoDatabase\projects.csv", ',');
            Dictionary<String, List<String>> projectsDictionary = new Dictionary<string, List<string>>();

            foreach (var projectRow in rawProjects)
            {
                projectsDictionary.Add($"{projectRow[0]}_{projectRow[1]}", projectRow);
            }

            return projectsDictionary;
        }

        internal void save()
        {
            var modules = fetchAll();

            if (modules.ContainsKey(id)) {
                modules[id] = this;
            } else {
                modules.Add(id, this);
            }

            saveProjects();

            FileHandler.CsvFileWriter(ToDataset(modules.Values.ToList()), @"pseudoDatabase\modules.csv", ',');
        }

        private void saveProjects()
        {
            var allProjects = fetchAllProject();
            foreach (var project in projects) {
                if (allProjects.ContainsKey($"{id}_{project.Key}"))
                {
                    allProjects[$"{id}_{project.Key}"] = new List<String>() { id, project.Key, project.Value };
                }
                else {
                    allProjects.Add($"{id}_{project.Key}", new List<String>() { id, project.Key, project.Value });
                }
            }

            FileHandler.CsvFileWriter(allProjects.Values.ToList(), @"pseudoDatabase\projects.csv", ',');
        }

        public List<String> ToStringList() => new List<String>() { id, name, description };

        public static List<List<String>> ToDataset(List<Module> modules)
        {
            var dataset = new List<List<String>>();
            foreach (var module in modules)
            {
                dataset.Add(module.ToStringList());
            }
            return dataset;
        }

        internal void delete()
        {
            var modules = fetchAll();

            if (modules.ContainsKey(id))
            {
                modules.Remove(id);
            }

            deleteProjects();

            FileHandler.CsvFileWriter(ToDataset(modules.Values.ToList()), @"pseudoDatabase\modules.csv", ',');
        }

        private void deleteProjects()
        {
            var allProjects = fetchAllProject();
            foreach (var project in projects)
            {
                if (allProjects.ContainsKey($"{id}_{project.Key}"))
                {
                    allProjects.Remove($"{id}_{project.Key}");
                }
            }

            FileHandler.CsvFileWriter(allProjects.Values.ToList(), @"pseudoDatabase\projects.csv", ',');
        }

        internal void deleteProject(string projectToDelete)
        {
            var allProjects = fetchAllProject();

            if (allProjects.ContainsKey($"{id}_{projectToDelete}"))
            {
                allProjects.Remove($"{id}_{projectToDelete}");
            }

            FileHandler.CsvFileWriter(allProjects.Values.ToList(), @"pseudoDatabase\projects.csv", ',');
        }
    }
}