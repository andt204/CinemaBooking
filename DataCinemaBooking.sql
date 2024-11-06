USE [master]
GO
/****** Object:  Database [CinemaBooking]    Script Date: 11/6/2024 9:36:01 PM ******/
CREATE DATABASE [CinemaBooking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CinemaBooking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CinemaBooking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CinemaBooking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CinemaBooking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CinemaBooking] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinemaBooking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinemaBooking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinemaBooking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinemaBooking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinemaBooking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinemaBooking] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinemaBooking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinemaBooking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinemaBooking] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CinemaBooking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinemaBooking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinemaBooking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinemaBooking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinemaBooking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinemaBooking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinemaBooking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinemaBooking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinemaBooking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinemaBooking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinemaBooking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinemaBooking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinemaBooking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinemaBooking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinemaBooking] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CinemaBooking] SET  MULTI_USER 
GO
ALTER DATABASE [CinemaBooking] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CinemaBooking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CinemaBooking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CinemaBooking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CinemaBooking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CinemaBooking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CinemaBooking] SET QUERY_STORE = OFF
GO
USE [CinemaBooking]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Avatar] [nvarchar](255) NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[DateOfBirth] [date] NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK__account__46A222CD53CD87B8] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[ActorName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActorMovieAssignments]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovieAssignments](
	[ActorMovieId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[ActorId] [int] NOT NULL,
 CONSTRAINT [PK__MovieAct__EEA9AABEAA76A3E9] PRIMARY KEY CLUSTERED 
(
	[ActorMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NULL,
	[PostId] [int] NULL,
	[AccountId] [int] NOT NULL,
	[Status] [tinyint] NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[CommentType] [tinyint] NOT NULL,
 CONSTRAINT [PK__comment__E7957687A0D65E34] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[DirectorId] [int] IDENTITY(1,1) NOT NULL,
	[DirectorName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Length] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[AgeLimit] [int] NOT NULL,
	[WarningText] [nvarchar](max) NULL,
	[PublishTime] [datetime] NOT NULL,
	[Country] [nvarchar](50) NULL,
	[Image] [nvarchar](255) NULL,
	[ImageBackground] [nvarchar](255) NULL,
	[Status] [tinyint] NOT NULL,
	[DirectorId] [int] NOT NULL,
	[VideoTrailer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__movie__83CDF74958A2A4FB] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieCategoryAssignments]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieCategoryAssignments](
	[MovieCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_MovieCategoryAssignments] PRIMARY KEY CLUSTERED 
(
	[MovieCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[AccountId] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK__Post__AA126018E05A2A62] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeId] [int] NOT NULL,
	[TheaterId] [int] NULL,
	[RoomName] [nvarchar](100) NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK__room__19675A8A4D60A5AE] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeName] [nvarchar](100) NOT NULL,
	[NumberOfSeat] [int] NULL,
	[NumberOfColumn] [int] NULL,
	[NumberOfRow] [int] NULL,
 CONSTRAINT [PK__room_typ__42395E8498196B71] PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seat]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seat](
	[SeatId] [int] IDENTITY(1,1) NOT NULL,
	[SeatTypeId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[Row] [nvarchar](50) NOT NULL,
	[Column] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK__seat__906DED9C9112E8C4] PRIMARY KEY CLUSTERED 
(
	[SeatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeatType]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeatType](
	[SeatTypeId] [int] IDENTITY(1,1) NOT NULL,
	[SeatTypeName] [nvarchar](100) NOT NULL,
	[SeatPrice] [decimal](10, 2) NULL,
 CONSTRAINT [PK__seat_typ__5C2EB1974D861E93] PRIMARY KEY CLUSTERED 
(
	[SeatTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Showtime]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Showtime](
	[ShowtimeId] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NULL,
	[StartHour] [time](7) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK__event__2370F727FC3A18F3] PRIMARY KEY CLUSTERED 
(
	[ShowtimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShowtimeMovieAssignments]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowtimeMovieAssignments](
	[ShowtimeMovieId] [int] IDENTITY(1,1) NOT NULL,
	[ShowtimeId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ShowtimeMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[ShowtimeId] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[BookingTime] [datetime] NOT NULL,
	[TicketPrice] [decimal](10, 2) NULL,
 CONSTRAINT [PK__ticket__D596F96B0D9BCFF2] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketMovieAssignments]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketMovieAssignments](
	[TicketMovieId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketSeatAssignments]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketSeatAssignments](
	[TicketSeatId] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NULL,
	[SeatId] [int] NULL,
 CONSTRAINT [PK_TicketSeatAssignments] PRIMARY KEY CLUSTERED 
(
	[TicketSeatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theater]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theater](
	[TheaterId] [int] NOT NULL,
	[TheaterName] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
 CONSTRAINT [PK_Theater] PRIMARY KEY CLUSTERED 
(
	[TheaterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 11/6/2024 9:36:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[VoteId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[MovieId] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[VoteDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (6, 4, NULL, 6, 1, N'Great movie!', CAST(N'2024-10-22T10:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (7, 2, NULL, 2, 1, N'Not bad!', CAST(N'2024-10-22T10:05:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (8, 5, NULL, 3, 1, N'Loved the action scenes!', CAST(N'2024-10-22T10:10:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (9, 3, NULL, 4, 1, N'Could have been better.', CAST(N'2024-10-22T10:15:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Comment] ([CommentId], [MovieId], [PostId], [AccountId], [Status], [Content], [CreatedAt], [UpdatedAt], [CommentType]) VALUES (10, 2, NULL, 5, 1, N'Amazing storyline!', CAST(N'2024-10-22T10:20:00.000' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Comment] OFF
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
SET IDENTITY_INSERT [dbo].[MovieCategoryAssignments] ON 

INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (2, 2, 2)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (3, 3, 3)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (4, 4, 4)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (5, 5, 5)
INSERT [dbo].[MovieCategoryAssignments] ([MovieCategoryId], [MovieId], [CategoryId]) VALUES (6, 6, 1)
SET IDENTITY_INSERT [dbo].[MovieCategoryAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (3, N'Avengers Review', N'A review of Avengers: Endgame', CAST(N'2024-10-22T10:00:00.000' AS DateTime), NULL, 6, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (4, N'Inception Explained', N'A deep dive into Inception', CAST(N'2024-10-22T10:05:00.000' AS DateTime), NULL, 2, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (5, N'Titanic: A Timeless Story', N'Review of the Titanic movie', CAST(N'2024-10-22T10:10:00.000' AS DateTime), NULL, 3, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (6, N'Pulp Fiction Analysis', N'A breakdown of Pulp Fiction', CAST(N'2024-10-22T10:15:00.000' AS DateTime), NULL, 4, 1)
INSERT [dbo].[Post] ([PostId], [Title], [Content], [CreatedDate], [ModifiedDate], [AccountId], [Status]) VALUES (7, N'The Irishman: A Masterpiece', N'Thoughts on The Irishman', CAST(N'2024-10-22T10:20:00.000' AS DateTime), NULL, 5, 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Customer')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (2, 1, 2, N'Room A', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (3, 2, 2, N'Room B', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (4, 3, 4, N'Room C', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (5, 4, 3, N'Room D', 1)
INSERT [dbo].[Room] ([RoomId], [RoomTypeId], [TheaterId], [RoomName], [Status]) VALUES (6, 5, 4, N'Room E', 1)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomType] ON 

INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (1, N'Standard', 50, 7, 6)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (2, N'VIP', 55, 8, 10)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (3, N'IMAX', 60, 4, 3)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (4, N'4DX', 65, 5, 6)
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeName], [NumberOfSeat], [NumberOfColumn], [NumberOfRow]) VALUES (5, N'Private', 70, 7, 10)
SET IDENTITY_INSERT [dbo].[RoomType] OFF
GO
SET IDENTITY_INSERT [dbo].[Seat] ON 

INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (11, 1, 3, N'A', 1, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (12, 1, 3, N'A', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (13, 1, 3, N'A', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (14, 1, 3, N'A', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (15, 1, 3, N'A', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (16, 1, 3, N'A', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (17, 1, 3, N'A', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (18, 1, 3, N'A', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (19, 2, 3, N'B', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (20, 2, 3, N'B', 2, 1)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (21, 2, 3, N'B', 3, 0)
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
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (37, 1, 3, N'D', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (38, 1, 3, N'D', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (39, 1, 3, N'D', 5, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (40, 1, 3, N'D', 6, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (41, 1, 3, N'D', 7, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (42, 1, 3, N'D', 8, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (43, 2, 3, N'E', 1, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (44, 2, 3, N'E', 2, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (45, 2, 3, N'E', 3, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (46, 2, 3, N'E', 4, 0)
INSERT [dbo].[Seat] ([SeatId], [SeatTypeId], [RoomId], [Row], [Column], [Status]) VALUES (47, 2, 3, N'E', 5, 0)
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
SET IDENTITY_INSERT [dbo].[SeatType] ON 

INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (1, N'Regular', CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (2, N'Premium', CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[SeatType] ([SeatTypeId], [SeatTypeName], [SeatPrice]) VALUES (3, N'VIP', CAST(150000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[SeatType] OFF
GO
SET IDENTITY_INSERT [dbo].[Showtime] ON 

INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date]) VALUES (2, 3, CAST(N'12:00:00' AS Time), CAST(N'2024-11-06' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date]) VALUES (3, 3, CAST(N'14:00:00' AS Time), CAST(N'2024-11-06' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date]) VALUES (4, 3, CAST(N'16:00:00' AS Time), CAST(N'2024-11-09' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date]) VALUES (5, 3, CAST(N'18:00:00' AS Time), CAST(N'2024-11-08' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date]) VALUES (6, 3, CAST(N'20:00:00' AS Time), CAST(N'2024-11-08' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date]) VALUES (10, 4, CAST(N'12:00:00' AS Time), CAST(N'2024-11-07' AS Date))
INSERT [dbo].[Showtime] ([ShowtimeId], [RoomId], [StartHour], [Date]) VALUES (11, 5, CAST(N'15:00:00' AS Time), CAST(N'2024-11-07' AS Date))
SET IDENTITY_INSERT [dbo].[Showtime] OFF
GO
SET IDENTITY_INSERT [dbo].[ShowtimeMovieAssignments] ON 

INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (2, 2, 3)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (3, 3, 3)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (4, 4, 3)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (5, 10, 3)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (6, 5, 3)
INSERT [dbo].[ShowtimeMovieAssignments] ([ShowtimeMovieId], [ShowtimeId], [MovieId]) VALUES (7, 6, 3)
SET IDENTITY_INSERT [dbo].[ShowtimeMovieAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (41, 8, 3, 4, CAST(N'2024-11-06T09:50:02.937' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ticket] ([TicketId], [AccountId], [ShowtimeId], [Status], [BookingTime], [TicketPrice]) VALUES (42, 7, 3, 4, CAST(N'2024-11-06T09:50:13.857' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketMovieAssignments] ON 

INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId]) VALUES (30, 41, 3)
INSERT [dbo].[TicketMovieAssignments] ([TicketMovieId], [TicketId], [MovieId]) VALUES (31, 42, 3)
SET IDENTITY_INSERT [dbo].[TicketMovieAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[TicketSeatAssignments] ON 

INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (38, 41, 11)
INSERT [dbo].[TicketSeatAssignments] ([TicketSeatId], [TicketId], [SeatId]) VALUES (39, 42, 11)
SET IDENTITY_INSERT [dbo].[TicketSeatAssignments] OFF
GO
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (1, N'Theater A', N'Location A')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (2, N'Theater B', N'Location B')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (3, N'Theater C', N'Location C')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (4, N'Theater D', N'Location D')
INSERT [dbo].[Theater] ([TheaterId], [TheaterName], [Location]) VALUES (5, N'Theater E', N'Location E')
GO
SET IDENTITY_INSERT [dbo].[Vote] ON 

INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (1, 6, 4, 5, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (2, 2, 2, 4, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (3, 3, 3, 3, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (4, 4, 4, 4, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
INSERT [dbo].[Vote] ([VoteId], [AccountId], [MovieId], [Rating], [VoteDate]) VALUES (5, 5, 2, 5, CAST(N'2024-10-23T10:56:48.473' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vote] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__account__F3DBC57261217132]    Script Date: 11/6/2024 9:36:01 PM ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [UQ__account__F3DBC57261217132] UNIQUE NONCLUSTERED 
(
	[FullName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vote] ADD  DEFAULT (getdate()) FOR [VoteDate]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK__account__role_id__300424B4] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK__account__role_id__300424B4]
GO
ALTER TABLE [dbo].[ActorMovieAssignments]  WITH CHECK ADD  CONSTRAINT [FK__MovieActo__Actor__6C190EBB] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ActorId])
GO
ALTER TABLE [dbo].[ActorMovieAssignments] CHECK CONSTRAINT [FK__MovieActo__Actor__6C190EBB]
GO
ALTER TABLE [dbo].[ActorMovieAssignments]  WITH CHECK ADD  CONSTRAINT [FK__MovieActo__Movie__6B24EA82] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[ActorMovieAssignments] CHECK CONSTRAINT [FK__MovieActo__Movie__6B24EA82]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Account]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Movie]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Post]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Director] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Director] ([DirectorId])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Director]
GO
ALTER TABLE [dbo].[MovieCategoryAssignments]  WITH CHECK ADD  CONSTRAINT [FK_MovieCategoryAssignments_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[MovieCategoryAssignments] CHECK CONSTRAINT [FK_MovieCategoryAssignments_Category]
GO
ALTER TABLE [dbo].[MovieCategoryAssignments]  WITH CHECK ADD  CONSTRAINT [FK_MovieCategoryAssignments_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[MovieCategoryAssignments] CHECK CONSTRAINT [FK_MovieCategoryAssignments_Movie]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Ticket]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Account]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK__room__room_type___2C3393D0] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([RoomTypeId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK__room__room_type___2C3393D0]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Theater] FOREIGN KEY([TheaterId])
REFERENCES [dbo].[Theater] ([TheaterId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Theater]
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD  CONSTRAINT [FK__seat__room_id__398D8EEE] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[Seat] CHECK CONSTRAINT [FK__seat__room_id__398D8EEE]
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD  CONSTRAINT [FK__seat__seat_type___38996AB5] FOREIGN KEY([SeatTypeId])
REFERENCES [dbo].[SeatType] ([SeatTypeId])
GO
ALTER TABLE [dbo].[Seat] CHECK CONSTRAINT [FK__seat__seat_type___38996AB5]
GO
ALTER TABLE [dbo].[Showtime]  WITH CHECK ADD  CONSTRAINT [FK_Showtime_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[Showtime] CHECK CONSTRAINT [FK_Showtime_Room]
GO
ALTER TABLE [dbo].[ShowtimeMovieAssignments]  WITH CHECK ADD  CONSTRAINT [FK__event_fil__event__34C8D9D1] FOREIGN KEY([ShowtimeId])
REFERENCES [dbo].[Showtime] ([ShowtimeId])
GO
ALTER TABLE [dbo].[ShowtimeMovieAssignments] CHECK CONSTRAINT [FK__event_fil__event__34C8D9D1]
GO
ALTER TABLE [dbo].[ShowtimeMovieAssignments]  WITH CHECK ADD  CONSTRAINT [FK__event_fil__movie__35BCFE0A] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[ShowtimeMovieAssignments] CHECK CONSTRAINT [FK__event_fil__movie__35BCFE0A]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Account]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Showtime] FOREIGN KEY([ShowtimeId])
REFERENCES [dbo].[Showtime] ([ShowtimeId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Showtime]
GO
ALTER TABLE [dbo].[TicketMovieAssignments]  WITH CHECK ADD  CONSTRAINT [FK__ticket_fi__movie__4316F928] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[TicketMovieAssignments] CHECK CONSTRAINT [FK__ticket_fi__movie__4316F928]
GO
ALTER TABLE [dbo].[TicketMovieAssignments]  WITH CHECK ADD  CONSTRAINT [FK__ticket_fi__ticke__4222D4EF] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[TicketMovieAssignments] CHECK CONSTRAINT [FK__ticket_fi__ticke__4222D4EF]
GO
ALTER TABLE [dbo].[TicketSeatAssignments]  WITH CHECK ADD  CONSTRAINT [FK_TicketSeatAssignments_Seat] FOREIGN KEY([SeatId])
REFERENCES [dbo].[Seat] ([SeatId])
GO
ALTER TABLE [dbo].[TicketSeatAssignments] CHECK CONSTRAINT [FK_TicketSeatAssignments_Seat]
GO
ALTER TABLE [dbo].[TicketSeatAssignments]  WITH CHECK ADD  CONSTRAINT [FK_TicketSeatAssignments_Ticket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[TicketSeatAssignments] CHECK CONSTRAINT [FK_TicketSeatAssignments_Ticket]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Account]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Movie]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
USE [master]
GO
ALTER DATABASE [CinemaBooking] SET  READ_WRITE 
GO
