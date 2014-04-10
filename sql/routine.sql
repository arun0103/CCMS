
USE [CCMS]
GO


/****** Object:  Table [dbo].[routine]    Script Date: 2/14/2014 11:04:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[routine](
	[routineId] [int] NOT NULL IDENTITY,
	[Fid] [int] NULL,
	[BatchId] [int] NULL,
	[EnrollYear] [int] Null,
	[Semester] [varchar](4) Null,
	[SubjectId] [int] NULL,
	[SectionName] [varchar](15) NULL,
 CONSTRAINT [PK__routine__568863CC412EB0B6] PRIMARY KEY CLUSTERED 
(
	[routineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[routine]  WITH CHECK ADD  CONSTRAINT [FK__routine__BatchId__440B1D61] FOREIGN KEY([BatchId])
REFERENCES [dbo].[batch] ([BatchId])
GO

ALTER TABLE [dbo].[routine] CHECK CONSTRAINT [FK__routine__BatchId__440B1D61]
GO

ALTER TABLE [dbo].[routine]  WITH CHECK ADD  CONSTRAINT [FK__routine__Fid__4316F928] FOREIGN KEY([Fid])
REFERENCES [dbo].[faculty] ([Fid])
GO

ALTER TABLE [dbo].[routine] CHECK CONSTRAINT [FK__routine__Fid__4316F928]
GO

ALTER TABLE [dbo].[routine]  WITH CHECK ADD FOREIGN KEY([routineId])
REFERENCES [dbo].[routine] ([routineId])
GO

ALTER TABLE [dbo].[routine]  WITH CHECK ADD  CONSTRAINT [FK__routine__Subject__45F365D3] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
GO

ALTER TABLE [dbo].[routine] CHECK CONSTRAINT [FK__routine__Subject__45F365D3]
GO

