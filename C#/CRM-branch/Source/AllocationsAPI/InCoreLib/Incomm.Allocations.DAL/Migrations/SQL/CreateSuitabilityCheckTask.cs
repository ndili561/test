namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_CreateSuitabilityCheckTask
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CreateSuitabilityCheckTask]') AND type in (N'P', N'PC'))
                        DROP PROCEDURE [dbo].[CreateSuitabilityCheckTask]
                "; } 
       }


        public static string create_CreateSuitabilityCheckTask
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("CreateSuitabilityCheckTask");
                return sqlString;
            }
        }

   }

}
