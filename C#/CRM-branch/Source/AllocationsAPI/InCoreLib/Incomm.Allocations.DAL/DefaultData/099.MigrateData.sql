USE [Allocations]
GO

/****** Object:  Trigger [trVBLIncomeDetails]    Script Date: 09/22/2016 10:28:54 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trVBLIncomeDetails]'))
DROP TRIGGER [dbo].[trVBLIncomeDetails]
GO
GO


DELETE FROM dbo.AuditVBLIncomeDetails
DELETE FROM dbo.VBLRequestedPropertymatchDetails
DELETE FROM dbo.VBLAddresses
DELETE FROM dbo.VBLContacts
DELETE FROM dbo.VBLRequestedPropertyAgeRestrictions
DELETE FROM  [Allocations].[dbo].VBLRequestedPropertyAgeRestrictions
DELETE FROM [VBLApplications]
SET IDENTITY_INSERT [dbo].[VBLApplications] ON
INSERT INTO [Allocations].[dbo].[VBLApplications]
		   (ApplicationId
		   ,[ApplicationStatusID]
		   ,[ApplicationStatusReason]
		   ,[ApplicationDate]
		   ,[ApplicationEligible]
		   ,[HOALevelOfNeedDate]
		   ,[ApplicationLevelOfNeedID]
		   ,[DataProtectionIsPrinted]
		   ,[DataProtectionIsSigned]
		   ,[DataProtectionConsented]
		   ,[HOACaseRef]
		   ,[HOAOutcome]
		   ,[HOAOutcomeDate]
		   ,[HOACaseIsOpen]
		   ,[HOAEligabilitySet]
		   ,[HOAAppointmentActivityID]
		   ,[HOAAppointmentScheduledStart]
		   ,[HOAAppointmentStatusID]
		   ,[HOAAppointmentIsAssessor]
		   ,[VBLSatisfationActivityID]
		   ,[ApplicationClosedDate]
		   ,[ResidencyTypeId]
		   ,[LandLordName]
		   ,[MoveReasonId]
		   ,[TenancyTypeId]
		   ,[LandLordId]
		   ,[LeaveVacantProperty]
		   ,[IsSignedDeclarationUploaded]
		   ,[MatchToMutualExchage]
		   ,[ISMainTenant]
		   ,[CreatedDate]
		   ,[ModifiedBy]
		   ,[DateMovedIn]
		  )
   ( SELECT
		  CustomerApplicationId
		   ,[ApplicationStatusID]
		   ,[ApplicationStatusReason]
		   ,[ApplicationDate]
		   ,[ApplicationEligable]
		   ,[HOALevelOfNeedDate]
		   ,[ApplicationLevelOfNeedID]
		   ,[DataProtectionIsPrinted]
		   ,[DataProtectionIsSigned]
		   ,[DataProtectionConsented]
		   ,[HOACaseRef]
		   ,[HOAOutcome]
		   ,[HOAOutcomeDate]
		   ,[HOACaseIsOpen]
		   ,[HOAEligabilitySet]
		   ,[HOAAppointmentActivityID]
		   ,[HOAAppointmentScheduledStart]
		   ,[HOAAppointmentStatusID]
		   ,[HOAAppointmentIsAssessor]
		   ,[VBLSatisfationActivityID]
		   ,[ApplicationClosedDate]
		   ,(CASE WHEN ca.ResidencyTypeCode = 'Hospital' THEN 9
	   WHEN ca.ResidencyTypeCode = 'Hostel' THEN 8
	   WHEN ca.ResidencyTypeCode = 'LiveFamFr' THEN 5
	   WHEN ca.ResidencyTypeCode = 'Lodge' THEN 1
	   WHEN ca.ResidencyTypeCode = 'NFA' THEN 4
	   WHEN ca.ResidencyTypeCode = 'Own' THEN 2
	   WHEN ca.ResidencyTypeCode = 'Prison' THEN 10
	   WHEN ca.ResidencyTypeCode = 'Rent' THEN 3
	   WHEN ca.ResidencyTypeCode = 'TemAcc' THEN 7
	   ELSE null
	  END )
		   ,[LandLordName]
		   ,(CASE [MoveReasonId] when '-100' then 33 else [MoveReasonId] END)
		   ,(select TOP 1 [TenancyTypeId] FROM TenancyType t WHERE t.TenancyTypeAndCategoryCode = [TenancyTypeCode] ORDER BY TenancyTypeId)
		   ,(select TOP 1 [LandLordId] FROM [LandLord] l WHERE l.LandlordCode = [LandLordCode] ORDER BY LandLordId)
		   ,[LeaveVacantProperty]
		   ,[IsSignedDeclarationUploaded]
		   ,ISNULL([MatchToMutualExhanges],0)
		   ,ISNULL([MatchToMutualExhanges],0)
		   ,GETDATE()
		   ,LastUpdatedUserName
			,(SELECT TOP 1 TENANCY_START_DATE FROM MasterReferenceData.dbo.TBL_TENANCY WHERE TENANCY_REFERENCE = (SELECT TOP 1 TENANCYREF FROM MasterReferenceData.dbo.TBL_CUSTOMER WHERE TENANT_CODE = TenancyCode AND PROPERTYREF = PropertyCode))
		   FROM CustomerApplication ca
		   WHERE [ApplicationStatusID] > 0)
SET IDENTITY_INSERT [dbo].[VBLApplications] OFF

  UPDATE [Allocations].[dbo].[VBLApplications] SET TenancyTypeId = 3 WHERE TenancyTypeId = 4
  UPDATE [Allocations].[dbo].[VBLApplications] SET TenancyTypeId = 6 WHERE TenancyTypeId > 6

--UPDATE [VBLApplications] SET LandLordId =(SELECT LandlordId from Landlord where Name ='Private Landlord') WHERE ISNULL(LandlordName,'')!='' and ISNULL(LandLordId,0)=0
DELETE FROM [VBLContacts]
SET IDENTITY_INSERT [dbo].[VBLContacts] ON
INSERT INTO [Allocations].[dbo].[VBLContacts]
		   (ContactId
		   ,[ApplicationID]
		   ,[ContactTypeID]
		   ,[TitleId]
		   ,[Forename]
		   ,[Surname]
		   ,[ImmigrationControl]
		   ,[PublicFunds]
		   ,[LivedInUkForFiveYears]
		   ,[DateOfBirth]
		   ,[NationalityTypeId]
		   ,[RelationshipID]
		   ,[IsMovingIn]
		   ,[GenderID]
		   ,[LanguageId]
		   ,[IsPregnant]
		   ,[PregnancyDueDate]
		   ,[Active]
		   ,[EthnicityId]
		   ,[ModifiedBy]
		   ,[MainTenantOnTenancy]
		   ,CreatedDate
		   )
	 (SELECT ContactID
			,[CustomerApplicationID]
		   ,[ContactTypeID]
		   ,CASE [TitleId] WHEN -100 THEN 11  WHEN 0 THEN 11 when 9 then 11 ELSE [TitleId] END
		   ,[Forename]
		   ,[Surname]
		   ,0
		   ,1
		   ,[LivedInUkForFiveYears]
		   ,[DateOfBirth]
		   ,CASE [NationalityID] WHEN -100 THEN 14 WHEN 0 THEN 14  ELSE [NationalityID] END
			 ,CASE [RelationshipID] WHEN -100 THEN 31  WHEN 0 THEN 31 ELSE [RelationshipID] END
		   ,[IsMovingIn]
		   ,CASE [GenderID] WHEN -100 THEN 3 WHEN 0 THEN 3 ELSE [GenderID] END
		   ,53
		   ,[IsPregnant]
		   ,[PregnancyDueDate]
		   ,[Active]
		   ,CASE [EthnicityId] WHEN -100 THEN 20  WHEN 0 THEN 20 ELSE [EthnicityId] END
		   ,[LastUpdatedUserName]
		   ,ISNULL( [MainTenant],0)
		   ,GETDATE()
		   FROM Contact WHERE CustomerApplicationID IN (SELECT ApplicationId FROM VBLApplications ))
SET IDENTITY_INSERT [dbo].[VBLContacts] OFF
		   /* Migrate Address*/
