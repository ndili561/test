USE [Allocations]
GO
/****** Object:  StoredProcedure [dbo].[GetPropertyDetailsByLandlordIdsAndPropertyCodes]    Script Date: 25/11/2016 11:40:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPropertyDetailsByLandlordIdsAndPropertyCodes]
    (
      @LandlordIdsAndPropertyCodes VARCHAR(5000) = NULL
    )
AS 
    BEGIN

        SET NOCOUNT ON;
		DECLARE @TempPropertyAndLandlord AS TABLE
		(
		PropertyCode varchar(256)
		)
		DECLARE @TempIncommunitiesProperty AS TABLE
		(
		PropertyCode varchar(256)
		)
		DECLARE @TempRSLProperty AS TABLE
		(
		LanlordId int,
		PropertyCode varchar(256)
		)
		INSERT INTO @TempPropertyAndLandlord
		(PropertyCode)
		SELECT * FROM fnSplitString(@LandlordIdsAndPropertyCodes,'&')
		
		INSERT INTO @TempIncommunitiesProperty
		(PropertyCode)
		SELECT REPLACE(PropertyCode,'0|','') FROM @TempPropertyAndLandlord WHERE PropertyCode LIKE '0|%'
		DELETE FROM @TempPropertyAndLandlord WHERE PropertyCode LIKE '0|%'
		
		INSERT INTO @TempIncommunitiesProperty
		(PropertyCode)
		SELECT REPLACE(PropertyCode,'1|','') FROM @TempPropertyAndLandlord WHERE PropertyCode LIKE '1|%'
		DELETE FROM @TempPropertyAndLandlord WHERE PropertyCode LIKE '1|%'
		
			DECLARE @PropertyCode as NVARCHAR(50);
			 
			DECLARE @TempPropertyAndLandlordCursor as CURSOR;
			 
			SET @TempPropertyAndLandlordCursor = CURSOR FOR
			SELECT PropertyCode
			 FROM @TempPropertyAndLandlord
			 
			OPEN @TempPropertyAndLandlordCursor;
			FETCH NEXT FROM @TempPropertyAndLandlordCursor INTO @PropertyCode;
			 
			WHILE @@FETCH_STATUS = 0
			BEGIN
			INSERT INTO @TempRSLProperty
			(LanlordId,PropertyCode)
			(SELECT SUBSTRING (@PropertyCode, CHARINDEX('|', @PropertyCode) -1 , 1) AS LanlordId,
			(SELECT SUBSTRING (@PropertyCode, CHARINDEX('|', @PropertyCode) + 1, LEN(@PropertyCode))) AS PropertyCode);
			 
			 FETCH NEXT FROM @TempPropertyAndLandlordCursor INTO @PropertyCode;
			END
			
			CLOSE @TempPropertyAndLandlordCursor;
			DEALLOCATE @TempPropertyAndLandlordCursor;
			            SELECT	(SELECT MAX(voidId) FROm CloudVoids.dbo.VOID v 
									Where v.PropertyCode =	p.PropertyCode)			AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								p.PropertyNumBedrooms								AS Bedrooms,
								p.IsWheelChairAdapted								AS WheelchairAdapted,
                                p.HasRampedAccess									AS RampedAccess,
                                p.HasWalkInShower									AS WalkInShower,
                                p.HasStepInShower									AS StepInShower,
                                p.IsLevelAccessProperty								AS LevelAccessProperty,
                                p.HasStairlift										AS Stairlift,
                                cast(  p.AgeCriteria	as varchar(10))				AS AgeRestriction,
                                ibs.PETS_ALLOWED									AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0)	as int)			AS NumberOfSteps,
                                p.HasLift											AS Lift,
                                p.HasCommunalEntrance								AS CommunalEntrance,
                                p.IsHighRise										AS HighRise,
                               	(SELECT TOP 1 ps.NeighbourhoodId  
								FROM MasterReferenceData.dbo.PropertyPostcodes pp
								INNER JOIN MasterReferenceData.dbo.PropertyOutputAreas ps
								ON pp.OutputAreaId = ps.OutputAreaId 
								WHERE pp.Postcode = IBS.POST_CODE)					AS NeighbourhoodId,
								(SELECT TOP 1 pn.Name  
								FROM MasterReferenceData.dbo.PropertyPostcodes ps 
								INNER JOIN MasterReferenceData.dbo.PropertyOutputAreas po
								ON ps.OutputAreaId = po.OutputAreaId
								INNER JOIN MasterReferenceData.dbo.PropertyNeighbourhoods pn
								ON po.NeighbourhoodId = pn.NeighbourhoodId  
								WHERE ps.Postcode = IBS.POST_CODE)					AS Area,
								
                                --TenancyEndDate
                               (SELECT TOP 1 CAST(psd.rent as decimal) 
									FROM Cloudvoids.dbo.PropertyShop psd) 			AS Rent ,
								(SELECT  TOP 1 CAST(psd.ServiceCharges as decimal) 
									FROM Cloudvoids.dbo.PropertyShop psd
									ORDER BY psd.PaymentCycleId DESC
									
									)												AS ServiceCharges,
                                p.LandLordcode										AS Landlord ,
                                (SELECT TOP 1 pc.Name 
								FROM Cloudvoids.dbo.PropertyShopStaticDetails pssd 
								LEFT JOIN Cloudvoids.dbo.PaymentCycle pc 
									ON pssd.PaymentCycleID = pc.PaymentCycleID 
									WHERE pssd.PropertyCode =  p.PropertyCode
									ORDER BY pssd.PaymentCycleID DESC
									)
          																			AS RentFrequency ,
                                IBS.ADDRESS_LINE_1									AS AddressLine1 ,
                                IBS.ADDRESS_LINE_2									AS AddressLine2 ,
                                IBS.ADDRESS_LINE_3									AS AddressLine3 ,
                                IBS.ADDRESS_LINE_4									AS AddressLine4 ,
                                IBS.POST_CODE										AS PostCode ,
								p.HasDriveway										AS Driveway,
								p.HasOutbuildings									AS Outbuildings,
								p.HasParking										AS Parking,
								p.HasBin											AS Bin,
								p.HasGarden											AS Garden,
								p.HasOutbuildings									AS Outbuildings,
								p.PropertyNumBathrooms								AS NumberOfBathrooms,
								p.PropertyNumReceptionRooms							AS NumberOfReceptionRooms,
								p.BathroomType										AS BathroomType,
								p.HasWasherSpace									AS SeparateWC,
								p.WCType											AS WCType,
								CAST(0 as bit)										AS Trustcare,
								p.FlatFloorLevel									AS FloorLevel,
								CAST(0 as bit)										AS Concierge,
								p.HasDoorEntry										AS DoorEntry,
								p.HasWasherSpace									AS WasherSpace,
								p.HasDryerSpace									    AS DryerSpace,
								p.HasCommunalLaundry								AS CommunalLaundry,
								p.HasFurnishings									AS Furnished,
								p.ElectricMeterType									AS ElectricMeterType,
								p.ElectricSupplier									AS ElectricSupplier,
								p.ElectricMeterLocation								AS ElectricMeterLocation,
								p.GasMeterType										AS GasMeterType,
								p.GasSupplier										AS GasSupplier,
								p.GasMeterLocation									AS GasMeterLocation,
								p.OtherAdaptationsDescription						AS OtherAdaptations,
								cast(pll.Longitude as DECIMAL(19,13))				AS Longitude,
								cast(pll.Latitude as DECIMAL(19,13))				AS Latitude,
                                0													AS MutualExchangeProperty 
                           
                       FROM     Cloudvoids.dbo.Property AS P
								INNER JOIN @TempIncommunitiesProperty tip
								 ON p.PropertyCode = tip.PropertyCode
								LEFT JOIN MasterReferenceData.dbo.TBL_PROPERTY AS IBS 
									ON P.PropertyCode = IBS.PROPERTY_CODE
								LEFT JOIN MasterReferenceData.dbo.TBL_POSTCODE_LONGLAT pll 
									ON pll.PostCode = IBS.POST_CODE
									
                  
                    
                    UNION
                      SELECT	0													AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								p.PropertyNumBedrooms								AS Bedrooms,
								p.IsWheelChairAdapted								AS WheelchairAdapted,
                                p.HasRampedAccess									AS RampedAccess,
                                p.HasWalkInShower									AS WalkInShower,
                                p.HasStepInShower									AS StepInShower,
                                p.IsLevelAccessProperty								AS LevelAccessProperty,
                                p.HasStairlift										AS Stairlift,
                                cast(  p.AgeCriteria	as varchar(10))				AS AgeRestriction,
                                CASE p.CatDog WHEN 0 THEN 'N' ELSE 'Y'  END			AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0)	as int)			AS NumberOfSteps,
                                p.HasLift											AS Lift,
                                p.CommEnt											AS CommunalEntrance,
                                p.HighRise											AS HighRise,
									(SELECT TOP 1 ps.NeighbourhoodId  
								FROM MasterReferenceData.dbo.PropertyPostcodes pp
								INNER JOIN MasterReferenceData.dbo.PropertyOutputAreas ps
								ON pp.OutputAreaId = ps.OutputAreaId 
								WHERE pp.Postcode = p.Postcode)						AS NeighbourhoodId,
								(SELECT TOP 1 pn.Name  
								FROM MasterReferenceData.dbo.PropertyPostcodes ps 
								INNER JOIN MasterReferenceData.dbo.PropertyOutputAreas po
								ON ps.OutputAreaId = po.OutputAreaId
								INNER JOIN MasterReferenceData.dbo.PropertyNeighbourhoods pn
								ON po.NeighbourhoodId = pn.NeighbourhoodId  
								WHERE ps.Postcode = p.Postcode)						AS Area,
								
                                ----TenancyEndDate
                                p.Rent 												AS Rent ,
                                p.ServiceCharge										AS ServiceCharges,
                                p.LandLord											AS Landlord ,
                                p.PaymentCycle										AS RentFrequency ,
                                p.AddressLine1										AS AddressLine1 ,
								p.AddressLine2										AS AddressLine2 ,
                                p.AddressLine3										AS AddressLine3 ,
                                p.AddressLine4										AS AddressLine4 ,
                                p.Postcode											AS PostCode, 
								p.HasDriveway										AS Driveway,
								p.HasOutbuildings									AS Outbuildings,
								p.HasParking										AS Parking,
								p.HasBin											AS Bin,
								p.HasGarden											AS Garden,
								p.HasOutbuildings									AS Outbuildings,
								p.PropertyNumBathrooms								AS NumberOfBathrooms,
								p.PropertyNumReceptionRooms							AS NumberOfReceptionRooms,
								p.BathroomType										AS BathroomType,
								p.HasWasherSpace									AS SeparateWC,
								p.WCType											AS WCType,
								CAST(0 as bit)										AS Trustcare,
								p.FlatFloorLevel									AS FloorLevel,
								CAST(0 as bit)										AS Concierge,
								p.HasDoorEntry										AS DoorEntry,
								p.HasWasherSpace									AS WasherSpace,
								p.HasDryerSpace									    AS DryerSpace,
								p.HasCommunalLaundry								AS CommunalLaundry,
								p.HasFurnishings									AS Furnished,
								p.ElectricMeterType									AS ElectricMeterType,
								p.ElectricSupplier									AS ElectricSupplier,
								p.ElectricMeterLocation								AS ElectricMeterLocation,
								p.GasMeterType										AS GasMeterType,
								p.GasSupplier										AS GasSupplier,
								p.GasMeterLocation									AS GasMeterLocation,
								p.OtherAdaptationsDescription						AS OtherAdaptations,
								cast(0 as DECIMAL(19,13))							AS Longitude,
								cast(0 as DECIMAL(19,13))							AS Latitude,
                                0													AS MutualExchangeProperty 
                           
                       FROM     MasterReferenceData.dbo.RSLProperties AS P
                       INNER JOIN @TempRSLProperty trsl
                       ON p.PropertyCode = trsl.PropertyCode
                       AND p.LandlordId = trsl.LanlordId
  END 