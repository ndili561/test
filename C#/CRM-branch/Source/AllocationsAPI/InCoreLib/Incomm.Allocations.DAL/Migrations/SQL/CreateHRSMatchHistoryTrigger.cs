namespace Incomm.Allocations.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {
        public static string CreateHRSMatchHistoryTrigger
        {
            get
            {
                return
                    @"SET ANSI_NULLS ON
	                    GO
	                    SET QUOTED_IDENTIFIER ON
	                    GO
	                    
                        CREATE TRIGGER [dbo].[trHRSMatchHistory] on [dbo].[HRSMatchHistory]
	AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO AuditHRSMatchHistory(
		MatchHistoryId,
		Outcome,
		Reason,
		DecisionDate,
		Reconsidered,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		Customer_HRSCustomerId,
		Placement_PlacementId,
		LoginName,
		ChangeType,
		ChangeDate
		)
	SELECT 
		ISNULL(INSERTED.[MatchHistoryId], DELETED.[MatchHistoryId]),
		ISNULL(INSERTED.[Outcome], DELETED.[Outcome]),
		ISNULL(INSERTED.[Reason], DELETED.[Reason]),
		ISNULL(INSERTED.[DecisionDate], DELETED.[DecisionDate]),
		ISNULL(INSERTED.[Reconsidered], DELETED.[Reconsidered]),
		ISNULL(INSERTED.[CreatedDate], DELETED.[CreatedDate]),
		ISNULL(INSERTED.[ModifiedBy], DELETED.[ModifiedBy]),
		ISNULL(INSERTED.[ModifiedDate], DELETED.[ModifiedDate]),
		ISNULL(INSERTED.[HRSCustomerId], DELETED.[HRSCustomerId]),
		ISNULL(INSERTED.[PlacementId], DELETED.[PlacementId]),
		[LoginName] 	= SUSER_NAME(),
		[ChangeType]	= CASE WHEN INSERTED.[MatchHistoryId] IS NOT NULL AND DELETED.[MatchHistoryId] IS NOT NULL THEN 'Updated' WHEN INSERTED.[MatchHistoryId] IS NOT NULL THEN 'Created' ELSE 'Deleted' End,
		[ChangeDate]	= GETDATE()
	FROM INSERTED
		FULL OUTER JOIN DELETED
			ON INSERTED.[MatchHistoryId] = DELETED.[MatchHistoryId]

	SET NOCOUNT OFF
END";
            }
        }

        public static string RemoveHRSMatchHistoryTrigger
        {
            get
            {
                return
                    @"IF EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHRSMatchHistory]'))
                    DROP TRIGGER [dbo].[trHRSMatchHistory]";
            }
        }
    }
}
