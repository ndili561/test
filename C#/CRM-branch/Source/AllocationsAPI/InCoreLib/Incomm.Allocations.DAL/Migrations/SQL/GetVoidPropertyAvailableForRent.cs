namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_GetVoidPropertyAvailableForRent
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVoidPropertyAvailableForRent]') AND type in (N'P', N'PC'))
                        DROP PROCEDURE [dbo].[GetVoidPropertyAvailableForRent]
                "; } 
       }


        public static string create_GetVoidPropertyAvailableForRent
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("GetVoidPropertyAvailableForRent");
                return sqlString;
            }
        }

   }

}
