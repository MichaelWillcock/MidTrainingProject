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

## Sprint 3 13/05/2021
Epic 1 - User home page  - User Story 1 - User Settings
As a user I want to be able to change my username and password should I wish
#### Sprint goals from project backlog
- [ ] 1.1 Given a user has successfully logged in, when the homepage loads, then they should be shown a list of their current created characters and see a create new character option and see a user settings option.
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
