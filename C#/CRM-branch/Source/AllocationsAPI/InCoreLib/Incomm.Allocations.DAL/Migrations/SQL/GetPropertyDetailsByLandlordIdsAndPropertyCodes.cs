namespace InCoreLib.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {

        public static string drop_GetPropertyDetailsByLandlordIdsAndPropertyCodes
        {
            get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPropertyDetailsByLandlordIdsAndPropertyCodes]') AND type in (N'P', N'PC'))
                DROP PROCEDURE [dbo].[GetPropertyDetailsByLandlordIdsAndPropertyCodes]
                "; }
        }


        public static string create_GetPropertyDetailsByLandlordIdsAndPropertyCodes
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("GetPropertyDetailsByLandlordIdsAndPropertyCodes");
                return sqlString;
            }
        }

    }

}
