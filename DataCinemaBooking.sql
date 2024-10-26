USE [CinemaBooking]
GO
SET IDENTITY_INSERT [dbo].[SeatType] ON 

INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (1, N'Regular', CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (2, N'Premium', CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (3, N'VIP', CAST(150000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (4, N'Recliner', CAST(200000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (5, N'Loveseat', CAST(250000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[SeatType] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON 

INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (1, N'Standard', 50, 7, 6)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (2, N'VIP', 55, 8, 10)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (3, N'IMAX', 60, 4, 3)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (4, N'4DX', 65, 5, 6)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (5, N'Private', 70, 7, 10)
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [RoomName], [Status]) VALUES (2, 1, N'Room A', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [RoomName], [Status]) VALUES (3, 2, N'Room B', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [RoomName], [Status]) VALUES (4, 3, N'Room C', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [RoomName], [Status]) VALUES (5, 4, N'Room D', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [RoomName], [Status]) VALUES (6, 5, N'Room E', 1)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Seat] ON 

INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (4, 1, 3, N'A', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (5, 1, 3, N'B', 2, 2)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (6, 2, 3, N'C', 3, 2)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (7, 1, 3, N'D', 4, 2)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (8, 1, 3, N'E', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (10, 3, 3, N'E', 4, 0)
SET IDENTITY_INSERT [dbo].[Seat] OFF
GO
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (1, N'Theater A', N'Location A')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (2, N'Theater B', N'Location B')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (3, N'Theater C', N'Location C')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (4, N'Theater D', N'Location D')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (5, N'Theater E', N'Location E')
GO
SET IDENTITY_INSERT [dbo].[Showtime] ON 

INSERT [dbo].[Showtime] ([ShowtimeId], [TheaterId], [RoomId], [StartHour], [Date]) VALUES (2, 1, 2, CAST(N'12:00:00' AS Time), CAST(N'2024-10-23' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [TheaterId], [RoomId], [StartHour], [Date]) VALUES (3, 2, 3, CAST(N'14:00:00' AS Time), CAST(N'2024-10-24' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [TheaterId], [RoomId], [StartHour], [Date]) VALUES (4, 3, 4, CAST(N'16:00:00' AS Time), CAST(N'2024-10-25' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [TheaterId], [RoomId], [StartHour], [Date]) VALUES (5, 1, 5, CAST(N'18:00:00' AS Time), CAST(N'2024-10-26' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [TheaterId], [RoomId], [StartHour], [Date]) VALUES (6, 2, 6, CAST(N'20:00:00' AS Time), CAST(N'2024-10-27' AS Date))
SET IDENTITY_INSERT [dbo].[Showtime] OFF
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
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (5, 6, 2, 1, CAST(N'2024-10-23T12:30:00.000' AS DateTime), NULL)
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (6, 2, 3, 1, CAST(N'2024-10-24T14:30:00.000' AS DateTime), NULL)
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (7, 3, 4, 1, CAST(N'2024-10-25T16:30:00.000' AS DateTime), NULL)
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (8, 4, 5, 1, CAST(N'2024-10-26T18:30:00.000' AS DateTime), NULL)
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (9, 5, 6, 1, CAST(N'2024-10-27T20:30:00.000' AS DateTime), NULL)
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (10, 7, 3, 4, CAST(N'2024-10-26T21:29:11.837' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (11, 7, 3, 4, CAST(N'2024-10-26T21:33:23.960' AS DateTime), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (12, 7, 3, 4, CAST(N'2024-10-26T21:42:33.167' AS DateTime), CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (13, 7, 3, 4, CAST(N'2024-10-26T21:42:40.173' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (14, 7, 3, 4, CAST(N'2024-10-26T21:42:50.223' AS DateTime), CAST(200000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (15, 7, 3, 4, CAST(N'2024-10-26T21:50:51.327' AS DateTime), CAST(300000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (18, 7, 3, 4, CAST(N'2024-10-26T23:20:18.017' AS DateTime), CAST(200000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Ticket] OFF
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
SET IDENTITY_INSERT [dbo].[TicketMovieAssignments] ON 

INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId], [RoomId]) VALUES (9, 9, 4, 6)
INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId], [RoomId]) VALUES (10, 5, 2, 2)
INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId], [RoomId]) VALUES (11, 6, 3, 3)
INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId], [RoomId]) VALUES (12, 7, 4, 4)
INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId], [RoomId]) VALUES (13, 8, 2, 5)
SET IDENTITY_INSERT [dbo].[TicketMovieAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketSeatAssignments] ON 

INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (1, 5, 4)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (2, 5, 5)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (3, 5, 6)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (4, 5, 7)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (5, 10, 7)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (7, 18, 5)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (8, 18, 6)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (9, 18, 7)
SET IDENTITY_INSERT [dbo].[TicketSeatAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[ShowtimeMovieAssignments] ON 

INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (2, 6, 4)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (3, 2, 2)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (4, 3, 3)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (5, 4, 4)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (6, 5, 2)
SET IDENTITY_INSERT [dbo].[ShowtimeMovieAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Action')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Comedy')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Drama')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Sci-Fi')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (5, N'Horror')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (2, 2, 2)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (3, 3, 3)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (4, 4, 4)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (5, 5, 5)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (6, 6, 1)
GO
SET IDENTITY_INSERT [dbo].[Vote] ON 

INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (1, 6, 4, 5, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (2, 2, 2, 4, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (3, 3, 3, 3, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (4, 4, 4, 4, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (5, 5, 2, 5, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vote] OFF
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
SET IDENTITY_INSERT [dbo].[Actor] ON 

INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (1, N'Robert Downey Jr.')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (2, N'Scarlett Johansson')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (3, N'Chris Evans')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (4, N'Chris Hemsworth')
INSERT [dbo].[Actor] ([ActorId], [ActorName]) VALUES (5, N'Mark Ruffalo')
SET IDENTITY_INSERT [dbo].[Actor] OFF
GO
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (1, 4, 1)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (2, 4, 2)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (3, 2, 3)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (4, 2, 4)
INSERT [dbo].[ActorMovieAssignments] ([ActorMovieId], [MovieId], [ActorId]) VALUES (5, 3, 5)
GO
