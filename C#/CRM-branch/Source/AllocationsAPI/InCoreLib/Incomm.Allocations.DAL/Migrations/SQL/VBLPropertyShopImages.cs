namespace InCoreLib.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {
        public static string drop_VBLPropertyShopImages
        {
            get { return @"IF  EXISTS (SELECT * FROM sys.views
                                  WHERE object_id = OBJECT_ID(N'dbo.VBLPropertyShopImages'))
                                  DROP VIEW dbo.VBLPropertyShopImages"; }
        }

        public static string create_VBLPropertyShopImages
        {
            get { return @"EXEC ('CREATE VIEW [dbo].[VBLPropertyShopImages]
                    AS select PropertyImageId,PropertyCode, ImagePath from [CloudVoids].[dbo].[PropertyImage] where ImagePath like''\\vbased%''')"; }
        }
    }
}
