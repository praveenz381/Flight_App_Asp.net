CREATE DATABASE PlanMyTrip

CREATE TABLE Roles
(
RoleId		INT			PRIMARY KEY	IDENTITY,
RoleName	VARCHAR(30)	NOT NULL
)

CREATE TABLE Users
(
UserId		INT			PRIMARY KEY IDENTITY,
FirstName	VARCHAR(30)	NOT NULL,
LastName	VARCHAR(30)	NOT NULL,
EmailId		VARCHAR(30)	NOT NULL UNIQUE,
Password	VARCHAR(12)	NOT NULL,
RoleId		INT			FOREIGN KEY REFERENCES Roles(RoleId)
)


CREATE TABLE Passenger
(
PassengerId INT			FOREIGN KEY REFERENCES Users(UserId),
FirstName	VARCHAR(30)	NOT NULL,
LastName	VARCHAR(30)	NOT NULL,
Age			INT 
)


CREATE TABLE Airport
(
AirportCode CHAR(6)		PRIMARY KEY ,
AirportName VARCHAR(30) NOT NULL ,
Location	VARCHAR(30) ,
Description VARCHAR(200) 
)
 
 CREATE TABLE Flight(
 FlightNumber		CHAR(6)		PRIMARY KEY, 
 FlightName			VARCHAR(30) NOT NULL,
 SeatsCapacity		INT			NOT NULL,
 NoOfSeatsAvailable INT			NOT NULL
 )



CREATE TABLE FlightSchedule
(
Id				INT		PRIMARY KEY IDENTITY,
FlightNumber	CHAR(6) FOREIGN KEY REFERENCES Flight(FlightNumber),
Origin			CHAR(6) FOREIGN KEY REFERENCES Airport(AirportCode),
Destination		CHAR(6) FOREIGN KEY REFERENCES Airport(AirportCode),
DepartureTime	DATETIME,
ArrivalTime		DATETIME
)



CREATE TABLE Itinerary(
ReservationId	INT PRIMARY KEY IDENTITY,
PassengerId		INT FOREIGN KEY REFERENCES Users(UserId),
ScheduleId		INT FOREIGN KEY REFERENCES FlightSchedule(Id)
)


INSERT INTO ROLES(RoleName) VALUES('admin')
insert into roles(rolename) values('user')

insert into users(FirstName,LastName,EmailId,Password,RoleId)
values('venkat','a','venkat@pmt.com','password',1)

