SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Address], [Password], [Username], [PhoneNr], [Email], [IsTeacher], [GroupId], [ImagePath]) VALUES (3, N'Pedro', N'Rainho', N'Kogevej, 123B, Roskilde', N'AQAAAAEAACcQAAAAEP2y8oKwadeuBrolvqbvehL9PwfbYYRPJhRt98iCbl24MF/50txfI82pkr/ckNSW2g==', N'pedro', N'928288282', N'pedr0402@edu.easj.dk', 0, 0, NULL)
INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Address], [Password], [Username], [PhoneNr], [Email], [IsTeacher], [GroupId], [ImagePath]) VALUES (4, N'Alex', N'Lazaroiu', N'Kogevej, 123B, Roskilde', N'AQAAAAEAACcQAAAAEKs8Ja+eC4kNBxp8hnFl0juDVEp/uSs8NiJWspE3TQ6uCAUSSI0PHg2uAzP4vfDh4Q==', N'alex', N'918181881', N'alex056t@edu.easj.dk', 0, 0, N'alex.jpg')
INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Address], [Password], [Username], [PhoneNr], [Email], [IsTeacher], [GroupId], [ImagePath]) VALUES (10, N'Catalina', N'Curca', N'Kogevej, 123B, Roskilde', N'AQAAAAEAACcQAAAAENBMu5ehdtUZ0ZggJ91moivCimNrnh8QS/vBs/LqAHgcBXXArmwFfTP4Yvhi5bFfSQ==', N'cata', N'928288282', N'paul6795@edu.easj.dk', 0, 0, N'cata.jpg')
INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Address], [Password], [Username], [PhoneNr], [Email], [IsTeacher], [GroupId], [ImagePath]) VALUES (11, N'Kristaps', N'Mezatucs', N'Kogevej, 123B, Roskilde', N'AQAAAAEAACcQAAAAEOOiY0nIR3PuMlZKizDZPqzcnLSIvUdjkO1lU6t5z9WIK5KeaxrfoQrlZhQwdeXWpA==', N'kristaps', N'928288282', N'kris52m2@edu.easj.dk', 0, 0, N'kristaps.jpg')
INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Address], [Password], [Username], [PhoneNr], [Email], [IsTeacher], [GroupId], [ImagePath]) VALUES (12, N'Radu', N'Adumitroaei', N'Kogevej, 123B, Roskilde', N'AQAAAAEAACcQAAAAEIZt/zp89PKbYn26KWtytUNkt5WDi8H5Ym+s28/wF0ZOXfbcjkwuUO/4EZUIR8tAwA==', N'radu', N'918181881', N'radu0210@edu.easj.dk', 0, 0, N'radu.jpg')
INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Address], [Password], [Username], [PhoneNr], [Email], [IsTeacher], [GroupId], [ImagePath]) VALUES (13, N'Test', N'Test', N'Test', N'AQAAAAEAACcQAAAAEDClDorP5/K5wi7lhoFhVBez8qexR75QBM3sMq2hD2LtjINM79dDxBdu2tALHULNqQ==', N'test', N'928288282', N'radu0210@edu.easj.dk', 0, 1, N'test.jpg')
INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName], [Address], [Password], [Username], [PhoneNr], [Email], [IsTeacher], [GroupId], [ImagePath]) VALUES (14, N'Teacher', N'Teacher', N'Aarhus', N'AQAAAAEAACcQAAAAEK8UMqAtOFiUTOyL2s9388sLy0E4G8RkXfkC29wxI5zQtVMdX+VYTX1RHnDBWCggwg==', N'teacher', N'91917177', N'teacher@zd.test.com', 1, 0, N'teacher.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Locations] ON
INSERT INTO [dbo].[Locations] ([LocationId], [Name], [Address], [ImageName]) VALUES (1, N'Roskilde', N'Maglegårdsvej 2, 4000 Roskilde', N'roskilde.jpg')
INSERT INTO [dbo].[Locations] ([LocationId], [Name], [Address], [ImageName]) VALUES (2, N'Næstved', N'Femøvej 3, 4700 Næstved', N'naestved.jpg')
INSERT INTO [dbo].[Locations] ([LocationId], [Name], [Address], [ImageName]) VALUES (3, N'Køge', N'Lyngvej 21, 4600 Køge', N'koge.jpg')
INSERT INTO [dbo].[Locations] ([LocationId], [Name], [Address], [ImageName]) VALUES (4, N'Holbæk', N'Anders Larsensvej 7-9', N'holbaek.jpg')
INSERT INTO [dbo].[Locations] ([LocationId], [Name], [Address], [ImageName]) VALUES (5, N'Slagelse', N'Bredahlsgade 1', N'slagelse.jpg')
INSERT INTO [dbo].[Locations] ([LocationId], [Name], [Address], [ImageName]) VALUES (6, N'Nykøbing F.', N'Bispegade 5', N'nykobing.jpg')
SET IDENTITY_INSERT [dbo].[Locations] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON
INSERT INTO [dbo].[Rooms] ([RoomId], [LocationId], [RoomNR], [Name], [ImagePath], [Type], [Big]) VALUES (1, 1, N'A1', N'Classroom', NULL, 0, 1)
INSERT INTO [dbo].[Rooms] ([RoomId], [LocationId], [RoomNR], [Name], [ImagePath], [Type], [Big]) VALUES (2, 1, N'D3', N'Smartboard Room', NULL, 4, 0)
INSERT INTO [dbo].[Rooms] ([RoomId], [LocationId], [RoomNR], [Name], [ImagePath], [Type], [Big]) VALUES (3, 3, N'B11', N'Lounge', NULL, 2, 0)
INSERT INTO [dbo].[Rooms] ([RoomId], [LocationId], [RoomNR], [Name], [ImagePath], [Type], [Big]) VALUES (4, 3, N'A4', N'Student Office', NULL, 3, 0)
INSERT INTO [dbo].[Rooms] ([RoomId], [LocationId], [RoomNR], [Name], [ImagePath], [Type], [Big]) VALUES (5, 1, N'G1', N'Room', NULL, 1, 0)
INSERT INTO [dbo].[Rooms] ([RoomId], [LocationId], [RoomNR], [Name], [ImagePath], [Type], [Big]) VALUES (6, 1, N'A31', N'CS Classroom', NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Groups] ON
INSERT INTO [dbo].[Groups] ([GroupId], [Owner]) VALUES (1, 13)
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[Bookings] ON
INSERT INTO [dbo].[Bookings] ([BookingID], [Student_GroupID], [FromDateTime], [ToDateTime], [RoomId], [UserId], [Active]) VALUES (1, 1, N'2021-06-30 08:00:00', N'2021-06-30 10:00:00', 1, 13, 1)
INSERT INTO [dbo].[Bookings] ([BookingID], [Student_GroupID], [FromDateTime], [ToDateTime], [RoomId], [UserId], [Active]) VALUES (2, 1, N'2021-07-01 08:00:00', N'2021-07-01 10:00:00', 6, 13, 1)
INSERT INTO [dbo].[Bookings] ([BookingID], [Student_GroupID], [FromDateTime], [ToDateTime], [RoomId], [UserId], [Active]) VALUES (3, 1, N'2021-06-23 10:00:00', N'2021-06-23 12:00:00', 2, 13, 1)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
