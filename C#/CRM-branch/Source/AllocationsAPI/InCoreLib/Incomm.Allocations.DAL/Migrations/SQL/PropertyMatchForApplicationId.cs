namespace InCoreLib.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {

        public static string drop_PropertyMatchForApplicationId
        {
            get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PropertyMatchForApplicationId]') AND type in (N'P', N'PC'))
                DROP PROCEDURE [dbo].[PropertyMatchForApplicationId]
                "; }
        }


        public static string create_PropertyMatchForApplicationId
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("PropertyMatchForApplicationId");
                return sqlString;
            }
        }

    }
}
