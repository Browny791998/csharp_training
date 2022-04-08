USE [MovieRenting]
GO
/****** Object:  Table [dbo].[tbl_customer]    Script Date: 4/8/2022 3:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[salutation_id] [int] NULL,
	[full_name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_movie]    Script Date: 4/8/2022 3:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_movie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movie] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_movie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_movierenting]    Script Date: 4/8/2022 3:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_movierenting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[movie_id] [int] NULL,
	[customer_id] [int] NULL,
 CONSTRAINT [PK_tbl_movierenting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_salutation]    Script Date: 4/8/2022 3:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salutation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[salutation] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Salutation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 4/8/2022 3:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_user_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[GetMovieRentingData]    Script Date: 4/8/2022 3:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[GetMovieRentingData] as 
SELECT  tbl_movierenting.id, ROW_NUMBER() OVER (ORDER BY tbl_movierenting.id) No, tbl_salutation.salutation as Salutation, tbl_customer.full_name AS Name, tbl_customer.address as Address, tbl_movie.movie as Movie,tbl_movierenting.customer_id,tbl_movierenting.movie_id
FROM     tbl_customer, tbl_movierenting, tbl_salutation, tbl_movie
WHERE  tbl_salutation.id = tbl_customer.salutation_id AND tbl_movie.id = tbl_movierenting.movie_id AND tbl_customer.id = tbl_movierenting.customer_id
GO
/****** Object:  View [dbo].[vGetAllMovieRentingData]    Script Date: 4/8/2022 3:41:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[vGetAllMovieRentingData] as
Select tbl_movierenting.id,tbl_salutation.salutation,tbl_customer.full_name,tbl_customer.address,tbl_movie.movie from tbl_customer,tbl_movierenting,tbl_salutation,tbl_movie Where  tbl_salutation.id = tbl_customer.salutation_id AND tbl_movie.id = tbl_movierenting.movie_id AND tbl_customer.id = tbl_movierenting.customer_id
GO
SET IDENTITY_INSERT [dbo].[tbl_customer] ON 

INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address], [email]) VALUES (1, 55, N'YeHtet', N'First Street Plot No 4', N'yehtetaung791998@gmail.com')
INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address], [email]) VALUES (3, 55, N'MyoMin', N'Second Street Plot No 35', N'donotbelievepeople@gmail.com')
INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address], [email]) VALUES (4, 55, N'MinMyo', N'Sixth Street Plot No 9', N'myominhtay01.mmh@gmail.com')
INSERT [dbo].[tbl_customer] ([id], [salutation_id], [full_name], [address], [email]) VALUES (5, 55, N'MyoMyo', N'Fifth Street Plot No 19', N'frozenswordfs077@gmail.com')
SET IDENTITY_INSERT [dbo].[tbl_customer] OFF
SET IDENTITY_INSERT [dbo].[tbl_movie] ON 

INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (1, N'Clash of Titans')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (2, N'Iron Man')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (3, N'Hotal trayslayvia')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (5, N'Mission Impossible 3')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (7, N'Avengers')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (39, N'dragon ball')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (40, N'dune')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (41, N'james bond')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (44, N'encanto')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (45, N'maleficent')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (47, N'toy story')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (48, N'daredevil')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (49, N'superman')
INSERT [dbo].[tbl_movie] ([id], [movie]) VALUES (50, N'justice league')
SET IDENTITY_INSERT [dbo].[tbl_movie] OFF
SET IDENTITY_INSERT [dbo].[tbl_movierenting] ON 

INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (1, 2, 3)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (2, 3, 6)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (4, 3, 5)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (5, 6, 1)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (6, 6, 5)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (9, 1, 10)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (10, 11, 5)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (13, 5, 15)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (14, 2, 6)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (19, 2, 10)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (20, 3, 11)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (21, 3, 18)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (22, 2, 18)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (23, 7, 19)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (24, 5, 20)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (25, 29, 19)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (26, 3, 22)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (27, 5, 21)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (28, 50, 19)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (29, 48, 24)
INSERT [dbo].[tbl_movierenting] ([id], [movie_id], [customer_id]) VALUES (30, 41, 23)
SET IDENTITY_INSERT [dbo].[tbl_movierenting] OFF
SET IDENTITY_INSERT [dbo].[tbl_salutation] ON 

INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (55, N'Mr')
INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (56, N'Ms')
INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (57, N'Jr')
INSERT [dbo].[tbl_salutation] ([id], [salutation]) VALUES (58, N'Tr')
SET IDENTITY_INSERT [dbo].[tbl_salutation] OFF
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

INSERT [dbo].[tbl_user] ([id], [name], [email], [password]) VALUES (1, N'YeHtet', N'yha@gmail.com', N'yha111')
INSERT [dbo].[tbl_user] ([id], [name], [email], [password]) VALUES (2, N'Jonas', N'jn@gmail.com', N'jn222')
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
