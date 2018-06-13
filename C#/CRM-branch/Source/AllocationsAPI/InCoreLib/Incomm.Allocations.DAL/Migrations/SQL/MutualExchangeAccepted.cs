namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_MutualExchangeAccepted
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MutualExchangeAccepted]') AND type in (N'P', N'PC'))
                        DROP PROCEDURE [dbo].[MutualExchangeAccepted]
                "; } 
       }


        public static string create_MutualExchangeAccepted
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("MutualExchangeAccepted");
                return sqlString;
            }
        }

   }

}
