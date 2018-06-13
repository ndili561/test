namespace InCoreLib.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {

        public static string drop_fnSplitString
        {
            get { return @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnSplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
                    DROP FUNCTION [dbo].[fnSplitString]
                "; }
        }


        public static string create_fnSplitString
        {
            get
            {
                var sqlString = SQLScriptsHelper.GetStoredProcedureSql("fnSplitString");
                return sqlString;
            }
        }

    }

}