DELETE FROM [VBLAddresses]

 CREATE TABLE #MainAddress(
 CustomerApplicationId int,
 Address1 nvarchar(255),
 Address2 nvarchar(255),
 Address3 nvarchar(255),
 Address4 nvarchar(255),
 PostCode nvarchar(50) ,
 AddressType int     ,
 LivedAtAddressDays int,
 ContactId int,
 CreatedDate DateTime,
 ModifiedBy  nvarchar(255),
 IsActive    bit
 )
INSERT INTO #MainAddress
(CustomerApplicationId, Address1, Address2, Address3, Address4, PostCode,AddressType,LivedAtAddressDays,ContactId,CreatedDate,ModifiedBy,IsActive)
SELECT [CustomerApplicationId],[MainAddress1]
	  ,[MainAddress2]
	  ,[MainAddress3]
	  ,[MainAddress4]
	  ,[MainPostCode]
	  ,0
	  ,null
	  ,(SELECT ContactId FROM Contact Where CustomerApplicationId = a.CustomerApplicationId and ContactTypeId = 1)
	  ,GetDate()
	  ,LastUpdatedUserName
	  ,1
FROM [Allocations].[dbo].[CustomerApplication] a
WHERE a.CustomerApplicationId IN (SELECT CustomerApplicationId FROM VBLApplications)
 SET IDENTITY_INSERT [dbo].[VBLAddresses] ON
INSERT INTO [Allocations].[dbo].[VBLAddresses]
		   ([ApplicationId]
		   ,[AddressId]
		   ,[AddressType]
		   ,[AddressLine1]
		   ,[AddressLine2]
		   ,[AddressLine3]
		   ,[AddressLine4]
		   ,[PostCode]
		   ,[IsActive]
		   ,[CreatedDate]
		   ,[ModifiedBy]
		  )
SELECT		M.CustomerApplicationId
			,M.CustomerApplicationId
		   ,M.[AddressType]
		   ,M.[Address1]
		   ,M.[Address2]
		   ,M.[Address3]
		   ,M.[Address4]
		   ,M.[PostCode]
		   ,M.[IsActive]
		   ,M.[CreatedDate]
		   ,M.[ModifiedBy] FROM #MainAddress M
	 where   M.CustomerApplicationId  in  (select ApplicationId from VBLApplications)
	 AND M.CustomerApplicationId > 0
	 ORDER BY M.[CustomerApplicationId], AddressType
  DROP TABLE  #MainAddress
 SET IDENTITY_INSERT [dbo].[VBLAddresses] OFF
DELETE FROM [Allocations].[dbo].[VBLRequestedPropertymatchDetails]


