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

CREATE TABLE Authors
(
    Id uniqueidentifier primary key not null,
    Fullname nvarchar(100) not null,
)

SELECT *
FROM Users;

DECLARE @UNIQUEX UNIQUEIDENTIFIER
SET @UNIQUEX = NEWID();

INSERT INTO Authors
    (
    Id,
    Fullname
    )
VALUES
    (
        @UNIQUEX,
        'J.WWWWWW'
)

SELECT *
FROM Authors

Drop table Authors