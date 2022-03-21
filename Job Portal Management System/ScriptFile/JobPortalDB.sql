USE [JobPortal]
GO
/****** Object:  Table [dbo].[tbl_company]    Script Date: 3/22/2022 1:10:33 AM ******/
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
	[mobile] [int] NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
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
/****** Object:  Table [dbo].[tbl_country]    Script Date: 3/22/2022 1:10:34 AM ******/
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
/****** Object:  Table [dbo].[tbl_job]    Script Date: 3/22/2022 1:10:34 AM ******/
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
	[specialization_id] [int] NULL,
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
/****** Object:  Table [dbo].[tbl_jobnature]    Script Date: 3/22/2022 1:10:34 AM ******/
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
/****** Object:  Table [dbo].[tbl_joboffer]    Script Date: 3/22/2022 1:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_joboffer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[job_seeker_id] [int] NULL,
	[company_id] [int] NULL,
	[job_id] [int] NULL,
	[applied_date] [date] NULL,
	[is_accept] [smallint] NULL,
 CONSTRAINT [PK_tbl_joboffer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_jobseeker]    Script Date: 3/22/2022 1:10:34 AM ******/
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
/****** Object:  Table [dbo].[tbl_position]    Script Date: 3/22/2022 1:10:34 AM ******/
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
/****** Object:  Table [dbo].[tbl_reset_password]    Script Date: 3/22/2022 1:10:34 AM ******/
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
/****** Object:  Table [dbo].[tbl_skill]    Script Date: 3/22/2022 1:10:34 AM ******/
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
/****** Object:  Table [dbo].[tbl_specialization]    Script Date: 3/22/2022 1:10:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_specialization](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[specialization] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_specialization] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 3/22/2022 1:10:34 AM ******/
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
SET IDENTITY_INSERT [dbo].[tbl_company] ON 

INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (1, N'Brighter Company', 2, N'Hlaing,30th street', N'U Myint', 988765, N'bb777@gmail.com', N'YmI3Nzc=', N'brighter.mm.com', N'Company', N'we currenly do window app ', 1, CAST(0x0000AE5E011595EB AS DateTime), CAST(0x0000AE5E0121F586 AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (2, N'BSS company', 5, N'Seoul,Gangnam', N'Mr. john Doe', 955432, N'bss333@gmail.com', N'YnNzMzMz', N'bss.kr.com', N'Company', N'jjjjjjjjjjjjj', 1, CAST(0x0000AE5E0116CD0D AS DateTime), CAST(0x0000AE5E0116CD0D AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (3, N'Top Company', 3, N'tokyo,45th street', N'Mr Jame', 944356, N'tjp454545@gmail.com', N'dGpwNDU0NTQ1', N'www.topjapan.com', N'Company', N'hsfsfdfsfd', 1, CAST(0x0000AE5E0151F15F AS DateTime), CAST(0x0000AE5E0151F15F AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (4, N'MM Company', 2, N'Kyi Myint daing,34th street', N'U Kyaw', 9887623, N'mm333444@gmail.com', N'bW0zMzM0NDQ=', N'mm.myanmar.com', N'Company', N'dsfsfsdf', 1, CAST(0x0000AE5F010217E6 AS DateTime), CAST(0x0000AE5F010217E6 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_company] OFF
SET IDENTITY_INSERT [dbo].[tbl_country] ON 

INSERT [dbo].[tbl_country] ([id], [country]) VALUES (1, N'Singapore')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (2, N'Myanmar')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (3, N'Japan')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (4, N'China')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (5, N'Korea')
SET IDENTITY_INSERT [dbo].[tbl_country] OFF
SET IDENTITY_INSERT [dbo].[tbl_job] ON 

INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (1, N'Full Time Developer', N'Graduate', N'Java,PHP,Python', N'2 years', 5, 1, 1, 2, 1, 300000, N'need basic knowledge of OOP', 1, CAST(0x0000AE5E0122397C AS DateTime), CAST(0x0000AE5E0122397C AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (2, N'.Net Senior Developer', N'Graduate & Under Graduate', N'C#', N'3 years', 6, 1, 2, 3, 1, 300000, N'sfsfsdfd', 0, CAST(0x0000AE5E01229414 AS DateTime), CAST(0x0000AE5F009C014F AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (3, N'PHP senior developer', N'Graduate', N'PHP', N'5 years', 8, 3, 2, 2, 1, 700000, N'need to speak japanese language', 1, CAST(0x0000AE5E01527EA8 AS DateTime), CAST(0x0000AE5E01527EA8 AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (4, N'Full time Java Developer', N'Graduate & Under Graduate', N'Java', N'5 years', 9, 1, 2, 2, 1, 300000, N'sfsfdfsdfdf', 1, CAST(0x0000AE5F009BD05A AS DateTime), CAST(0x0000AE5F009BD05A AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (5, N'Accountant', N'Graduate', N'Excel', N'no need', 5, 4, 5, 2, 1, 300000, N'dsfsfsdfsdf', 1, CAST(0x0000AE5F010493DA AS DateTime), CAST(0x0000AE5F010493DA AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_job] OFF
SET IDENTITY_INSERT [dbo].[tbl_jobnature] ON 

INSERT [dbo].[tbl_jobnature] ([id], [job_nature]) VALUES (1, N'Part-time')
INSERT [dbo].[tbl_jobnature] ([id], [job_nature]) VALUES (2, N'Full-time')
INSERT [dbo].[tbl_jobnature] ([id], [job_nature]) VALUES (3, N'Freelance')
SET IDENTITY_INSERT [dbo].[tbl_jobnature] OFF
SET IDENTITY_INSERT [dbo].[tbl_joboffer] ON 

INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (1, 1, 1, 2, CAST(0xB9430B00 AS Date), 1)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (2, 2, 3, 3, CAST(0xB9430B00 AS Date), 0)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (3, 1, 1, 1, CAST(0xBA430B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[tbl_joboffer] OFF
SET IDENTITY_INSERT [dbo].[tbl_jobseeker] ON 

INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (1, N'Mg Kaung Myat', N'Hledan,45th street', 966543, N'Male', CAST(0x00008E6300000000 AS DateTime), N'C#,Java,Python', N'3 years', N'Graduate', N'Bsc', N'CV/resume1.docx', N'~/Profile/avatar2.png', N'km33459@gmail.com', N'a20zMzQ1OQ==', N'worked as junior python developer', N'Job Seeker', 1, CAST(0x0000AE5E011B4111 AS DateTime), CAST(0x0000AE5E011B4111 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (2, N'Ma Hla', N'Thinkankyun,50th road', 965378, N'Female', CAST(0x00008F5700000000 AS DateTime), N'Java,PHP', N'2 years', N'Under Graduate', N'Student', N'CV/resume2.docx', N'~/Profile/avatar5.png', N'hlahla333@gmail.com', N'aGxhaGxhMzMz', N'nothing', N'Job Seeker', 1, CAST(0x0000AE5E01214241 AS DateTime), CAST(0x0000AE5E01214241 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_jobseeker] OFF
SET IDENTITY_INSERT [dbo].[tbl_position] ON 

INSERT [dbo].[tbl_position] ([id], [position]) VALUES (1, N'Junior Developer')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (2, N'Senior Developer')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (3, N'Leader')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (4, N'Manager')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (5, N'Staff')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (6, N'HR')
SET IDENTITY_INSERT [dbo].[tbl_position] OFF
SET IDENTITY_INSERT [dbo].[tbl_skill] ON 

INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (1, N'C#')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (2, N'Java')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (3, N'PHP')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (4, N'Python')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (5, N'Excel')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (6, N'Powerpoint')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (7, N'UI/UX')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (8, N'Other')
SET IDENTITY_INSERT [dbo].[tbl_skill] OFF
SET IDENTITY_INSERT [dbo].[tbl_specialization] ON 

INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (1, N'IT')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (2, N'engineering')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (3, N'marketing')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (4, N'restaurant')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (5, N'healthcare')
SET IDENTITY_INSERT [dbo].[tbl_specialization] OFF
ALTER TABLE [dbo].[tbl_company] ADD  CONSTRAINT [DF_tbl_company_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[tbl_job] ADD  CONSTRAINT [DF_tbl_job_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[tbl_joboffer] ADD  CONSTRAINT [DF_tbl_joboffer_is_accept]  DEFAULT ((2)) FOR [is_accept]
GO
ALTER TABLE [dbo].[tbl_jobseeker] ADD  CONSTRAINT [DF_tbl_jobseeker_degree_name]  DEFAULT (N'Student') FOR [degree_name]
GO
ALTER TABLE [dbo].[tbl_jobseeker] ADD  CONSTRAINT [DF_tbl_jobseeker_active]  DEFAULT ((1)) FOR [active]
GO
