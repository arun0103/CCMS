USE [CCMS]
GO

/****** Object:  Table [dbo].[StudentAttendance]    Script Date: 2/14/2014 11:05:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StudentAttendance](
	[RollNo] [int] NOT NULL,
	[FacultyClassId] [int] NOT NULL,
	[Attendance] [bit] NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
	[routineid] [int] NOT NULL
) ON [PRIMARY]

GO

