USE [MovieRenting]
GO
/****** Object:  Table [dbo].[tbl_Movie]    Script Date: 2/17/2022 12:32:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Movie](
	[MOVIES_RENTED] [nvarchar](50) NULL,
	[USER_ID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Salutation]    Script Date: 2/17/2022 12:32:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Salutation](
	[id] [int] NOT NULL,
	[SALUTATION] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Salutation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 2/17/2022 12:32:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[id] [int] NOT NULL,
	[FULL_NAME] [nvarchar](50) NULL,
	[ADDRESS] [nvarchar](50) NULL,
	[SALUTATION] [int] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tbl_Movie] ([MOVIES_RENTED], [USER_ID]) VALUES (N'Daddy''s Little Girls', 1)
INSERT [dbo].[tbl_Movie] ([MOVIES_RENTED], [USER_ID]) VALUES (N'Clash of the Titans', 1)
INSERT [dbo].[tbl_Movie] ([MOVIES_RENTED], [USER_ID]) VALUES (N'Forgetting Sarah Marshal', 2)
INSERT [dbo].[tbl_Movie] ([MOVIES_RENTED], [USER_ID]) VALUES (N'Clash of the Titans', 2)
INSERT [dbo].[tbl_Movie] ([MOVIES_RENTED], [USER_ID]) VALUES (N'Daddy''s Little Girls', 3)
INSERT [dbo].[tbl_Salutation] ([id], [SALUTATION]) VALUES (1, N'Mr')
INSERT [dbo].[tbl_Salutation] ([id], [SALUTATION]) VALUES (2, N'Ms')
INSERT [dbo].[tbl_User] ([id], [FULL_NAME], [ADDRESS], [SALUTATION]) VALUES (1, N'Sandy', N'First Street Plot No 4', 2)
INSERT [dbo].[tbl_User] ([id], [FULL_NAME], [ADDRESS], [SALUTATION]) VALUES (2, N'John', N'Second Street Plot No 5', 1)
INSERT [dbo].[tbl_User] ([id], [FULL_NAME], [ADDRESS], [SALUTATION]) VALUES (3, N'Jonet Jones', N'Second Street Plot No 7', 1)
