using System;
using System.Collections.Generic;
using ResumeApp.model;

namespace ResumeApp.utils
{
    struct State
    {
        public User user;
        public UserType loggedInAs;

        public State(User user, UserType loggedInAs) { 
            this.user = user;
            this.loggedInAs = loggedInAs;
        }
    }
}
