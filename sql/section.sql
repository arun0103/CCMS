

USE [CCMS]
GO

/****** Object:  Table [dbo].[Section]    Script Date: 2/14/2014 11:05:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Section](
	[SectionId] [varchar](20) NOT NULL,
	[RollNo] [int] NULL,
	[Section] [varchar](10) NULL,
	[Semester] [varchar](10) NULL,
	[BatchId] [int] NULL,
 CONSTRAINT [PK__Section__80EF08722F10007B] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK__Section__BatchId__30F848ED] FOREIGN KEY([BatchId])
REFERENCES [dbo].[batch] ([BatchId])
GO

ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK__Section__BatchId__30F848ED]
GO

