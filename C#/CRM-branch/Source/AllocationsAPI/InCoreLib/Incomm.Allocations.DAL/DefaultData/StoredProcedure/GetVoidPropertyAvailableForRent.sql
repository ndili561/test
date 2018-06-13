CREATE  PROCEDURE [dbo].[GetVoidPropertyAvailableForRent]
AS 
    BEGIN

        SET NOCOUNT ON;
                    SELECT		v.VoidId											AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								CAST(p.PropertyNumBedrooms as int)					AS Bedrooms,
								CAST(p.IsWheelChairAdapted as bit)					AS WheelchairAdapted,
                                CAST(p.HasRampedAccess as bit)						AS RampedAccess,
                                CAST(p.HasWalkInShower as bit)						AS WalkInShower,
                                CAST(p.HasStepInShower as bit)						AS StepInShower,
                                CAST(p.IsLevelAccessProperty as bit)				AS LevelAccessProperty,
                                CAST(p.HasStairlift	 as bit)						AS Stairlift,
                                CAST(p.AgeCriteria as varchar(10))					AS AgeRestriction,
                                ibs.PETS_ALLOWED									AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0) as int)			AS NumberOfSteps,
                                CAST(p.HasLift as bit)								AS Lift,
                                CAST(p.HasCommunalEntrance as bit)					AS CommunalEntrance,
                                CAST(p.IsHighRise as bit)							AS HighRise,
                                	(SELECT TOP 1 ps.NeighbourhoodId  
								FROM MasterReferenceData.dbo.PropertyPostcodes ps 
								WHERE ps.Postcode = IBS.POST_CODE)					AS NeighbourhoodId,
								(SELECT TOP 1 pn.Name  
									FROM MasterReferenceData.dbo.PropertyPostcodes ps 
									INNER JOIN MasterReferenceData.dbo.PropertyNeighbourhoods pn
										ON ps.NeighbourhoodId = pn.NeighbourhoodId  
										WHERE ps.Postcode = IBS.POST_CODE)			AS Area,
                                psd.rent 											AS Rent ,
                                psd.ServiceCharges									AS ServiceCharges,
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
								p.PropertyNumBathrooms								AS NumberOfBathrooms,
								p.PropertyNumReceptionRooms							AS NumberOfReceptionRooms,
								p.BathroomType										AS BathroomType,
								CAST(p.HasWasherSpace as bit)						AS SeparateWC,
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
                                0													AS MutualExchangeProperty ,
								p.LandLordcode										AS Landlord ,
                                1													AS LandlordId 
                       FROM     Cloudvoids.dbo.Property AS P
								INNER JOIN Cloudvoids.dbo.Void v 
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
                    WHERE		v.IsReadyForPropertyShop = 1
							AND v.VoidStatusId = 4
                    UNION
					 
                SELECT			0													AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								p.PropertyNumBedrooms								AS Bedrooms,
								p.IsWheelChairAdapted								AS WheelchairAdapted,
                                p.HasRampedAccess									AS RampedAccess,
                                p.HasWalkInShower									AS WalkInShower,
                                p.HasStepInShower									AS StepInShower,
                                p.IsLevelAccessProperty								AS LevelAccessProperty,
                                p.HasStairlift										AS Stairlift,
                                CAST(p.AgeCriteria as varchar(10))					AS AgeRestriction,
                                CASE p.CatDog WHEN 0 THEN 'N' ELSE 'Y' END 			AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0)	as int)			AS NumberOfSteps,
                                p.HasLift											AS Lift,
                                p.CommEnt											AS CommunalEntrance,
                                p.HighRise											AS HighRise,
                                (SELECT TOP 1 ps.NeighbourhoodId  
								FROM MasterReferenceData.dbo.PropertyPostcodes ps 
								WHERE ps.Postcode = p.Postcode)						AS NeighbourhoodId,
								(SELECT TOP 1 pn.Name  
								FROM MasterReferenceData.dbo.PropertyPostcodes ps 
								INNER JOIN MasterReferenceData.dbo.PropertyNeighbourhoods pn
								ON ps.NeighbourhoodId = pn.NeighbourhoodId  
								WHERE ps.Postcode = p.Postcode)						AS Area,
                                p.rent 												AS Rent ,
                                p.ServiceCharge										AS ServiceCharges,
                                p.PaymentCycle										AS RentFrequency ,
                                p.AddressLine1										AS AddressLine1 ,
                                p.AddressLine2										AS AddressLine2 ,
                                p.AddressLine3										AS AddressLine3 ,
                                p.AddressLine4										AS AddressLine4 ,
                                p.Postcode											AS PostCode ,
								p.HasDriveway										AS Driveway,
								CAST(p.HasOutbuildings as bit)						AS Outbuildings,
								p.HasParking										AS Parking,
								p.HasBin											AS Bin,
								p.HasGarden											AS Garden,
								p.PropertyNumBathrooms								AS NumberOfBathrooms,
								p.PropertyNumReceptionRooms							AS NumberOfReceptionRooms,
								p.BathroomType										AS BathroomType,
								p.HasWasherSpace									AS SeparateWC,
								p.WCType											AS WCType,
								CAST(0 as 	bit)									AS Trustcare,
								p.FlatFloorLevel									AS FloorLevel,
								CAST(0 as 	bit)									AS Concierge,
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
								CAST(0	as decimal(19,11))							AS Longitude,
								CAST(0	as decimal(19,11))							AS Latitude,
								0													AS MutualExchangeProperty ,
								p.LandLord											AS LandLord,
								p.LandlordId										AS LandlordId
                   FROM     MasterReferenceData.dbo.RSLProperties AS P
				   WHERE p.PropertyStatusID = 4
               END
   