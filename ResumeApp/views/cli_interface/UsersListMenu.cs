using ResumeApp.model;
using ResumeApp.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeApp.views.cli_interface
{
    static class UsersListMenu
    {
        private static Dictionary<string, User> Users;
        private static string title = @"
___  ___                              __   _   _                        
|  \/  |                             / _| | | | |                       
| .  . |  ___  _ __   _   _    ___  | |_  | | | | ___   ___  _ __  ___  
| |\/| | / _ \| '_ \ | | | |  / _ \ |  _| | | | |/ __| / _ \| '__|/ __| 
| |  | ||  __/| | | || |_| | | (_) || |   | |_| |\__ \|  __/| |   \__ \ 
\_|  |_/ \___||_| |_| \__,_|  \___/ |_|    \___/ |___/ \___||_|   |___/ 
                                                                        
                                                                        
                            ";
        private static string typeSelectedUsername = "";
        private static State LoggedInStatus;

        public static void DisplayUsersListMenu(Dictionary<string, User> users, State state) {
            Users = users;
            LoggedInStatus = state;

            string input = "";
            Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");

            while (true) {
                Console.WriteLine(title);
                Console.WriteLine("{0,-10} {1,10} {2,10}\n", "Username", "First name", "Last name");
                foreach (var user in Users)
                {
                    Console.WriteLine("{0,-10} {1,10} {2,10}", user.Value.username, user.Value.firstName, user.Value.lastName);
                }

                Console.WriteLine("Enter a command to proceed(e.g., <username>, delete <username>, add user)");
                input = Console.ReadLine();
                if (input == "<-") {
                    break;
                } else if (input == "add user")
                {
                    if (LoggedInStatus.loggedInAs == UserType.admin)
                    {
                        var newUser = AddUserForm.DisplayAddUserForm(Users, LoggedInStatus);
                        if (newUser!=null) { 
                            Users.Add(newUser.username, newUser);
                            newUser.save();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ERROR\nUnauthorised action\n");
                    }
                } else if (input.StartsWith("delete ")) {
                    var usernameToDelete = input.Split(' ')[1];
                    if (!Users.ContainsKey(usernameToDelete))
                    {
                        Console.WriteLine($"ERROR\n{usernameToDelete} does not exist!\nPlease, try again.");
                    }
                    else if (LoggedInStatus.loggedInAs != UserType.admin || usernameToDelete != LoggedInStatus.user.username)
                    {
                        Console.WriteLine("ERROR\nUnauthorised action!\n");
                    }
                    else
                    {
                        Users.Remove(usernameToDelete);
                        (from user in Users.Values select user).First().save(); //By saving just one random user, the deletion also take effect in the database/file.
                    }
                }
                else if (!Users.ContainsKey(input))
                {
                    Console.WriteLine($"ERROR\n{input} does not exist!\nPlease, try again.");
                }
                else
                {
                    UserPage.DisplayUserPage(Users[input], LoggedInStatus);
                }
                Console.WriteLine("\nEnter \"<-\", at any point, to go back.\n");
            }
        }
    }
}