INSERT INTO [Allocations].[dbo].[VBLRequestedPropertymatchDetails]
		   ([CatOrDog]
	  ,[RehousePet]
	  ,[CommunalEntrance]
	  ,[HighRise]
	  ,[AgeRestricted]
	  ,[FloorLevel]
		   ,[LiftServed]
		   ,[TrustCare]
		   ,[Sheltered]
		   ,[Garden]
		   ,[WheelChairAdapted]
		   ,[RampedAccess]
		   ,[LevelAccessProperty]
		   ,[StairLift]
		   ,[WalkInShower]
		   ,[StepInShower]
		   ,[ApplicationId]
		   ,[StartDate]
		   ,[EndDate]
		   ,[CreatedDate]
		   ,[ModifiedBy]
		   ,[ModifiedDate]
		   ,[IsNewVBLApplication]
		   ,NumberOfSteps
			,[RequireAdaptations])
   (SELECT
			CASE WHEN pet.petismoving = 1 THEN 1 WHEN pet.petismoving IS NULL THEN 0 ELSE 0 END
			,CASE WHEN pet.petismoving = 0 THEN 1 WHEN pet.petismoving IS NULL THEN 0 ELSE 0 END
			,1
			,1
			,CAST ((CASE WHEN ca.agecriteria > 18 THEN 1 ELSE 0 end)AS bit)
			,ca.[MatchingFloorlevel]
		   ,null
		   ,ca.[MatchingTrustCare]
		   ,ca.[MatchingSheltered]
		   ,ca.[MatchingGarden]
		   ,ca.[MatchingWheelChairAdapted]
		   ,ca.[MatchingRampedAccess]
		   ,ca.[MatchingLevelAccessProperty]
		   ,ca.[MatchingStairLift]
		   ,ca.[MatchingWalkInShower]
		   ,ca.[MatchingStepInShower]
		   ,ca.[CustomerApplicationId]
		   ,ca.[MatchingEarliestMoveDate]
		   ,ca.[MatchingLatestMoveDate]
		   ,GETDATE()
		   ,ca.[LastUpdatedUserName]
		   ,GETDATE()
		   ,0
		   ,5
		   ,CASE WHEN (ca.[MatchingWheelChairAdapted] = 1 or [MatchingRampedAccess] = 1 or [MatchingStairLift] = 1 or ca.[MatchingWalkInShower] = 1 or ca.[MatchingStepInShower] = 1)THEN 1 else 0 end
		   FROM CustomerApplication ca
		   OUTER APPLY (SELECT TOP 1 cp.customerapplicationid, cp.petismoving FROM customerPet cp WHERE petid IN(1,2) AND ca.customerapplicationid = cp.customerapplicationid)AS pet
		WHERE 	ca.[CustomerApplicationId] IN (SELECT c.[CustomerApplicationId] FROM Contact c)


   )

INSERT INTO [Allocations].[dbo].VBLRequestedPropertyAgeRestrictions
		   ([ApplicationId]
		   ,[AgeRestrictionId]
		   ,[CreatedDate])

(SELECT r.ApplicationId,h.AgeRestrictionId,GETDATE() FROM
AgeRestrictions h INNER JOIN (SELECT CustomerApplicationId,
LTRIM(RTRIM(m.n.value('.[1]','varchar(8000)'))) AS AgeRestrictions
FROM
(
SELECT CustomerApplicationId,CAST('<XMLRoot><RowData>' + REPLACE(AgeCriteria,',','</RowData><RowData>') + '</RowData></XMLRoot>' AS XML) AS x
FROM   CustomerApplication
)t
CROSS APPLY x.nodes('/XMLRoot/RowData')m(n))
as query
ON RTRIM(LTRIM(Replace(Replace(h.Name,'+',''),'.00',''))) = RTRIM(LTRIM(Replace(query.AgeRestrictions,'.00','')))
INNER JOIN VBLApplications r
ON query.CustomerApplicationId = r.ApplicationId
AND r.ApplicationId IN (select ApplicationId from VBLRequestedPropertymatchDetails)
)
--HeatingTypes
DELETE FROM [Allocations].[dbo].[VBLRequestedPropertyHeatingTypes]

INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyHeatingTypes]
		   ([ApplicationId]
		   ,[HeatingTypeId]
		   ,[CreatedDate])

(SELECT r.ApplicationId,h.HeatingTypeId,GETDATE() FROM
HeatingType h INNER JOIN (SELECT CustomerApplicationId,
LTRIM(RTRIM(m.n.value('.[1]','varchar(8000)'))) AS MatchingHeatingTypesNames
FROM
(
SELECT CustomerApplicationId,CAST('<XMLRoot><RowData>' + REPLACE(MatchingHeatingTypesNames,',','</RowData><RowData>') + '</RowData></XMLRoot>' AS XML) AS x
FROM   CustomerApplication
)t
CROSS APPLY x.nodes('/XMLRoot/RowData')m(n))
as query
ON h.Name = query.MatchingHeatingTypesNames
INNER JOIN VBLRequestedPropertymatchDetails r
ON query.CustomerApplicationId = r.ApplicationId)

--Schemes
DELETE FROM [Allocations].[dbo].[VBLRequestedPropertySchemes]
INSERT INTO [Allocations].[dbo].[VBLRequestedPropertySchemes]
		   ([ApplicationId]
		   ,[SchemeId]
		   ,[CreatedDate])

(SELECT r.ApplicationId,s.SchemeId,GETDATE() FROM
Scheme s INNER JOIN (SELECT CustomerApplicationId,
LTRIM(RTRIM(m.n.value('.[1]','varchar(8000)'))) AS MatchingSchemesNames
FROM
(
SELECT CustomerApplicationId,CAST('<XMLRoot><RowData>' + REPLACE(MatchingSchemesNames,',','</RowData><RowData>') + '</RowData></XMLRoot>' AS XML) AS x
FROM   CustomerApplication
)t
CROSS APPLY x.nodes('/XMLRoot/RowData')m(n))
as query
ON s.Name = query.MatchingSchemesNames
INNER JOIN VBLRequestedPropertymatchDetails r
ON query.CustomerApplicationId = r.ApplicationId)

	DECLARE @Results AS TABLE(
Neighbourhoodid int,
ApplicationID int)

