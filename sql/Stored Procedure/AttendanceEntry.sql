USE [CCMS]
GO

/****** Object:  UserDefinedTableType [dbo].[AttendanceEntryType]    Script Date: 2/14/2014 11:32:26 AM ******/
CREATE TYPE [dbo].[AttendanceEntryType] AS TABLE(
	[RollNo] [int] NULL,
	[Attendance] [bit] NULL
)
GO

