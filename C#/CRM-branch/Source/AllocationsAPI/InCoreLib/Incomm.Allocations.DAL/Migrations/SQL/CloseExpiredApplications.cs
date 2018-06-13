namespace InCoreLib.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {

        public static string drop_CloseExpiredApplication
        {
        
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("Revert_CloseExpiredApplication");
                return sqlString;
            }
        }
    


        public static string create_CloseExpiredApplication
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("CloseExpiredApplication");
                return sqlString;
            }
        }

    }

}
