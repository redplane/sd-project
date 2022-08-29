# SD Project

## 1. Overview
This project is for demonstrating how to solve the below problem:
```
You’re building a backend service to support the goodreads mobile app. Please build a set of APIs that would allow a user to do the following activities:
1. Add a book to the list of books they have read
2. View a list of books they have completed reading
3. Search for a book by name
We’re looking only for APIs, no Frontend is needed. Please make sure that the APIs are RESTful.
Please make reasonable assumptions if anything is not clear.
```

## 2. Technical stacks
- Net 5
- Entity Framework Core
- Microsoft SQL Server 2022

## 3. Development

### 3.1. Pre-requisite:
- Install Microsoft SQL Server 2019 or higher.
- Install .Net 5 SDK
- Install one of the following IDE: 
  - Visual Studio 2022 or higher
  - Jetbrain Rider
  - Visual Studio Code

### 3.2. Database migration

- Go to `appsettings.json` or `appsettings.Development.json` or create a [secret file](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows) to configure database connection string.
The database connection will be as the following settings:

```
"ConnectionStrings": {
    "Default": "<YOUR_MSSQL_CONNECTION_STRING>"
  }
```

- Open terminal or command prompt and point to `src` folder.
- Run the following command to generate the database this project uses in MSSQL Database:
```
dotnet ef database update --startup-project src/apis/SdProject.Apis/SdProject.Apis.csproj --project src/apis/SdProject.Cores/SdProject.Cores.csproj --context SdProjectDbContext 
```

### 3.3. Use cases

The below list items are use cases that mentioned in the question, they will be gone through one by one with the related CURL.

- Pre-requisite:
  - **User must be added by using:**:
```
curl --location --request POST 'http://localhost:64068/api/user' \
--header 'Content-Type: application/json' \
--data-raw '{
    "FirstName": "Linh",
    "LastName": "Nguyen",
    "Birthdate": "19/08/1994"

}'
```
  - **Book must be added by using:**
```
curl --location --request POST 'http://localhost:64068/api/book' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Title": "Book",
    "Category": "Book Category",
    "Description": "Description",
    "Price": 185000
}'
```
  - **Relationship between user & book must be added by using:
```
curl --location --request POST 'http://localhost:64068/api/user/favorite' \
--header 'Content-Type: application/json' \
--data-raw '{
    "userId": 1,
    "bookId": 2
}'
```



#### 3.3.1. Add a book to the list of books they have read:

- To mark a book as complete reading, use the below CURL:
```
curl --location --request PUT 'http://localhost:64068/api/user/mark-as-read' \
--header 'Content-Type: application/json' \
--data-raw '{
    "userId": 1,
    "bookId": 1
}'
```

#### 3.3.2. View a list of books they have completed reading
- To search for completed reading books, use the following CURL:
```
curl --location --request POST 'http://localhost:64068/api/user/search-user-books' \
--header 'Content-Type: application/json' \
--data-raw '{
    "userId": 1,
    "haveRead": null
}'
```

**NOTE**: `haveRead` can be nullable, if it is null, **ALL BOOKS** which have relationship with the specific user will be returned.

#### 3.3.3. Search for a book by name
- In this example, book name is treated as book title. Use the following CURL for searching for books by their name.
```
curl --location --request POST 'http://localhost:64068/api/Book/search' \
--header 'Content-Type: application/json' \
--data-raw '{
    "title": "b"
}'
```


## NOTE
For more api information, please refer to: [http://localhost:64068/swagger/index.html](http://localhost:64068/swagger/index.html).
