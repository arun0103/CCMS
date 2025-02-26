USE [CCMS]
GO
INSERT [dbo].[batch] ([BatchName], [StartDate], [EndDate], [Active], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate], [BatchId]) VALUES (N'2016', CAST(0x94360B00 AS Date), CAST(0xDB3A0B00 AS Date), 1, N'anil', CAST(0x0000A27400000000 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[Section] ([SectionId], [RollNo], [Section], [Semester], [BatchId]) VALUES (N'1', 201, N'A IV', N'2', 2)
INSERT [dbo].[faculty] ([Fid], [FName], [UserId]) VALUES (12, N'Deepak', 2)
INSERT [dbo].[Subject] ([SubjectId], [SubName], [classId]) VALUES (201, N'C programming', N'1')
INSERT [dbo].[routine] ([routineId], [Fid], [BatchId], [SubjectId], [SectionName]) VALUES (1, 12, 2, 201, N'B/II')
INSERT [dbo].[StudentAttendance] ([RollNo], [FacultyClassId], [Attendance], [AttendanceDate], [routineid]) VALUES (201, 2, 1, CAST(0x0000A2C200DB5F04 AS DateTime), 1)
INSERT [dbo].[StudentAttendance] ([RollNo], [FacultyClassId], [Attendance], [AttendanceDate], [routineid]) VALUES (202, 2, 1, CAST(0x0000A2C200DB5F04 AS DateTime), 1)
INSERT [dbo].[StudentAttendance] ([RollNo], [FacultyClassId], [Attendance], [AttendanceDate], [routineid]) VALUES (203, 2, 1, CAST(0x0000A2C200DB5F04 AS DateTime), 1)
INSERT [dbo].[StudentAttendance] ([RollNo], [FacultyClassId], [Attendance], [AttendanceDate], [routineid]) VALUES (204, 2, 0, CAST(0x0000A2C200DB5F04 AS DateTime), 1)
INSERT [dbo].[students] ([RollNo], [FirstName], [MiddleName], [LastName], [Email]) VALUES (201, N'Hari', N'', N'shrestha', N'hari_201@deerwalk.edu.np')
INSERT [dbo].[students] ([RollNo], [FirstName], [MiddleName], [LastName], [Email]) VALUES (202, N'Ram', N'', N'shrestha', N'ram_202@deerwalk.edu.np')
INSERT [dbo].[students] ([RollNo], [FirstName], [MiddleName], [LastName], [Email]) VALUES (203, N'Manish', N'', N'shrestha', N'manish_203@deerwalk.edu.np')
INSERT [dbo].[students] ([RollNo], [FirstName], [MiddleName], [LastName], [Email]) VALUES (204, N'Sundar', N'', N'shrestha', N'sundar_204@deerwalk.edu.np')
