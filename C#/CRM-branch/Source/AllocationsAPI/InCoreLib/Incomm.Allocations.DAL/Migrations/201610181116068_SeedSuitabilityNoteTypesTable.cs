namespace InCoreLib.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedSuitabilityNoteTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT dbo.SuitabilityNoteTypes ON

                MERGE dbo.SuitabilityNoteTypes AS TARGET
                USING(
                    SELECT Id, [Name], IsActive
                    FROM(
                        VALUES(1, 'Note', 1)
                        ) AS Notes(Id, [Name], IsActive)
                    ) AS SOURCE
                    ON SOURCE.Id = TARGET.SuitabilityNoteTypeId
                WHEN NOT MATCHED
                    THEN
                        INSERT(SuitabilityNoteTypeId, [Name], IsActive)
                        VALUES(SOURCE.Id, SOURCE.[Name], SOURCE.IsActive);

            SET IDENTITY_INSERT dbo.SuitabilityNoteTypes OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.SuitabilityNoteTypes");
        }
    }
}
