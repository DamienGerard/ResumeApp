using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeApp.model
{
    enum SkillType { personal, technological}
    class Skill
    {
        public string name { get; set; }
        public string id { get; set; }
        public string desc { get; set; }
        public float proficiency { get; set; }
        public SkillType skillType { get; set; }
        public Skill(string name, string id, string desc, float proficiency, SkillType skillType)
        {
            this.name = name;
            this.id = id;
            this.desc = desc;
            this.proficiency = proficiency;
            this.skillType = skillType;
        }

        internal static Dictionary<String, Skill> fetchAll()
        {
            Dictionary<String, Skill> skills = new Dictionary<String, Skill>();

            var rawSkills = FileHandler.CsvFileReader(@"C:\Users\p128bf6\source\repos\ResumeApp\ResumeApp\pseudoDatabase\skills.csv", ',');

            foreach (var rawSkill in rawSkills) {
                skills.Add(rawSkill[0], new Skill(rawSkill[2],
                    rawSkill[1],
                    rawSkill[3],
                    float.Parse(rawSkill[4]),
                    rawSkill[5] == "personal" ? SkillType.personal : SkillType.technological
                    ));
            }
            return skills;
        }
    }
}
