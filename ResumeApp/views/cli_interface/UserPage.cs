using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResumeApp.model;
using ResumeApp.utils;

namespace ResumeApp.views.cli_interface
{
    static class UserPage
    {
        private static string title = @"
                             _   _                   ______                   
                            | | | |                  | ___ \                  
                            | | | | ___   ___  _ __  | |_/ /__ _   __ _   ___ 
                            | | | |/ __| / _ \| '__| |  __// _` | / _` | / _ \
                            | |_| |\__ \|  __/| |    | |  | (_| || (_| ||  __/
                             \___/ |___/ \___||_|    \_|   \__,_| \__, | \___|
                                                                   __/ |      
                                                                  |___/       
                                                                               ";
        private static string experiencesTitle = @"
                             _____                          _                              
                            |  ___|                        (_)                             
                            | |__ __  __ _ __    ___  _ __  _   ___  _ __    ___  ___  ___ 
                            |  __|\ \/ /| '_ \  / _ \| '__|| | / _ \| '_ \  / __|/ _ \/ __|
                            | |___ >  < | |_) ||  __/| |   | ||  __/| | | || (__|  __/\__ \
                            \____//_/\_\| .__/  \___||_|   |_| \___||_| |_| \___|\___||___/
                                        | |                                                
                                        |_|                                                
                                                                                            ";
        private static string addExperienceTitle = @"
                          ___       _      _   _____                          _                         
                         / _ \     | |    | | |  ___|                        (_)                        
                        / /_\ \  __| |  __| | | |__ __  __ _ __    ___  _ __  _   ___  _ __    ___  ___ 
                        |  _  | / _` | / _` | |  __|\ \/ /| '_ \  / _ \| '__|| | / _ \| '_ \  / __|/ _ \
                        | | | || (_| || (_| | | |___ >  < | |_) ||  __/| |   | ||  __/| | | || (__|  __/
                        \_| |_/ \__,_| \__,_| \____//_/\_\| .___/ \___|__|   |_| \___||_| |_| \___|\___|
                                                          | |                                           
                                                          |_|                                           
                                                                                                            ";
        private static string educationsTitle = @"
                             _____     _                     _    _                    
                            |  ___|   | |                   | |  (_)                   
                            | |__   __| | _   _   ___  __ _ | |_  _   ___   _ __   ___ 
                            |  __| / _` || | | | / __|/ _` || __|| | / _ \ | '_ \ / __|
                            | |___| (_| || |_| || (__| (_| || |_ | || (_) || | | |\__ \
                            \____/ \__,_| \__,_| \___|\__,_| \__||_| \___/ |_| |_||___/
                                                           
                                                                                        ";
        private static string addEducationsTitle = @"
                          ___       _      _   _____     _                     _    _               
                         / _ \     | |    | | |  ___|   | |                   | |  (_)              
                        / /_\ \  __| |  __| | | |__   __| | _   _   ___  __ _ | |_  _   ___   _ __  
                        |  _  | / _` | / _` | |  __| / _` || | | | / __|/ _` || __|| | / _ \ | '_ \ 
                        | | | || (_| || (_| | | |___| (_| || |_| || (__| (_| || |_ | || (_) || | | |
                        \_| |_/ \__,_| \__,_| \____/ \__,_| \__,_| \___|\__,_| \__||_| \___/ |_| |_|
                                                                                
                                                                                                    ";
        private static string addModuleTitle = @"
                              ___       _      _  ___  ___            _         _       
                             / _ \     | |    | | |  \/  |           | |       | |      
                            / /_\ \  __| |  __| | | .  . |  ___    __| | _   _ | |  ___ 
                            |  _  | / _` | / _` | | |\/| | / _ \  / _` || | | || | / _ \
                            | | | || (_| || (_| | | |  | || (_) || (_| || |_| || ||  __/
                            \_| |_/ \__,_| \__,_| \_|  |_/ \___/  \__,_| \__,_||_| \___|
                                                            
                                                                                            ";
        private static string skillsTitle = @"
                                 _____  _     _  _  _      
                                /  ___|| |   (_)| || |     
                                \ `--. | | __ _ | || | ___ 
                                 `--. \| |/ /| || || |/ __|
                                /\__/ /|   < | || || |\__ \
                                \____/ |_|\_\|_||_||_||___/
                           
                           
                                                            ";
        private static string addSkillsTitle = @"
                              ___       _      _   _____  _     _  _  _ 
                             / _ \     | |    | | /  ___|| |   (_)| || |
                            / /_\ \  __| |  __| | \ `--. | | __ _ | || |
                            |  _  | / _` | / _` |  `--. \| |/ /| || || |
                            | | | || (_| || (_| | /\__/ /|   < | || || |
                            \_| |_/ \__,_| \__,_| \____/ |_|\_\|_||_||_|
                                            
                                                                        ";
        private static string contactTitle = @"
                             _____                _                _   
                            /  __ \              | |              | |  
                            | /  \/  ___   _ __  | |_  __ _   ___ | |_ 
                            | |     / _ \ | '_ \ | __|/ _` | / __|| __|
                            | \__/\| (_) || | | || |_| (_| || (__ | |_ 
                             \____/ \___/ |_| |_| \__|\__,_| \___| \__|
                                           
                                                                        ";
        private static User SelectedUser;
        public static State LoggedInStatus;

        public static void DisplayUserPage(User user, State state) {
            SelectedUser = user;
            LoggedInStatus = state;

            string input = "";

            Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            while (true)
            {
                Console.WriteLine(title);
                Console.WriteLine("{0,20} {1,20}", "First name", "Last name");
                Console.WriteLine("{0,20} {1,20}\n", SelectedUser.firstName, SelectedUser.lastName);
                Console.WriteLine("{0,20}", "Description");
                Console.WriteLine("{0,20}\n\n", SelectedUser.description);
                Console.WriteLine("Enter a command to proceed(e.g., experiences, edit first name, etc...)");
                input = Console.ReadLine();
                if (input == "<-") break;
                //input = input.ToLower();
                if (input.StartsWith("edit") && (LoggedInStatus.loggedInAs != UserType.admin && SelectedUser.username != LoggedInStatus.user.username))
                {
                    Console.WriteLine("ERROR\nUnauthorised action!\nPlease, try again.");
                }
                else if (input == "edit first name")
                {
                    Console.Write("Enter the new first name: ");
                    SelectedUser.firstName = Console.ReadLine();
                    SelectedUser.save();
                }
                else if (input == "edit last name")
                {
                    Console.Write("Enter the new last name: ");
                    SelectedUser.lastName = Console.ReadLine();
                    SelectedUser.save();
                }
                else if (input == "edit description")
                {
                    Console.Write("Enter the new description: ");
                    SelectedUser.firstName = Console.ReadLine();
                    SelectedUser.save();
                }
                else if (input == "experiences")
                {
                    DisplayExperiencesScreen();
                }
                else if (input == "education")
                {
                    DisplayEducationScreen();
                }
                else if (input == "skills")
                {
                    DisplaySkillsScreen();
                }
                else if (input == "contact")
                {
                    DisplayContactScreen();
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        private static void DisplayExperiencesScreen()
        {
            string input = "";
            while (true) {
                Console.WriteLine(experiencesTitle);
                foreach (var experience in SelectedUser.experiences.Values)
                {
                    Console.WriteLine("{0,20}", "Experience Id");
                    Console.WriteLine("{0, 10}\n\n", experience.id);
                    Console.WriteLine("{0,20} {1,20}", "Job Title", "Company Name");
                    Console.WriteLine("{0,20} {1,20}\n", experience.jobTitle, experience.companyName);
                    Console.WriteLine("{0,20} {1,20}", "Starting date", "Ending date");
                    Console.WriteLine("{0,20} {1,20}\n", experience.start.ToShortDateString(), (experience.end.Year != 1) ? experience.end.ToShortDateString() : "Present");
                    Console.WriteLine("{0,20}", "Description");
                    Console.WriteLine("{0, 100}\n\n", experience.description);
                }

                Console.WriteLine("Enter a command to proceed(e.g., add experience, <experience_id> or delete <experience_id> )");
                input = Console.ReadLine();
                //input = input.ToLower();
                if (input == "<-")
                {
                    break;
                }
                else if (input=="add experience")
                {
                    if (LoggedInStatus.loggedInAs != UserType.admin && LoggedInStatus.user.username != SelectedUser.username) { 
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        var newExperience = DisplayAddExperienceForm(SelectedUser.username);
                        if (newExperience != null) {
                            newExperience.save();
                            SelectedUser.experiences.Add(newExperience.id, newExperience);
                        }
                    }
                        
                }
                else if (input.StartsWith("delete "))
                {
                    var experienceToDelete = input.Split(' ')[1];
                    if (!SelectedUser.experiences.ContainsKey(experienceToDelete))
                    {
                        Console.WriteLine($"ERROR\n{experienceToDelete} does not exist!\nPlease, try again.");
                    }
                    else if (LoggedInStatus.loggedInAs != UserType.admin && !LoggedInStatus.user.experiences.ContainsKey(experienceToDelete))
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        SelectedUser.experiences[experienceToDelete].delete();
                        SelectedUser.experiences.Remove(experienceToDelete);
                    }
                }
                else if (!SelectedUser.experiences.ContainsKey(input))
                {
                    Console.WriteLine($"ERROR\n{input} does not exist!\nPlease, try again.");
                }
                else
                {
                    DisplayExperienceScreen(SelectedUser.experiences[input]);
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        private static void DisplayExperienceScreen(Experience experience)
        {
            string input = "";
            while (true)
            {
                Console.WriteLine("{0,20}", "Experience Id");
                Console.WriteLine("{0, 10}\n\n", experience.id);
                Console.WriteLine("{0,20} {1,20}", "Job Title", "Company Name");
                Console.WriteLine("{0,20} {1,20}\n", experience.jobTitle, experience.companyName);
                Console.WriteLine("{0,20} {1,20}", "Starting date", "Ending date");
                Console.WriteLine("{0,20} {1,20}\n", experience.start.ToShortDateString(), (experience.end.Year != 1) ? experience.end.ToShortDateString() : "Present");
                Console.WriteLine("{0,20}", "Description");
                Console.WriteLine("{0, 100}\n\n", experience.description);

                Console.WriteLine("Enter a command to proceed(e.g., edit job title, edit description)");
                input = Console.ReadLine();
                //input = input.ToLower();
                if (input == "<-")
                {
                    break;
                }
                else if (input == "edit job title")
                {
                    Console.Write("Enter the new Job Title: ");
                    experience.jobTitle = Console.ReadLine();
                    experience.save();
                }
                else if (input == "edit company name")
                {
                    Console.Write("Enter the new Company Name: ");
                    experience.companyName = Console.ReadLine();
                    experience.save();
                }
                else if (input == "edit starting date")
                {
                    Console.Write("Enter the new Starting date: ");
                    experience.start = DateTime.Parse(Console.ReadLine());
                    experience.save();
                }
                else if (input == "edit ending date")
                {
                    Console.Write("Enter the new Ending date: ");
                    experience.end = DateTime.Parse(Console.ReadLine());
                    experience.save();
                }
                else if (input == "edit description")
                {
                    Console.Write("Enter the new description: ");
                    experience.description = Console.ReadLine();
                    experience.save();
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        public static Experience DisplayAddExperienceForm(string username)
        {
            string id = Tools.RandomString(5);
            string jobTitle;
            string companyName;
            DateTime startDate;
            DateTime endDate;
            string description;

            string input = "";
            while (true)
            {
                Console.WriteLine(addExperienceTitle);
                Console.WriteLine("Enter the job title: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                jobTitle = input;

                Console.WriteLine("Enter the company name: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                companyName = input;

                Console.WriteLine("Enter the starting date: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                try
                {
                    startDate = DateTime.Parse(input);  
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                    continue;
                }

                Console.WriteLine("Enter the ending date(or nothing if their no ending date): ");
                input = Console.ReadLine();
                if (input == "<-")
                {
                    return null;
                }
                else if (input == "")
                {
                    endDate = default;
                }
                else {
                    try
                    {
                        endDate = DateTime.Parse(input);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR\nWrong input!\nPlease, try again.\n");
                        continue;
                    }
                }

                Console.WriteLine("Enter a description: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                description = input;

                break;
            }

            return new Experience(id, companyName, jobTitle, startDate, endDate, description, username);
        }

        private static void DisplayEducationScreen()
        {
            string input = "";
            while (true)
            {
                Console.WriteLine(educationsTitle);
                Console.WriteLine("{0,20} {1,20} {2,20} {3,20}", "Education Id", "Certification", "Institution", "Type");
                foreach (var education in SelectedUser.educations.Values)
                {
                    Console.WriteLine("{0,20} {1,20} {2,20} {3,20}", education.id, education.certification, education.institution, (education.educationType==EducationType.professional) ? "Professional Training" : "University Training");
                }

                Console.WriteLine("Enter a command to proceed(e.g., add education, <education_id> or delete <education_id> )");
                input = Console.ReadLine();
                //input = input.ToLower();
                if (input == "<-")
                {
                    break;
                }
                else if (input == "add education")
                {
                    if (LoggedInStatus.loggedInAs != UserType.admin && LoggedInStatus.user.username!=SelectedUser.username)
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        var newEducation = DisplayAddEducationForm(SelectedUser.username);
                        if (newEducation != null)
                        {
                            SelectedUser.educations.Add(newEducation.id, newEducation);
                            if (newEducation.educationType == EducationType.university)
                            {
                                ((University)newEducation).save();
                            }
                            else if (newEducation.educationType == EducationType.professional)
                            {
                                ((ProfTrain)newEducation).save();
                            }
                        }
                    }

                }
                else if (input.StartsWith("delete "))
                {
                    var educationToDelete = input.Split(' ')[1];
                    if (!SelectedUser.educations.ContainsKey(educationToDelete))
                    {
                        Console.WriteLine($"ERROR\n{educationToDelete} does not exist!\nPlease, try again.");
                    }
                    else if (LoggedInStatus.loggedInAs != UserType.admin && !LoggedInStatus.user.educations.ContainsKey(educationToDelete))
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        SelectedUser.educations[educationToDelete].delete();
                        SelectedUser.educations.Remove(educationToDelete);
                    }
                }
                else if (!SelectedUser.educations.ContainsKey(input))
                {
                    Console.WriteLine($"ERROR\n{input} does not exist!\nPlease, try again.");
                }
                else
                {
                    _ = SelectedUser;
                    DisplayEducationScreen(SelectedUser.educations[input]);
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        private static void DisplayEducationScreen(Education education)
        {
            string input = "";

            while (true)
            {
                education.display();
                input = Console.ReadLine();
                //input = input.ToLower();
                if (input == "<-")
                {
                    break;
                }
                else if (input == "edit certification")
                {
                    Console.Write("Enter the new certification: ");
                    education.certification = Console.ReadLine();
                    education.save();
                }
                else if (input == "edit institution")
                {
                    Console.Write("Enter the new institution: ");
                    education.institution = Console.ReadLine();
                    education.save();
                }
                else if (input == "edit description" && education.educationType==EducationType.professional)
                {
                    Console.Write("Enter the new description: ");
                    ((ProfTrain)education).description = Console.ReadLine();
                    education.save();
                }
                else if (input == "add module")
                {
                    if (LoggedInStatus.loggedInAs != UserType.admin && LoggedInStatus.user.username != SelectedUser.username)
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        Module newModule = DisplayAddModuleForm();
                        if (newModule != null) ((University) SelectedUser.educations[education.id]).modules.Add(newModule.id, newModule);
                    }

                }
                else if (input.StartsWith("delete "))
                {
                    var moduleToDelete = input.Split(' ')[1];
                    if (!((University)SelectedUser.educations[education.id]).modules.ContainsKey(moduleToDelete))
                    {
                        Console.WriteLine($"ERROR\n{moduleToDelete} does not exist!\nPlease, try again.");
                    }
                    else if (LoggedInStatus.loggedInAs != UserType.admin && !LoggedInStatus.user.educations.ContainsKey(moduleToDelete))
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        ((University)SelectedUser.educations[education.id]).modules[moduleToDelete].delete();
                        ((University)SelectedUser.educations[education.id]).modules.Remove(moduleToDelete);
                    }
                }
                else if (education.educationType==EducationType.university && !((University)SelectedUser.educations[education.id]).modules.ContainsKey(input))
                {
                    Console.WriteLine($"ERROR\n{input} does not exist!\nPlease, try again.");
                }
                else
                {
                    DisplayModuleScreen(((University)SelectedUser.educations[education.id]).modules[input]);
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        private static void DisplayModuleScreen(Module module)
        {
            string input = "";
            while (true)
            {
                Console.WriteLine("Module");

                Console.WriteLine("{0,-20}: {1,20}", "Module Id", module.id);
                Console.WriteLine("{0,-20}: {1,20}", "Module name", module.name);
                Console.WriteLine("{0,-20}: {1,20}", "Description", module.description);

                Console.WriteLine("\nProjects");
                foreach (var project in module.projects)
                {
                    Console.WriteLine("{0,20} {1,20}", "Project title", project.Key);
                    Console.WriteLine("{0,20} {1,20}", "Project description", project.Value);
                }

                Console.WriteLine("\n\nEnter a command to proceed(e.g., edit email name, edit project title/description <project_title>, add project, delete <project_title>, etc...)");
                input = Console.ReadLine();
                if (input == "<-") break;
                //input = input.ToLower();
                if ((input.StartsWith("edit") || input.StartsWith("add") || input.StartsWith("delete")) && (LoggedInStatus.loggedInAs != UserType.admin && SelectedUser.username != LoggedInStatus.user.username))
                {
                    Console.WriteLine("ERROR\nUnauthorised action!\nPlease, try again.");
                }
                else if (input == "edit name")
                {
                    Console.Write("Enter the new name: ");
                    module.name = Console.ReadLine();
                    module.save();
                }
                else if (input == "edit description")
                {
                    Console.Write("Enter the new description: ");
                    module.description = Console.ReadLine();
                    module.save();
                }
                else if (input.StartsWith("edit project description "))
                {
                    var projectToEdit = input.Split(' ')[3];
                    if (!module.projects.ContainsKey(projectToEdit))
                    {
                        Console.WriteLine($"ERROR\n{projectToEdit} does not exist!\nPlease, try again.");
                    }
                    else
                    {
                        Console.Write("Enter the new project description: ");
                        var newProjectDescription = Console.ReadLine();
                        module.projects[projectToEdit] = newProjectDescription;
                        module.save();
                    }
                }
                else if (input.StartsWith("edit project title "))
                {
                    var projectToEdit = input.Split(' ')[3];
                    if (!module.projects.ContainsKey(projectToEdit))
                    {
                        Console.WriteLine($"ERROR\n{projectToEdit} does not exist!\nPlease, try again.");
                    }
                    else
                    {
                        Console.Write("Enter the new project title: ");
                        var newProjectTitle = Console.ReadLine();
                        var projectDescription = module.projects[projectToEdit];
                        module.projects.Remove(projectToEdit);
                        module.deleteProject(projectToEdit);
                        module.projects.Add(newProjectTitle, projectDescription);
                        module.save();
                    }
                }
                else if (input.StartsWith("add project"))
                {
                    Console.Write("Enter the project title: ");
                    var projectTitle = Console.ReadLine();
                    Console.Write("Enter the project description: ");
                    var projectDescription = Console.ReadLine();
                    module.projects.Add(projectTitle, projectDescription);
                    module.save();
                }
                else if (input.StartsWith("delete "))
                {
                    var projectToDelete = input.Split(' ')[1];
                    if (!module.projects.ContainsKey(projectToDelete))
                    {
                        Console.WriteLine($"ERROR\n{projectToDelete} does not exist!\nPlease, try again.");
                    }
                    else
                    {
                        module.deleteProject(projectToDelete);
                        module.projects.Remove(projectToDelete);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        private static Module DisplayAddModuleForm()
        {
            string id = Tools.RandomString(5);
            string name;
            string description;
            Dictionary<string, string> projects = new Dictionary<string, string>();

            string input = "";
            while (true)
            {
                Console.WriteLine(addModuleTitle);
                Console.WriteLine("Enter the module name: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                name = input;

                Console.WriteLine("Enter a description of the module: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                description = input;

                while (true)
                {
                    Console.WriteLine("Do you want to add a project?(yes or no): ");
                    input = Console.ReadLine();
                    if (input == "<-")
                    {
                        return null;
                    }
                    else if (input == "yes")
                    {
                        Console.WriteLine("Enter the project title: ");
                        input = Console.ReadLine();
                        if (input == "<-") return null;
                        var projectTitle = input;
                        Console.WriteLine("Enter the project description: ");
                        input = Console.ReadLine();
                        if (input == "<-") return null;
                        var projectDescription = input;
                        projects.Add(projectTitle, projectDescription);
                        return new Module(id, name, description, projects);
                    }
                    else if (input == "no")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ERROR\nWrong input!\nPlease, try again.\n");
                    }
                }
            }
        }

        public static Education DisplayAddEducationForm(string username)
        {
            string id = Tools.RandomString(5);
            string certification;
            string institution;

            string input = "";
            while (true)
            {
                Console.WriteLine(addEducationsTitle);
                Console.WriteLine("Enter the certification: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                certification = input;

                Console.WriteLine("Enter the institution: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                institution = input;

                Console.WriteLine("Enter the type of education(university or professional): ");
                input = Console.ReadLine();
                if (input == "<-")
                {
                    return null;
                }
                else if (input == "university")
                {
                    Dictionary<string, Module> modules = new Dictionary<string, Module>();
                    while (true) { 
                        Console.WriteLine("Do you want to add a module?(yes or no): ");
                        input = Console.ReadLine();
                        if (input == "<-")
                        {
                            return null;
                        }
                        else if (input == "yes")
                        {
                            Module newModule = DisplayAddModuleForm();
                            if (newModule != null) {
                                newModule.save();
                                modules.Add(newModule.id, newModule);
                            }
                        }
                        else if (input == "no")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ERROR\nWrong input!\nPlease, try again.\n");
                        }
                    }                    
                    return new University(id, institution, certification, modules, username);
                }
                else if (input == "professional")
                {
                    Console.WriteLine("Enter the description: ");
                    input = Console.ReadLine();
                    if (input == "<-") return null;
                    string description = input;
                    return new ProfTrain(id, institution, certification, description, username);
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                    continue;
                }
            }
        }

        private static void DisplaySkillsScreen()
        {
            string input = "";
            while (true)
            {
                Console.WriteLine(skillsTitle);
                Console.WriteLine("{0,20} {1,20} {2,20}", "Skill Id", "Skill Name", "Type");
                foreach (var skill in SelectedUser.skills.Values)
                {
                    Console.WriteLine("{0,20} {1,20} {2,20}", skill.id, skill.name, (skill.skillType == SkillType.technological) ? "Technological skill" : "Personal skill");
                }

                Console.WriteLine("Enter a command to proceed(e.g., add skill, <skill_id> or delete <skill_id> )");
                input = Console.ReadLine();
                //input = input.ToLower();
                if (input == "<-")
                {
                    break;
                }
                else if (input == "add skill")
                {
                    if (LoggedInStatus.loggedInAs != UserType.admin && LoggedInStatus.user.username != SelectedUser.username)
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        Skill newSkill = DisplayAddSkillForm(SelectedUser.username);
                        if (newSkill != null)
                        {
                            newSkill.save();
                            SelectedUser.skills.Add(newSkill.id, newSkill);
                        }
                    }

                }
                else if (input.StartsWith("delete "))
                {
                    var skillToDelete = input.Split(' ')[1];
                    if (!SelectedUser.skills.ContainsKey(skillToDelete))
                    {
                        Console.WriteLine($"ERROR\n{skillToDelete} does not exist!\nPlease, try again.");
                    }
                    else if (LoggedInStatus.loggedInAs != UserType.admin && !LoggedInStatus.user.educations.ContainsKey(skillToDelete))
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        SelectedUser.skills[skillToDelete].delete();
                        SelectedUser.skills.Remove(skillToDelete);
                    }
                }
                else if (!SelectedUser.skills.ContainsKey(input))
                {
                    Console.WriteLine($"ERROR\n{input} does not exist!\nPlease, try again.");
                }
                else
                {
                    DisplaySkillScreen(SelectedUser.skills[input]);
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        private static void DisplaySkillScreen(Skill skill)
        {
            string input = "";
            while (true)
            {
                Console.WriteLine("{0,20}", "Skill Id");
                Console.WriteLine("{0, 10}\n", skill.id);
                Console.WriteLine("{0,20} {1,20}", "Skill name", "Proficiency");
                Console.WriteLine("{0,20} {1,20}\n", skill.name, $"{ skill.proficiency * 100}%");
                Console.WriteLine("{0,20}", "Description");
                Console.WriteLine("{0, 100}\n\n", skill.description);
                Console.WriteLine("{0,20}", "Skill type");
                Console.WriteLine("{0,20}", (skill.skillType == SkillType.technological) ? "Technological skill" : "Personal skill");
                
                Console.WriteLine("Enter a command to proceed(e.g., edit name, edit description, etc...)");
                input = Console.ReadLine();
                //input = input.ToLower();
                if (input == "<-")
                {
                    break;
                }
                else if (input == "edit name")
                {
                    Console.Write("Enter the new name: ");
                    skill.name = Console.ReadLine();
                    skill.save();
                }
                else if (input == "edit proficiency")
                {
                    Console.Write("Enter the new proficiency: ");
                    skill.proficiency = float.Parse(Console.ReadLine());
                    skill.save();
                }
                else if (input == "edit type")
                {
                    Console.Write("Enter the new skill type(technological/personal): ");
                    input = Console.ReadLine();
                    if (input == "technological") {
                        skill.skillType = SkillType.technological;
                        skill.save();
                    }
                    else if (input == "personal")
                    {
                        skill.skillType = SkillType.personal;
                        skill.save();
                    }
                    else
                    {
                        Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                    }
                }
                else if (input == "edit description")
                {
                    Console.Write("Enter the new description: ");
                    skill.description = Console.ReadLine();
                    skill.save();
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }

        public static Skill DisplayAddSkillForm(string username)
        {
            string id = Tools.RandomString(5);
            string name;
            float proficiency;
            SkillType skillType;
            string description;

            string input = "";
            while (true)
            {
                Console.WriteLine(addSkillsTitle);
                Console.WriteLine("Enter the skill name: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                name = input;

                Console.WriteLine("Enter the level of proficiency in terms of percentage: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                proficiency = float.Parse(input)/100;

                Console.Write("Enter the skill type(technological/personal): ");
                input = Console.ReadLine();
                if (input == "technological")
                {
                    skillType = SkillType.technological;
                }
                else if (input == "personal")
                {
                    skillType = SkillType.personal;
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                    continue;
                }

                Console.WriteLine("Enter a description: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                description = input;

                break;
            }

            return new Skill(id, name, description, proficiency, skillType, username);
        }

        private static void DisplayContactScreen()
        {
            string input = "";
            while (true)
            {
                Console.WriteLine(contactTitle);

                Console.WriteLine("{0,-20}: {1,20}", "Email address", SelectedUser.contact.email);
                Console.WriteLine("{0,-20}: {1,20}", "Phone number", SelectedUser.contact.phoneNum);
                
                Console.WriteLine("Links");
                Console.WriteLine("{0,20} {1,20}", "Link title", "URL");
                foreach (var link in SelectedUser.contact.links)
                {
                    Console.WriteLine("{0,20} {1,20}", link.Key, link.Value);
                }

                Console.WriteLine("\n\nEnter a command to proceed(e.g., edit email address, edit link title/url <link_title>, add link, delete link <link_title>, etc...)");
                input = Console.ReadLine();
                if (input == "<-") break;
                //input = input.ToLower();
                if ((input.StartsWith("edit") || input.StartsWith("add") || input.StartsWith("delete")) && (LoggedInStatus.loggedInAs != UserType.admin || SelectedUser.username != LoggedInStatus.user.username))
                {
                    Console.WriteLine("ERROR\nUnauthorised action!\nPlease, try again.");
                }
                else if (input == "edit email address")
                {
                    Console.Write("Enter the new email address: ");
                    SelectedUser.contact.email = Console.ReadLine();
                    SelectedUser.contact.save();
                }
                else if (input == "edit phone number")
                {
                    Console.Write("Enter the new phone number: ");
                    SelectedUser.contact.phoneNum = Console.ReadLine();
                    SelectedUser.contact.save();
                }
                else if (input.StartsWith("edit link url "))
                {
                    var linkToEdit = input.Split(' ')[3];
                    if (!SelectedUser.contact.links.ContainsKey(linkToEdit))
                    {
                        Console.WriteLine($"ERROR\n{linkToEdit} does not exist!\nPlease, try again.");
                    }
                    else
                    {
                        Console.Write("Enter the new link url: ");
                        var url = Console.ReadLine();
                        SelectedUser.contact.editLink(linkToEdit, url);
                        SelectedUser.contact.save(); //By saving just one random link, the deletion also take effect in the database/file.
                    }
                }
                else if (input.StartsWith("edit link title "))
                {
                    var linkToEdit = input.Split(' ')[3];
                    if (!SelectedUser.contact.links.ContainsKey(linkToEdit))
                    {
                        Console.WriteLine($"ERROR\n{linkToEdit} does not exist!\nPlease, try again.");
                    }
                    else
                    {
                        Console.Write("Enter the new link title: ");
                        var newLinkTitle = Console.ReadLine();
                        var url = SelectedUser.contact.links[linkToEdit];
                        SelectedUser.contact.links.Remove(linkToEdit);
                        SelectedUser.contact.editLink(newLinkTitle, url);
                        SelectedUser.contact.save(); //By saving just one random link, the deletion also take effect in the database/file.
                    }
                } else if (input.StartsWith("add link"))
                {
                    Console.Write("Enter the new link title: ");
                    var newLinkTitle = Console.ReadLine();
                    Console.Write("Enter the new link url: ");
                    var newLinkUrl = Console.ReadLine();
                    SelectedUser.contact.editLink(newLinkTitle, newLinkUrl);
                    SelectedUser.contact.save();
                }
                else if (input.StartsWith("delete "))
                {
                    var linkToDelete = input.Split(' ')[1];
                    if (!SelectedUser.contact.links.ContainsKey(linkToDelete))
                    {
                        Console.WriteLine($"ERROR\n{linkToDelete} does not exist!\nPlease, try again.");
                    }
                    else
                    {
                        SelectedUser.contact.deleteLink(linkToDelete);
                        SelectedUser.contact.links.Remove(linkToDelete);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }
    }
}