INSERT INTO @Results(Neighbourhoodid, ApplicationID)
(SELECT DISTINCT pn.neighbourhoodid
,ca.CustomerApplicationId
FROM [MasterReferenceData].[dbo].[PropertyNeighbourhoods] pn
inner JOIN [MasterReferenceData].[dbo].[PropertyOutputAreas] poa
ON pn.NeighbourhoodId = poa.neighbourhoodid
inner JOIN [MasterReferenceData].[dbo].[PropertyPostcodes] pp
ON poa.outputareaid = pp.outputareaid
inner JOIN [MasterReferenceData].[dbo].[TBL_SHAPEPOSTCODES] spc
ON pp.Postcode = spc.postcode
inner JOIN [MasterReferenceData].[dbo].[TBL_MAPSHAPES] ms
ON spc.ShapeId = ms.ShapeId
inner JOIN Allocations.dbo.CustomerApplication ca
ON ms.LocalId = ca.CustomerApplicationId
WHERE pn.Name NOT LIKE '%(sheltered)%'
)

DECLARE @RSLs AS TABLE(
POST_CODE NVARCHAR(10),
NEIGHBOURHOOD_COMB VARCHAR(30)
)

INSERT INTO @RSLs
		( POST_CODE, NEIGHBOURHOOD_COMB )
(SELECT p.Postcode, s.SubNeighbourhoodCodeComb FROM Allocations.dbo.tbl_Property p
INNER JOIN CloudVoids.dbo.SubNeighbourhood s
ON s.SubNeighbourhoodCode = p.SubNeighbourhood)

INSERT INTO @Results(Neighbourhoodid, ApplicationID)
(
SELECT DISTINCT pn.neighbourhoodid, ca.CustomerApplicationId FROM
[MasterReferenceData].[dbo].[PropertyNeighbourhoods] pn
INNER JOIN [MasterReferenceData].[dbo].[PropertyOutputAreas] poa
ON poa.neighbourhoodid = pn.NeighbourhoodId
INNER JOIN [MasterReferenceData].[dbo].[PropertyPostcodes] pp
ON pp.outputareaid = poa.outputareaid
INNER JOIN (SELECT POST_CODE,NEIGHBOURHOOD_COMB FROM [MasterReferenceData].[dbo].[TBL_PROPERTY] UNION (SELECT * FROM @RSLs)) tp
ON tp.POST_CODE = pp.Postcode
INNER JOIN [Allocations].[dbo].[MatchingLocations] ml
ON ml.MatchingCode = tp.NEIGHBOURHOOD_COMB
INNER JOIN Allocations.dbo.CustomerApplication ca
ON ca.CustomerApplicationId = ml.CustomerApplicationID
WHERE pn.Name NOT LIKE '%(sheltered)%'
)

 DECLARE @SchemMap AS TABLE(
   schemeId INT,
   Nid int
   )

   INSERT INTO @SchemMap
		   ( schemeId, Nid )
   VALUES  ( 1, -- schemeId - int
			 399  -- Nid - int
			 ),
( 2, -- schemeId - int
			 405  -- Nid - int
			 ),
( 3, -- schemeId - int
			 406  -- Nid - int
			 ),
( 4, -- schemeId - int
			 406  -- Nid - int
			 ),
( 5, -- schemeId - int
			 406  -- Nid - int
			 ),
( 6, -- schemeId - int
			 406  -- Nid - int
			 ),
( 7, -- schemeId - int
			 412  -- Nid - int
			 ),
( 8, -- schemeId - int
			 413  -- Nid - int
			 ),
( 9, -- schemeId - int
			 419  -- Nid - int
			 ),
( 10, -- schemeId - int
			 420  -- Nid - int
			 ),
( 11, -- schemeId - int
			 406  -- Nid - int
			 ),
( 13, -- schemeId - int
			 414  -- Nid - int
			 ),
( 14, -- schemeId - int
			 415  -- Nid - int
			 ),
( 15, -- schemeId - int
			 418  -- Nid - int
			 ),
( 16, -- schemeId - int
			 417  -- Nid - int
			 ),
( 17, -- schemeId - int
			 410  -- Nid - int
			 ),
( 18, -- schemeId - int
			 409  -- Nid - int
			 ),
( 19, -- schemeId - int
			 403  -- Nid - int
			 ),
( 20, -- schemeId - int
			 421  -- Nid - int
			 ),
( 22, -- schemeId - int
			 408  -- Nid - int
			 ),
( 23, -- schemeId - int
			 404  -- Nid - int
			 ),
( 9, -- schemeId - int
			 400  -- Nid - int
			 ),
( 10, -- schemeId - int
			 402  -- Nid - int
			 ),
( 16, -- schemeId - int
			 401  -- Nid - int
			 ),
( 18, -- schemeId - int
			 411  -- Nid - int
			 ),
( 20, -- schemeId - int
			 416  -- Nid - int
			 ),
( 20, -- schemeId - int
			 407  -- Nid - int
			 )
INSERT INTO @Results( Neighbourhoodid, ApplicationID )
(
SELECT  sm.Nid,ms.customerapplicationid FROM [Allocations].[dbo].[MatchingSchemes]ms
RIGHT JOIN @SchemMap sm
ON ms.SelectedValue = sm.schemeId
)

DECLARE @UniqueResults AS TABLE(
Neighbourhoodid int,
ApplicationID int)

INSERT INTO @UniqueResults(Neighbourhoodid, ApplicationID)
(
SELECT distinct * FROM @Results
)

SELECT * FROM @UniqueResults ORDER BY ApplicationID

