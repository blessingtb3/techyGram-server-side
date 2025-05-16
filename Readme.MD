# Steps to create a RESTFUL API using .NET Core, Entity Framework Core and SQLite for local storage

# Prerequisites

Install .NET SDK: Make sure you have the .NET SDK installed on your machine. You can download it from the .NET official website.

IDE: You can use Visual Studio, Visual Studio Code, or any other text editor of your choice.

# Step 1: Create a New ASP.NET Core Web API Project

Open your terminal or command prompt and run the following command: dotnet new webapi -n myApiName
This command creates a new directory called MyApi with a basic Web API project structure.

# Step 2: Add Entity Framework Core and SQLite Packages

Navigate to your project directory:
cd MyApi

Now, add the necessary NuGet packages for Entity Framework Core and SQLite:
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Step 3: Create your Model(s)

Create a new folder called 'Users' and add a class for your data model. For example, let's create a simple User model.

Create a file named Users.cs in the Models folder:

# Step 4: Create a Database Context

Create a folder called Data and add a new class called AppDbContext.cs:

# Step 5: Configure the Database Context

Open Startup.cs and add the following using directive at the top: using MyApi.Data;
In the ConfigureServices method, add the DbContext to the service container:

# Step 6: Create a Controller

Create a folder called Controllers and add a new controller named User.cs:

# Step 7: Create the Database

To create the SQLite database, you need to add a migration and update the database. Run the following commands in your terminal:
dotnet ef migrations add InitialCreate
dotnet ef database update

# Step 8: Run the API

You can now run your API: dotnet run
Your API should be running at http://localhost:5000/api/users.

# More info

# Testing the API

# You can use tools like Postman or cURL to test the API endpoints:

# User Stories Endpoints

# Get All User Stories

# Method: GET

Endpoint: /api/v1/userstories
Description: Retrieves a list of all user stories.

# Get User Story by ID

Method: GET
Endpoint: /api/v1/userstories/{id}
Description: Retrieves a specific user story by its ID.

# Create a New User Story

Method: POST
Endpoint: /api/v1/userstories
Description: Creates a new user story.
Request Body:
json

{
"firstName": "string",
"profileImage": "string"
}

# Update an Existing User Story

Method: PUT
Endpoint: /api/v1/userstories/{id}
Description: Updates an existing user story by its ID.
Request Body:
json

{
"id": 1,
"firstName": "string",
"profileImage": "string"
}

# Delete a User Story

Method: DELETE
Endpoint: /api/v1/userstories/{id}
Description: Deletes a specific user story by its ID.

# User Posts Endpoints

# 1. Get All User Posts

Method: GET
Endpoint: /api/v1/userposts
Description: Retrieves a list of all user posts.

# 2. Get User Post by ID

Method: GET
Endpoint: /api/v1/userposts/{id}
Description: Retrieves a specific user post by its ID.

# 3. Create a New User Post

Method: POST
Endpoint: /api/v1/userposts
Description: Creates a new user post.
Request Body:
json

{
"firstName": "string",
"lastName": "string",
"location": "string",
"likes": 0,
"comments": 0,
"bookmarks": 0,
"image": "string",
"profileImage": "string"
}

# 4. Update an Existing User Post

Method: PUT
Endpoint: /api/v1/userposts/{id}
Description: Updates an existing user post by its ID.
Request Body:
json

{
"id": 1,
"firstName": "string",
"lastName": "string",
"location": "string",
"likes": 0,
"comments": 0,
"bookmarks": 0,
"image": "string",
"profileImage": "string"
}

# 5. Delete a User Post

Method: DELETE
Endpoint: /api/v1/userposts/{id}
Description: Deletes a specific user post by its ID.

# Summary of (CRUD)Endpoints

Method Endpoint Description
GET /api/v1/userstories Get all user stories
GET /api/v1/userstories/{id} Get user story by ID
POST /api/v1/userstories Create a new user story
PUT /api/v1/userstories/{id} Update an existing user story
DELETE /api/v1/userstories/{id} Delete a user story
GET /api/v1/userposts Get all user posts
GET /api/v1/userposts/{id} Get user post by ID
POST /api/v1/userposts Create a new user post
PUT /api/v1/userposts/{id} Update an existing user post
DELETE /api/v1/userposts/{id} Delete a user post

These endpoints will allow you to perform CRUD operations on user stories and user posts in your ASP.NET Core Web API. You can test these endpoints using tools like Postman or cURL.

# Project structure

GramAPI/
│
├── Controllers/
│ └── v1/
│ ├── UserPostsController.cs
│ └── UserStoriesController.cs
│
├── Data/
│ └── AppDbContext.cs
│
├── Models/
│ ├── UserPost.cs
│ └── UserStory.cs
│
├── Migrations/ // This folder will be created after running migrations
│ └── ...
│
├── Properties/
│ └── launchSettings.json
│
├── appsettings.json
│
├── GramApi.csproj
│
└── Startup.cs
Explanation of the Structure:
Controllers/: This folder contains all the controllers for your API. Each controller handles requests for a specific resource (e.g., products, user posts, user stories).
Data/: This folder contains the AppDbContext.cs file, which is responsible for interacting with the database.
Models/: This folder contains all the model classes that represent the data structures used in your application (e.g., UserPost, UserStory).
Migrations/: This folder will be created automatically when you run the migrations command. It contains the migration files that track changes to your database schema.
Properties/: This folder contains project properties, including the launchSettings.json file, which is used to configure how the application is launched.
appsettings.json: This file is used to store configuration settings for your application, such as connection strings and other settings.
MyApi.csproj: This is the project file for your ASP.NET Core application, which contains information about dependencies and project configuration.
Startup.cs: This file configures services and the application's request pipeline.
Additional Notes
Make sure to run the commands to create migrations and update the database after defining your models and context.
The folder and file names are case-sensitive on some operating systems, so be mindful of that when creating files and folders.
This structure will help you keep your project organized and maintainable as you continue to develop your API.

# Conclusion

You have now built a simple RESTful API using .NET Core, Entity Framework Core, and SQLite. You can expand on this by adding more features, such as authentication, logging, or more complex business logic as needed.
