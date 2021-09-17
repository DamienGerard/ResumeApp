# ResumeApp

## Introduction

> This is a simple CRUD cli-app in C#. This project was done as an exercise to familiarise myself with C#.
> This application allows users to create, read, update and delete their resume/CV. There are 2 type of users: admin and simple. Admins can create/delete users and has write priviledges on the resume of every users while simple users only has write priviledges on there own resume but can read other users' resume.

## How to use

>The application starts on a Login form. The user must enter their username and password. For testing purpose the username: ProtoAdmin and its password: ProtoAdmin were hardcoded(those interested in running the app can use these credentials as it was not removed,even though it should be). 
>After the entry of correct credential, the user will be prompted to enter: 1 or 2, to login as either admin or simple user. Simple users can only log in as simple uer but admins can log in both ways. however, if admin log in as simple user, they do not get admin priviledge.

>The user will then land of the "Menu of Users" which will list all users. The following details the various commands avaible on the screens/views/forms as the navigate through the app(Note: this may not be an exhaustive list).
>> ### Global Commands
>> <- -> To go back to the previous page/screen/view/form(similar to a pop on a stack).
>> ### Menu of Users
>> add user -> Lead to the "Add user" form, to create new user.
>> delete user <user_id> -> delete the specified user from the database.
>> <user_id> -> Lead to the "User page" form, to read the resume of the selected user in.

>> ### User Page
>> edit first name -> To change the first name of the selected user.
>> edit last name -> To change the last name of the selected user.
>> edit description -> To change the description of the selected user.
>> experiences -> Lead to the "Experiences" submenu, which list all the experiences of the selected user.
>> education -> Lead to the "Educations" submenu, which list all the educations of the selected user.
>> skills -> Lead to the "Skils" submenu, which list all the skills of the selected user.
>> contact -> Lead to the "Contact" submenu, which display the contact of the selected user.

>> ### Experiences
>> add experience -> To add a new experience.
>> delete <experience_id> -> To delete the specified experience.
>> <experience_id> -> To select the specified experience and display in further details in a new page and possible edit it.

>> ### Educations
>> add education -> To add a new education.
>> delete <education_id> -> To delete the specified education.
>> <experience_id> -> To select the specified education and display in further details in a new page and possible edit it.

>> ### Skills
>> add skill -> To add a new skill.
>> delete <skill_id> -> To delete the specified skill.
>> <skill_id> -> To select the specified skill and display in further details in a new page and possible edit it.

>> ### Contact
>> edit email address -> To edit the email address of the selected user.
>> edit phone number -> To edit the phone number of the selected user.
>> add link -> To add of new link to the contact of the selected user.
>> delete link <link_title> -> To delete the specified link.
>> edit link title <link_title> -> To edit the title of the specified link.
>> edit link url <link_title> -> To edit the URL of the specified link.

## Installation

> Download/Git Pull the repository and run the program.cs file. There is no dependencies...
