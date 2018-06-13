namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_VBLTenancySearchView
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.views
                                  WHERE object_id = OBJECT_ID(N'dbo.VBLTenancySearches'))
                                  DROP VIEW dbo.VBLTenancySearches"; } 
       }


        public static string create_VBLTenancySearchView
        {
            get { return @"CREATE VIEW [dbo].[VBLTenancySearches]
    AS
	SELECT DISTINCT tp.PROPERTY_CODE AS PropertyCode ,
			tp.ADDRESS_LINE_1 AS Address1 ,
			tp.ADDRESS_LINE_2 AS Address2 ,
			tp.ADDRESS_LINE_3 AS Address3 ,
			tp.ADDRESS_LINE_4 AS Address4 ,
			tp.POST_CODE AS Postcode ,
			pt.Description AS IBSPropertyType ,
			tp.AGE_RESTRICTION_AMOUNT AS AgeCriteria ,
			tp.PETS_ALLOWED AS PetsAllowed ,
			tp.NUMBER_OF_BEDROOMS AS PropertyNumBedrooms ,
			ISNULL(Schemes.SchemeID, 0) AS SchemeID ,
			ISNULL(pn.WardId,0) AS SubNeighbourhoodId,
			pn.Code AS SubNeighbourhoodCode,
			pn.Name AS SubNeighbourhoodName,
			pw.Code AS NeighbourhoodCode,
			pw.Name AS NeighbourhoodName,
			CASE WHEN pt.LookupCode = 'HOUSE' THEN 0
				 WHEN pt.LookupCode = 'BUNGALOW' THEN 0
				 WHEN LEN(RTRIM(TP.FLOOR_LEVEL)) = 0 THEN 0
				 ELSE TP.FLOOR_LEVEL
			END AS FlatFloorLevel ,
			CASE WHEN LIFT_ACCESS_FLAG = 'Y' THEN 1
				 ELSE 0
			END AS LiftAccess ,
			CASE WHEN SCHEME = 'CARELI' THEN 1
				 ELSE 0
			END AS Careline ,
			CASE TP.HEATING
			  WHEN 'GAS' THEN 1
			  WHEN 'GASW' THEN 2
			  WHEN 'GELW' THEN 2
			  WHEN 'ELEC' THEN 3
			  WHEN 'ELGA' THEN 1
			  WHEN 'SFL' THEN 1
			  ELSE 0
			END AS HeatingTypeID ,
			CASE WHEN GARDEN_FLAG = 'Y' THEN 1
				 ELSE 0
			END AS Garden ,
			0 AS StepsToAccess ,  --TODO look at this
			0 AS IsWheelChairAdapted ,  --TODO look at this
			CASE WHEN TP.RAMPED_ACCESS = 'Y' THEN 1
				 ELSE 0
			END AS HasRampedAccess ,
			CASE WHEN TP.LEVEL_ACCESS_PROP = 'Y' THEN 1
				 ELSE 0
			END AS IsLevelAccessProperty ,
			CASE WHEN TP.STAIRLIFT = 'Y' THEN 1
				 ELSE 0
			END AS HasStairlift ,
			0 AS HasWalkInShower ,  --TODO look at this
			CASE WHEN TP.STEP_IN_SHOWER_TRAY = 'Y' THEN 1
				 ELSE 0
			END AS HasStepInShower ,
			CASE WHEN LEN(RTRIM(BLOCK_REFERENCE)) = 0 THEN '0' ELSE CAST(BLOCK_REFERENCE AS INT) END AS BlockID ,
			ISNULL(tt.[TNCY_TYPE_CODE],'') AS IBSTypeCode ,
			ISNULL(tt.[TNCY_CAT_CODE],'') AS IBSCatCode ,
			tt.[TENANCY_START_DATE] AS TenancyStart ,
			ISNULL(tt.[TENANCY_END_DATE],CAST('1753-01-01 00:00:00.000' AS DATETIME)) AS TenancyEnd ,
			tc.[FIRSTNAME] AS Forename ,
			tc.[LASTNAME] AS Surname ,
			ISNULL(tc.[DOB],CAST('1753-01-01 00:00:00.000' AS DATETIME)) AS DateOfBirth ,
			TT.[TENANCY_REFERENCE] AS TenancyRef ,
			tc.[TENANT_CODE] AS TenantCode ,
			CASE WHEN TC.MAIN_TENANT_FLAG = 'Y' THEN 1 ELSE 0 END AS MainTenant ,
			ISNULL(v.VoidId,0) AS VoidId ,
			ISNULL(v.TerminationTypeID,0) AS TerminationTypeID ,
			CASE WHEN TT.TENANCY_END_DATE IS NOT NULL THEN 1 ELSE 0 END AS IBSTerminating ,
	        ISNULL(TNT.TenancyTypeId,0) AS TenancyTypeId ,
            ISNULL(TNT.Name,'') AS TenancyTypeName ,
			ISNULL(TT.TNCY_TYPE_CODE,'')  + '-' + ISNULL(TT.TNCY_CAT_CODE,'') AS TenancyType ,
			ISNULL(va.ApplicationId,-1) AS CustomerApplicationID,
			CAST(ISNULL(po.Latitude,0) AS Decimal(19,7)) AS Latitude,
			CAST(ISNULL(po.Longitude,0)  AS Decimal(19,7)) AS Longitude
	FROM    MasterReferenceData.dbo.TBL_PROPERTY AS TP
			LEFT JOIN MasterReferenceData.dbo.PropertyWards AS pw 
			ON  pw.Code = tp.NEIGHBOURHOOD_CODE
			AND tp.NEIGHBOURHOOD_CODE IS NOT NULL
			LEFT JOIN MasterReferenceData.dbo.PropertyWards AS pn 
			ON pn.Code = tp.SUB_NEIGHBOURHOOD_CODE
			AND tp.SUB_NEIGHBOURHOOD_CODE IS NOT NULL
			INNER JOIN CloudVoids.dbo.v_PropertyTypes pt ON tp.PROPERTY_TYPE = pt.LookupCode
			INNER JOIN MasterReferenceData.dbo.TBL_TENANCY AS TT 
			ON TP.PROPERTY_CODE = tt.[PLACE-REF]
			LEFT JOIN dbo.VBLMutualExchagePropertyDetails AS VM 
			ON tp.PROPERTY_CODE = VM.PropertyCode 
            LEFT JOIN dbo.TenancyType AS TNT 
			ON TT.TNCY_TYPE_CODE + '-' + TT.TNCY_CAT_CODE = TNT.TenancyTypeAndCategoryCode 
			LEFT JOIN dbo.VBLApplications AS VA 
			ON VA.ApplicationId = VM.ApplicationId
			AND VA.ApplicationStatusID != 2
			INNER JOIN MasterReferenceData.dbo.TBL_CUSTOMER AS TC ON tc.[PROPERTYREF] = tp.PROPERTY_CODE
																  AND NOT ( tc.[MAIN_TENANT_FLAG] = 'N'
								   AND tc.[JOINT_TENANT] = 'N'
																  )
																  AND TT.[TENANCY_REFERENCE] = TC.[TENANCYREF]
			LEFT OUTER JOIN CloudVoids.dbo.SchemeBlock Schemes 
                ON tp.BLOCK_REFERENCE = Schemes.BlockRef  
			LEFT OUTER JOIN [MasterReferenceData].[dbo].[TBL_POSTCODE_LONGLAT] po
                ON tp.POST_CODE= po.PostCode
			OUTER APPLY
			(
			SELECT v.voidID, 0 AS 'TerminationTypeID'
			FROM CloudVoids.dbo.Void AS V 
			LEFT OUTER JOIN CloudVoids.dbo.VoidStatus AS VS ON vs.VoidStatusID = v.[VoidStatusId]
			WHERE 
			vs.StatusIsOpen = 1
			AND v.PropertyCode = tp.PROPERTY_CODE

			) v
	        WHERE   tt.[TENANCY_START_DATE] < GETDATE()
			AND ISNULL(tt.[TENANCY_END_DATE], GETDATE()) >= DATEADD(MONTH, -1,GETDATE())
	        AND TT.TNCY_TYPE_CODE != 'SFL'AND TT.TNCY_CAT_CODE != 'SFL' "; }
        }

   }

}
