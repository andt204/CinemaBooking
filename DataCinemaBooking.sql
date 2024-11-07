USE [CinemaBooking]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Customer')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [FullName], [Avatar], [Gender], [PhoneNumber], [DateOfBirth], [Email], [Password], [Status], [RoleId]) VALUES (2, N'John Doe', NULL, N'Male', N'123456789', CAST(N'1990-01-01' AS Date), N'john@example.com', N'password123', 1, 1)
INSERT [dbo].[Account] ([AccountId], [FullName], [Avatar], [Gender], [PhoneNumber], [DateOfBirth], [Email], [Password], [Status], [RoleId]) VALUES (3, N'Jane Smith', NULL, N'Female', N'987654321', CAST(N'1985-05-15' AS Date), N'jane@example.com', N'password456', 1, 2)
INSERT [dbo].[Account] ([AccountId], [FullName], [Avatar], [Gender], [PhoneNumber], [DateOfBirth], [Email], [Password], [Status], [RoleId]) VALUES (4, N'Alice Brown', NULL, N'Female', N'555555555', CAST(N'1992-02-20' AS Date), N'alice@example.com', N'password789', 1, 3)
INSERT [dbo].[Account] ([AccountId], [FullName], [Avatar], [Gender], [PhoneNumber], [DateOfBirth], [Email], [Password], [Status], [RoleId]) VALUES (5, N'Bob Johnson', NULL, N'Male', N'444444444', CAST(N'1988-12-12' AS Date), N'bob@example.com', N'passwordabc', 1, 1)
INSERT [dbo].[Account] ([AccountId], [FullName], [Avatar], [Gender], [PhoneNumber], [DateOfBirth], [Email], [Password], [Status], [RoleId]) VALUES (6, N'Charlie Davis', NULL, N'Male', N'666666666', CAST(N'1995-03-30' AS Date), N'charlie@example.com', N'passwordxyz', 1, 2)
INSERT [dbo].[Account] ([AccountId], [FullName], [Avatar], [Gender], [PhoneNumber], [DateOfBirth], [Email], [Password], [Status], [RoleId]) VALUES (7, N'Truong An Doo', NULL, N'Male', N'0382657656', CAST(N'2003-04-20' AS Date), N'andthe1708522@fpt.edu.vn', N'$2a$11$dCJfpLhgdwFzUyKgNCmb1.jWeiNeMEDD9wNQuz7wLHWlpQRuZCeke', 1, 2)
INSERT [dbo].[Account] ([AccountId], [FullName], [Avatar], [Gender], [PhoneNumber], [DateOfBirth], [Email], [Password], [Status], [RoleId]) VALUES (8, N'Nguyen Manh Cuong', NULL, N'Female', N'0382657888', CAST(N'2002-12-29' AS Date), N'cuongnm1708522@fpt.edu.vn', N'$2a$11$TWzTSOlQT06qV0p0fh7Eqetn1qz61k.fUVCV4oQIgIHwURIHwm/i6', 1, 2)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Director] ON 

