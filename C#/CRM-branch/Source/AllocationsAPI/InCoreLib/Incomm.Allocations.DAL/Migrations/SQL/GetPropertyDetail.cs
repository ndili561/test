namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_GetPropertyDetail
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPropertyDetail]') AND type in (N'P', N'PC'))
                DROP PROCEDURE [dbo].[GetPropertyDetail]
                "; } 
       }


        public static string create_GetPropertyDetail
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("GetPropertyDetail");
                return sqlString;
            }
        }

   }

}
