USE [JobPortal]
GO
/****** Object:  Table [dbo].[tbl_company]    Script Date: 3/18/2022 1:36:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[country_id] [int] NULL,
	[address] [nvarchar](50) NULL,
	[contact_person] [nvarchar](50) NULL,
	[mobile] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[website] [nvarchar](50) NULL,
	[role] [nvarchar](50) NULL,
	[detail] [nvarchar](max) NULL,
	[active] [smallint] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_tbl_company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_country]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[country] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_job]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_job](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[degree] [nvarchar](50) NULL,
	[skill] [nvarchar](50) NULL,
	[experience] [nvarchar](50) NULL,
	[vacancy] [int] NULL,
	[company_id] [int] NULL,
	[position_id] [int] NULL,
	[job_nature_id] [int] NULL,
	[salary] [int] NULL,
	[detail] [nvarchar](max) NULL,
	[active] [smallint] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_tbl_job] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_jobnature]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_jobnature](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[job_nature] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_jobnature] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_joboffer]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_joboffer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[job_seeker_id] [int] NULL,
	[company_id] [int] NULL,
	[job_id] [int] NULL,
	[is_accept] [smallint] NULL,
 CONSTRAINT [PK_tbl_joboffer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_jobseeker]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_jobseeker](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[mobile] [int] NULL,
	[gender] [nvarchar](50) NULL,
	[dob] [datetime] NULL,
	[skill] [nvarchar](50) NULL,
	[experience] [nvarchar](50) NULL,
	[degree] [nvarchar](50) NULL,
	[degree_name] [nvarchar](50) NULL,
	[cvform] [nvarchar](50) NULL,
	[profile] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[detail] [nvarchar](max) NULL,
	[role] [nvarchar](20) NULL,
	[active] [smallint] NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_tbl_jobseeker] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_position]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[position] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_position] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_reset_password]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_reset_password](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [nvarchar](50) NULL,
	[requestdatetime] [datetime] NULL,
 CONSTRAINT [PK_tbl_reset_password] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_skill]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_skill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[skill] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_skill] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 3/18/2022 1:36:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[role] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_jobseeker] ON 

INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (1, N'dd', N'ee', 333, N'Male', CAST(0x0000AE4C00000000 AS DateTime), N'C#', N'4 years', N'Y', N'Bsc', N'mycv', N'myprofile', N'sam@gmail.com', N'222333', N'ff', N'Job Seeker', 1, CAST(0x0000AE5B0145BAAF AS DateTime), CAST(0x0000AE5B0145BAAF AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (2, N'Mg', N'dfsfs', 33333, N'Male', CAST(0x0000AE6400000000 AS DateTime), N'Java,Python', N'3 years', N'Under Graduate', N'Bsc', N'mycv', N'myprofile', N'mgmg@gmail.com', N'55555', N'yuooioi', N'Job Seeker', 1, CAST(0x0000AE5B014BD8D7 AS DateTime), CAST(0x0000AE5B014BD8D7 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (3, N'vxv', N'etet', 978989, N'Male', CAST(0x0000AE4D00000000 AS DateTime), N'Java', N'2 years', N'Under Graduate', N'Student', N'mycv', N'~/Profile/2.jpg', N'jj@gmail.com', N'55565', N'fsf', N'Job Seeker', 1, CAST(0x0000AE5B014F899D AS DateTime), CAST(0x0000AE5B014F899D AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (4, N'fff', N'dfs', 65464, N'Female', CAST(0x0000AE6800000000 AS DateTime), N'Java', N'2 years', N'Under Graduate', N'Student', N'~/CV/My CV Form.docx', N'~/Profile/Flowerlady.jpg', N'ff@gmail.com', N'445tty', N'fsfs', N'Job Seeker', 1, CAST(0x0000AE5B0150DAA2 AS DateTime), CAST(0x0000AE5B0150DAA2 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (5, N'Kyaw Kyaw 2', N'North Dagon,Yangon', 9887364, N'Male', CAST(0x00008C7900000000 AS DateTime), N'Python', N'6 years', N'Graduate', N'Bsc', N'~/CV/My CV Form.docx', N'~/Profile/thOHJEB78A.jpg', N'KK@gmail.com', N'KK33333', N'Worked as PHP developer in SCM company blah blah blah', N'Job Seeker', 1, CAST(0x0000AE5B016C4878 AS DateTime), CAST(0x0000AE5C00199B4F AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_jobseeker] OFF
ALTER TABLE [dbo].[tbl_company] ADD  CONSTRAINT [DF_tbl_company_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[tbl_job] ADD  CONSTRAINT [DF_tbl_job_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[tbl_jobseeker] ADD  CONSTRAINT [DF_tbl_jobseeker_degree_name]  DEFAULT (N'Student') FOR [degree_name]
GO
ALTER TABLE [dbo].[tbl_jobseeker] ADD  CONSTRAINT [DF_tbl_jobseeker_active]  DEFAULT ((1)) FOR [active]
GO
