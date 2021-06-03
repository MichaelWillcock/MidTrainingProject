### Disclaimer - This project was built for demonstration purposes only, as such none of the entered passwords are encrypted and thus stored as plain text. Do not enter sensitive information when using this application for any reason!
# MidTrainingProject
The project is to build a 3 tier application involving a database, business layer and gui.

## Sprint 1 - 11/05/2021

I started by creating the project backlog seen here
![StartofSprintOneish](https://user-images.githubusercontent.com/81698105/117843468-be171180-b276-11eb-96d4-ca00a9571b77.png)

#### Sprint Goals From Project Backlog
Epic - Create a framework for the application
User Story - As a creator I want to create a base framework for the application to use
- [x] 1.1 Given that I will need to see how the tables in the database interact with each other, when I got to create the database I will need to reference an entity relationship diagram.
- [x] 1.2 Given that I will need to create a database that'll need to be updated along the way, when I've finished my erd then I'll create a model first database for use in my application.
- [x] 1.3 Given I will need to have an understanding of my application, when I go to create the wpf gui application then I will need to have created wireframes to reference when creating my application.
- [x] 1.4 Given that I have created wireframes when I go to create the application I will need a base wpf file to use during the creation of the app.
- [x] 1.5 Given that I want my application to reference the database, when I have created the database and gui then I will need to create a business layer.
- [x] 1.6 Given that I want to test my applciation, when I have testable methods then I shall need a test file in which to write unit tests.

![BS1](https://user-images.githubusercontent.com/81698105/118703336-e621ea00-b80d-11eb-9937-d37fb7fdc963.png)
Here is my initial project board  with the usre stories for the first sprint in the sprint backlog.

#### Sprint Timeline
This was to gain an idea of all the work I would have to do in order to meet the projects definition of done, which was also detailed in the project backlog
(Insert screenshot of definition of done on kanban board)
Once this was completed I started working on setting up the framework that I would need later on in the project to create the application. This was detailed in the project backlog.
I started by creating the entity relationship diagram for my database

![InitialERD](https://user-images.githubusercontent.com/81698105/117853421-4f3eb600-b280-11eb-9006-da83696a6757.png)

I then used this to create by database using the code first approach so that I can update the database later on if needed.
I then moved on to creating wireframes to get a better idea of what I would be creating upon using wpf

![WireFrames](https://user-images.githubusercontent.com/81698105/117853453-582f8780-b280-11eb-9cb3-47ac73502dd9.png)

I then created a wpf project within my solution called DnDCharacterBuilderGUI to complete sprint goal 1.4
Finally I created a Business layer and test project to complete sprint goals 1.5 and 1.6

#### Retrospective
During this sprint I started well, the erd was fairly straightforward although did require some minor alterations after I started building the database in visual studio, this was to assign primary keys to the relevant tables otherwise I recieved syntax errors due to primary keys not being correctly allocated.
The wireframes also started well with the exception of the used character sheet wireframe which, because of the amount of data that needs to be added to the page during character creation slowed down the process, it would have been easier to just add a simple block and label it "D&D 5e character sheet".

The sprint goals for tomorrow are to focus on the user registration epic and code methods and create a gui so that a user can create an account that is then stored in the database.

![ES1BS2](https://user-images.githubusercontent.com/81698105/118703133-a8bd5c80-b80d-11eb-8828-c9f6106fbdc8.png)
This is a screenshot of my project board at the end of my first sprint. I decided to add the user stories I would aim to complete for the next day to the sprint backlog at the end of the sprint.

## Sprint 2 - 12/05/2021
User Story 1 - User and Login Registration System
As a user I want to be able to register an account if I do not have one and then log in.
#### Sprint Goals From Project Backlog
- [x] 1.1 Given a user does not have an account and wants to log in, when they click on log in and do not have a user name, then they are taken to the registration page and asked to create an account.
- [x] 1.2 Given a user has an account and wants to log in, when they enter their details and click log in, then they will be taken to main page and greeted with a list of their characters.
- [x] 1.3 Given a user has an account and wants to log in and enters the wrong password, when they click log in, they will be greeted with an error message informing them that they entered the wrong password and asking them to try again.

#### Sprint Timeline
Once the main user stories were started upon, the work progressed smoothly. The basic functionality of the applciation can be seen in the following scrrenshots.

![ApplicationHome](https://user-images.githubusercontent.com/81698105/118011885-677a0800-b348-11eb-8ad3-15a9e129e7ec.png)

![NoName](https://user-images.githubusercontent.com/81698105/118011908-6e087f80-b348-11eb-9d85-e0241c67a419.png)

![Register](https://user-images.githubusercontent.com/81698105/118011933-73fe6080-b348-11eb-9655-93726c412836.png)

![PasswordCheck](https://user-images.githubusercontent.com/81698105/118011946-7791e780-b348-11eb-8fc4-24c6c6efa65f.png)

![UserInterface](https://user-images.githubusercontent.com/81698105/118011960-7b256e80-b348-11eb-8943-7f6eb36cad1e.png)

#### Sprint Retrospective
I had to reset the database at the start in order to change the primary keys of the tables to int values instead of strings so that they could be automatically incremeneted when a new account is made. I want to just alter the property but it required me to drop the column which given that they were the primary key, wouldn't work. This meant I had to delete and the recreate the entire database, which thanks to copypaste didn't take as long as in the first sprint but it was still time.
The next delay was when I tried to add background music to the application. I spent an hour or so on this with no real progress and it wasn't part of the official sprint goals so I left it to focus on the main project outcomes.
Learning how to use the pages for naigation was interesting and for the time being it appears to work well for the aims of the project. The creation of the registration system progressed smoothly and leaves room for extension if needed later on in the project. There was one minor hiccup with one of the if statements, but I quickly found the error after debugging through the code and resolved the issue.

#### Work left to do after standup
- [ ] create unit tests for methods written for registration system. Note. Methods were all manually tested during creation so should pass with minimal alterations.

Work for tomorrow's sprint will involve creating the user interface gui and character viewing platforms. As well as creating unit tests for any methods created to implement the functionality described in the project backlog.

![ES2BS3](https://user-images.githubusercontent.com/81698105/118703452-03ef4f00-b80e-11eb-882f-ec73e28bbf2a.png)
Here is a screen shot pf my project board at the end of the second sprint. The items in the sprint backlog are for sprint 3.

## Sprint 3 13/05/2021
Epic 1 - User home page  - User Story 1 - User Settings
As a user I want to be able to change my username and password should I wish
#### Sprint goals from project backlog
- [x] 1.1 Given a user has successfully logged in, when the homepage loads, then they should be shown a list of their current created characters and see a create new character option and see a user settings option.
- [x] 1.2 Given that a user wants to change their user name or password, when they click on the user settings option they will be taken to a separate page with buttons to change or reset their username/password
- [x] 1.3 Given that a user wants to change their password, when they enter their new password and confirm it, then the data base is updated with their new password details
- [x] 1.4 Given that a user wants to change their user name, when they enter their new user name and confirm it, then the data base is user name with their new user name details.
#### Sprint Timeline

![BlankLogInTable](https://user-images.githubusercontent.com/81698105/118167918-26a0f280-b41f-11eb-8f4b-2100f38c4159.png)

The following screenshot demonstrates the initial functionality to ensure the user can only access their data and no one elses, I initially tried to pass the user name inputted from the login screen across the pages into a string on the homepage page but after 2 hours of work that proved a dead end, so instead I created another table that contains one row, the logged in user, this table displays their userID, username and password. All of the remaining derivations will use the userID from this table to ensure individual users data can be kept separate.

![LoginUpdate](https://user-images.githubusercontent.com/81698105/118168320-9f07b380-b41f-11eb-998f-c5cc5bb8f17d.png)

This screenshot just shows the updated login table, with the single loaded row, giving the user details of the logged in user. One can also see the welcome message at the top that personalises to the users username.

![UserSettings](https://user-images.githubusercontent.com/81698105/118168552-e130f500-b41f-11eb-89e6-f7b0e5dc1ce6.png)

The creation of the user settings page completes sprint goal 1.2 and begins to demonstrate the functionality needed to complete sprint goals 1.3 & 1.4. Here one can enter a different user name and password and after clicking the respective buttons the corresponding data will be updated in the database as seen in the following screenshots.

![UpdatedUsername](https://user-images.githubusercontent.com/81698105/118168845-33721600-b420-11eb-8d90-c3c293963562.png)

![UpdatedPassword](https://user-images.githubusercontent.com/81698105/118168863-379e3380-b420-11eb-8439-04b142bae2e3.png)


#### Sprint Retrospective
The hardest part today was maintaining perseverance whilst trying to carry data from one page to anyother so that the application would recognise which user had logged in and only edit their data and allow them access to their characters. The presented a significant challenge both when I initially tried to use the navigation keyword to pass the data to a new page and then attempted to use databinding to add the data to the format of the homepage.

After 2 hours of multiple methods non of which worked I came up with a work around by which I created another database that imports the row of the user who has logged in, when the user logs out manually or restarts the applciation the database is cleared leaving it blank for the next user. I also got around the databinding by jsut setting the text content during the pages initialisation. Due to the longer amount of time needed than thought to set the data unique to the logged in user, I have yet to add the listbox to the homepage or create unit tests for any of the methods created so far, these will be done after the review and tomorrow.

#### Post Review Work
Created unit tests for all of the methods used in the UserManager and LoginManager classes. The Password changed test revealed a failing in the database based around the accidental inclusion of an Id column alongside a userID column. The database was reset with the Id column removed meaning that the userID column is now the primary key of the users table as originally intended and all of the unit tests pass as see below.

![Unittests](https://user-images.githubusercontent.com/81698105/118191224-2d8a2e00-b43c-11eb-89d1-dd2a70448ffd.png)

![ES3BS4](https://user-images.githubusercontent.com/81698105/118703575-2c774900-b80e-11eb-9973-2a12f71800ec.png)
Here is my project board at the end of the sprint demonstrating what sprints I completed and showing the sprint backlog loaded with user stories ready for my 4th sprint.

## Sprint 4 - 14/05/2021
### Work from Sprint 3
Epic 1 - User home page  - User Story 1 - User Settings
As a user I want to be able to change my username and password should I wish
#### Sprint goals from project backlog
- [x] 1.1 Given a user has successfully logged in, when the homepage loads, then they should be shown a list of their current created characters and see a create new character option and see a user settings option.
### Sprint 4 goals from project backlog
Epic 1 - User home page  - User Story 2 - new and current characters
As a user I want to be able to view, create, edit and delete my current characters.
- [x] 2.1 Given that a user wants to create a new character, when they click on the create character button, a new window will open, with a blank character sheet.
- [x] 2.2 Given that a user wants to view a current character, when they click on the character in the list, then it will open up a new window showing the selected character.
- [x] 2.3 Given that a user wants to delete a current character when they select the character and click delete then the character will be deleted after a confirmation message is displayed.
Epic 2 - Creating a Character - User story 3 - Choosing a Class
As a user I want to be able to choose my characters class from a descriptive selection
- [x] 3.1 Given that a user wants to select their characters class, when they click on "classes" then a list of classes will appear for selection.
- [x] 3.2 Given that a user has decided what class they want , when they select it, then the class is selected.
Epic 2 - Creating a Character - User story 2 - Choosing a race
As a user I want to be able to choose my characters race from a selection.
- [x] 2.1 Given that a user wants to select their characters race, when they select the race they want their character to have, then that race is selected.
- [x] 2.2 Given that a user has decided what race they want and have selected it, when they click "Add Character", then the race is added to their character sheet along with the abilities and their ability scores are updated.

#### Sprint Timeline
![Homepage](https://user-images.githubusercontent.com/81698105/118544123-1c4b6500-b74d-11eb-8caf-1c6c87368101.png)

![AddCharacter](https://user-images.githubusercontent.com/81698105/118544132-1eadbf00-b74d-11eb-9af7-a75427a3cd9a.png)

![Choose Race](https://user-images.githubusercontent.com/81698105/118547792-72220c00-b751-11eb-857a-dfe6f2ce3e1e.png)

![Choose Class](https://user-images.githubusercontent.com/81698105/118547809-764e2980-b751-11eb-9201-c05367cf5b95.png)

![RemoveCharacter](https://user-images.githubusercontent.com/81698105/118544138-22414600-b74d-11eb-83de-24e06fd23bc3.png)

#### Sprint Retrospective
Once I had worked out how to make it so that only the characters of a selected user were selected in the previous sprint the major challenge of this sprint was learning how to use the full selection functionality of list boxes so that I sould select characters to view them or delete them. Once this was done I was fairly comfortable coding the methods to open new character windows and delete select characters from the database.

![ES4BS5](https://user-images.githubusercontent.com/81698105/118703727-54ff4300-b80e-11eb-97a2-7842f1f42221.png)
Here is my project board at the end of the sprint demonstrating what sprints I completed and showing the sprint backlog loaded with user stories ready for my 5th sprint.

## Sprint 5 - 15/05/2021
#### Sprint goals from project backlog
Epic 2 - Creating a Character - User story 1 - Generating stats
As a user I want to be able to generate my characters 6 core ability scores
 - [x] 1.1 Given that a user wishes to generate a score when they click roll stat then a stat should be randomly determined and added to a list for reference.
 - [x] 1.2 Given that a user has rolled their stats and they want to compare them to the average, when they click compare, then a dialogue box should come up comparing their stats to the standard set and advising on them whether or not they should switch.
 - [x] 1.3 Given that the user has rolled less than average and want to switch, when they click on "use average stats" then their rolled list is dumped and replaced with the average set.
 - [x] 1.4 Given that the user has an array of stats and wishes to assign them to their character, when they select "assign stat to *ability*" then the stat is assigned to the selected ability score.

#### Sprint Timeline
![StatGenWindow](https://user-images.githubusercontent.com/81698105/118544408-44d35f00-b74d-11eb-82b6-6d5a06f4641c.png)

![RolledScoresButSwitched](https://user-images.githubusercontent.com/81698105/118544416-47ce4f80-b74d-11eb-938d-dbf17338f8f4.png)

![SelectingAlternativeScores](https://user-images.githubusercontent.com/81698105/118544419-49981300-b74d-11eb-88d5-ba7bf5d5b058.png)

![NewCharWithStats](https://user-images.githubusercontent.com/81698105/118544427-4ac94000-b74d-11eb-82fd-dee55f850873.png)

#### Sprint Retrospective
Sprint 5 initially went well. The races that did not have to select which ability scores they needed to increase were easily computed into a method that added the modifiers to the stats. I encountered a significant number of bugs when trying to select which ability scores a Half Elf or Human variant could select to increase however these were not difficult to fix, just numerous and through constant use of the debugger I was able to get the code working.

![ES5BS6](https://user-images.githubusercontent.com/81698105/118703833-6e07f400-b80e-11eb-80ea-1d928d45b911.png)
Here is my project board at the end of the sprint demonstrating what sprints I completed and showing the sprint backlog loaded with user stories ready for my 6th sprint.

## Sprint 6 - 16/05/2021
#### Sprint goals from project backlog
Epic 3 - Using a Character - User story 1 - Viewing abilities
As a user once my character is fully created I want to be able to view its abilities in greater detail to get a better understanding of what they can do.
- [ ] 1.1 Given my character is fully created and that I want to see what abilities I have, when I click on my ability names then a dialogue box should open explaining in greater detail what they do.
#### Sprint Timeline
![ShowsGennedStats](https://user-images.githubusercontent.com/81698105/118545699-dabbb980-b74e-11eb-8507-9f2eac8fd502.png)
#### Sprint Retrospective
Sprint 6 went smoothly, with little bugs. I had a good idea in my head of what I wanted the character page to look like and so it was relatively simple to implement everything.

The issues that occured were due to the rounding errors caused by rounding negative integers when an ability score turned out to be less than 10, these were switftly resolved when I altered the modifier method to work better for negative numbers.

![ES6BS7](https://user-images.githubusercontent.com/81698105/118703884-78c28900-b80e-11eb-99ea-675ed5bab438.png)
Here is my project board at the end of the sprint demonstrating what sprints I completed and showing the sprint backlog loaded with user stories ready for my 7th sprint.

## Sprint 7 - 17/05/2021
#### Sprint goals from project backlog
Epic 3 Using a Character - User story 4 - editing hit points
As a user, when my character takes damage or is healed I want to be able to adjust its hit points accordingly
- [x] 4.1 Given that my character has taken damage/is healed and I want to adjust its hit points, when I select its hit points in the text box and edit the value then the new value should be saved to the sheet.
Epic 3 Using a Character - User story 5 - Leveling up
As a user I want to be able to level up my character 
- [x] 5.1 Given that I want to level up my character, when I click "set level" then then new hit points and abilities will be added to the character.
#### Sprint Timeline

![Level 1 example](https://user-images.githubusercontent.com/81698105/118549977-1b6a0180-b754-11eb-9c9b-25c26057b21c.png)

![Level2 example](https://user-images.githubusercontent.com/81698105/118549995-21f87900-b754-11eb-8bf3-856b6e8cf952.png)

![DatabaseClassDiagram](https://user-images.githubusercontent.com/81698105/118708193-554e0d00-b813-11eb-99e3-7ec2ce62d4ac.png)
Here is the class diagram of the database, it is different from the initial ERD but thankfully I used the method first approach which meant I could easily update the database as needed when new tables and/or variables were required by the data.

![UnitTests](https://user-images.githubusercontent.com/81698105/118708313-7adb1680-b813-11eb-9998-a6344bbecbc8.png)
Here is a screenshot of all of the unit tests for the project. There should technically be more as the DetailManagerTests should test every race and class combo to fully test the entire functionality of the app. However, with 15 race options and 12 class options and 4 tests for each combination, there wasn't time to write 720 units to test all of those so I wrote out the tests for once specific race class combo and as the code is identical for all of the options, the tests should all pass any way.

#### Sprint Retrospective
The level up feature and hit point tracker progressed much smoother than I anticipated. Granted it only loads in the ability names and one can only advance a character one level but none the less I was very happy with the work I managed to complete today. With the level up feature being implemented my project now meets its definition of done as described in the project notes. Some user stories remain but due to a poor wording of the definition of done on my part they actually are required to be completed in order for the project to be considered done. The remaining user stories would add even more extensive customisation the the characters, allowing a player to select skills, features, equipment and a background and then use their character interactively with whilst playing a dnd 5e game. This would require significantly more time to be implemented however and due to me overestimating the scope of the project I barely managed to get everything done as it is, so I shall work on these features in my spare time in order to truly finish the project.
![ES7](https://user-images.githubusercontent.com/81698105/118703932-8415b480-b80e-11eb-8b83-060fdbe9824b.png)
Here is my project board at the end of the project.

#### Project Retrospective
As stated previously I very much overestimated the scope of this project when I started. Thankfully, I had chosen a subject that combines my two main hobbies of coding and DnD so despite me putting in long hours every day (often I was coding until 11pm) I did not lose interest in the project nor lose focus over the course of the project. In the future I will aim to better estimate the scope of my project and better suit it to the project specifications so that I will not have as much work to do.

In the future there are huge areas of this project that are available for extension. Completing the remaining user stories to add backgrounds and equipment would be the first port of call along with adding some background music for added immersion. Following that I would start to work on making the sheet fully interactive so that could play the character instead of just observing it. After that there are options to add the rules for magic and subclasses into the app which would further increase its usability. Penultimately, I would add a tutorial option to the character creation feature so that someone who has never played the game before could generate a character. Finally I would learn how to add internet functionality so that multiple users at once could use the app and that a local instance of the app is unecessary so that everything could be used online.

A failing of the code in this project is that to understand some of the functionality, one has to have a basic understanding of the rules of dnd 5e, for this reason I will include a link in pmy project set up, as this is a public repo so in the even that a programmer who has never encountered the game wishes to use it they will be able to understand the full functionality of the app.

### Project Set-up
1. Clone Git Repository to your designated folder.
2. Open the solution in visual studio, ensuring that DnDCharacterBuilderBusiness, DnDCharacterBuilderData and DnDCharacterBuilderGUI projects are present.
3. right click on DnDCharacterBuilderData and set it as start up project.
4. go to the search bar at the top of visual studio and search for sql server object explorer. Open sql server object explorer, create a new database, right click on the created database and select properties.
5. copy the connection string from properties into the DnDCharacterBuilderContext class located in the DnDCharacterBuilderData project, use comment for direction.
6. Uncomment database additions located in program.cs of DnDCharacterBuilderData project and run to populate races and classes into database.
7. navigate to the nuget package console manager and type in "Add-Migration InitialMigration", ensure console is set to DnDCharacterBuilderData and not the GUI then press enter
8. Once the migration is added type in "Update-Database" and press enter.
9. go to the program.cs file located in DnDCharacterBuilderData project and uncomment all lines inside the using statement including the db.SaveChanges() line (These should be lines 12 to 40). Then run the program. This adds the race and class data to the database. Close the console box when it has finished running.
10. right click on DnDCharacterBuilderGUI and set it as start up project.
11. Run project and use application.
12. Some of this code is specifically tailored to the rules of dnd 5e so if any of the code appears arbitrary, it is unlikely to be. The basic rules of the game can be found at the following url - https://dnd.wizards.com/articles/features/basicrules