DECLARE @TempNeighbourhood AS TABLE(
RPPNId INT IDENTITY (1,1),
ApplicationId INT,
CreatedDate DATETIME,
iscurrent BIT,
createdby NVARCHAR(40)
)
INSERT INTO @TempNeighbourhood( ApplicationId,CreatedDate,iscurrent,createdby)(SELECT DISTINCT applicationId, GETDATE(),1,'Data Migration' FROM @UniqueResults WHERE ApplicationId IN(SELECT applicationid FROM dbo.VBLRequestedPropertymatchDetails))
SELECT * FROM @TempNeighbourhood
DELETE FROM [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]
DELETE FROM [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoods]
SET IDENTITY_INSERT [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoods] on
  INSERT INTO  [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoods]([RequestedPropertyPrefferedNeighbourhoodId]
	  ,[ApplicationId]
	  ,[CreatedDate],[IsCurrent]
	  ,[CreatedBy])(SELECT RPPNId, ApplicationId,CreatedDate,iscurrent,createdby FROM @TempNeighbourhood)
SET IDENTITY_INSERT [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoods] OFF

  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId < 1000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 1000 AND tn.applicationid < 2000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 2000 AND tn.applicationid < 3000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 3000 AND tn.applicationid < 4000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 4000 AND tn.applicationid < 5000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 5000 AND tn.applicationid < 6000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 6000 AND tn.applicationid < 7000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 7000 AND tn.applicationid < 8000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 8000 AND tn.applicationid < 9000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 9000 AND tn.applicationid < 10000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 10000 AND tn.applicationid < 11000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 11000 AND tn.applicationid < 12000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 12000 AND tn.applicationid < 13000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 13000 AND tn.applicationid < 14000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 14000 AND tn.applicationid < 15000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 15000 AND tn.applicationid < 16000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 16000 AND tn.applicationid < 17000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 17000 AND tn.applicationid < 18000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 18000 AND tn.applicationid < 19000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 19000 AND tn.applicationid < 20000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 20000 AND tn.applicationid < 21000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 21000 AND tn.applicationid < 22000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 22000 AND tn.applicationid < 23000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 23000 AND tn.applicationid < 24000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 24000 AND tn.applicationid < 25000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 25000 AND tn.applicationid < 26000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 26000 AND tn.applicationid < 27000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 27000 AND tn.applicationid < 28000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 28000 AND tn.applicationid < 29000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 29000 AND tn.applicationid < 30000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 30000 AND tn.applicationid < 31000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 31000 AND tn.applicationid < 32000        )
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPrefferedNeighbourhoodDetails]([NeighbourhoodId]
	  ,[RequestedPropertyPrefferedNeighbourhoodId],[CreatedDate] ,[CreatedBy])(SELECT ur.NeighbourhoodId, tn.RPPNId, GETDATE(), 'Data Migration' FROM @UniqueResults ur, @TempNeighbourhood tn WHERE ur.ApplicationID = tn.ApplicationId  AND tn.ApplicationId >= 32000       )



--PropertyType
DELETE FROM [VBLRequestedPropertyPropertyTypes]
INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPropertyTypes]
		   ([ApplicationId]
		   ,[PropertyTypeId]
		   ,[CreatedDate])

(SELECT r.ApplicationId,p.PropertyTypeId,GETDATE() FROM
PropertyType p INNER JOIN (SELECT CustomerApplicationId,
LTRIM(RTRIM(m.n.value('.[1]','varchar(8000)'))) AS MatchingPropertyTypesNames
FROM
(
SELECT CustomerApplicationId,CAST('<XMLRoot><RowData>' + REPLACE(MatchingPropertyTypesNames,',','</RowData><RowData>') + '</RowData></XMLRoot>' AS XML) AS x
FROM   CustomerApplication
)t
CROSS APPLY x.nodes('/XMLRoot/RowData')m(n))
as query
ON p.Name = query.MatchingPropertyTypesNames
INNER JOIN VBLRequestedPropertymatchDetails r
ON query.CustomerApplicationId = r.ApplicationId)

-- Number of bedroom

DELETE FROM [Allocations].[dbo].[VBLRequestedPropertyPropertySizes]
Update lstNumberBedrooms
SET [Number Bedrooms Desc]= '1 Bedrooms'
WHERE [Number Bedrooms] = 1

INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyPropertySizes]
		   ([ApplicationId]
		   ,[PropertySizeId]
		   ,CreatedDate)


(SELECT r.ApplicationId,n.[Number Bedrooms],GETDATE() FROM
lstNumberBedrooms n INNER JOIN (SELECT CustomerApplicationId,
LOWER(LTRIM(RTRIM(m.n.value('.[1]','varchar(8000)')))) AS MatchingNumBedroomsNames
FROM
(
SELECT CustomerApplicationId,CAST('<XMLRoot><RowData>' + REPLACE(MatchingNumBedroomsNames,',','</RowData><RowData>') + '</RowData></XMLRoot>' AS XML) AS x
FROM   CustomerApplication
)t
CROSS APPLY x.nodes('/XMLRoot/RowData')m(n))
as query
ON LOWER(n.[Number Bedrooms Desc]) = LOWER(query.MatchingNumBedroomsNames)
INNER JOIN VBLRequestedPropertymatchDetails r
ON query.CustomerApplicationId = r.ApplicationId)

Update lstNumberBedrooms
SET [Number Bedrooms Desc]= '1 bedroom'
WHERE [Number Bedrooms] = 1

DELETE FROM [Allocations].[dbo].[VBLContactByDetails]


INSERT INTO [Allocations].[dbo].[VBLContactByDetails]
		   ([ContactId]
		   ,[ContactById]
		   ,[ContactValue])
	(Select c.ContactID,(SELECT ContactById FROM ContactBy WHERE Code ='Phone'),a.TelNum from Contact c
	INNER JOIN CustomerApplication a
	ON c.CustomerApplicationID = a.CustomerApplicationId
	where a.ContactByPhone = 1
	AND c.ContactID IN (SELECT ContactID FROM VBLContacts)
	)

