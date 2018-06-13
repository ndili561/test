namespace InCoreLib.DAL.Migrations.SQL
{

    public partial class SqlProgrammability
    {

        public static string drop_VBLPropertyShopView
        {
            get { return @"IF  EXISTS (SELECT * FROM sys.views
                                  WHERE object_id = OBJECT_ID(N'dbo.VBLPropertyShops'))
                                  DROP VIEW dbo.VBLPropertyShops"; }
        }


        public static string create_VBLPropertyShopView
        {
            get { return @"EXEC ('CREATE VIEW [dbo].[VBLPropertyShops]
    AS
      SELECT 
v.voidId AS VoidId,
p.propertycode as PropertyCode,
p.PropertyType as PropertyType,
p.PropertyNumBedrooms as Bedrooms,
p.IsWheelChairAdapted AS WheelchairAdapted,
p.HasRampedAccess AS RampedAccess,
p.HasWalkInShower As WalkInShower,
p.HasStepInShower as StepInShower,
p.HasStairlift AS Stairlift,
p.AgeCriteria as AgeRestriction,
ts.PETS_ALLOWED AS Pets,
p.NumStepsToAccess as NumberOfSteps,
p.HasLift as Lift,
p.HasCommunalEntrance as CommunalEntrance,
p.IsHighRise as HighRise,
vpp.NeighbourhoodId,
TenancyEndDate,
p.Rent as Rent,
p.ServiceCharges as ServiceCharges,
p.LandLordCode as Landlord,
RentFrequency,
ts.ADDRESS_LINE_1 as AddressLine1,
ts.ADDRESS_LINE_2 as AddressLine2,
ts.ADDRESS_LINE_3 as AddressLine3,
ts.ADDRESS_LINE_4 as AddressLine4,
ts.POST_CODE as PostCode,
p.HasDriveway as Driveway,
p.HasOutbuildings as Outbuildings,
p.HasParking as Parking,
p.HasBin as Bin,
p.HasGarden as Garden,
p.PropertyNumFloors as NumberOfFloors,
p.PropertyNumReceptionRooms as NumberOfReceptionRooms,
p.PropertyNumBathrooms as NumberOfBathrooms,
p.BathroomType as BathroomType,
p.WCIsSeperate as SeparateWC,
p.WCType as WCType,
p.Careline as Trustcare,
p.FlatFloorLevel as FloorLevel,
p.HasConcierge as Concierge,
p.HasDoorEntry as DoorEntry,
p.HasWasherSpace as WasherSpace,
p.HasDryerSpace as DryerSpace,
p.HasCommunalLaundry as CommunalLaundry,
p.HasFurnishings as Furnished,
p.ElectricMeterType as ElectricMeterType,
p.ElectricSupplier as ElectricSupplier,
p.ElectricMeterLocation as ElectricMeterLocation,
p.GasMeterType as GasMeterType,
p.GasSupplier as GasSupplier,
p.GasMeterLocation as GasMeterLocation,
p.OtherAdaptationsDescription as OtherAdaptations,
CAST(ISNULL(po.Latitude,0) AS DECIMAL(19,7)) AS Latitude,
CAST(ISNULL(po.Longitude,0)  AS Decimal(19,7)) AS Longitude
FROM CloudVoids.dbo.Void v INNER JOIN [CloudVoids].[dbo].[voidstatus] vs
ON v.VoidStatusId = vs.VoidStatusID AND vs.AllowMatches = 1
LEFT JOIN
[CloudVoids].[dbo].[Property] p
ON v.PropertyCode = p.PropertyCode
OUTER APPLY(
SELECT TOP 1
t.[RENT_GROUP_DESCRIPTION] as RentFrequency,
t.TENANCY_END_DATE AS TenancyEndDate
FROM
[MasterReferenceData].[dbo].[TBL_TENANCY] t
WHERE
t.[PLACE-REF] = p.PropertyCode 
ORDER BY t.TENANCY_REFERENCE desc
)  as Tenancy 
LEFT JOIN 
[MasterReferenceData].[dbo].[TBL_PROPERTY] ts
ON p.PropertyCode = ts.PROPERTY_CODE
LEFT OUTER JOIN [MasterReferenceData].[dbo].[TBL_POSTCODE_LONGLAT] po
                ON ts.POST_CODE= po.PostCode
LEFT JOIN [Allocations].[dbo].[VBLPropertyPostcodes] vpp
ON vpp.Postcode = ts.POST_CODE')"; }
        }
    }
}