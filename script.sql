USE [UniversityManagementSystem]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](5) NULL,
	[CourseName] [varchar](50) NULL,
	[CourseCredit] [decimal](18, 2) NULL,
	[CourseDescription] [varchar](150) NULL,
	[CourseDepartmentId] [int] NULL,
	[CourseSemesterId] [int] NULL,
	[CourseTeacherName] [varchar](150) NULL,
	[Assign] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AllocatedRooms]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocatedRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[RoomNo] [int] NULL,
	[Day] [varchar](50) NULL,
	[FromTime] [varchar](10) NULL,
	[ToTime] [varchar](10) NULL,
 CONSTRAINT [PK_AllocatedRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[AllocatedRoomsView]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   create view  [dbo].[AllocatedRoomsView] as
   select Courses.CourseCode, Courses.CourseName, Rooms.RoomNo, AllocatedRooms.Day,AllocatedRooms.FromTime,AllocatedRooms.ToTime, Courses.CourseDepartmentId from AllocatedRooms
   join Courses on Courses.Id=AllocatedRooms.CourseId
   join Rooms on Rooms.Id=AllocatedRooms.RoomNo
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Semesters] [varchar](50) NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[CourseAssignView]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create view  [dbo].[CourseAssignView] as
  select Courses.CourseCode, Courses.CourseName,Semesters.Semesters,Courses.CourseTeacherName,Courses.CourseDepartmentId from Courses
  join Semesters on Semesters.Id=CourseSemesterId
