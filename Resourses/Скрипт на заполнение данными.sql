USE [gr602_stmti]
GO
SET IDENTITY_INSERT [dbo].[RoleType] ON 

INSERT [dbo].[RoleType] ([idRoleType], [Name]) VALUES (1, N'User')
INSERT [dbo].[RoleType] ([idRoleType], [Name]) VALUES (2, N'Admin')
INSERT [dbo].[RoleType] ([idRoleType], [Name]) VALUES (3, N'Coach')
SET IDENTITY_INSERT [dbo].[RoleType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([idUser], [Name], [Surname], [Patronymic], [Email], [Login], [Password], [PhoneNumber], [idRoleType]) VALUES (1, N'Ivan', N'Bezmamov', N'Errorovich', N'ivan@mail.ru', N'ivan', N'123', N'79609876522', 1)
INSERT [dbo].[User] ([idUser], [Name], [Surname], [Patronymic], [Email], [Login], [Password], [PhoneNumber], [idRoleType]) VALUES (2, N'Grisha', N'Kolmakov', N'Igorevich', N'rexv@mail.ru', N'rexv', N'321', N'79609266272', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
