USE [JobPortal]
GO
/****** Object:  Table [dbo].[tbl_company]    Script Date: 4/7/2022 2:23:36 PM ******/
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
	[mobile] [bigint] NULL,
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
/****** Object:  Table [dbo].[tbl_country]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  Table [dbo].[tbl_job]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  Table [dbo].[tbl_jobnature]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  Table [dbo].[tbl_joboffer]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  Table [dbo].[tbl_jobseeker]    Script Date: 4/7/2022 2:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_jobseeker](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[mobile] [bigint] NULL,
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
/****** Object:  Table [dbo].[tbl_position]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  Table [dbo].[tbl_reset_password]    Script Date: 4/7/2022 2:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_reset_password](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[requestdatetime] [datetime] NULL,
 CONSTRAINT [PK_tbl_reset_password] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_skill]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  Table [dbo].[tbl_specialization]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  Table [dbo].[tbl_user]    Script Date: 4/7/2022 2:23:36 PM ******/
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
/****** Object:  View [dbo].[FilterJob]    Script Date: 4/7/2022 2:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[FilterJob] AS Select tbl_job.id,title,degree,skill,experience,vacancy,company_id,name,country,tbl_company.country_id,position_id,position,job_nature_id,job_nature,specialization_id,specialization,salary,tbl_job.detail,tbl_job.active,tbl_job.created_at,tbl_job.updated_at from tbl_job join tbl_position on tbl_position.id = tbl_job.position_id join tbl_jobnature on tbl_jobnature.id = tbl_job.job_nature_id join tbl_specialization on tbl_job.specialization_id = tbl_specialization.id join tbl_company on tbl_company.id=tbl_job.company_id join tbl_country on tbl_country.id = tbl_company.country_id Where tbl_job.active = 1

GO
SET IDENTITY_INSERT [dbo].[tbl_company] ON 

INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (1, N'Brighter Company', 2, N'Hlaing,34th street', N'U Naing Tun', 9873364758, N'brightermm@gmail.com', N'YnJpZ2h0ZXJtbQ==', N'www.brightermm.com', N'Company', N'We currenlty do window app and web app.', 1, CAST(0x0000AE6C0155A7A8 AS DateTime), CAST(0x0000AE6D0155A7A8 AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (2, N'Top Company', 1, N'No 34,Jasmine Road', N'Mr John Doe', 65876453678, N'topcmpss@yahoo.com', N'dG9wY21wc3M=', N'www.topcompany.com', N'Company', N'We are one of the most influential company over the world.', 1, CAST(0x0000AE6B0156F67C AS DateTime), CAST(0x0000AE6D0156F67C AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (3, N'MM Company', 2, N'No 35 ,Gandamar street Mandalay', N'U Kyaw Kyaw', 9874637584, N'MM5555@gmail.com', N'TU01NTU1', N'www.mmmyanmar.com', N'Company', N'Trust us.We always gurantee to give the best service.', 1, CAST(0x0000AE6B0157CB66 AS DateTime), CAST(0x0000AE6D0157CB66 AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (4, N'Golden Company', 3, N'No 44,block 5 Tokyo,Japan', N'Mr Yoshi', 81787465786, N'goldenJapan@gmail.com', N'Z29sZGVuSmFwYW4=', N'www.golden.jp.com', N'Company', N'best service,best quality,best management', 1, CAST(0x0000AE6D0159549C AS DateTime), CAST(0x0000AE6D0159549C AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (5, N'BSS company', 2, N'Hladan,No 44 street', N'U Yan Naing', 9746356473, N'bssmm@gmail.com', N'YnNzbW1AZ21haWwuY29t', N'www.Bssmyanmar.com', N'Company', N'We always provide best product ', 1, CAST(0x0000AE6D015B1792 AS DateTime), CAST(0x0000AE6D015B1792 AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (6, N'SCM company', 2, N'Botahtaung,Yangon', N'U Tun Tun', 9764758365, N'scmmyanmar@gmail.com', N'c2NtbXlhbm1hcg==', N'scmcompanymm.com', N'Company', N'We currently do mobile,window app and others.', 1, CAST(0x0000AE6E015D50F4 AS DateTime), CAST(0x0000AE6D015D50F4 AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (7, N'CGM company', 2, N'Botahtaung,Myanmar', N'U Soe Naing', 9764523456, N'cgmmyanmar@gmail.com', N'Y2dtbXlhbm1hcg==', N'cgmmyanmar.com', N'Company', N'we currently do mobile and window apps', 1, CAST(0x0000AE6F015ECEE9 AS DateTime), CAST(0x0000AE6D015ECEE9 AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (8, N'UNIQUE myanmar ', 2, N'34th street,Sule,Yangon', N'U Hla Myint', 9736457263, N'uniquemm@yahoo.com', N'dW5pcXVlbW0=', N'www.uniquemyanmar.com', N'Company', N'selling electronics and software services', 1, CAST(0x0000AE700160273F AS DateTime), CAST(0x0000AE6D0160273F AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (9, N'JJJ Company', 5, N'Gangnam,Korea', N'Mr Jin', 82374657865, N'jjjkr3345@gmail.com', N'ampqa3IzMzQ1', N'www.jjjkr.com', N'Company', N'Media service and broadcasting system', 1, CAST(0x0000AE700161E096 AS DateTime), CAST(0x0000AE6D0161E096 AS DateTime))
INSERT [dbo].[tbl_company] ([id], [name], [country_id], [address], [contact_person], [mobile], [email], [password], [website], [role], [detail], [active], [created_at], [updated_at]) VALUES (10, N'MMK company', 2, N'Thinkankyun,Yangon', N'U Aung Aung', 9874625476, N'MMKMyanmar@gmail.com', N'TU1LTXlhbm1hcg==', N'www.mmkmyanmar.com', N'Company', N'best service,best quality,best management', 1, CAST(0x0000AE6D016C53DB AS DateTime), CAST(0x0000AE6D016C53DB AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_company] OFF
SET IDENTITY_INSERT [dbo].[tbl_country] ON 

INSERT [dbo].[tbl_country] ([id], [country]) VALUES (1, N'Singapore')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (2, N'Myanmar')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (3, N'Japan')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (5, N'Korea')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (9, N'Vietnam')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (20, N'India')
INSERT [dbo].[tbl_country] ([id], [country]) VALUES (26, N'Dubai')
SET IDENTITY_INSERT [dbo].[tbl_country] OFF
SET IDENTITY_INSERT [dbo].[tbl_job] ON 

INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (1, N'Ruby Freelance Developer', N'1', N'Ruby,Testing', N'3 years', 5, 1, 2, 3, 1, 500000, N'need to know OOP concept,MVC concept', 1, CAST(0x0000AE6D016FC3FA AS DateTime), CAST(0x0000AE6D016FC3FA AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (2, N'Junior Csharp developer', N'2', N'C#', N'no need', 4, 1, 1, 2, 1, 200000, N'need to speak Japanese language.', 1, CAST(0x0000AE6D01712E9C AS DateTime), CAST(0x0000AE6D01712E9C AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (3, N'Sale Manager', N'1', N'Other', N'3 years', 2, 2, 4, 1, 10, 600000, N'you can speak at least two languages and need social skills and time management', 1, CAST(0x0000AE6D01733037 AS DateTime), CAST(0x0000AE6D01733037 AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (4, N'we are hiring content writer', N'3', N'Content Writing', N'no need', 2, 3, 5, 1, 1, 200000, N'need english speaking business level', 1, CAST(0x0000AE6D017E284E AS DateTime), CAST(0x0000AE6D017E284E AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (5, N'Company Accountant', N'1', N'Excel,Powerpoint', N'2 years', 6, 4, 10, 1, 1, 500000, N'We support ferry,hostel and other services', 1, CAST(0x0000AE6D017F1C49 AS DateTime), CAST(0x0000AE6D017F1C49 AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (6, N'Senior full time java developer', N'1', N'Java', N'5 years', 3, 6, 2, 2, 1, 500000, N'need problem solving skill', 1, CAST(0x0000AE6D017FD3E0 AS DateTime), CAST(0x0000AE6D017FD3E0 AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (7, N'Junior python developer', N'1', N'Python', N'2 years', 5, 7, 1, 2, 1, 300000, N'need to know version control system', 1, CAST(0x0000AE6D018140AB AS DateTime), CAST(0x0000AE6D018140AB AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (8, N'We need two salers', N'1', N'Other', N'no need', 2, 8, 5, 2, 10, 300000, N'need selling skills and \socail skill', 1, CAST(0x0000AE6D01831422 AS DateTime), CAST(0x0000AE6D01831422 AS DateTime))
INSERT [dbo].[tbl_job] ([id], [title], [degree], [skill], [experience], [vacancy], [company_id], [position_id], [job_nature_id], [specialization_id], [salary], [detail], [active], [created_at], [updated_at]) VALUES (9, N'We are hiring video editor', N'1', N'Other', N'2 years', 3, 9, 5, 1, 6, 400000, N'have a good view of video editing skills', 1, CAST(0x0000AE6D0183A30B AS DateTime), CAST(0x0000AE6D0183A30B AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_job] OFF
SET IDENTITY_INSERT [dbo].[tbl_jobnature] ON 

INSERT [dbo].[tbl_jobnature] ([id], [job_nature]) VALUES (1, N'Part-time')
INSERT [dbo].[tbl_jobnature] ([id], [job_nature]) VALUES (2, N'Full-time')
INSERT [dbo].[tbl_jobnature] ([id], [job_nature]) VALUES (3, N'Freelance')
SET IDENTITY_INSERT [dbo].[tbl_jobnature] OFF
SET IDENTITY_INSERT [dbo].[tbl_joboffer] ON 

INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (1, 1, 3, 4, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (2, 1, 4, 5, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (3, 2, 1, 2, CAST(0xC9430B00 AS Date), 1)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (4, 2, 2, 3, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (5, 3, 6, 6, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (6, 4, 7, 7, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (7, 5, 4, 5, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (8, 6, 6, 6, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (9, 6, 7, 7, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (10, 7, 1, 1, CAST(0xC9430B00 AS Date), 0)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (11, 7, 8, 8, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (12, 9, 1, 2, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (13, 10, 9, 9, CAST(0xC9430B00 AS Date), 2)
INSERT [dbo].[tbl_joboffer] ([id], [job_seeker_id], [company_id], [job_id], [applied_date], [is_accept]) VALUES (14, 10, 1, 2, CAST(0xC9430B00 AS Date), 2)
SET IDENTITY_INSERT [dbo].[tbl_joboffer] OFF
SET IDENTITY_INSERT [dbo].[tbl_jobseeker] ON 

INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (1, N'Mg Kaung Myat', N'No 30th street,Insein,Yangon', 9873647582, N'Male', CAST(0x00008D6100000000 AS DateTime), N'Excel,Powerpoint,UI/UX,Content Writing', N'4 years', N'1', N'Bsc', N'CV/My CV Form.docx', N'~/Profile/avatar1.png', N'km33456@gmail.com', N'a20zMzQ1Ng==', N'Worked as a content writer at bmm company', N'Job Seeker', 1, CAST(0x0000AE6E00009F79 AS DateTime), CAST(0x0000AE6E00009F79 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (2, N'Mg Thura', N'20 street,Mawlamyine', 9873465738, N'Male', CAST(0x00008D4300000000 AS DateTime), N'PHP,C#', N'1 year', N'2', N'Student', N'CV/resume1.docx', N'~/Profile/avatar2.png', N'thura999@gmail.com', N'dGh1cmE5OTk=', N'worked as a internship ', N'Job Seeker', 1, CAST(0x0000AE6E00018E6C AS DateTime), CAST(0x0000AE6E00018E6C AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (3, N'Ma Thuzar', N'Hlaing,Yangon', 9773456876, N'Female', CAST(0x000091AA00000000 AS DateTime), N'Java', N'3 years', N'1', N'Bsc', N'CV/resume3.docx', N'~/Profile/avatar6.png', N'thuzar667@gmail.com', N'dGh1emFyNjY3', N'I can speak japanese language', N'Job Seeker', 1, CAST(0x0000AE700006D4C3 AS DateTime), CAST(0x0000AE6E0006D4C3 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (4, N'Mg Thet Naing Kyaw', N'Pyin Oo Lwiin', 9736473865, N'Male', CAST(0x0000A06700000000 AS DateTime), N'PHP,Python,Testing', N'4 years', N'1', N'Bsc', N'CV/resume2.docx', N'~/Profile/avatar3.png', N'thetnaing777@gmail.com', N'dGhldG5haW5nNzc3', N'Worked as a junior python developer', N'Job Seeker', 1, CAST(0x0000AE710007CCCC AS DateTime), CAST(0x0000AE6E0007CCCC AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (5, N'Ma Sandi', N'Hlaing,34th street,Yangon', 9874657365, N'Female', CAST(0x00009A3900000000 AS DateTime), N'Excel,Powerpoint,UI/UX,Other', N'2 years', N'1', N'Bsc', N'CV/resume4.docx', N'~/Profile/avatar5.png', N'sandi333@gmail.com', N'c2FuZGkzMzM=', N'fast learning skill', N'Job Seeker', 1, CAST(0x0000AE72000922EC AS DateTime), CAST(0x0000AE6E000922EC AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (6, N'Mg Myo Min', N'Hlaing thar yar', 9252073737, N'Male', CAST(0x0000922200000000 AS DateTime), N'Java,PHP,Python', N'4 years', N'1', N'Bsc', N'CV/resume4.docx', N'~/Profile/avatar3.png', N'myominhtay01.mmh@gmail.com', N'bXlvbWluaHRheTAx', N'Worked in OJT at SCM company', N'Job Seeker', 1, CAST(0x0000AE730097C5B3 AS DateTime), CAST(0x0000AE6E0097C5B3 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (7, N'Ma Kyarphyu', N'Kyi Myin dine,Yangon', 9635472546, N'Male', CAST(0x00008C6D00000000 AS DateTime), N'Ruby,Other', N'3 years', N'2', N'Student', N'CV/resume3.docx', N'~/Profile/team1.jpg', N'kyarphyu333@gmail.com', N'a3lhcnBoeXUzMzM=', N'good skills in problem solving and communication ', N'Job Seeker', 1, CAST(0x0000AE74009988F3 AS DateTime), CAST(0x0000AE6E009988F3 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (8, N'Mg Thawdar', N'Thar Kay Ta,Yangon', 9874635647, N'Male', CAST(0x00008DDA00000000 AS DateTime), N'Java,PHP,Excel,Powerpoint', N'3 years', N'1', N'Student', N'CV/resume2.docx', N'~/Profile/profile1.jpg', N'thawdar55555@gmail.com', N'dGhhd2RhcjU1NTU1', N'Worked as a senior java developer at CGM company', N'Job Seeker', 1, CAST(0x0000AE72009AA6CB AS DateTime), CAST(0x0000AE6E009AA6CB AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (9, N'Mg Tun Wai', N'Sanchaung,Yangon', 9436574534, N'Male', CAST(0x00008D7E00000000 AS DateTime), N'UI/UX,Testing', N'2 years', N'1', N'Bsc', N'CV/resume3.docx', N'~/Profile/avatar1.png', N'myominhtay07.mmh@gmail.com', N'bXlvbWluaHRheTA3', N'Worked as a junior developer', N'Job Seeker', 1, CAST(0x0000AE71009D7EF8 AS DateTime), CAST(0x0000AE6E009D7EF8 AS DateTime))
INSERT [dbo].[tbl_jobseeker] ([id], [name], [address], [mobile], [gender], [dob], [skill], [experience], [degree], [degree_name], [cvform], [profile], [email], [password], [detail], [role], [active], [created_date], [updated_date]) VALUES (10, N'Ma Nilar', N'Htaung kyant,Yangon', 9763546723, N'Male', CAST(0x000090D300000000 AS DateTime), N'PHP,C#,Testing', N'3 years', N'2', N'Student', N'CV/resume1.docx', N'~/Profile/avatar3.png', N'nilar333444555@gmail.com', N'bmlsYXIzMzM0NDQ1NTU=', N'worked as a junior developer.', N'Job Seeker', 1, CAST(0x0000AE70009F1B08 AS DateTime), CAST(0x0000AE6E009F1B08 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_jobseeker] OFF
SET IDENTITY_INSERT [dbo].[tbl_position] ON 

INSERT [dbo].[tbl_position] ([id], [position]) VALUES (1, N'Junior Developer')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (2, N'Senior Developer')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (3, N'Leader')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (4, N'Manager')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (5, N'Staff')
INSERT [dbo].[tbl_position] ([id], [position]) VALUES (10, N'Accountant')
SET IDENTITY_INSERT [dbo].[tbl_position] OFF
SET IDENTITY_INSERT [dbo].[tbl_skill] ON 

INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (1, N'Ruby')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (2, N'Java')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (3, N'PHP')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (4, N'Python')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (5, N'Excel')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (6, N'Powerpoint')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (7, N'UI/UX')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (8, N'Other')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (9, N'Content Writing')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (12, N'C#')
INSERT [dbo].[tbl_skill] ([id], [skill]) VALUES (17, N'Testing')
SET IDENTITY_INSERT [dbo].[tbl_skill] OFF
SET IDENTITY_INSERT [dbo].[tbl_specialization] ON 

INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (1, N'IT')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (2, N'engineering')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (3, N'Marketing')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (4, N'Restaurant')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (5, N'Healthcare')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (6, N'Video editing')
INSERT [dbo].[tbl_specialization] ([id], [specialization]) VALUES (10, N'Sale')
SET IDENTITY_INSERT [dbo].[tbl_specialization] OFF
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

INSERT [dbo].[tbl_user] ([id], [name], [email], [password], [role]) VALUES (1, N'YeHtet', N'admin@gmail.com', N'admin123', N'admin')
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
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
