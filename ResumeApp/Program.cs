using ResumeApp.model;
using System;
using System.Collections.Generic;
using ResumeApp.views.cli_interface;

namespace ResumeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var protoAdmin = new User("ProtoAdmin", "Proto", "Admin", UserType.admin, "ProtoAdmin", "NAN", new Dictionary<string, Experience>(), new Dictionary<string, Education>(), new Dictionary<string, Skill>(), new Contact("NAN", "NAN", new Dictionary<string, string>(), "ProtoAdmin"));
            protoAdmin.save();

            LoginForm.DisplayLoginForm();
        }
    }
}