INSERT INTO [Allocations].[dbo].[VBLContactByDetails]
		   ([ContactId]
		   ,[ContactById]
		   ,[ContactValue])
	(Select c.ContactID,(SELECT ContactById FROM ContactBy WHERE Code ='Mobile'),a.MobileNum from Contact c
	INNER JOIN CustomerApplication a
	ON c.CustomerApplicationID = a.CustomerApplicationId
	where a.ContactByMobile = 1
	AND c.ContactID IN (SELECT ContactID FROM VBLContacts)
	)

	INSERT INTO [Allocations].[dbo].[VBLContactByDetails]
		   ([ContactId]
		   ,[ContactById]
		   ,[ContactValue])
	(Select c.ContactID,(SELECT ContactById FROM ContactBy WHERE Code ='MobileText'),a.MobileNum from Contact c
	INNER JOIN CustomerApplication a
	ON c.CustomerApplicationID = a.CustomerApplicationId
	where a.ContactByMobileText = 1
	AND c.ContactID IN (SELECT ContactID FROM VBLContacts)
	)


	INSERT INTO [Allocations].[dbo].[VBLContactByDetails]
		   ([ContactId]
		   ,[ContactById]
		   ,[ContactValue])
	(Select c.ContactID,(SELECT ContactById FROM ContactBy WHERE Code ='Mail'),a.LivingAddress1+ ' '+a.LivingAddress2+ ' '+a.LivingAddress3+ ' '+a.LivingAddress4+ ' '+a.LivingPostCode from Contact c
	INNER JOIN CustomerApplication a
	ON c.CustomerApplicationID = a.CustomerApplicationId
	where a.ContactByMail = 1
	AND c.ContactID IN (SELECT ContactID FROM VBLContacts)
	)

INSERT INTO [Allocations].[dbo].[VBLContactByDetails]
		   ([ContactId]
		   ,[ContactById]
		   ,[ContactValue])
	(Select c.ContactID,(SELECT ContactById FROM ContactBy WHERE Code ='SecondaryNumber'),a.SecondaryPhoneNum from Contact c
	INNER JOIN CustomerApplication a
	ON c.CustomerApplicationID = a.CustomerApplicationId
	where a.ContactBySecondaryNum = 1
	AND c.ContactID IN (SELECT ContactID FROM VBLContacts)
	)


UPDATE [Allocations].[dbo].[VBLContactByDetails] SET [ContactById] = 3 WHERE [ContactById] = 9

DELETE FROM [Allocations].[dbo].[VBLIncomeDetails]

INSERT INTO [Allocations].[dbo].[VBLIncomeDetails]
		   ([IncomeTypeId]
		   ,[IncomeFrequencyId]
		   ,[Amount]
		   ,[ContactId]
		   ,[CreatedDate]
		   ,[ModifiedBy]
		   ,[ModifiedDate])
	(SELECT
IncomeTypeID,
Case IncomeFrequencyID when 0 then 5  when -100 then 5 else  IncomeFrequencyID end,
IncomeAmount,
ContactID,
GETDATE(),
LastUpdatedUserName,
GETDATE()
FROM ContactIncome where ContactID in (SELECT ContactID FROM VBLContacts) AND Active =1)

update [Allocations].[dbo].[CustomerInterest] set [CustomerInterestStatusID] = 2 where [CustomerInterestStatusID] = 0

DELETE FROM [VBLCustomerInterests]

SET IDENTITY_INSERT [Allocations].[dbo].[VBLCustomerInterests] ON

insert into [Allocations].[dbo].[VBLCustomerInterests]
	([CustomerInterestId]
	  ,[ApplicationId]
	  ,[PropertyCode]
	  ,[CustomerInterestStatusId]
	  ,[VoidContactId]
	  ,[IsPreViewingUndertaken]
	  ,[CreatedDate]
	  ,[TaskId]
	  ,[VoidId]
	  ,StatusReasonsDate
	  ,CustomerDecision
	  ,ActivityId
	  )
	  (
	  select
	  [CustomerInterestId]
	  ,[CustomerApplicationId]
	  ,[PropertyCode]
	  ,[CustomerInterestStatusId]
	  ,[VoidContactId]
	  ,ISNULL([IsPreViewingUndertaken],0)
	  ,(SELECT MAX(a.ChangeDate) FROM dbo.AuditCustomerInterest a WHERE a.CustomerInterestID = CustomerInterestID AND a.ChangeType='Created')
	  ,ISNULL([TaskId],0)
	  ,0
	  ,(SELECT MAX(a.ChangeDate) FROM dbo.AuditCustomerInterest a WHERE a.CustomerInterestID = CustomerInterestID AND a.ChangeType='Created')
	  ,0
	  ,0
	  from [Allocations].[dbo].[CustomerInterest]
	  WHERE CustomerApplicationID IN(SELECT CustomerApplicationId FROM dbo.CustomerApplication)
	  )

SET IDENTITY_INSERT [Allocations].[dbo].[VBLCustomerInterests] OFF
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 18 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'JephsonHousingGroup')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 3 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'ManninghamHousingAssociation')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 2 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'AccentHousing')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 27 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'Bradford Incommunities')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 24 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'Sanctuary Housing')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 25 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'AffinitySutton')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 22 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'PlacesForPeople')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 19 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'BradfordNominations')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 26 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'YorkshireHousing')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 12 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'AnchorHousing')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 16 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'HomeGroup')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 6 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'YourHousingGroup')
  UPDATE dbo.VBLCustomerInterests SET LandlordId = 15 WHERE PropertyCode IN (SELECT propertyid FROM dbo.tbl_Property WHERE RSL = 'Hanover')
