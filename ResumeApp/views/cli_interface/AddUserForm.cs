using ResumeApp.model;
using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeApp.views.cli_interface
{
    static class AddUserForm
    {
        private static State LoggedInStatus;
        private static string title = @"";

        public static User DisplayAddUserForm(Dictionary<string, User> users, State status) {
            LoggedInStatus = status;
            UserPage.LoggedInStatus = LoggedInStatus;
            string username;
            string firstName;
            string lastName;
            UserType usertype;
            string password;
            string description;
            var experiences = new Dictionary<string, Experience>();
            var educations = new Dictionary<string, Education>();
            var skills = new Dictionary<string, Skill>();
            Contact contact;

            string input = "";
            while (true)
            {
                Console.WriteLine("ADD USER\n");
                Console.WriteLine("Enter a new username: ");
                input = Console.ReadLine();
                if (input == "<-")
                {
                    return null;
                }
                else if (users.ContainsKey(input))
                {
                    Console.WriteLine("ERROR\nUsername already exist!\nPlease, try again.\n");
                    continue;
                }

                username = input;

                Console.WriteLine("Enter the user's first name: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                firstName = input;

                Console.WriteLine("Enter the user's last name: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                lastName = input;

                Console.WriteLine("Enter the user's password: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                password = input;

                Console.WriteLine("Enter the user's description: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                description = input;

                Console.WriteLine("Enter the type of te user(admin/simple): ");
                input = Console.ReadLine();
                if (input == "<-")
                {
                    return null;
                }
                else if (input=="admin") 
                {
                    usertype = UserType.admin;
                }else if (input == "simple")
                {
                    usertype = UserType.simple;
                }
                else
                {
                    Console.WriteLine("ERROR\nWrong input!\nPlease, try again.\n");
                    continue;
                }

                contact = DisplayAddContactForm(username);

                while (true)
                {
                    Console.WriteLine("Do you want to add an experience?(yes or no): ");
                    input = Console.ReadLine();
                    if (input == "<-")
                    {
                        return null;
                    }
                    else if (input == "yes")
                    {

                        var newExperience = UserPage.DisplayAddExperienceForm(username);
                        experiences.Add(newExperience.id, newExperience);
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

                while (true)
                {
                    Console.WriteLine("Do you want to add an education?(yes or no): ");
                    input = Console.ReadLine();
                    if (input == "<-")
                    {
                        return null;
                    }
                    else if (input == "yes")
                    {
                        var newEducation = UserPage.DisplayAddEducationForm(username);
                        if (newEducation!=null) { 
                            educations.Add(newEducation.id, newEducation);
                            if (newEducation.educationType == EducationType.university) {
                                ((University)newEducation).save();
                            }else if (newEducation.educationType == EducationType.professional)
                            {
                                ((ProfTrain)newEducation).save();
                            }
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

                while (true)
                {
                    Console.WriteLine("Do you want to add a skill?(yes or no): ");
                    input = Console.ReadLine();
                    if (input == "<-")
                    {
                        return null;
                    }
                    else if (input == "yes")
                    {
                        var newSkill = UserPage.DisplayAddSkillForm(username);
                        skills.Add(newSkill.id, newSkill);
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
                break;
            }
            return new User(username, firstName, lastName, usertype, password, description, experiences, educations, skills, contact);
        }

        private static Contact DisplayAddContactForm(string username)
        {
            string email;
            string phoneNumber;
            var links = new Dictionary<string, string>();


            string input = "";
            while (true)
            {
                Console.WriteLine("ADD Contact\n");
                Console.WriteLine("Enter email address: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                email = input;

                Console.WriteLine("Enter phone number: ");
                input = Console.ReadLine();
                if (input == "<-") return null;
                phoneNumber = input;

                while (true)
                {
                    Console.WriteLine("Do you want to add a links?(yes or no): ");
                    input = Console.ReadLine();
                    if (input == "<-")
                    {
                        return null;
                    }
                    else if (input == "yes")
                    {
                        Console.WriteLine("Enter the link title(e.g., Github, linkedIn, etc...): ");
                        input = Console.ReadLine();
                        if (input == "<-") return null;
                        var linkTitle = input;
                        Console.WriteLine("Enter the link url: ");
                        input = Console.ReadLine();
                        if (input == "<-") return null;
                        var linkUrl = input;
                        links.Add(linkTitle, linkUrl);
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
                break;
            }
            return new Contact(email, phoneNumber, links, username);
        }
    }
}
