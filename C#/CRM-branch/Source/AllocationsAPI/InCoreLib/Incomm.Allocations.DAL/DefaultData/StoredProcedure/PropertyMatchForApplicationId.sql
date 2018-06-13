USE [Allocations]
GO
/****** Object:  StoredProcedure [dbo].[PropertyMatchForApplicationId]    Script Date: 25/11/2016 11:38:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec [PropertyMatchForApplicationId] 35108
ALTER PROCEDURE [dbo].[PropertyMatchForApplicationId]
    (
      @ApplicationId INT = null 
    )
    AS 
    BEGIN

        SET NOCOUNT ON;
            WITH    CTEInterests
                  AS ( SELECT   ci.CustomerInterestID ,
                                ci.ApplicationID ,
                                ci.PropertyCode ,
								ci.LandlordId ,
                                ci.CustomerInterestStatusID 
                       FROM     dbo.VBLCustomerInterests ci
					   WHERE ci.ApplicationId = @ApplicationId

                     ),
                CTEMatches
                  AS ( 
                  SELECT		v.VoidId											AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								p.PropertyNumBedrooms								AS Bedrooms,
								p.IsWheelChairAdapted								AS WheelchairAdapted,
                                p.HasRampedAccess									AS RampedAccess,
                                p.HasWalkInShower									AS WalkInShower,
                                p.HasStepInShower									AS StepInShower,
                                p.IsLevelAccessProperty								AS LevelAccessProperty,
                                p.HasStairlift										AS Stairlift,
                                p.AgeCriteria										AS AgeRestriction,
                                ibs.PETS_ALLOWED									AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0)	as int)			AS NumberOfSteps,
                                p.HasLift											AS Lift,
                                p.HasCommunalEntrance								AS CommunalEntrance,
                                p.IsHighRise										AS HighRise,
                                psd.rent 											AS Rent ,
                                psd.ServiceCharges									AS ServiceCharges,
                                p.LandLordcode										AS Landlord ,
                                pc.Name												AS RentFrequency ,
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
								CAST(pll.Longitude	as decimal(19,11))				AS Longitude,
								CAST(pll.Latitude	as decimal(19,11))				AS Latitude,
                                0													AS MutualExchangeProperty ,
								1													AS LandlordId
             FROM     dbo.VBLApplications AS CA 
						INNER JOIN dbo.VBLRequestedPropertymatchDetails AS PRD 
							ON CA.ApplicationID = PRD.ApplicationId
							AND CA.ApplicationId = @ApplicationId 
						INNER JOIN dbo.VBLRequestedPropertyPropertyTypes AS RPT 
							ON CA.ApplicationID = RPT.ApplicationId
							AND RPT.ApplicationId = @ApplicationId
						INNER JOIN dbo.VBLRequestedPropertyPropertySizes AS RPS 
							ON CA.ApplicationID = RPS.ApplicationId
							AND RPS.ApplicationId = @ApplicationId
						INNER JOIN dbo.VBLRequestedPropertyPrefferedNeighbourhoods AS RPN 
							ON CA.ApplicationID = RPN.ApplicationId
							AND RPN.ApplicationId = @ApplicationId
							AND RPN.IsCurrent = 1
						INNER JOIN dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails AS RPND 
							ON RPN.RequestedPropertyPrefferedNeighbourhoodId = RPND.RequestedPropertyPrefferedNeighbourhoodId
						LEFT JOIN dbo.VBLRequestedPropertyAdaptationDetails AS RPAD 
							ON CA.ApplicationID = RPAD.ApplicationId
						LEFT JOIN dbo.VBLRequestedPropertyAgeRestrictions AS RPAR 
							ON CA.ApplicationID = RPAR.ApplicationId
						INNER JOIN 
								( Cloudvoids.dbo.Property AS P
									INNER JOIN Cloudvoids.dbo.PropertyStatus ps 
										ON p.PropertyStatusID = ps.PropertyStatusID
										AND ps.StatusAllowSearches = 1
									INNER JOIN Cloudvoids.dbo.Void v 
										ON v.PropertyCode = p.PropertyCode
										AND v.IsReadyForPropertyShop = 1
										AND v.VoidStatusId = 4
									INNER JOIN Cloudvoids.dbo.PropertyShop psd 
										ON p.PropertyCode = psd.PropertyCode
										AND v.VoidId = psd.VoidID
									LEFT JOIN Cloudvoids.dbo.PropertyImage vpi 
										ON p.PropertyCode = vpi.PropertyCode
									LEFT JOIN Cloudvoids.dbo.PropertyShopStaticDetails pssd 
										ON p.PropertyCode = pssd.PropertyCode
									LEFT JOIN Cloudvoids.dbo.PaymentCycle pc 
										ON pssd.PaymentCycleID = pc.PaymentCycleID
									INNER JOIN MasterReferenceData.dbo.TBL_PROPERTY AS IBS 
										ON P.PropertyCode = IBS.PROPERTY_CODE
									LEFT JOIN MasterReferenceData.dbo.TBL_POSTCODE_LONGLAT pll 
										ON pll.PostCode = IBS.POST_CODE
								 ) 
						ON RTRIM(LTRIM(p.PropertyNumBedrooms)) = (Select RTRIM(LTRIM(REPLACE(Name,' Bedrooms',''))) FROM MasterReferenceData.dbo.PropertySizes WHERE PropertySizeId = RPS.PropertySizeId)
						AND RTRIM(LTRIM(Lower(p.PropertyType))) = (Select RTRIM(LTRIM(Lower(pt.Name))) FROM MasterReferenceData.dbo.PropertyTypes pt WHERE pt.PropertyTypeId = RPT.PropertyTypeId)
						OUTER APPLY ( SELECT    ApplicationID
									  FROM      CTEInterests
									  WHERE     PropertyCode = p.PropertyCode
												AND CustomerInterestStatusID NOT IN (11)
									) AS Ignore -- Apart from Reconsider ignore all the property that has entry in the VBLCustomerInterests for the Application
						WHERE    ca.ApplicationId = @ApplicationID
								AND RPND.NeighbourhoodId IN (SELECT  mrdpo.NeighbourhoodId FROm MasterReferenceData.dbo.PropertyOutputAreas mrdpo INNER JOIN MasterReferenceData.dbo.PropertyPostcodes mrdp ON mrdpo.OutputAreaId = mrdp.OutputAreaId  WHERE mrdp.PostCode =  IBS.POST_CODE)		
                                AND GETDATE() >= PRD.StartDate
                                AND (ISNULL(PRD.LiftServed,0) = 0 OR ( PRD.LiftServed = p.HasLift))
                                AND ((PRD.RehousePet IS NULL OR PRD.CatOrDog = 0) OR (Prd.CatOrDog = 1 AND PRD.RehousePet = 0 AND ((p.PropertyType IN ('FLAT','bedsit','maison') AND p.HasCommunalEntrance = 0)OR(p.PropertyType NOT IN ('Flat','bedsit','maison')))))
                                AND ((RPAR.ApplicationID IS NULL AND  p.AgeCriteria = '18.00')
															OR Replace(p.AgeCriteria,'.00','')=(SELECT REPLACE(Name,'+','') FROM AgeRestrictions WHERE AgeRestrictionId =  RPAR.AgeRestrictionId)
															)
                                and (
										RPAD.ApplicationId is null
										OR
										(
											RPad.AdaptationId = 1 and ISNULL(p.IsWheelChairAdapted,0)= 1
										)
										OR(
											(
												ISNULL(p.HasRampedAccess,0) = 1 or ISNULL(p.HasStairlift,0) = 1 or ISNULL(p.HasWalkInShower,0) = 1 or ISNULL(p.HasStepInShower,0) = 1
											)
											AND RPAD.AdaptationID = 2
										)
									)
                      AND Ignore.ApplicationID IS NULL


                --Select RSL Property     
 UNION
               ( SELECT			0													AS VoidId,
								p.PropertyCode										AS PropertyCode,
								p.PropertyType										AS PropertyType,
								p.PropertyNumBedrooms								AS Bedrooms,
								p.IsWheelChairAdapted								AS WheelchairAdapted,
                                p.HasRampedAccess									AS RampedAccess,
                                p.HasWalkInShower									AS WalkInShower,
                                p.HasStepInShower									AS StepInShower,
                                p.IsLevelAccessProperty								AS LevelAccessProperty,
                                p.HasStairlift										AS Stairlift,
                                p.AgeCriteria										AS AgeRestriction,
                                CASE p.CatDog WHEN 0 THEN 'N' ELSE 'Y'  END			AS Pets,
                                CAST(ISNULL(p.NumStepsToAccess , 0)	as int)			AS NumberOfSteps,
                                p.HasLift											AS Lift,
                                p.CommEnt											AS CommunalEntrance,
                                p.HighRise											AS HighRise,
                                p.rent 												AS Rent ,
                                p.ServiceCharge										AS ServiceCharges,
								p.LandLord											AS LandLord,
                                p.PaymentCycle										AS RentFrequency ,
                                p.AddressLine1										AS AddressLine1 ,
                                p.AddressLine2										AS AddressLine2 ,
                                p.AddressLine3										AS AddressLine3 ,
                                p.AddressLine4										AS AddressLine4 ,
                                p.Postcode											AS PostCode ,
								p.HasDriveway										AS Driveway,
								p.HasOutbuildings									AS Outbuildings,
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
								CAST(pll.Longitude	as decimal(19,11))				AS Longitude,
								CAST(pll.Latitude	as decimal(19,11))				AS Latitude,
								0													AS MutualExchangeProperty, 
								p.LandlordId										AS LandlordId
                   FROM     dbo.VBLApplications AS CA 
						INNER JOIN dbo.VBLRequestedPropertymatchDetails AS PRD 
							ON CA.ApplicationID = PRD.ApplicationId
							AND CA.ApplicationId = @ApplicationId 
						INNER JOIN dbo.VBLRequestedPropertyPropertyTypes AS RPT 
							ON CA.ApplicationID = RPT.ApplicationId
							AND RPT.ApplicationId = @ApplicationId
						INNER JOIN dbo.VBLRequestedPropertyPropertySizes AS RPS 
							ON CA.ApplicationID = RPS.ApplicationId
							AND RPS.ApplicationId = @ApplicationId
						INNER JOIN dbo.VBLRequestedPropertyPrefferedNeighbourhoods AS RPN 
							ON CA.ApplicationID = RPN.ApplicationId
							AND RPN.ApplicationId = @ApplicationId
							AND RPN.IsCurrent = 1
						INNER JOIN dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails AS RPND 
							ON RPN.RequestedPropertyPrefferedNeighbourhoodId = RPND.RequestedPropertyPrefferedNeighbourhoodId
						LEFT JOIN dbo.VBLRequestedPropertyAdaptationDetails AS RPAD 
							ON CA.ApplicationID = RPAD.ApplicationId
						LEFT JOIN dbo.VBLRequestedPropertyAgeRestrictions AS RPAR 
							ON CA.ApplicationID = RPAR.ApplicationId
						INNER JOIN 
								( MasterReferenceData.dbo.RSLProperties AS P
									LEFT JOIN MasterReferenceData.dbo.TBL_POSTCODE_LONGLAT pll 
										ON pll.PostCode = p.Postcode
										AND p.status = 'Void'
								 ) 
						ON RTRIM(LTRIM(p.PropertyNumBedrooms)) = (Select REPLACE(Name,' Bedrooms','') FROM MasterReferenceData.dbo.PropertySizes WHERE PropertySizeId = RPS.PropertySizeId)
						AND RTRIM(LTRIM(LOWER(p.PropertyType))) = (Select  RTRIM(LTRIM(Lower(pt.Name))) FROM MasterReferenceData.dbo.PropertyTypes pt WHERE pt.PropertyTypeId = RPT.PropertyTypeId)

						OUTER APPLY ( SELECT    ApplicationID
									  FROM      CTEInterests
									  WHERE     PropertyCode = p.PropertyCode
												AND LandlordId = p.LandlordId
												AND CustomerInterestStatusID NOT IN (11)
									) AS Ignore -- Apart from Reconsider ignore all the property that has entry in the VBLCustomerInterests for the Application

						WHERE    ca.ApplicationId = @ApplicationID
								AND RPND.NeighbourhoodId IN (SELECT  mrdpo.NeighbourhoodId FROm MasterReferenceData.dbo.PropertyOutputAreas mrdpo INNER JOIN MasterReferenceData.dbo.PropertyPostcodes mrdp ON mrdpo.OutputAreaId = mrdp.OutputAreaId  WHERE mrdp.PostCode =  p.Postcode)		
                                AND GETDATE() >= PRD.StartDate
                                AND (ISNULL(PRD.LiftServed,0) = 0 OR ( PRD.LiftServed = p.HasLift))
                               AND ((p.PROPERTYTYPE IN('HOUSE','BUNGALOW')) OR (p.PROPERTYTYPE IN ('FLAT','BEDSIT','MAISON') AND ((ISNULL(PRD.RehousePet ,1)= 0 AND (p.CommEnt = 1 OR ISNULL(PRD.CatOrDog,0) = 0)) OR PRD.RehousePet = 1)))
                                AND (RPAR.ApplicationID IS NULL 
															OR Replace(p.AgeCriteria,'.00','')=(SELECT REPLACE(Name,'+','') FROM AgeRestrictions WHERE AgeRestrictionId =  RPAR.AgeRestrictionId)
															)
                                and (
										RPAD.ApplicationId is null
										OR
										(
											RPad.AdaptationId = 1 and ISNULL(p.IsWheelChairAdapted,0)= 1
										)
										OR(
											(
												ISNULL(p.HasRampedAccess,0) = 1 or ISNULL(p.HasStairlift,0) = 1 or ISNULL(p.HasWalkInShower,0) = 1 or ISNULL(p.HasStepInShower,0) = 1
											)
											AND RPAD.AdaptationID = 2
										)
									)
                               AND Ignore.ApplicationID IS NULL
 )
                      )    

            SELECT  CM.*
            FROM    CTEMatches CM
  END 



