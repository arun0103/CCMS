USE [CCMS]
GO

/****** Object:  Table [dbo].[batch]    Script Date: 2/14/2014 11:03:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[batch](
	[BatchName] [varchar](20) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Active] [bit] NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[LastModifiedDate] [datetime] NULL,
	[BatchId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


