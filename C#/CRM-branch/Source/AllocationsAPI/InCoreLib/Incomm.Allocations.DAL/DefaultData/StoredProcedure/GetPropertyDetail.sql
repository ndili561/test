CREATE PROCEDURE [dbo].[GetPropertyDetail]
     (
      @PropertyCode VARCHAR(30) = NULL
    )
AS 
   BEGIN

        SET NOCOUNT ON;
		IF (EXISTS(	SELECT	1 FROM     Cloudvoids.dbo.Property AS P
								LEFT JOIN Cloudvoids.dbo.Void v 
									ON v.PropertyCode = p.PropertyCode
								LEFT JOIN Cloudvoids.dbo.PropertyShop psd 
									ON p.PropertyCode = psd.PropertyCode
									AND v.VoidId = psd.VoidID
								LEFT JOIN Cloudvoids.dbo.PropertyShopStaticDetails pssd 
									ON p.PropertyCode = pssd.PropertyCode
								LEFT JOIN Cloudvoids.dbo.PaymentCycle pc 
									ON pssd.PaymentCycleID = pc.PaymentCycleID
								LEFT JOIN MasterReferenceData.dbo.TBL_PROPERTY AS IBS 
									ON P.PropertyCode = IBS.PROPERTY_CODE
								LEFT JOIN MasterReferenceData.dbo.TBL_POSTCODE_LONGLAT pll 
									ON pll.PostCode = IBS.POST_CODE
                    WHERE p.PropertyCode =@PropertyCode))
                    BEGIN
                    SELECT	DISTINCT(SELECT MAX(cv.VoidId) FROM Cloudvoids.dbo.Void cv 
									WHERE cv.PropertyCode = p.PropertyCode)			AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								CAST(p.PropertyNumBedrooms as int)					AS Bedrooms,
								CAST(p.IsWheelChairAdapted as bit)					AS WheelchairAdapted,
                                CAST(p.HasRampedAccess as bit)						AS RampedAccess,
                                CAST(p.HasWalkInShower as bit)						AS WalkInShower,
                                CAST(p.HasStepInShower as bit)						AS StepInShower,
                                CAST(p.IsLevelAccessProperty as bit)				AS LevelAccessProperty,
                                CAST(p.HasStairlift	 as bit)						AS Stairlift,
                                p.AgeCriteria										AS AgeRestriction,
                                ibs.PETS_ALLOWED 									AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0) as int)			AS NumberOfSteps,
                                CAST(p.HasLift as bit)								AS Lift,
                                CAST(p.HasCommunalEntrance as bit)					AS CommunalEntrance,
                                CAST(p.IsHighRise as bit)							AS HighRise,
                                 1													AS NeighbourhoodId,
                                --TenancyEndDate
                                psd.rent 											AS Rent ,
                                psd.ServiceCharges									AS ServiceCharges,
                                p.LandLordcode										AS Landlord ,
                                1													AS LandlordId ,
                                pc.Name												AS RentFrequency ,
                                IBS.ADDRESS_LINE_1									AS AddressLine1 ,
                                IBS.ADDRESS_LINE_2									AS AddressLine2 ,
                                IBS.ADDRESS_LINE_3									AS AddressLine3 ,
                                IBS.ADDRESS_LINE_4									AS AddressLine4 ,
                                IBS.POST_CODE										AS PostCode ,
								CAST(p.HasDriveway	 as bit)						AS Driveway,
								CAST(p.HasOutbuildings as bit)						AS Outbuildings,
								CAST(p.HasParking as bit)							AS Parking,
								CAST(p.HasBin as bit)								AS Bin,
								CAST(p.HasGarden as bit)							AS Garden,
								CAST(p.HasOutbuildings as bit)						AS Outbuildings,
								p.PropertyNumBathrooms								AS NumberOfBathrooms,
								p.PropertyNumReceptionRooms							AS NumberOfReceptionRooms,
								p.BathroomType										AS BathroomType,
								p.HasWasherSpace									AS SeparateWC,
								p.WCType											AS WCType,
								CAST(0 as bit)										AS Trustcare,
								p.FlatFloorLevel									AS FloorLevel,
								CAST(0 as bit)										AS Concierge,
								CAST(p.HasDoorEntry	 as bit)						AS DoorEntry,
								CAST(p.HasWasherSpace as bit)						AS WasherSpace,
								CAST(p.HasDryerSpace as bit)						AS DryerSpace,
								CAST(p.HasCommunalLaundry as bit)					AS CommunalLaundry,
								CAST(p.HasFurnishings as bit)						AS Furnished,
								p.ElectricMeterType									AS ElectricMeterType,
								p.ElectricSupplier									AS ElectricSupplier,
								p.ElectricMeterLocation								AS ElectricMeterLocation,
								p.GasMeterType										AS GasMeterType,
								p.GasSupplier										AS GasSupplier,
								p.GasMeterLocation									AS GasMeterLocation,
								p.OtherAdaptationsDescription						AS OtherAdaptations,
								CAST(pll.Longitude	as decimal(19,11))				AS Longitude,
								CAST(pll.Latitude	as decimal(19,11))				AS Latitude,
                                0													AS MutualExchangeProperty 
                           
                       FROM     Cloudvoids.dbo.Property AS P
								LEFT JOIN Cloudvoids.dbo.Void v 
									ON v.PropertyCode = p.PropertyCode
								LEFT JOIN Cloudvoids.dbo.PropertyShop psd 
									ON p.PropertyCode = psd.PropertyCode
									AND v.VoidId = psd.VoidID
								LEFT JOIN Cloudvoids.dbo.PropertyShopStaticDetails pssd 
									ON p.PropertyCode = pssd.PropertyCode
								LEFT JOIN Cloudvoids.dbo.PaymentCycle pc 
									ON pssd.PaymentCycleID = pc.PaymentCycleID
								LEFT JOIN MasterReferenceData.dbo.TBL_PROPERTY AS IBS 
									ON P.PropertyCode = IBS.PROPERTY_CODE
								LEFT JOIN MasterReferenceData.dbo.TBL_POSTCODE_LONGLAT pll 
									ON pll.PostCode = IBS.POST_CODE
                    WHERE p.PropertyCode =@PropertyCode
                    
               END
               ELSE IF (EXISTS(SELECT 1 FROM MasterReferenceData.dbo.RSLProperties AS P WHERE p.PropertyId = @PropertyCode))
               BEGIN 
                      SELECT	0													AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								p.PropertyNumBedrooms								AS Bedrooms,
								CAST(p.IsWheelChairAdapted as bit)					AS WheelchairAdapted,
                                CAST(p.HasRampedAccess as bit)						AS RampedAccess,
                                CAST(p.HasWalkInShower as bit)						AS WalkInShower,
                                CAST(p.HasStepInShower as bit)						AS StepInShower,
                                CAST(p.IsLevelAccessProperty as bit)				AS LevelAccessProperty,
                                CAST(p.HasStairlift	 as bit)						AS Stairlift,
                                CAST(p.AgeCriteria AS NVARCHAR(5))					AS AgeRestriction,
                                CAST(ISNULL(p.CatDog,1)AS NVARCHAR(1))				AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0) as int)			AS NumberOfSteps,
                                CAST(p.HasLift	as bit)								AS Lift,
                                CAST(p.CommEnt as bit)								AS CommunalEntrance,
                                CAST(p.HighRise as bit)								AS HighRise,
                                1													AS NeighbourhoodId,
                                --TenancyEndDate
                                p.Rent												AS Rent ,
                                p.ServiceCharge										AS ServiceCharges,
                                p.RSL												AS Landlord ,
								p.LandlordId										AS LandlordId ,
                                p.PaymentCycle										AS RentFrequency ,
                                p.AddressLine1										AS AddressLine1 ,
                                p.AddressLine2										AS AddressLine2 ,
                                p.AddressLine3										AS AddressLine3 ,
                                p.AddressLine4										AS AddressLine4 ,
                                p.Postcode											AS PostCode ,
								CAST(p.HasDriveway as bit)							AS Driveway,
								CAST(p.HasOutbuildings as bit)						AS Outbuildings,
								CAST(p.HasParking as bit)							AS Parking,
								CAST(p.HasBin as bit)								AS Bin,
								CAST(p.HasGarden as bit)							AS Garden,
								CAST(p.HasOutbuildings as bit)						AS Outbuildings,
								p.PropertyNumBathrooms								AS NumberOfBathrooms,
								p.PropertyNumReceptionRooms							AS NumberOfReceptionRooms,
								p.BathroomType										AS BathroomType,
								p.HasWasherSpace									AS SeparateWC,
								p.WCType											AS WCType,
								CAST(0 as bit)										AS Trustcare,
								p.FlatFloorLevel									AS FloorLevel,
								CAST(0 as bit)										AS Concierge,
								CAST(p.HasDoorEntry	 as bit)						AS DoorEntry,
								CAST(p.HasWasherSpace as bit)						AS WasherSpace,
								CAST(p.HasDryerSpace as bit)						AS DryerSpace,
								CAST(p.HasCommunalLaundry as bit)					AS CommunalLaundry,
								CAST(p.HasFurnishings as bit)						AS Furnished,
								p.ElectricMeterType									AS ElectricMeterType,
								p.ElectricSupplier									AS ElectricSupplier,
								p.ElectricMeterLocation								AS ElectricMeterLocation,
								p.GasMeterType										AS GasMeterType,
								p.GasSupplier										AS GasSupplier,
								p.GasMeterLocation									AS GasMeterLocation,
								p.OtherAdaptationsDescription						AS OtherAdaptations,
								CAST(0	as decimal(19,11))							AS Longitude,
								CAST(0	as decimal(19,11))							AS Latitude,
                                0													AS MutualExchangeProperty 
                           
                       FROM   MasterReferenceData.dbo.RSLProperties AS P--Get landlord name
                    WHERE p.PropertyID =@PropertyCode
                     END
			ELSE
			BEGIN
			DECLARE @ApplicationId INT = (SELECT TOP 1 applicationId FROM Allocations.dbo.VBLMutualExchagePropertyDetails v WHERE v.PropertyCode = @PropertyCode ORDER BY v.CreatedDate DESC) 

			SELECT	
								-100																			AS VoidId,
								p.Property_Code																	AS PropertyCode,
								p.Property_Type																	AS PropertyType,
								p.NUMBER_OF_BEDROOMS															AS Bedrooms,
								CAST(CASE WHEN (madw.applicationId IS null) THEN 0 ELSE 1 END	AS BIT)					AS WheelchairAdapted,
                                CAST(CASE WHEN (madr.applicationId IS null) THEN 0 ELSE 1 END	AS BIT)					AS RampedAccess,
                                CAST(CASE WHEN (madws.applicationId IS null) THEN 0 ELSE 1 END	AS BIT)					AS WalkInShower,
                                CAST(CASE WHEN (madss.applicationId IS null) THEN 0 ELSE 1 END	AS BIT)					AS StepInShower,
                                CAST(v.IsLevelAccessProperty as bit)											AS LevelAccessProperty,
                                CAST(CASE WHEN (mads.applicationId IS null) THEN 0 ELSE 1 END	AS BIT)					AS Stairlift,
                                CAST(p.AGE_RESTRICTION_AMOUNT AS NVARCHAR(10))														AS AgeRestriction,
								CASE WHEN (p.PETS_ALLOWED = 'Y') THEN '1' ELSE '0'END							AS Pets,
                                CAST(ISNULL(mpd.NumberOfStepsToAccess , 0) as int)								AS NumberOfSteps,
                                CAST(CASE WHEN (p.Lift_Access_Flag = 'Y') THEN 1 ELSE 0 END		AS bit)				AS Lift,
                                CAST(CASE WHEN (mpd.PropertyEntranceTypeId = 1) THEN 1 else 0 END AS BIT)					AS CommunalEntrance,
                                CAST(CASE WHEN (mpd.PropertyBlockTypeId = 1) THEN 1 else 0 end	AS BIT)					AS HighRise,
                                1																				AS NeighbourhoodId,
                                --TenancyEndDate
                                p.TARGET_RENT_RATE_CURRENT														AS Rent ,
                                v.ServiceCharges																AS ServiceCharges,
                                'INCOMM'																		AS Landlord ,
								1																				AS LandlordId ,
                                pc.Name																			AS RentFrequency ,
                                p.Address_Line_1																AS AddressLine1 ,
                                p.Address_Line_2																AS AddressLine2 ,
                                p.Address_Line_3																AS AddressLine3 ,
                                p.Address_Line_4																AS AddressLine4 ,
                                p.Post_code																		AS PostCode ,
								CAST(v.HasDriveway as bit)							AS Driveway,
								CAST(v.HasOutbuildings as bit)						AS Outbuildings,
								CAST(v.HasParking as bit)							AS Parking,
								CAST(v.HasBin as bit)								AS Bin,
								CAST(v.HasGarden as bit)							AS Garden,
								CAST(v.HasOutbuildings as bit)						AS Outbuildings,
								v.PropertyNumBathrooms								AS NumberOfBathrooms,
								v.PropertyNumReceptionRooms							AS NumberOfReceptionRooms,
								v.BathroomType										AS BathroomType,
								CAST(v.HasWasherSpace as bit)									AS SeparateWC,
								v.WCType											AS WCType,
								CAST(0 as bit)										AS Trustcare,
								v.FlatFloorLevel									AS FloorLevel,
								CAST(0 as bit)										AS Concierge,
								CAST(v.HasDoorEntry	 as bit)						AS DoorEntry,
								CAST(v.HasWasherSpace as bit)						AS WasherSpace,
								CAST(v.HasDryerSpace as bit)						AS DryerSpace,
								CAST(v.HasCommunalLaundry as bit)					AS CommunalLaundry,
								CAST(v.HasFurnishings as bit)						AS Furnished,
								v.ElectricMeterType									AS ElectricMeterType,
								v.ElectricSupplier									AS ElectricSupplier,
								v.ElectricMeterLocation								AS ElectricMeterLocation,
								v.GasMeterType										AS GasMeterType,
								v.GasSupplier										AS GasSupplier,
								v.GasMeterLocation									AS GasMeterLocation,
								v.OtherAdaptationsDescription						AS OtherAdaptations,
								CAST(0	as decimal(19,11))							AS Longitude,
								CAST(0	as decimal(19,11))							AS Latitude,
                                1													AS MutualExchangeProperty 
                            FROM MasterReferenceData.dbo.TBL_PROPERTY p
					   LEFT JOIN Cloudvoids.dbo.Property v
					   ON p.PROPERTY_CODE = v.PropertyCode
								LEFT JOIN Cloudvoids.dbo.PropertyShopStaticDetails pssd 
									ON v.PropertyCode = pssd.PropertyCode
								LEFT JOIN Cloudvoids.dbo.PaymentCycle pc 
									ON pssd.PaymentCycleID = pc.PaymentCycleID
					   LEFT JOIN Allocations.dbo.VBLMutualExchagePropertyDetails mpd
					   ON p.PROPERTY_CODE = mpd.PropertyCode
					   AND mpd.ApplicationId = @ApplicationId
					   LEFT JOIN Allocations.dbo.VBLMutualExchangeAdaptationDetails madw
					   ON mpd.applicationId = madw.applicationID
					   AND madw.adaptationid = 1
					   LEFT JOIN Allocations.dbo.VBLMutualExchangeAdaptationDetails madr
					   ON mpd.applicationId = madw.applicationID
					   AND madw.adaptationid = 2
					   LEFT JOIN Allocations.dbo.VBLMutualExchangeAdaptationDetails madws
					   ON mpd.applicationId = madw.applicationID
					   AND madw.adaptationid = 3
					   LEFT JOIN Allocations.dbo.VBLMutualExchangeAdaptationDetails mads
					   ON mpd.applicationId = madw.applicationID
					   AND madw.adaptationid = 4
					   LEFT JOIN Allocations.dbo.VBLMutualExchangeAdaptationDetails madss
					   ON mpd.applicationId = madw.applicationID
					   AND madw.adaptationid = 5
							
							WHERE p.PROPERTY_CODE = @PropertyCode
							AND mpd.PropertyCode = @propertyCode
            END
            
  END 


