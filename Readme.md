# Configuration
Set your MongoDB setting in the file **appsettings.json**
```
"MongoDB": {
    "ConnectionURI": "localhost:27017",
    "DatabaseName": "UserManager", 
    "CollectionName": "Users"
}
```


# Running it Locally
```
dotnet watch --project ENG.UserManager.API
```


# Run the Docker
```
docker-compose up -d
```


# Run the Unit Testing
Work in progress
```
dotnet test
```