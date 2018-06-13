-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE MutualExchangeNotInterestedFromOtherCustomer
	-- Add the parameters for the stored procedure here
	@applicationIdA INT,
	@applicationIdB INT,
	@propertyCodeA  NVARCHAR(20),
	@propertyCodeB NVARCHAR(20),
	@CIStatusA INT,
	@CIStatusB INT,
	@UserId NVARCHAR(40),
	@TaskId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	--UPDATE VBLCI FOR applicant A/PropertyB
update dbo.VBLCustomerInterests SET CustomerInterestStatusId = @CIStatusA, TaskId = @TaskId,ModifiedBy = @UserId, modifiedDate = GETDATE() WHERE ApplicationId = @applicationIdA AND PropertyCode = @propertyCodeB
   
	--Insert VBLI for applicantB/propertyA
	INSERT INTO dbo.VBLCustomerInterests
           ( PropertyCode ,
             VoidId ,
             CustomerInterestStatusId ,
             VoidContactId ,
             IsPreViewingUndertaken ,
             StatusReasonsDate ,
             OutcomeNotes ,
             CustomerDecision ,
             Notes ,
             TaskId ,
             ActivityId ,
             CreatedDate ,
             ModifiedBy ,
             ModifiedDate ,
             ApplicationId ,
             LandlordId ,
             NotInterestedReasonId ,
             CreatedBy
           )
   VALUES  ( @propertyCodeA , -- PropertyCode - nvarchar(max)
             -100 , -- VoidId - int
             @CIStatusB , -- CustomerInterestStatusId - int
             0 , -- VoidContactId - int
             0 , -- IsPreViewingUndertaken - bit
             GETDATE() , -- StatusReasonsDate - datetime
             N'' , -- OutcomeNotes - nvarchar(max)
             1 , -- CustomerDecision - bit
             N'' , -- Notes - nvarchar(max)
             @TaskId , -- TaskId - int
             0 , -- ActivityId - int
             GETDATE() , -- CreatedDate - datetime
             N'' , -- ModifiedBy - nvarchar(60)
             GETDATE() , -- ModifiedDate - datetime
             @applicationIdB , -- ApplicationId - int
             1 , -- LandlordId - int
             0 , -- NotInterestedReasonId - int
             @UserId  -- CreatedBy - nvarchar(40)
           )


END
