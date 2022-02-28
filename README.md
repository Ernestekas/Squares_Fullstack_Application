# Squares_Fullstack_Application

1. Link to task description: https://trello.com/b/Ly4QaNwt/devbridge-squares

2. Application details.
Summary:
This application must be single page application, where user can see existing collections of points (with x y coordinates), create new or update existing collection, add new points to a list and get list of all possible squares in a selected collecetion of points.

SERVER. .NET Core, MSSQL
Functionality:
- Get all. Get Basic collection data (id, name and count of points in a collection).
- Get by Id. Get selected collection data with all points.
- Add collection. Creates new collection or overwrites collection with the same name.
- Remove. Remove collection with all it's points.
- Get all squares. Calculate all squares in a collection sent with a http post request. Return list of all calculated squares.
- Soft delete functionality implemented.

CLIENT. Angular
Functionality:
- Single page apllication.
- Get all existing collections of points from server and display them.
- Select collection and display selected list data and contents.
- Add new points, remove existing or unsaved points.
- Save collection in database.
- Import points from txt file.
- Delete collection with all its points.
