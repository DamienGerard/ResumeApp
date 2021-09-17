using ResumeApp.model;
using System;
using System.Collections.Generic;
using ResumeApp.utils;

namespace ResumeApp.views.cli_interface
{
    static class  LoginForm
    {
        private static string title = @"
                             _                 _       
                            | |               (_)      
                            | |     ___   __ _ _ _ __  
                            | |    / _ \ / _` | | '_ \ 
                            | |___| (_) | (_| | | | | |
                            \_____/\___/ \__, |_|_| |_|
                                          __/ |        
                                         |___/         
                            ";
        private static string enterYourUsername = @"";
        private static string enterYourPassword = @"";
        private static string loginAsGuest = @"";
        private static string loginAsAdmin = @"";
        private static string goBack = @"";
        public static string username { get; set; }
        private static string password { get; set; }
        private static Dictionary<string, User> users;

        public static void DisplayLoginForm()
        {
            users = User.fetchAll();
            //Console.Title = "ASCII Art";
            string input = "";
            Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            while (true) { 
                Console.WriteLine(title);
                Console.WriteLine(enterYourUsername);
                input = Console.ReadLine();
                if (input == "<-") break;
                username = input;

                Console.WriteLine(enterYourPassword);
                input = Console.ReadLine();
                if (input == "<-") break;
                password = input;

                if (!users.ContainsKey(username))
                {
                    Console.WriteLine("ERROR\nUsername does not exist!\nPlease, try again.");
                }
                else if (users[username].password != password)
                {
                    Console.WriteLine("ERROR\nUsername does not exist!\nPlease, try again.");
                }
                else
                {
                    Console.WriteLine("To log in as \"Admin\", enter \"1\"");
                    Console.WriteLine("To log in as \"Guest\", enter \"2\"");
                    input = Console.ReadLine();
                    if (input == "<-") break;
                    if (input != "1" || input != "2")
                    {
                        Console.WriteLine("ERROR\nWrong input!\nPlease, try again.");
                    }
                    else {
                        if (input == "1" && users[username].usertype != UserType.admin)
                        {
                            Console.WriteLine($"ERROR\n{username} cannot log in as an Admin!\nPlease, try again.");
                        }
                        else {
                            UsersListMenu.DisplayUsersListMenu(users, new State(users[username], users[username].usertype));
                        }
                    }
                        
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }
    }
}
