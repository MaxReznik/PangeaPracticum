# Pangea Practicum

## Application supports 2 endpoints
- ~/LoadData -  sends the message to rabbitMq to load the data
- ~/Repositories - returns json representation of all repositories from database

## Frameworks/Libraries used
- EntityFramework Core
- RawRabbit
- Newtonsoft.json

## Configuration:
- MS SQL Server: Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;
- RabbitMQ:
```
    Username = "guest",
    Password = "guest",
    Port = 5672,
    VirtualHost = "/",
    Hostnames = { "localhost" }
```

## Comments
- RabbitMQ consumer is running inside asp.net core application. It should be in a separate windows service, but since it's a test assignment, it's OK.
- Using MS SQL Server to persist data. The application does not check if data already in the 
database, but can add it if needed :)
- Did not add unit tests because they are trivial, but application is written with unit testability in mind
- Overall had lots of fun with it :) 

