namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedByAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuditVblExpenditureDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLContacts", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLAddresses", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLApplications", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLApplicationHistories", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLCustomerInterests", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLDocuments", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLMutualExchagePropertyDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLMutualExchangeAdaptationDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertymatchDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertyAdaptationDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertyAgeRestrictions", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertyHeatingTypes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertyPropertySizes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertyPropertyTypes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertyPrefferedNeighbourhoods", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedPropertySchemes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLDisabilityDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLDisabilityTypes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLIncomeDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLIncommunitiesRelationshipTypes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLReceivingSupportDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLSupportContactByDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLSupportProviders", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLSupportTypes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLRequestedSupportDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLTenantDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLNotes", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.AuditVBLIncomeDetails", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.Hostels", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.HRSProviders", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.HRSCustomers", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.HRSPlacementMatchedForCustomers", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.HRSPlacements", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.HRSMatchHistory", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.HRSQuestionAnswers", "CreatedBy", c => c.String(maxLength: 40));
            AddColumn("dbo.VBLExpenditureDetails", "CreatedBy", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VBLExpenditureDetails", "CreatedBy");
            DropColumn("dbo.HRSQuestionAnswers", "CreatedBy");
            DropColumn("dbo.HRSMatchHistory", "CreatedBy");
            DropColumn("dbo.HRSPlacements", "CreatedBy");
            DropColumn("dbo.HRSPlacementMatchedForCustomers", "CreatedBy");
            DropColumn("dbo.HRSCustomers", "CreatedBy");
            DropColumn("dbo.HRSProviders", "CreatedBy");
            DropColumn("dbo.Hostels", "CreatedBy");
            DropColumn("dbo.AuditVBLIncomeDetails", "CreatedBy");
            DropColumn("dbo.VBLNotes", "CreatedBy");
            DropColumn("dbo.VBLTenantDetails", "CreatedBy");
            DropColumn("dbo.VBLRequestedSupportDetails", "CreatedBy");
            DropColumn("dbo.VBLSupportTypes", "CreatedBy");
            DropColumn("dbo.VBLSupportProviders", "CreatedBy");
            DropColumn("dbo.VBLSupportContactByDetails", "CreatedBy");
            DropColumn("dbo.VBLReceivingSupportDetails", "CreatedBy");
            DropColumn("dbo.VBLIncommunitiesRelationshipTypes", "CreatedBy");
            DropColumn("dbo.VBLIncomeDetails", "CreatedBy");
            DropColumn("dbo.VBLDisabilityTypes", "CreatedBy");
            DropColumn("dbo.VBLDisabilityDetails", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertySchemes", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertyPrefferedNeighbourhoodDetails", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertyPrefferedNeighbourhoods", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertyPropertyTypes", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertyPropertySizes", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertyHeatingTypes", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertyAgeRestrictions", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertyAdaptationDetails", "CreatedBy");
            DropColumn("dbo.VBLRequestedPropertymatchDetails", "CreatedBy");
            DropColumn("dbo.VBLMutualExchangeAdaptationDetails", "CreatedBy");
            DropColumn("dbo.VBLMutualExchagePropertyDetails", "CreatedBy");
            DropColumn("dbo.VBLDocuments", "CreatedBy");
            DropColumn("dbo.VBLCustomerInterests", "CreatedBy");
            DropColumn("dbo.VBLApplicationHistories", "CreatedBy");
            DropColumn("dbo.VBLApplications", "CreatedBy");
            DropColumn("dbo.VBLAddresses", "CreatedBy");
            DropColumn("dbo.VBLContacts", "CreatedBy");
            DropColumn("dbo.AuditVblExpenditureDetails", "CreatedBy");
        }
    }
}
