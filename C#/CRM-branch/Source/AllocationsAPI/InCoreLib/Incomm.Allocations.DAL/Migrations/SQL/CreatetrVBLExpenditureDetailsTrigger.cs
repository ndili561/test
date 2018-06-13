using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incomm.Allocations.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {

        public static string CreatetrVBLExpenditureDetailsTrigger
        {
            get
            {
                return
                    @"IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trVBLExpenditureDetails]'))
                    DROP TRIGGER [dbo].[trVBLExpenditureDetails]

                    SET ANSI_NULLS ON
                    GO

                    SET QUOTED_IDENTIFIER ON
                    GO

                    CREATE TRIGGER [dbo].[trVBLExpenditureDetails] on [dbo].[VBLExpenditureDetails]
	                    AFTER INSERT, UPDATE, DELETE
                    AS
                    BEGIN
	                    SET NOCOUNT ON

	                    INSERT INTO AuditVBLExpenditureDetails(
		                    ExpenditureDetailId,
		                    ExpendituresComment,
		                    ExpenditureTypeId,
		                    ExpenditureFrequencyId,
		                    Amount,
		                    Debt,
		                    FutureCostInUse,
		                    ContactId,
		                    CreatedDate,
		                    ModifiedBy,
		                    ModifiedDate,
		                    LoginName,
		                    ChangeType,
		                    ChangeDate
		                    )
	                    SELECT
		                    ISNULL(INSERTED.[ExpenditureDetailId], DELETED.[ExpenditureDetailId]),
		                    ISNULL(INSERTED.[ExpendituresComment], DELETED.[ExpendituresComment]),
		                    ISNULL(INSERTED.[ExpenditureTypeId], DELETED.[ExpenditureTypeId]),
		                    ISNULL(INSERTED.[ExpenditureFrequencyId], DELETED.[ExpenditureFrequencyId]),
		                    ISNULL(INSERTED.[Amount], DELETED.[Amount]),
		                    ISNULL(INSERTED.[Debt], DELETED.[Debt]),
		                    ISNULL(INSERTED.[FutureCostInUse], DELETED.[FutureCostInUse]),
		                    ISNULL(INSERTED.[ContactId], DELETED.[ContactId]),
		                    ISNULL(INSERTED.[CreatedDate], DELETED.[CreatedDate]),
		                    ISNULL(INSERTED.[ModifiedBy], DELETED.[ModifiedBy]),
		                    ISNULL(INSERTED.[ModifiedDate], DELETED.[ModifiedDate]),
		                    [LoginName] 	= SUSER_NAME(),
		                    [ChangeType]	= CASE WHEN INSERTED.[ExpenditureDetailId] IS NOT NULL AND DELETED.[ExpenditureDetailId] IS NOT NULL THEN 'Updated' WHEN INSERTED.[ExpenditureDetailId] IS NOT NULL THEN 'Created' ELSE 'Deleted' End,
		                    [ChangeDate]	= GETDATE()
	                    FROM INSERTED
		                    FULL OUTER JOIN DELETED
			                    ON INSERTED.[ExpenditureDetailId] = DELETED.[ExpenditureDetailId]

	                    SET NOCOUNT OFF
                    END";
            }
        }

        public static string RemovetrVBLExpenditureDetailsTrigger
        {
            get
            {
                return
                    @"IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trVBLExpenditureDetails]'))
                    DROP TRIGGER [dbo].[trVBLExpenditureDetails]";
            }
        }

    }
}
