namespace InCoreLib.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class MigrateIncommunitiesRelationshipData : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO dbo.VBLIncommunitiesRelationships (ContactId, HasIncommunitiesRelationship, IncommunitiesRelationshipDescription, CreatedDate, CreatedBy)
                    SELECT C.ContactID, C.HasIncommunitiesRelationship, CASE LEN(C.IncommunitiesRelationshipDescription)
		                    WHEN 0
			                    THEN NULL
		                    ELSE C.IncommunitiesRelationshipDescription
		                    END, A.ChangeDate, A.UserName
                    FROM dbo.Contact AS C
                    CROSS APPLY (
	                    SELECT TOP 1 ChangeDate, UserName
	                    FROM dbo.AuditContact AS AC
	                    WHERE ChangeType = 'Created'
		                    AND AC.ContactID = C.ContactID
	                    ) AS A
                    WHERE HasIncommunitiesRelationship IN (
		                    0
		                    ,1
		                    )
	                    AND NOT EXISTS (
		                    SELECT 1
		                    FROM dbo.VBLIncommunitiesRelationships AS I
		                    WHERE I.ContactId = C.ContactID
		                    )
	                    AND EXISTS (
		                    SELECT 1
		                    FROM dbo.VBLContacts AS VC
		                    WHERE VC.ContactId = C.ContactID
		                    )");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM dbo.VBLIncommunitiesRelationships");
        }
    }
}
