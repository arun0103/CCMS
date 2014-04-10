USE [CCMS]
GO

/****** Object:  UserDefinedTableType [dbo].[AttendanceEntryTableType]    Script Date: 2/14/2014 11:29:30 AM ******/
CREATE TYPE [dbo].[AttendanceEntryTableType] AS TABLE(
	[RollNo] [int] NULL,
	[FacultyClassId] [int] NULL,
	[Attendance] [bit] NULL,
	[AttendanceDate] [datetime] NULL,
	[routineid] [int] NULL
)
GO

