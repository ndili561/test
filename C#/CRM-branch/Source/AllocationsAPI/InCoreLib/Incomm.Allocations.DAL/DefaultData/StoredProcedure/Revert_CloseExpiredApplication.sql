USE [Allocations]
GO
/****** Object:  StoredProcedure [dbo].[p_CloseExpiredApplications]    Script Date: 11/10/2016 12:45:48 ******/
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
	UPDATE  CA
	SET     ApplicationStatusID = 2 , --Closed
			ApplicationStatusReason = 'Application Expired' ,
			ApplicationClosedDate = DATEADD(N, 1980, CAST(GETDATE() AS DATETIME))
	FROM    dbo.CustomerApplication AS CA
			INNER JOIN dbo.ApplicationStatus AS AppS 
				ON CA.ApplicationStatusID = AppS.ApplicationStatusID
			LEFT JOIN ( dbo.CustomerInterest AS CI
						INNER JOIN dbo.CustomerInterestStatus AS CIS 
							ON CI.CustomerInterestStatusID = CIS.CustomerInterestStatusID
					  ) ON ci.CustomerApplicationID = ca.CustomerApplicationId
						   AND cis.StatusIsOpen = 1 --not cancelled or completed
						   AND cis.StatusOnlyShowProperty = 1 --All type of matches
	WHERE   AppS.StatusIsOpen = 1
			AND ca.MatchingLatestMoveDate < CAST(GETDATE() AS DATE)
			AND ci.CustomerApplicationID IS NULL
			           
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
					,va.CustomerApplicationID AS SystemReference2
					,2 AS SystemStatusId --InProgress
					,va.ApplicationClosedDate AS ScheduledStart
					,DATEADD(minute, at.TaskTypeLength,va.ApplicationClosedDate) AS ScheduledEnd
					,@dteBlankDate AS ActualStart
					,@dteBlankDate AS ActualEnd
					,1 AS SystemTaskLocation
					--,'' --GUID for CSO Queue
					,681 AS PersonID
					,@SP_Name					
			FROM    dbo.v_Applications AS VA
					INNER JOIN Allocations.dbo.CustomerApplication AS CA 
						ON ca.CustomerApplicationId = va.CustomerApplicationId
					INNER JOIN [CloudVoids].dbo.TaskType AS AT 
						ON AT.TaskTypeId = 16 --VBLCustomerSatisfaction
					INNER JOIN dbo.ApplicationStatus AS AppS 
						ON CA.ApplicationStatusID = AppS.ApplicationStatusID
					LEFT JOIN ( dbo.CustomerInterest AS CI
								INNER JOIN dbo.CustomerInterestStatus
								AS CIS ON CI.CustomerInterestStatusID = CIS.CustomerInterestStatusID
							  ) ON ci.CustomerApplicationID = ca.CustomerApplicationId
								   AND cis.StatusIsOpen = 1
								   AND cis.StatusOnlyShowProperty = 1
			WHERE   ca.MatchingLatestMoveDate < CAST(GETDATE() AS DATE)
					AND ci.CustomerApplicationID IS NULL
					--AND va.ApplicationStatusID = 2
					--AND ca.LastUpdatedPersonIDLevelOfNeed IS NOT NULL
					AND	ca.ApplicationStatusID = 2 --only closed applications
					--AND NOT EXISTS ( SELECT 1
					--				 FROM   cloudvoids.dbo.v_Employee AS VE
					--				 WHERE  ve.EmployeeId = ca.LastUpdatedPersonIDLevelOfNeed
					--						AND ISNULL(ve.CSO, 0) = 1
					--						AND ISNULL(ve.NeighbourhoodOfficer,0) = 0 )
					AND NOT EXISTS( SELECT	1
									FROM	[CloudVoids].dbo.[Task]
									WHERE	CustomerApplicationId = va.CustomerApplicationID
									AND		TaskTypeId = 16
									AND		VoidId = -1)

  ;WITH    CTEAges
              AS ( SELECT   c.CustomerApplicationID ,
                            CAST(MAX(CAST(DATEDIFF(MONTH, c.DateOfBirth,
                                                   CASE WHEN ca.MatchingEarliestMoveDate > GETDATE()
                                                        THEN ca.MatchingEarliestMoveDate
                                                        ELSE GETDATE()
                                                   END) AS NUMERIC(28, 4))
                                     / CAST(12 AS NUMERIC(28, 4))) AS NUMERIC(10,
                                                              2)) AS ApplicantAge
                   FROM     dbo.Contact c
                            INNER JOIN dbo.CustomerApplication AS CA ON c.CustomerApplicationID = CA.CustomerApplicationId
                   WHERE    c.ContactTypeID IN ( 1, 2 )
                            AND c.IsMovingIn = 1
                            AND c.Active = 1
                   GROUP BY c.CustomerApplicationID
                 )
        UPDATE  ca
        SET     MatchingApplicantsAge = 18 
        FROM    CTEAges Age
                INNER JOIN dbo.CustomerApplication AS CA ON Age.CustomerApplicationID = ca.CustomerApplicationID   
				WHERE age.ApplicantAge < 18   
				

	/* BELOW CHECKS FOR ALL EXPIRED APPLICATIONS WITH A CUSTOMER INTEREST STATUS OF:
		10 - MATCHED FROM WAITING LIST
		 4 - MATCHED
		 1 - INTERSTED
	
	   AND THEN UPDATES THEM TO NO INTESTED -- SEAN MALLER 17/04/2014
	*/

	-- Update customer interest
        UPDATE  Allocations.dbo.CustomerInterest
        SET     CustomerInterestStatusID = 2
        WHERE   CustomerInterestID IN (
                SELECT  CI.CustomerInterestID
                FROM    Allocations.dbo.CustomerApplication CA
                        JOIN Allocations.dbo.CustomerInterest CI ON CI.CustomerApplicationID = CA.CustomerApplicationId
                WHERE   ca.ApplicationStatusID IN ( 2 ) -- APPLICATION IS CLOSED
                        AND CI.CustomerInterestStatusID IN ( 10, 4, 1 ) )
	
	-- Update customer interest status reasons
        UPDATE  Allocations.dbo.CustomerInterestStatusReasons
        SET     CustomerInterestStatusID = 2
        WHERE   CustomerInterestStatusReasonsID IN (
                SELECT  CI.CustomerInterestStatusReasonsID
                FROM    Allocations.dbo.CustomerApplication CA
                        JOIN Allocations.dbo.CustomerInterest CI ON CI.CustomerApplicationID = CA.CustomerApplicationId
                WHERE   ca.ApplicationStatusID IN ( 2 ) -- APPLICATION IS CLOSED
                        AND CI.CustomerInterestStatusID IN ( 10, 4, 1 ) ) --Matched from Waiting List & Interested
END


