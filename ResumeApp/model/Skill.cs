using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeApp.model
{
    enum SkillType { personal, technological}
    class Skill
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float proficiency { get; set; }
        public SkillType skillType { get; set; }
        public string username { get; private set; }

        public Skill(string id, string name, string desc, float proficiency, SkillType skillType, string username)
        {
            this.id = id;
            this.name = name;
            this.description = desc;
            this.proficiency = proficiency;
            this.skillType = skillType;
            this.username = username;
        }

        internal static Dictionary<String, Skill> fetchAll()
        {
            Dictionary<String, Skill> skills = new Dictionary<String, Skill>();

            var rawSkills = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\skills.csv", ',');

            foreach (var rawSkill in rawSkills) {
                skills.Add(rawSkill[1], new Skill(rawSkill[1],
                    rawSkill[2],
                    rawSkill[3],
                    float.Parse(rawSkill[4]),
                    rawSkill[5] == "personal" ? SkillType.personal : SkillType.technological,
                    rawSkill[0]
                    ));
            }
            return skills;
        }

        internal void save()
        {
            var skills = fetchAll();

            if (skills.ContainsKey(id))
            {
                skills[id] = this;
            }
            else
            {
                skills.Add(id, this);
            }

            FileHandler.CsvFileWriter(ToDataset(skills.Values.ToList()), @"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\skills.csv", ',');
        }

        public List<String> ToStringList() => new List<String>() { username, id, name, description, proficiency.ToString(), (skillType == SkillType.personal) ? "personal" : "technological" };

        public static List<List<String>> ToDataset(List<Skill> skills)
        {
            var dataset = new List<List<String>>();
            foreach (var skill in skills)
            {
                dataset.Add(skill.ToStringList());
            }
            return dataset;
        }

        internal void delete()
        {
            var skills = fetchAll();

            if (skills.ContainsKey(id))
            {
                skills.Remove(id);
            }

            FileHandler.CsvFileWriter(ToDataset(skills.Values.ToList()), @"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\skills.csv", ',');
        }
    }
}
