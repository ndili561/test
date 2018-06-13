using InCoreLib.DAL.Migrations.SQL;

namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredProcedureAdded : DbMigration
    {
        public override void Up()
        {
            Down();
            Sql(SqlProgrammability.create_CreateSuitabilityCheckTask);
            Sql(SqlProgrammability.create_fnSplitString);
            Sql(SqlProgrammability.create_GetPropertyDetailsByLandlordIdsAndPropertyCodes);
            Sql(SqlProgrammability.create_PropertyMatchForApplicationId);
            Sql(SqlProgrammability.create_GetPropertyDetail);
            Sql(SqlProgrammability.create_GetPropertyImage);
            Sql(SqlProgrammability.create_GetVoidPropertyAvailableForRent);
            Sql(SqlProgrammability.create_MutualExchangeAccepted);
            Sql(SqlProgrammability.create_MutualExchangeNotInterestedFromOtherCustomer);
            Sql(SqlProgrammability.create_CloseExpiredApplication);
        }
        
        public override void Down()
        {
           
            Sql(SqlProgrammability.drop_GetPropertyDetailsByLandlordIdsAndPropertyCodes);
            Sql(SqlProgrammability.drop_PropertyMatchForApplicationId);
            Sql(SqlProgrammability.drop_GetPropertyDetail);
            Sql(SqlProgrammability.drop_GetPropertyImage);
            Sql(SqlProgrammability.drop_fnSplitString);
            Sql(SqlProgrammability.drop_CreateSuitabilityCheckTask);
            Sql(SqlProgrammability.drop_GetVoidPropertyAvailableForRent);
            Sql(SqlProgrammability.drop_MutualExchangeAccepted);
            Sql(SqlProgrammability.drop_MutualExchangeNotInterestedFromOtherCustomer);
            Sql(SqlProgrammability.drop_CloseExpiredApplication);
        }
    }
}