UPDATE t
	SET t.voidid = ISNULL(t2.voidid,0)
	FROM [Allocations].[dbo].[VBLCustomerInterests] t
	INNER JOIN
		(
			SELECT voidid,taskid
			FROM CloudVoids.dbo.Task
		) t2 ON t.taskid = t2.taskid;


UPDATE [Allocations].[dbo].[VBLCustomerInterests]
	SET
		[StatusReasonsDate] = BD.StatusReasonsDate
		,[OutcomeNotes] = BD.OutcomeNotes
		,[CustomerDecision] = BD.CustomerDecision
		,[Notes] = BD.Notes
		,[ActivityId] = BD.ActivityID
	FROM
		[Allocations].[dbo].[CustomerInterestStatusReasons] BD
	WHERE
		BD.CustomerInterestStatusReasonsID = (select MAX(customerintereststatusreasonsid) from [Allocations].[dbo].[CustomerInterestStatusReasons] where [Allocations].[dbo].[VBLCustomerInterests].CustomerInterestId = [Allocations].[dbo].[CustomerInterestStatusReasons].CustomerInterestID)

UPDATE s
	SET s.HOAContact = ISNULL(s2.AllocatedUserID,0)
	FROM [Allocations].[dbo].[VBLApplications] s
	INNER JOIN
		(
			SELECT AllocatedUserID,[CaseRefNumber]
			FROM [Allocations].[dbo].[tblHOAssessment]
		) s2 ON s.HOACaseRef= s2.[CaseRefNumber];

DELETE FROM [VBLTenantDetails]

INSERT INTO [Allocations].[dbo].[VBLTenantDetails] (
	[ContactId]
	,[TenantCode]
	,[MainTenant]
	,[IsActive]
	,[CreatedDate]
	,[ModifiedBy]
	,[ModifiedDate]
	)
SELECT c.ContactID
	,ISNULL(TenancyCode, '')
	,1
	,1
	,GETDATE()
	,'Data Load'
	,GETDATE()
FROM CustomerApplication a
INNER JOIN Contact c ON a.CustomerApplicationID = c.CustomerApplicationId
WHERE ISNULL(a.TenancyCode, '') ! = ''
	AND ISNULL(c.ContactTypeID, 0) = 1
	AND c.ContactID IN (
		SELECT ContactID
		FROM VBLContacts
		)
--Update IsCurrent status of the selected Preferred Neighbourhoods
UPDATE v
SET v.IsCurrent = 1
 FROM VBLRequestedPropertyPrefferedNeighbourhoods v

LEFT OUTER JOIN (
   SELECT MIN(RequestedPropertyPrefferedNeighbourhoodId) as RequestedPropertyPrefferedNeighbourhoodId, ApplicationId
   FROM VBLRequestedPropertyPrefferedNeighbourhoods
   GROUP BY ApplicationId
) as KeepRows ON
   v.RequestedPropertyPrefferedNeighbourhoodId = KeepRows.RequestedPropertyPrefferedNeighbourhoodId
