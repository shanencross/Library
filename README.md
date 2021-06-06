# Library

#### Learning project for Epicodus course for database practice with many-to-many relationships with authentication

#### By Shanen Cross and Salim Mayan

## Technologies Used

* C#
* .NET 5 SDK
* ASP.NET Core MVC
* Entity Framework Core
* MySQL
* HTML
* CSS
* Bootstrap

## Description

A Learning projecting for Epicodus class. Purpose is to practice using databases with ASP.NET Core MVC and Entity Framework Core. Uses a many-to-many database relationship and authentication.

## Setup/Installation Requirements

### Installing Prerequisites
* Install git
* Install the [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* Install [MySQL](https://dev.mysql.com/downloads/mysql/) and create a server with a password of your choosing

### Installing Application
* Use ```git clone``` to download this repository to a local directory
* Navigate to this local directory in your terminal
* Navigate to the ```/Library``` folder in your terminal
* Enter ```dotnet restore``` to install packages
* Enter ```touch appsettings.json``` to create an appsettings file.
* Open appsettings.json with a text editor and enter the following, replacing \[PASSWORD\] with your chosen server password:
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=shanen_cross;uid=root;pwd=[PASSWORD];"
  }
}
```

### Generating Database
* If you aren't there already, navigate to the ```/Library``` subfolder in your terminal
* Enter the following to generate the database using the migration:
```
dotnet ef database update
```

### Running Application
* Enter ```dotnet run``` to build and run the application; or alternatively, use ```dotnet watch run``` to make the server refresh whenever a file is saved
* The terminal will output that it is "Now listening on" a certain URL. For me this is ```http://localhost:5000```, but it could be different.
* Navigate in your web browser to whatever URL is displayed. This will show the home page.

## Known Bugs

None.

## License

[MIT](LICENSE)

Copyright (c) 2021 Shanen Cross and Salim Mayan
