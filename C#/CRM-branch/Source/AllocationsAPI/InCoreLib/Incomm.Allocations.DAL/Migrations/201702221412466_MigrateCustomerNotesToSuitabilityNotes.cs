namespace InCoreLib.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateCustomerNotesToSuitabilityNotes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
BEGIN TRY
	BEGIN TRAN

	IF EXISTS (
			SELECT 1
			FROM Allocations..SuitabilityNotes
			)
	BEGIN
		PRINT 'Suitability Notes are not empty.'

		RAISERROR (
				'Suitability Notes are not empty.'
				,10
				,1
				)
	END

	SET IDENTITY_INSERT Allocations..SuitabilityNotes ON

	INSERT INTO Allocations..SuitabilityNotes (
		SuitabilityNoteId
		,SuitabilityNoteTypeId
		,ContactId
		,[Text]
		,CreatedBy
		,CreatedDate
		)
	SELECT CN.CustomerNoteID
		,1 AS SuitabilityNoteTypeId
		,C.ContactId
		,CN.Note
		,ISNULL(U.Id, 'fc6518fd-3677-4406-aa2a-5c558eafc84c') AS CreatedBy
		,CONVERT(DATETIME, CN.NoteDate, 105) AS CreatedDate
	FROM Allocations..CustomerNote AS CN
	CROSS APPLY (
		SELECT C.ContactId
		FROM Allocations..VBLContacts AS C
		WHERE C.ApplicationId = CN.CustomerApplicationID
			AND c.ContactTypeId = 1
		) C
	OUTER APPLY (
		SELECT TOP 1 U.Id
		FROM [Identity]..AspNetUsers AS U
		WHERE CONCAT (
				U.FirstName
				,' '
				,U.LastName
				) = CN.UserName
			OR (
				CN.UserName = 'Bev Lockwood'
				AND U.Id = 'c624c884-c5e8-473d-a3c4-312140ae9a3d'
				)
			OR (
				CN.UserName = 'Vicky Carroll'
				AND U.Id = '7E8EF32A-5937-4F65-B0A7-723A32616829'
				)
			OR (
				CN.UserName = 'Julie Tetlaw (Crane)'
				AND U.Id = '024af1f9-18b2-4694-8fda-c495e656ba33'
				)
			OR (
				CN.UserName = 'Kyra Louise West'
				AND U.Id = 'cdadded1-0b1a-4162-a2ab-ac1c569f8220'
				)
			OR (
				CN.UserName = 'Davinda Kaur Rai'
				AND U.Id = 'EBB5B3A5-EA1D-4DA7-A835-08DBAB0CABAA'
				)
			OR (
				CN.UserName = 'Anne-Laure Doyle'
				AND U.Id = 'a0224f13-f0be-407e-b189-e07266c30853'
				)
			OR (
				CN.UserName = 'Kirk Keach'
				AND U.Id = '81D30AE2-43A0-4EBE-A15B-95D139E5E086'
				)
			OR (
				CN.UserName = 'Elizabeth Farrer'
				AND U.Id = 'DE201B88-2A0A-41A2-93BB-0D839E1672D6'
				)
			OR (
				CN.UserName = 'Lucy Vogel'
				AND U.Id = '846381D3-1828-48C2-BF99-9CBE58703A95'
				)
			OR (
				CN.UserName = 'Marie Judson'
				AND U.Id = 'fd1b25ed-7e59-4140-ba14-48a4a3b8865a'
				)
		ORDER BY U.LockoutEnabled
		) U

	UPDATE Allocations..CustomerNote
	SET NoteActive = 0
	WHERE EXISTS (
			SELECT 1
			FROM Allocations..SuitabilityNotes AS S
			WHERE S.SuitabilityNoteId = CustomerNoteID
			)

	SET IDENTITY_INSERT Allocations..SuitabilityNotes OFF

	COMMIT TRAN
END TRY

BEGIN CATCH
	ROLLBACK TRAN

	PRINT 'Inserting Suitability Notes failed.'
	PRINT @@ERROR
END CATCH
");
        }

        public override void Down()
        {
            Sql(@"
BEGIN TRY
	BEGIN TRAN

	UPDATE Allocations..CustomerNote
	SET NoteActive = 1
	WHERE EXISTS (
			SELECT 1
			FROM Allocations..SuitabilityNotes AS S
			WHERE S.SuitabilityNoteId = CustomerNoteID
			)

    DELETE FROM Allocations..SuitabilityNotes

	COMMIT TRAN
END TRY

BEGIN CATCH
	ROLLBACK TRAN

	PRINT 'Inserting Suitability Notes failed.'
	PRINT @@ERROR
END CATCH
");
        }
    }
}
