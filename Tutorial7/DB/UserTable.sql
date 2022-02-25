USE [USER_LOGIN]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 2/25/2022 4:31:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [smallint] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_User] ON 

INSERT [dbo].[tbl_User] ([id], [Name], [Password], [Status]) VALUES (1, N'Admin@gmail.com', N'admin123', 0)
INSERT [dbo].[tbl_User] ([id], [Name], [Password], [Status]) VALUES (2, N'Bobby@gmail.com', N'bbb333', 0)
INSERT [dbo].[tbl_User] ([id], [Name], [Password], [Status]) VALUES (3, N'Henry@gmail.com', N'hhh123', 0)
SET IDENTITY_INSERT [dbo].[tbl_User] OFF