GO
/****** Object:  Table [dbo].[CoureseEnrolled]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoureseEnrolled](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[StudentId] [int] NULL,
	[EnrollDate] [datetime] NULL,
	[CourseGrade] [varchar](20) NULL,
 CONSTRAINT [PK_CoureseEnrolled] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[StudentResultView]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create view  [dbo].[StudentResultView] as
  select CourseCode, CourseName, CourseGrade,StudentId from  CoureseEnrolled
  join Courses on Courses.Id=CoureseEnrolled.CourseId
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](10) NULL,
	[DepartmentName] [varchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designations]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](50) NULL,
 CONSTRAINT [PK_Designations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentRegNo] [varchar](20) NULL,
	[StudentName] [varchar](50) NULL,
	[StudentEmail] [varchar](20) NULL,
	[StudentContactNo] [varchar](15) NULL,
	[StudentAddress] [varchar](100) NULL,
	[StudentRegistrationDate] [datetime] NULL,
	[StudentDepartmnetId] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 2/16/2017 8:48:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[TeacherAddress] [varchar](150) NULL,
	[TeacherEmail] [varchar](50) NULL,
	[ContactNo] [varchar](15) NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
	[TakenCredit] [decimal](18, 2) NULL,
	[RemainingCredit] [decimal](18, 2) NULL,
	[TotalCreditTake] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AllocatedRooms] ON 

INSERT [dbo].[AllocatedRooms] ([Id], [CourseId], [RoomNo], [Day], [FromTime], [ToTime]) VALUES (1011, 2, 1, N'Mon', N'12:15 AM', N'04:00 AM')
INSERT [dbo].[AllocatedRooms] ([Id], [CourseId], [RoomNo], [Day], [FromTime], [ToTime]) VALUES (1012, 2, 2, N'Mon', N'12:00 AM', N'12:30 AM')
SET IDENTITY_INSERT [dbo].[AllocatedRooms] OFF
SET IDENTITY_INSERT [dbo].[CoureseEnrolled] ON 

INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (4, 2, 1, CAST(N'2017-02-09T00:00:00.000' AS DateTime), N'A+')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (5, 3, 1, CAST(N'2017-02-09T00:00:00.000' AS DateTime), N'A+')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (6, 8, 1, CAST(N'2017-02-10T00:00:00.000' AS DateTime), N'B')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (7, 6, 1, CAST(N'2017-02-10T00:00:00.000' AS DateTime), N'A+')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (8, 2, 2, CAST(N'2017-02-10T00:00:00.000' AS DateTime), N'A')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (9, 6, 2, CAST(N'2017-02-10T00:00:00.000' AS DateTime), N'A-')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (1009, 3, 4, CAST(N'2017-02-15T00:00:00.000' AS DateTime), N'Not Graded Yet')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (1010, 8, 4, CAST(N'2017-02-15T00:00:00.000' AS DateTime), N'B+')
INSERT [dbo].[CoureseEnrolled] ([Id], [CourseId], [StudentId], [EnrollDate], [CourseGrade]) VALUES (1011, 2, 4, CAST(N'2017-02-15T00:00:00.000' AS DateTime), N'A+')
SET IDENTITY_INSERT [dbo].[CoureseEnrolled] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [CourseDepartmentId], [CourseSemesterId], [CourseTeacherName], [Assign]) VALUES (2, N'CSE-1', N'Programming C', CAST(3.00 AS Decimal(18, 2)), N'Programming C as', 1, 1, N'Not Assigned Yet', 0)
INSERT [dbo].[Courses] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [CourseDepartmentId], [CourseSemesterId], [CourseTeacherName], [Assign]) VALUES (3, N'CSE-2', N'Java', CAST(3.00 AS Decimal(18, 2)), N'Java Programming', 1, 4, N'Not Assigned Yet', 0)
INSERT [dbo].[Courses] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [CourseDepartmentId], [CourseSemesterId], [CourseTeacherName], [Assign]) VALUES (4, N'EEE-1', N'Tarcera', CAST(5.00 AS Decimal(18, 2)), N'asdad', 2, 8, N'Not Assigned Yet', 0)
INSERT [dbo].[Courses] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [CourseDepartmentId], [CourseSemesterId], [CourseTeacherName], [Assign]) VALUES (6, N'CSE-3', N'C# Programming', CAST(5.00 AS Decimal(18, 2)), N'C# Programming Lng.', 1, 5, N'Not Assigned Yet', 0)
INSERT [dbo].[Courses] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [CourseDepartmentId], [CourseSemesterId], [CourseTeacherName], [Assign]) VALUES (7, N'as', N'assas', CAST(10.00 AS Decimal(18, 2)), N'asasasas', 3, 7, N'Not Assigned Yet', 0)
INSERT [dbo].[Courses] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [CourseDepartmentId], [CourseSemesterId], [CourseTeacherName], [Assign]) VALUES (8, N'CSE-4', N'Java script', CAST(5.00 AS Decimal(18, 2)), N'Not Assigned YeNot Assigned Yett', 1, 3, N'Not Assigned Yet', 0)
INSERT [dbo].[Courses] ([Id], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [CourseDepartmentId], [CourseSemesterId], [CourseTeacherName], [Assign]) VALUES (9, N'rasre', N'asdas', CAST(5.00 AS Decimal(18, 2)), N'asdasdas', 5, 5, N'Not Assigned Yet', 0)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([Id], [DepartmentCode], [DepartmentName]) VALUES (1, N'CSE', N'Computer Sceience And Eng.')
INSERT [dbo].[Departments] ([Id], [DepartmentCode], [DepartmentName]) VALUES (2, N'EEE', N'Electrical And Electronics ENG.')
INSERT [dbo].[Departments] ([Id], [DepartmentCode], [DepartmentName]) VALUES (3, N'BBA', N'BBA')
INSERT [dbo].[Departments] ([Id], [DepartmentCode], [DepartmentName]) VALUES (4, N'LLB', N'Law Department')
INSERT [dbo].[Departments] ([Id], [DepartmentCode], [DepartmentName]) VALUES (5, N'CE', N'Civil Engnr.')
INSERT [dbo].[Departments] ([Id], [DepartmentCode], [DepartmentName]) VALUES (6, N'jkkj', N'jkk')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Designations] ON 

INSERT [dbo].[Designations] ([Id], [DesignationName]) VALUES (2, N'Associate Professor')
INSERT [dbo].[Designations] ([Id], [DesignationName]) VALUES (3, N'Asst. Professor')
INSERT [dbo].[Designations] ([Id], [DesignationName]) VALUES (5, N'Lecturer')
INSERT [dbo].[Designations] ([Id], [DesignationName]) VALUES (1, N'Professor')
INSERT [dbo].[Designations] ([Id], [DesignationName]) VALUES (4, N'Sr. Lecturer')
SET IDENTITY_INSERT [dbo].[Designations] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (1, N'A-202')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (2, N'A-302')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (3, N'A-305')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (4, N'B-202')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (5, N'C-202')
INSERT [dbo].[Rooms] ([Id], [RoomNo]) VALUES (6, N'C-205')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
SET IDENTITY_INSERT [dbo].[Semesters] ON 

INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (1, N'1st Semester')
INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (2, N'2nd Semester')
INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (3, N'3rd Semester')
INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (4, N'4th Semester')
INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (5, N'5th Semester')
INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (6, N'6th Semester')
INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (7, N'7th Semester')
INSERT [dbo].[Semesters] ([Id], [Semesters]) VALUES (8, N'8th Semester')
SET IDENTITY_INSERT [dbo].[Semesters] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [StudentRegNo], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddress], [StudentRegistrationDate], [StudentDepartmnetId]) VALUES (1, N'CSE-2017-001', N'Rasel', N'rasel@gmail.com', N'01934758007', N'Dhaka Bangladesh', CAST(N'2017-02-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Students] ([StudentId], [StudentRegNo], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddress], [StudentRegistrationDate], [StudentDepartmnetId]) VALUES (2, N'CSE-2016-001', N'Robin', N'robin@gmail.com', N'019341225744', N'Wari', CAST(N'2016-11-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Students] ([StudentId], [StudentRegNo], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddress], [StudentRegistrationDate], [StudentDepartmnetId]) VALUES (3, N'EEE-2016-001', N'Limon', N'Limon@gmail.com', N'0193475889', N'Bangladesh', CAST(N'2016-05-09T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Students] ([StudentId], [StudentRegNo], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddress], [StudentRegistrationDate], [StudentDepartmnetId]) VALUES (4, N'CSE-2017-002', N'Akash', N'robin2@gmail.com', N'019341225744', N'ghhjj', CAST(N'2017-02-10T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Students] ([StudentId], [StudentRegNo], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddress], [StudentRegistrationDate], [StudentDepartmnetId]) VALUES (8, N'BBA-2016-001', N'Akash', N'rasel22@gmail.com', N'019341225744', N'hjkkj', CAST(N'2016-03-09T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Students] ([StudentId], [StudentRegNo], [StudentName], [StudentEmail], [StudentContactNo], [StudentAddress], [StudentRegistrationDate], [StudentDepartmnetId]) VALUES (9, N'LLB-2017-001', N'Akash', N'akash@gmail.com', N'01934758007', N'Aasas', CAST(N'2017-02-11T00:00:00.000' AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[Students] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [ContactNo], [DesignationId], [DepartmentId], [TakenCredit], [RemainingCredit], [TotalCreditTake]) VALUES (1, N'Amanullah Hoque', N'Jatrabari, Dhaka Bangladesh', N'rasel.lumia@live.com', N'01934758007', 4, 1, CAST(18.00 AS Decimal(18, 2)), CAST(18.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)))
INSERT [dbo].[Teachers] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [ContactNo], [DesignationId], [DepartmentId], [TakenCredit], [RemainingCredit], [TotalCreditTake]) VALUES (2, N'Amanullah', N'teacher.TakenCredit', N'amanullahhoque.cse@gmail.com', N'01934758007', 2, 1, CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)))
INSERT [dbo].[Teachers] ([Id], [TeacherName], [TeacherAddress], [TeacherEmail], [ContactNo], [DesignationId], [DepartmentId], [TakenCredit], [RemainingCredit], [TotalCreditTake]) VALUES (3, N'Rasel Ahamed', N'Dhaka Bangladesh', N'rasel@email.com', N'01934758007', 5, 2, CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Teachers] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [IX_Course] UNIQUE NONCLUSTERED 
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course_1]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [IX_Course_1] UNIQUE NONCLUSTERED 
(
	[CourseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Departments]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [IX_Departments] UNIQUE NONCLUSTERED 
(
	[DepartmentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Departments_1]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [IX_Departments_1] UNIQUE NONCLUSTERED 
(
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Designations]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Designations] ADD  CONSTRAINT [IX_Designations] UNIQUE NONCLUSTERED 
(
	[DesignationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Rooms]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Rooms] ADD  CONSTRAINT [IX_Rooms] UNIQUE NONCLUSTERED 
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Semesters]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Semesters] ADD  CONSTRAINT [IX_Semesters] UNIQUE NONCLUSTERED 
(
	[Semesters] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Students]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [IX_Students] UNIQUE NONCLUSTERED 
(
	[StudentEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Students_1]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [IX_Students_1] UNIQUE NONCLUSTERED 
(
	[StudentRegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Teachers]    Script Date: 2/16/2017 8:48:17 AM ******/
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [IX_Teachers] UNIQUE NONCLUSTERED 
(
	[TeacherEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllocatedRooms]  WITH CHECK ADD  CONSTRAINT [FK_AllocatedRooms_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[AllocatedRooms] CHECK CONSTRAINT [FK_AllocatedRooms_Courses]
GO
ALTER TABLE [dbo].[AllocatedRooms]  WITH CHECK ADD  CONSTRAINT [FK_AllocatedRooms_Rooms] FOREIGN KEY([RoomNo])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[AllocatedRooms] CHECK CONSTRAINT [FK_AllocatedRooms_Rooms]
GO
ALTER TABLE [dbo].[CoureseEnrolled]  WITH CHECK ADD  CONSTRAINT [FK_CoureseEnrolled_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[CoureseEnrolled] CHECK CONSTRAINT [FK_CoureseEnrolled_Courses]
GO
ALTER TABLE [dbo].[CoureseEnrolled]  WITH CHECK ADD  CONSTRAINT [FK_CoureseEnrolled_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[CoureseEnrolled] CHECK CONSTRAINT [FK_CoureseEnrolled_Students]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([CourseDepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Semesters] FOREIGN KEY([CourseSemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Semesters]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Departments] FOREIGN KEY([StudentDepartmnetId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Departments]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Departments]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Designations] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Designations]
GO
