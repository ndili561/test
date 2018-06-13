namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_GetPropertyImage
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPropertyImage]') AND type in (N'P', N'PC'))
                        DROP PROCEDURE [dbo].[GetPropertyImage]
                "; } 
       }


        public static string create_GetPropertyImage
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("GetPropertyImage");
                return sqlString;
            }
        }

   }

}
