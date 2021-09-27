JAP_Task_1_API
This is a .NET Core Web API project made for the purposes of completing first task of JAP. The idea was to make a small and simple web app similar to IMDB.com but much much more simple and rudimentary.

You can find the Angular project on this link: https://github.com/mehmedca/JAP-Task-1-WEB


Some of the guidelines in order to start up the project below:
PostgreSQL was used as a DB provider. So, after the initial clone of the project, make sure to adjust the connection string which is located in appsettings.json file, then run "update-database" in npm console in order to create a new db on your machine. Test data should be seeded to your db automatically.
Startup the app, you should see swagger running on localhost:25398, you can test the endpoints straight from there. Authentication is implemented on swagger as well, and most of the endpoints are protected so you need to authenticate using /auth/login then paste the JWT token which you'll receive as a response. You can also register using /auth/register endpoint.
Credentials:
admin - P4$$word

moderator - P4$$word

user - P4$$word


After you clone the Angular app, you should do the following:

Run npm install
Check if the baseUrl in environment variable matches the url of the started API project
Run ng serve and check out the app :)
