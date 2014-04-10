USE [CCMS]
GO

/****** Object:  StoredProcedure [dbo].[AttendanceEntry]    Script Date: 2/14/2014 11:28:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AttendanceEntry] 
	-- Add the parameters for the stored procedure here
	@Attendance AttendanceEntryType READONLY
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY

    -- Insert statements for procedure here
		INSERT dbo.StudentAttendance
			(RollNo,Attendance)
			SELECT * FROM @Attendance

	END TRY
	BEGIN CATCH
		DECLARE @ErrMsg NVARCHAR(2000) = ERROR_MESSAGE() ,
			@ErrNum INT = ERROR_NUMBER() ,
			@ErrpROC NVARCHAR(126) = ERROR_PROCEDURE()
		DECLARE @DataError NVARCHAR(4000) = 'Error loading data to Orders table'
			+ CONVERT(NVARCHAR(10), @ErrNum) + ', Error Details: '+ @ErrMsg

		RAISERROR (@DataError, 16,1)

		END CATCH

END

GO

