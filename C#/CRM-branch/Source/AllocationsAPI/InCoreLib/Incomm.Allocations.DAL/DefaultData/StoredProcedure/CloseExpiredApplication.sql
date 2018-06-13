USE [Allocations]
GO
/****** Object:  StoredProcedure [dbo].[p_CloseExpiredApplications]    Script Date: 07/11/2016 13:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[p_CloseExpiredApplications]
AS 
BEGIN
    SET NOCOUNT ON;
    DECLARE @dteBlankDate AS DATETIME = '1753-01-01 00:00:00.000'
    DECLARE @SP_Name AS NVARCHAR(250) = 'Allocations.dbo.p_CloseExpiredApplications'

			UPDATE VBLA
			SET VBLA.applicationStatusID = 2,
			VBLA.ApplicationStatusReason = 'Application Expired' ,
			VBLA.ApplicationClosedDate = GETDATE()
			FROM dbo.VBLApplications VBLA
			INNER JOIN dbo.ApplicationStatus AppS
			ON VBLA.ApplicationStatusID = appS.ApplicationStatusID
			INNER JOIN dbo.VBLRequestedPropertymatchDetails VRPMD
			ON VRPMD.ApplicationId = VBLA.ApplicationId
			LEFT JOIN ( dbo.VBLCustomerInterests AS CI
						INNER JOIN dbo.CustomerInterestStatus AS CIS 
							ON CI.CustomerInterestStatusID = CIS.CustomerInterestStatusID
					  ) ON ci.ApplicationID = VBLA.ApplicationId
						   AND cis.StatusIsOpen = 1 --not cancelled or completed
						   AND cis.StatusOnlyShowProperty = 1 --All type of matches
			WHERE   AppS.StatusIsOpen = 1
			AND VRPMD.EndDate < CAST(GETDATE() AS DATE)
			AND ci.ApplicationID IS NULL
			           --------------------------------------------------------------------------------------------------------------------
	
	INSERT  INTO [CloudVoids].dbo.[Task]
					( 					
					TaskTypeId
					,DateCreated
					,CreatedById
					,VoidId
					,CustomerApplicationId
					,TaskStatusId
					,ScheduledStart
					,ScheduledEnd
					,ActualStart
					,ActualEnd
					,TaskLocation
					--,AllocatedToId
					,PersonId
					,UpdatedBySP
					)
			SELECT  DISTINCT
								
					TaskTypeId
					,GETDATE()
					,'' AS CreatedById --GUID for System
					,-1 AS SystemReference
					,CA.ApplicationId AS SystemReference2
					,2 AS SystemStatusId --InProgress
					,CA.ApplicationClosedDate AS ScheduledStart
					,DATEADD(minute, at.TaskTypeLength,CA.ApplicationClosedDate) AS ScheduledEnd
					,@dteBlankDate AS ActualStart
					,@dteBlankDate AS ActualEnd
					,1 AS SystemTaskLocation
					--,'' --GUID for CSO Queue
					,681 AS PersonID
					,@SP_Name					
			FROM    Allocations.dbo.VBLApplications AS CA 
					INNER JOIN dbo.VBLRequestedPropertymatchDetails VRPMD
					ON CA.ApplicationId = VRPMD.ApplicationId
					INNER JOIN [CloudVoids].dbo.TaskType AS AT 
						ON AT.TaskTypeId = 16 --VBLCustomerSatisfaction
					INNER JOIN dbo.ApplicationStatus AS AppS 
						ON CA.ApplicationStatusID = AppS.ApplicationStatusID
					LEFT JOIN ( dbo.VBLCustomerInterests AS CI
								INNER JOIN dbo.CustomerInterestStatus
								AS CIS ON CI.CustomerInterestStatusID = CIS.CustomerInterestStatusID
							  ) ON ci.ApplicationID = ca.ApplicationId
								   AND cis.StatusIsOpen = 1
								   AND cis.StatusOnlyShowProperty = 1
			WHERE   VRPMD.EndDate  < CAST(GETDATE() AS DATE)
					AND ci.ApplicationID IS NULL
					AND	ca.ApplicationStatusID = 2 --only closed applications
					AND NOT EXISTS( SELECT	1
									FROM	[CloudVoids].dbo.[Task]
									WHERE	CustomerApplicationId = CA.ApplicationID
									AND		TaskTypeId = 16
									AND		VoidId = -1)

------------------------------------------------------------------------------------------------------------------------------
 
							-- Update customer interest
        UPDATE  Allocations.dbo.VBLCustomerInterests
        SET     CustomerInterestStatusID = 2
        WHERE   CustomerInterestID IN (
                SELECT  CI.CustomerInterestID
                FROM    Allocations.dbo.VBLApplications CA
                        JOIN Allocations.dbo.VBLCustomerInterests CI ON CI.ApplicationID = CA.ApplicationId
                WHERE   ca.ApplicationStatusID IN ( 2 ) -- APPLICATION IS CLOSED
                        AND CI.CustomerInterestStatusID IN ( 10, 4, 1 ) )
	

END


