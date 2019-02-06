CREATE DATABASE Library

USE Library

CREATE TABLE Users
(
    Id uniqueidentifier primary key not null,
    Email nvarchar(100) not null,
    Password nvarchar(200) not null,
    Salt nvarchar(200) not null,
    Username nvarchar(100) not null,
    CreatedAt datetime not null,
    UpdatedAt datetime not null
)

SELECT *
FROM Users;