WHERE
   KeepRows.RequestedPropertyPrefferedNeighbourhoodId IS NOT NULL

   DELETE FROM [Allocations].[dbo].[VBLMutualExchagePropertyDetails]
  INSERT INTO [Allocations].[dbo].[VBLMutualExchagePropertyDetails]([ApplicationId]
	  ,[PropertyCode]
	  ,[PropertyIsTerminating]
	  ,[Rent]
	  ,[ServiceCharges]
	  ,[OtherCharges]
	  ,[PropertyNumberOfBedrooms]
	  ,[AgeCritera]
	  ,[HeatingTypeId]
	  ,[FlatFloorLevel]
	  ,[HasStepsToAccess]
	  ,[NumberOfStepsToAccess]
	  ,[HasGarden]
	  ,[HasLift]
	  ,[HasTrustcare]
	  ,[IsWheelChairAdapted]
	  ,[HasRampledAccess]
	  ,[IsLevelAccessProperty]
	  ,[HasStairLift]
	  ,[HasWalkInShower]
	  ,[HasStepInShower]
	  ,[PropertyTypeId]
	  ,[PropertySizeId]
	  ,[PropertyEntranceTypeId]
	  ,[PropertyBlockTypeId]
	  ,[AgeRestrictionId]
	  ,[CreatedDate]
	  ,[CreatedBy])
	  (SELECT [CustomerApplicationId]
	  ,[PropertyCode]
	  ,CAST(1 AS BIT)
	  ,[Rent]
	  ,[ServiceCharges]
	  ,[OtherCharges]
	  ,[PropertyNumBedrooms]
	  ,CASE WHEN ([AgeCriteria] = '18.00') THEN 1 WHEN ([AgeCriteria] = '55.00') THEN 2 WHEN ([AgeCriteria] = '65.00') THEN 3 ELSE 1 end
	  ,CASE WHEN ([HeatingType] = 'CENTH')THEN 1 WHEN  ([HeatingType] = 'ELECH')THEN 3 WHEN ([HeatingType] = 'WRMAIRH') THEN 2 ELSE 1 end
	  ,[FlatFloorLevel]
	  ,[HasStepsToAccess]
	  ,[NumStepsToAccess]
	  ,[HasGarden]
	  ,[HasLift]
	  ,[HasTrustcare]
	  ,[IsWheelChairAdapted]
	  ,[HasRampedAccess]
	  ,[IsLevelAccessProperty]
	  ,[HasStairlift]
	  ,[HasWalkInShower]
	  ,[HasStepInShower]
	  ,CASE WHEN ([PropertyType] = 'HOUSE') THEN 10 WHEN ([PropertyType] = 'FLAT') THEN 6 WHEN ([PropertyType] = 'BEDSIT') THEN 1 WHEN ([PropertyType] = 'BUNGALOW') THEN 4 WHEN ([PropertyType] = 'MAISON') THEN 12 end
	  ,[PropertyNumBedrooms]
	  ,NULL
	  ,NULL
	  ,CASE WHEN ([AgeCriteria] = '18.00') THEN 1 WHEN ([AgeCriteria] = '55.00') THEN 2 WHEN ([AgeCriteria] = '65.00') THEN 3 ELSE 1 end
	  ,GETDATE()
	  ,'Data Migration'
  FROM [Allocations].[dbo].[CustomerApplication] WHERE ApplicationEligable = 1 AND MatchToMutualExhanges = 1 AND LeaveVacantProperty = 1 AND MainTenantOnTenancy = 1 AND LandLordCode = 'Incomm'
  AND TenancyTypeCode IN ('ASS-TAR','ASS-PRO'))



  DELETE FROM [Allocations].[dbo].[VBLMutualExchangeAdaptationDetails]
  INSERT INTO [Allocations].[dbo].[VBLMutualExchangeAdaptationDetails]([ApplicationId]
	  ,[AdaptationId]
	  ,[CreatedDate]
	  ,[CreatedBy])(
	  SELECT CustomerApplicationId,
	  1,
	  GETDATE(),
	  'Data Migration'
	  FROM [Allocations].[dbo].[CustomerApplication] WHERE ApplicationEligable = 1 AND MatchToMutualExhanges = 1 AND LeaveVacantProperty = 1 AND MainTenantOnTenancy = 1 AND LandLordCode = 'Incomm'  AND TenancyTypeCode IN ('ASS-TAR','ASS-PRO')
AND IsWheelChairAdapted = 1
	  )
 INSERT INTO [Allocations].[dbo].[VBLMutualExchangeAdaptationDetails]([ApplicationId]
	  ,[AdaptationId]
	  ,[CreatedDate]
	  ,[CreatedBy])(

		  SELECT CustomerApplicationId,
	  2,
	  GETDATE(),
	  'Data Migration'
	  FROM [Allocations].[dbo].[CustomerApplication] WHERE ApplicationEligable = 1 AND MatchToMutualExhanges = 1 AND LeaveVacantProperty = 1 AND MainTenantOnTenancy = 1 AND LandLordCode = 'Incomm' AND TenancyTypeCode IN ('ASS-TAR','ASS-PRO')
 AND (HasRampedAccess = 1 or HasWalkInShower = 1 OR HasStairlift = 1 or HasStepInShower = 1)
)
DELETE FROM [Allocations].[dbo].[VBLRequestedPropertyAdaptationDetails]
  INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyAdaptationDetails]([ApplicationId]
	  ,[AdaptationId]
	  ,[CreatedDate]
	  ,[CreatedBy])(
	  SELECT CustomerApplicationId,
	  1,
	  GETDATE(),
	  'Data Migration'
	  FROM [Allocations].[dbo].[CustomerApplication] WHERE MatchingWheelChairAdapted = 1
	  )
		INSERT INTO [Allocations].[dbo].[VBLRequestedPropertyAdaptationDetails]([ApplicationId]
	  ,[AdaptationId]
	  ,[CreatedDate]
	  ,[CreatedBy])(
	  SELECT CustomerApplicationId,
	  2,
	  GETDATE(),
	  'Data Migration'
	  FROM [Allocations].[dbo].[CustomerApplication] WHERE ((MatchingRampedAccess = 1 or MatchingWalkInShower = 1 OR MatchingStairlift = 1 or MatchingStepInShower = 1) AND MatchingWheelChairAdapted IS null)
	  )



USE [Allocations]
GO

/****** Object:  Trigger [dbo].[trVBLIncomeDetails]    Script Date: 09/22/2016 10:28:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trVBLIncomeDetails] on [dbo].[VBLIncomeDetails]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.AuditVBLIncomeDetails(
		IncomeDetailId,
		IncomesComment,
		IncomeTypeId,
		IncomeFrequencyId,
		Amount,
		ContactId,
		LoginName,
		ChangeType,
		ChangeDate,
		CreatedDate,
		ModifiedBy,
		ModifiedDate
		)
		SELECT
			ISNULL(INSERTED.[IncomeDetailId], DELETED.[IncomeDetailId]),
			ISNULL(INSERTED.[IncomesComment], DELETED.[IncomesComment]),
			ISNULL(INSERTED.[IncomeTypeId], DELETED.[IncomeTypeId]),
			ISNULL(INSERTED.[IncomeFrequencyId], DELETED.[IncomeFrequencyId]),
			ISNULL(INSERTED.[Amount], DELETED.[Amount]),
			ISNULL(INSERTED.[ContactId], DELETED.[ContactId]),
			[LoginName] = SUSER_NAME(),
			[ChangeType] = CASE WHEN INSERTED.[IncomeDetailId] IS NOT NULL AND DELETED.[IncomeDetailId] IS NOT NULL THEN 'Updated' WHEN INSERTED.[IncomeDetailId] IS NOT NULL THEN 'Created' ELSE 'Deleted' End,
			[ChangeDate] = GETDATE(),
			ISNULL(INSERTED.[CreatedDate], DELETED.[CreatedDate]),
			ISNULL(INSERTED.[ModifiedBy], DELETED.[ModifiedBy]),
			ISNULL(INSERTED.[ModifiedDate], DELETED.[ModifiedDate])
		FROM INSERTED
			FULL OUTER JOIN DELETED
				ON INSERTED.[IncomeDetailId] = DELETED.[IncomeDetailId]

		SET NOCOUNT OFF
END
