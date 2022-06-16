USE [master]
GO
/****** Object:  Database [gr602_stmti]    Script Date: 05.06.2022 10:38:50 ******/
CREATE DATABASE [gr602_stmti]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gr602_stmti', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\gr602_stmti.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gr602_stmti_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\gr602_stmti_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [gr602_stmti] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gr602_stmti].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gr602_stmti] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gr602_stmti] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gr602_stmti] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gr602_stmti] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gr602_stmti] SET ARITHABORT OFF 
GO
ALTER DATABASE [gr602_stmti] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gr602_stmti] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gr602_stmti] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gr602_stmti] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gr602_stmti] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gr602_stmti] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gr602_stmti] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gr602_stmti] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gr602_stmti] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gr602_stmti] SET  ENABLE_BROKER 
GO
ALTER DATABASE [gr602_stmti] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gr602_stmti] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gr602_stmti] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gr602_stmti] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gr602_stmti] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gr602_stmti] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gr602_stmti] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gr602_stmti] SET RECOVERY FULL 
GO
ALTER DATABASE [gr602_stmti] SET  MULTI_USER 
GO
ALTER DATABASE [gr602_stmti] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gr602_stmti] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gr602_stmti] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gr602_stmti] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gr602_stmti] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'gr602_stmti', N'ON'
GO
ALTER DATABASE [gr602_stmti] SET QUERY_STORE = OFF
GO
USE [gr602_stmti]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [gr602_stmti]
GO
/****** Object:  Table [dbo].[Coach]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coach](
	[idCoach] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Surname] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCoach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[idOrder] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](7, 2) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](0) NOT NULL,
	[idOrderStatusType] [int] NOT NULL,
	[idSubscriptionList] [int] NOT NULL,
	[idCoach] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[idPayment] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatusType]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatusType](
	[idOrderStatusType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrderStatusType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[idPayment] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Amount] [decimal](7, 2) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](0) NOT NULL,
	[Status] [nvarchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleType]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleType](
	[idRoleType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRoleType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[idSchedule] [int] IDENTITY(1,1) NOT NULL,
	[idTraining] [int] NOT NULL,
	[TrainingCount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSchedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[idSubscription] [int] IDENTITY(1,1) NOT NULL,
	[VisitsAmount] [int] NOT NULL,
	[Validity] [datetime] NOT NULL,
	[idSubscriptionType] [int] NOT NULL,
	[idSchedule] [int] NOT NULL,
	[Cost] [decimal](7, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSubscription] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionList]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionList](
	[idSubscriptionList] [int] IDENTITY(1,1) NOT NULL,
	[idSubscription] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSubscriptionList] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionType]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionType](
	[idSubscriptionType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSubscriptionType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Training]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Training](
	[idTraining] [int] IDENTITY(1,1) NOT NULL,
	[idTrainingType] [int] NOT NULL,
	[Time] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTraining] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingType]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingType](
	[idTrainingType] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTrainingType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 05.06.2022 10:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Surname] [nvarchar](25) NOT NULL,
	[Patronymic] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[PhoneNumber] [nvarchar](25) NOT NULL,
	[idRoleType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoleType] ON 

INSERT [dbo].[RoleType] ([idRoleType], [Name]) VALUES (1, N'User')
INSERT [dbo].[RoleType] ([idRoleType], [Name]) VALUES (2, N'Admin')
INSERT [dbo].[RoleType] ([idRoleType], [Name]) VALUES (3, N'Coach')
SET IDENTITY_INSERT [dbo].[RoleType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([idUser], [Name], [Surname], [Patronymic], [Email], [Login], [Password], [PhoneNumber], [idRoleType]) VALUES (1, N'Ivan', N'Bezmamov', N'Errorovich', N'ivan@mail.ru', N'ivan', N'123', N'79609876522', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__5E55825B814AA70E]    Script Date: 05.06.2022 10:38:51 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__85FB4E38B1F6DE34]    Script Date: 05.06.2022 10:38:51 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__A9D10534584F7B73]    Script Date: 05.06.2022 10:38:51 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([idCoach])
REFERENCES [dbo].[Coach] ([idCoach])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([idOrderStatusType])
REFERENCES [dbo].[OrderStatusType] ([idOrderStatusType])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([idPayment])
REFERENCES [dbo].[Payment] ([idPayment])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([idSubscriptionList])
REFERENCES [dbo].[SubscriptionList] ([idSubscriptionList])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([idTraining])
REFERENCES [dbo].[Training] ([idTraining])
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD FOREIGN KEY([idSchedule])
REFERENCES [dbo].[Schedule] ([idSchedule])
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD FOREIGN KEY([idSubscriptionType])
REFERENCES [dbo].[SubscriptionType] ([idSubscriptionType])
GO
ALTER TABLE [dbo].[SubscriptionList]  WITH CHECK ADD FOREIGN KEY([idSubscription])
REFERENCES [dbo].[Subscription] ([idSubscription])
GO
ALTER TABLE [dbo].[Training]  WITH CHECK ADD FOREIGN KEY([idTrainingType])
REFERENCES [dbo].[TrainingType] ([idTrainingType])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([idRoleType])
REFERENCES [dbo].[RoleType] ([idRoleType])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD CHECK  (([Email]<>''))
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD CHECK  (([PhoneNumber]<>''))
GO
USE [master]
GO
ALTER DATABASE [gr602_stmti] SET  READ_WRITE 
GO
