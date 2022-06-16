CREATE DATABASE [gr602_stmti]

GO

USE [gr602_stmti]

GO

CREATE TABLE [TrainingType]
(
	idTrainingType INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(25) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
)

CREATE TABLE [Training]
(
	idTraining INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idTrainingType INT REFERENCES TrainingType(idTrainingType) NOT NULL,
	[Time] NVARCHAR(25) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL, 
)

CREATE TABLE [Schedule]
(
	idSchedule INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idTraining INT REFERENCES Training(idTraining) NOT NULL,
	TrainingCount INT NOT NULL,
)

CREATE TABLE [SubscriptionType]
(
	idSubscriptionType INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(25) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
)

CREATE TABLE [Subscription]
(
	idSubscription INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	VisitsAmount INT NOT NULL,
	Validity NVARCHAR(25) NOT NULL,
	idSubscriptionType INT REFERENCES SubscriptionType(idSubscriptionType) NOT NULL,
	idSchedule INT REFERENCES Schedule(idSchedule) NOT NULL,
	Cost DECIMAL(7,2) NOT NULL,
)

CREATE TABLE [SubscriptionList]
(
	idSubscriptionList INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	idSubscription INT REFERENCES Subscription(idSubscription) NOT NULL,
)

CREATE TABLE [Coach]
(
	idCoach INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(25) NOT NULL,
	Surname NVARCHAR(25) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
)

CREATE TABLE [RoleType]
(
	idRoleType INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(10) NOT NULL,
)

CREATE TABLE [User]
(
	idUser INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(25) NOT NULL,
	Surname NVARCHAR(25) NOT NULL,
	Patronymic NVARCHAR(25) NOT NULL,
	Email NVARCHAR(50) UNIQUE CHECK(Email !='') NOT NULL,
	[Login] NVARCHAR(20) UNIQUE NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	PhoneNumber NVARCHAR(25) UNIQUE CHECK(PhoneNumber !='') NOT NULL,
	idRoleType INT REFERENCES RoleType(idRoleType) NOT NULL,
)

CREATE TABLE [Payment]
(
	idPayment INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Type] NVARCHAR(50) NOT NULL,
	Amount DECIMAL(7,2) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME(0) NOT NULL,
	[Status] NVARCHAR(25) NOT NULL,
)

CREATE TABLE [Order]
(
	idOrder INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Amount] DECIMAL(7,2) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME(0) NOT NULL,
	[Status] NVARCHAR(25) NOT NULL,
	idSubscriptionList INT REFERENCES SubscriptionList(idSubscriptionList) NOT NULL,
	idCoach INT REFERENCES Coach(idCoach) NOT NULL,
	idUser INT REFERENCES [User](idUser) NOT NULL,
	idPayment INT REFERENCES Payment(idPayment) NOT NULL,
)

INSERT INTO [RoleType]([Name]) VALUES
(N'User'),
(N'Admin'),
(N'Coach');

INSERT INTO [User]([Name], Surname, Patronymic, Email, [Login], [Password], PhoneNumber, idRoleType) VALUES
(N'Ivan', N'Bezmamov', N'Errorovich', N'ivan@mail.ru', N'ivan', N'123', N'79609876522', 1),
(N'Grisha', N'Kolmakov', N'Igorevich', N'rexv@mail.ru', N'rexv', N'321', N'79609266272', 2);