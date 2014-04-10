USE [CCMS]
GO

/****** Object:  Table [dbo].[students]    Script Date: 2/14/2014 11:05:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[students](
	[RollNo] [int] NOT NULL,
	[FirstName] [varchar](30) NULL,
	[MiddleName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Email] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[RollNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

