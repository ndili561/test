CREATE PROCEDURE [dbo].[CreateSuitabilityCheckTask]
    (
      @ApplicationId INT,
      @VoidId INT,
      @CreatedBy varchar(50) 
    )
AS 
    BEGIN
        SET NOCOUNT ON;
        DECLARE @PropertyMatchTaskTypeId int;
        DECLARE @SuitabilityCheckTaskTypeId int;
        DECLARE @SuitabilityCheckTaskDuration int;
        DECLARE @NHOUserId VARCHAR(50);
        DECLARE @TaskId int;
		DECLARE @PropertyMatchTaskId int;
        DECLARE @PropertyCode varchar(50);
        DECLARE @ScheduledEnd DATETIME;
       
        SET @PropertyMatchTaskTypeId =(SELECT TOP 1 TaskTypeId FROM [CloudVoids].[dbo].[TaskType] WHERE TaskTypeName = 'PropertyMatch')
        
        SET @SuitabilityCheckTaskTypeId =(SELECT TOP 1 TaskTypeId FROM [CloudVoids].[dbo].[TaskType] WHERE TaskTypeName = 'SuitabilityCheck')
        SET @SuitabilityCheckTaskDuration =(SELECT TOP 1 TaskTypeLength FROM [CloudVoids].[dbo].[TaskType] WHERE TaskTypeName = 'SuitabilityCheck')
        SET @ScheduledEnd = DATEADD(MINUTE, @SuitabilityCheckTaskDuration, GETDATE())
        SET @NHOUserId =(SELECT TOP 1  NHOUserId FROM [CloudVoids].[dbo].[Void] WHERE VoidId = @VoidId)
        SET @PropertyCode = (SELECT TOP 1 PropertyCode From [CloudVoids].[dbo].[Void] WHERE VoidId = @VoidId)
        
        
        UPDATE [CloudVoids].[dbo].[Task]
        SET TaskStatusId = 4
        WHERE TaskTypeId = 28
        AND VoidId = @VoidId
        
        INSERT INTO [CloudVoids].[dbo].[Task]
           ([TaskTypeId],[DateCreated],[CreatedById],[VoidId],[TaskStatusId],[AllocatedToId],ScheduledStart,ScheduledEnd,[LastModifiedById],[DateModified],[UpdatedBySP])
		VALUES
           (@PropertyMatchTaskTypeId,GETDATE(),@CreatedBy,@VoidId,0,@NHOUserId,GETDATE(),@ScheduledEnd,@CreatedBy,GETDATE(),'EF_InComm.GateWay_CreatePropertyMatchTaskAndGetMatchTaskId')
		SET @PropertyMatchTaskId = SCOPE_IDENTITY()
		SELECT @PropertyMatchTaskId
		INSERT INTO [CloudVoids].[dbo].[PropertyMatch]
           ([TaskId],[CustomerApplicationId],[DecisionBy],[LastModifiedbyUserId])
           VALUES
           (@PropertyMatchTaskId,@ApplicationId,'Emp',@CreatedBy)
               
        INSERT INTO [CloudVoids].[dbo].[Task]
           ([TaskTypeId],[DateCreated],[CreatedById],[VoidId],[TaskStatusId],[AllocatedToId],ScheduledStart,ScheduledEnd,[LastModifiedById],[DateModified],[ParentTaskId],[UpdatedBySP])
		VALUES
           (@SuitabilityCheckTaskTypeId,GETDATE(),@CreatedBy,@VoidId,0,@NHOUserId,GETDATE(),@ScheduledEnd,@CreatedBy,GETDATE(),@PropertyMatchTaskId,'EF_InComm.GateWay_CreatePropertyMatchTaskAndGetMatchTaskId')
		SET @TaskId = SCOPE_IDENTITY()
		SELECT @TaskId
		INSERT INTO [CloudVoids].[dbo].[SuitabilityCheck]
           ([TaskId],[PropertyMatchTaskId],[DecisionBy])
           VALUES
           (@TaskId,@PropertyMatchTaskId,'Emp')
           
		UPDATE [CloudVoids].[dbo].[Void] SET VoidStatusId = 5, PropertyMatchTaskId = @PropertyMatchTaskId WHERE VoidId = @VoidId
		
		-- TODO confirm excluded CustomerInterestStatuses !
		DECLARE @CustomerInterestId INT = (
		SELECT TOP 1 CustomerInterestId
		FROM [Allocations].[dbo].[VBLCustomerInterests]
		WHERE ApplicationId = @ApplicationId
			AND VoidId = @VoidId
			AND CustomerInterestStatusId NOT IN (11, -- Reconsider
			2, -- Interested
			3, -- Rejected
			5, -- Canceled
			6, -- Complete
			7, --Accepted
			9 --Rejection from other customer
			)
		ORDER BY CustomerInterestId DESC
		)

      IF(@CustomerInterestId IS NULL)
          BEGIN
          INSERT INTO [Allocations].[dbo].[VBLCustomerInterests]
           ([PropertyCode],[VoidId],VoidContactId,[CustomerInterestStatusId],[TaskId],[ApplicationId],[LandlordId],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],IsPreViewingUndertaken,StatusReasonsDate,CustomerDecision,ActivityId)
          VALUES 
          (@PropertyCode,@VoidId,0,1,@PropertyMatchTaskId,@ApplicationId,1,@CreatedBy,GETDATE(),@CreatedBy,GETDATE(),0,GETDATE(),0,0)
     END
     ELSE
     BEGIN
           UPDATE Allocations.dbo.VBLCustomerInterests
           SET TaskId = @PropertyMatchTaskId
           WHERE CustomerInterestId = @CustomerInterestId
       END    
           
    RETURN 1 
  END


