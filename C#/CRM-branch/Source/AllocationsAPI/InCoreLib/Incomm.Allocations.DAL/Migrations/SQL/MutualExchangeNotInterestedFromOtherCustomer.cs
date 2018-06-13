namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_MutualExchangeNotInterestedFromOtherCustomer
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MutualExchangeNotInterestedFromOtherCustomer]') AND type in (N'P', N'PC'))
                        DROP PROCEDURE [dbo].[MutualExchangeNotInterestedFromOtherCustomer]
                "; } 
       }


        public static string create_MutualExchangeNotInterestedFromOtherCustomer
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("MutualExchangeNotInterestedFromOtherCustomer");
                return sqlString;
            }
        }

   }

}