INSERT [dbo].[Director] ([DirectorId], [DirectorName]) VALUES (1, N'Steven Spielberg')
INSERT [dbo].[Director] ([DirectorId], [DirectorName]) VALUES (2, N'Christopher Nolan')
INSERT [dbo].[Director] ([DirectorId], [DirectorName]) VALUES (3, N'James Cameron')
INSERT [dbo].[Director] ([DirectorId], [DirectorName]) VALUES (4, N'Quentin Tarantino')
INSERT [dbo].[Director] ([DirectorId], [DirectorName]) VALUES (5, N'Martin Scorsese')
SET IDENTITY_INSERT [dbo].[Director] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([MovieId], [Title], [Length], [Description], [AgeLimit], [WarningText], [PublishTime], [Country], [Image], [ImageBackground], [Status], [DirectorId], [VideoTrailer]) VALUES (2, N'Avengers: Endgame', 180, N'Superheroes saving the world.', 13, NULL, CAST(N'2024-12-12T00:00:00.000' AS DateTime), N'USA', N'https://bazaarvietnam.vn/wp-content/uploads/2022/03/Harpers-Bazaar-Phim-chieu-rap-thang-4-2022-BATMAN-scaled.jpg', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzySlkI1lCgCNpo0QTMQV5wVS33pqdM9boPA&s', 1, 1, N'https://www.youtube.com/watch?v=puHjyVLpMT4')
INSERT [dbo].[Movie] ([MovieId], [Title], [Length], [Description], [AgeLimit], [WarningText], [PublishTime], [Country], [Image], [ImageBackground], [Status], [DirectorId], [VideoTrailer]) VALUES (3, N'Inception', 148, N'Dreams within dreams.', 13, NULL, CAST(N'2024-02-01T00:00:00.000' AS DateTime), N'USA', N'https://bazaarvietnam.vn/wp-content/uploads/2022/03/Harpers-Bazaar-Phim-chieu-rap-thang-4-2022-BATMAN-scaled.jpg', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzySlkI1lCgCNpo0QTMQV5wVS33pqdM9boPA&s', 1, 2, N'https://www.youtube.com/watch?v=puHjyVLpMT4')
INSERT [dbo].[Movie] ([MovieId], [Title], [Length], [Description], [AgeLimit], [WarningText], [PublishTime], [Country], [Image], [ImageBackground], [Status], [DirectorId], [VideoTrailer]) VALUES (4, N'Titanic', 195, N'Historical romance on a doomed ship.', 13, NULL, CAST(N'2024-03-01T00:00:00.000' AS DateTime), N'USA', N'https://bazaarvietnam.vn/wp-content/uploads/2022/03/Harpers-Bazaar-Phim-chieu-rap-thang-4-2022-BATMAN-scaled.jpg', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzySlkI1lCgCNpo0QTMQV5wVS33pqdM9boPA&s', 1, 3, N'https://www.youtube.com/watch?v=puHjyVLpMT4')
INSERT [dbo].[Movie] ([MovieId], [Title], [Length], [Description], [AgeLimit], [WarningText], [PublishTime], [Country], [Image], [ImageBackground], [Status], [DirectorId], [VideoTrailer]) VALUES (5, N'Pulp Fiction', 154, N'Intertwined stories of crime.', 18, NULL, CAST(N'2024-04-01T00:00:00.000' AS DateTime), N'USA', N'https://bazaarvietnam.vn/wp-content/uploads/2022/03/Harpers-Bazaar-Phim-chieu-rap-thang-4-2022-BATMAN-scaled.jpg', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzySlkI1lCgCNpo0QTMQV5wVS33pqdM9boPA&s', 1, 4, N'https://www.youtube.com/watch?v=puHjyVLpMT4')
INSERT [dbo].[Movie] ([MovieId], [Title], [Length], [Description], [AgeLimit], [WarningText], [PublishTime], [Country], [Image], [ImageBackground], [Status], [DirectorId], [VideoTrailer]) VALUES (6, N'The Irishman', 209, N'A mob hitman recalls his past.', 18, NULL, CAST(N'2024-05-01T00:00:00.000' AS DateTime), N'USA', N'https://bazaarvietnam.vn/wp-content/uploads/2022/03/Harpers-Bazaar-Phim-chieu-rap-thang-4-2022-BATMAN-scaled.jpg', N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzySlkI1lCgCNpo0QTMQV5wVS33pqdM9boPA&s', 1, 5, N'https://www.youtube.com/watch?v=puHjyVLpMT4')
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (3, N'Avengers Review', N'A review of Avengers: Endgame', CAST(N'2024-10-22T10:00:00.000' AS DateTime), NULL, 6, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (4, N'Inception Explained', N'A deep dive into Inception', CAST(N'2024-10-22T10:05:00.000' AS DateTime), NULL, 2, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (5, N'Titanic: A Timeless Story', N'Review of the Titanic movie', CAST(N'2024-10-22T10:10:00.000' AS DateTime), NULL, 3, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (6, N'Pulp Fiction Analysis', N'A breakdown of Pulp Fiction', CAST(N'2024-10-22T10:15:00.000' AS DateTime), NULL, 4, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (7, N'The Irishman: A Masterpiece', N'Thoughts on The Irishman', CAST(N'2024-10-22T10:20:00.000' AS DateTime), NULL, 5, 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (6, 4, NULL, 6, 1, N'Great movie!', CAST(N'2024-10-22T10:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (7, 2, NULL, 2, 1, N'Not bad!', CAST(N'2024-10-22T10:05:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (8, 5, NULL, 3, 1, N'Loved the action scenes!', CAST(N'2024-10-22T10:10:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (9, 3, NULL, 4, 1, N'Could have been better.', CAST(N'2024-10-22T10:15:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (10, 2, NULL, 5, 1, N'Amazing storyline!', CAST(N'2024-10-22T10:20:00.000' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON 

INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (1, N'Standard', 50, 7, 6)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (2, N'VIP', 55, 8, 10)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (3, N'IMAX', 60, 4, 3)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (4, N'4DX', 65, 5, 6)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (5, N'Private', 70, 7, 10)
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[Theater] ON 

INSERT [dbo].[Theater] ([TheaterName], [Location], [Status]) VALUES (N'Theater B', N'Location B', 1)
INSERT [dbo].[Theater] ([TheaterName], [Location], [Status]) VALUES (N'Theater C', N'Location C', 0)
INSERT [dbo].[Theater] ([TheaterName], [Location], [Status]) VALUES (N'Theater D', N'Location D', 0)
INSERT [dbo].[Theater] ([TheaterName], [Location], [Status]) VALUES (N'Theater E', N'Location E', 0)
INSERT [dbo].[Theater] ([TheaterName], [Location], [Status]) VALUES (N'CGV Royal City', N'Royal City', 0)
SET IDENTITY_INSERT [dbo].[Theater] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (2, 1, 2, N'Room A', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (3, 2, 2, N'Room B', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (4, 3, 4, N'Room C', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (5, 4, 3, N'Room D', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (6, 5, 4, N'Room E', 1)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Showtime] ON 

INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (2, 3, CAST(N'12:00:00' AS Time), CAST(N'2024-11-06' AS Date), 3)
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (3, 3, CAST(N'14:00:00' AS Time), CAST(N'2024-11-06' AS Date), 3)
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (4, 3, CAST(N'16:00:00' AS Time), CAST(N'2024-11-09' AS Date), 3)
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (5, 3, CAST(N'18:00:00' AS Time), CAST(N'2024-11-08' AS Date), 3)
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (6, 3, CAST(N'20:00:00' AS Time), CAST(N'2024-11-08' AS Date), 3)
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (10, 3, CAST(N'12:00:00' AS Time), CAST(N'2024-11-07' AS Date), 3)
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (11, 3, CAST(N'15:00:00' AS Time), CAST(N'2024-11-07' AS Date), 3)
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date], [MovieId]) VALUES (12, 3, CAST(N'11:11:00' AS Time), CAST(N'2024-11-10' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Showtime] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (41, 8, 3, 4, CAST(N'2024-11-06T09:50:02.937' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (42, 7, 3, 4, CAST(N'2024-11-06T09:50:13.857' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (43, 7, 2, 4, CAST(N'2024-11-06T23:23:21.150' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (44, 7, 2, 4, CAST(N'2024-11-06T23:24:55.087' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (45, 8, 2, 4, CAST(N'2024-11-06T23:25:27.310' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (46, 8, 2, 4, CAST(N'2024-11-06T23:26:06.350' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (47, 8, 2, 4, CAST(N'2024-11-06T23:27:04.387' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (48, 8, 2, 4, CAST(N'2024-11-06T23:28:24.623' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (49, 7, 2, 4, CAST(N'2024-11-06T23:29:28.303' AS DateTime), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (50, 7, 2, 4, CAST(N'2024-11-06T23:35:16.520' AS DateTime), CAST(150000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (51, 7, 2, 4, CAST(N'2024-11-06T23:36:04.160' AS DateTime), CAST(300000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[Vote] ON 

INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (1, 6, 4, 5, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (2, 2, 2, 4, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (3, 3, 3, 3, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (4, 4, 4, 4, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (5, 5, 2, 5, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vote] OFF
GO
SET IDENTITY_INSERT [dbo].[Actor] ON 

INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (1, N'Robert Downey Jr.')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (2, N'Scarlett Johansson')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (3, N'Chris Evans')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (4, N'Chris Hemsworth')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (5, N'Mark Ruffalo')
SET IDENTITY_INSERT [dbo].[Actor] OFF
GO
SET IDENTITY_INSERT [dbo].[ActorMovieAssignments] ON 

INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (1, 4, 1)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (2, 4, 2)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (3, 2, 3)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (4, 2, 4)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (5, 3, 5)
SET IDENTITY_INSERT [dbo].[ActorMovieAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Action')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Comedy')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Drama')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Sci-Fi')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (5, N'Horror')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[MovieCategoryAssignments] ON 

INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (2, 2, 2)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (3, 3, 3)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (4, 4, 4)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (5, 5, 5)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (6, 6, 1)
SET IDENTITY_INSERT [dbo].[MovieCategoryAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketMovieAssignments] ON 

INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId]) VALUES (30, 41, 3)
INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId]) VALUES (31, 42, 3)
SET IDENTITY_INSERT [dbo].[TicketMovieAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[SeatType] ON 

INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (1, N'Regular', CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (2, N'Premium', CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (3, N'VIP', CAST(150000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[SeatType] OFF
GO
SET IDENTITY_INSERT [dbo].[Seat] ON 

INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (11, 1, 3, N'A', 1, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (12, 1, 3, N'A', 2, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (13, 1, 3, N'A', 3, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (14, 1, 3, N'A', 4, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (15, 1, 3, N'A', 5, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (16, 1, 3, N'A', 6, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (17, 1, 3, N'A', 7, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (18, 1, 3, N'A', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (19, 2, 3, N'B', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (20, 2, 3, N'B', 2, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (21, 2, 3, N'B', 3, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (22, 2, 3, N'B', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (23, 2, 3, N'B', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (24, 2, 3, N'B', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (25, 2, 3, N'B', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (26, 2, 3, N'B', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (27, 3, 3, N'C', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (28, 3, 3, N'C', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (29, 3, 3, N'C', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (30, 3, 3, N'C', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (31, 3, 3, N'C', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (32, 3, 3, N'C', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (33, 3, 3, N'C', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (34, 3, 3, N'C', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (35, 1, 3, N'D', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (36, 1, 3, N'D', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (37, 1, 3, N'D', 3, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (38, 1, 3, N'D', 4, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (39, 1, 3, N'D', 5, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (40, 1, 3, N'D', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (41, 1, 3, N'D', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (42, 1, 3, N'D', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (43, 2, 3, N'E', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (44, 2, 3, N'E', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (45, 2, 3, N'E', 3, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (46, 2, 3, N'E', 4, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (47, 2, 3, N'E', 5, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (48, 2, 3, N'E', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (49, 2, 3, N'E', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (50, 2, 3, N'E', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (51, 2, 3, N'E', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (52, 2, 3, N'E', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (53, 2, 3, N'E', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (54, 2, 3, N'E', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (55, 2, 3, N'E', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (56, 2, 3, N'E', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (57, 2, 3, N'E', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (58, 2, 3, N'E', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (59, 1, 3, N'F', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (60, 1, 3, N'F', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (61, 1, 3, N'F', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (62, 1, 3, N'F', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (63, 1, 3, N'F', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (64, 1, 3, N'F', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (65, 1, 3, N'F', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (66, 1, 3, N'F', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (67, 2, 3, N'G', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (68, 2, 3, N'G', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (69, 2, 3, N'G', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (70, 2, 3, N'G', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (71, 2, 3, N'G', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (72, 2, 3, N'G', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (73, 2, 3, N'G', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (74, 2, 3, N'G', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (75, 3, 3, N'H', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (76, 3, 3, N'H', 2, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (77, 3, 3, N'H', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (78, 3, 3, N'H', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (79, 3, 3, N'H', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (80, 3, 3, N'H', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (81, 3, 3, N'H', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (82, 3, 3, N'H', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (83, 1, 3, N'I', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (84, 1, 3, N'I', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (85, 1, 3, N'I', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (86, 1, 3, N'I', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (87, 1, 3, N'I', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (88, 1, 3, N'I', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (89, 1, 3, N'I', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (90, 1, 3, N'I', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (91, 2, 3, N'J', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (92, 2, 3, N'J', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (93, 2, 3, N'J', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (94, 2, 3, N'J', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (95, 2, 3, N'J', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (96, 2, 3, N'J', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (97, 2, 3, N'J', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (98, 2, 3, N'J', 8, 0)
SET IDENTITY_INSERT [dbo].[Seat] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketSeatAssignments] ON 

INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (38, 41, 11)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (39, 42, 11)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (40, 43, 12)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (41, 44, 13)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (42, 45, 14)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (43, 46, 15)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (44, 47, 16)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (45, 48, 17)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (46, 49, 21)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (47, 50, 37)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (48, 50, 38)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (49, 50, 39)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (50, 51, 47)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (51, 51, 46)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (52, 51, 45)
SET IDENTITY_INSERT [dbo].[TicketSeatAssignments] OFF
GO
