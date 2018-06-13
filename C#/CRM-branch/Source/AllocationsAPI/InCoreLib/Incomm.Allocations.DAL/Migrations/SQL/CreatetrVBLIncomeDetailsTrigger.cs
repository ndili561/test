namespace Incomm.Allocations.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {
        public static string CreatetrVBLIncomeDetailsTrigger {
            get
            {
                return
                    @"
                        SET ANSI_NULLS ON
	                    GO
	                    SET QUOTED_IDENTIFIER ON
	                    GO
	                    
                        CREATE TRIGGER [dbo].[trVBLIncomeDetails] on [dbo].[VBLIncomeDetails]
		                    AFTER INSERT, UPDATE, DELETE
	                    AS
		                    BEGIN
			                    SET NOCOUNT ON
			
			                    INSERT INTO dbo.AuditVBLIncomeDetails(
				                    IncomeDetailId,
				                    IncomesComment,
				                    IncomeTypeId,
				                    IncomeFrequencyId,
				                    Amount,
				                    ContactId,
				                    LoginName,
				                    ChangeType,
				                    ChangeDate,
				                    CreatedDate,
				                    ModifiedBy,
				                    ModifiedDate
				                    )
				                    SELECT
					                    ISNULL(INSERTED.[IncomeDetailId], DELETED.[IncomeDetailId]),
					                    ISNULL(INSERTED.[IncomesComment], DELETED.[IncomesComment]),
					                    ISNULL(INSERTED.[IncomeTypeId], DELETED.[IncomeTypeId]),
					                    ISNULL(INSERTED.[IncomeFrequencyId], DELETED.[IncomeFrequencyId]),
					                    ISNULL(INSERTED.[Amount], DELETED.[Amount]),
					                    ISNULL(INSERTED.[ContactId], DELETED.[ContactId]),
					                    [LoginName] = SUSER_NAME(),
					                    [ChangeType] = CASE WHEN INSERTED.[IncomeDetailId] IS NOT NULL AND DELETED.[IncomeDetailId] IS NOT NULL THEN 'Updated' WHEN INSERTED.[IncomeDetailId] IS NOT NULL THEN 'Created' ELSE 'Deleted' End,
					                    [ChangeDate] = GETDATE(),
					                    ISNULL(INSERTED.[CreatedDate], DELETED.[CreatedDate]),
					                    ISNULL(INSERTED.[ModifiedBy], DELETED.[ModifiedBy]),
					                    ISNULL(INSERTED.[ModifiedDate], DELETED.[ModifiedDate])
				                    FROM INSERTED
					                    FULL OUTER JOIN DELETED
						                    ON INSERTED.[IncomeDetailId] = DELETED.[IncomeDetailId]
						
				                    SET NOCOUNT OFF
		                    END";
            }
        }

        public static string RemovetrVBLIncomeDetailsTrigger
        {
            get
            {
                return
                    @"IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trVBLIncomeDetails]'))
                    DROP TRIGGER [dbo].[trVBLIncomeDetails]";
            }
        }
    }
}
