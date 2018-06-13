namespace Incomm.Allocations.DAL.Migrations.SQL
{
    /// <summary>
    /// </summary>
    public partial class SqlProgrammability
    {
        /// <summary>
        /// </summary>
        public static string RemoveDuplicateRiskCategory
        {
            get {
                return @"IF EXISTS(SELECT 1 FROM RiskCategories WHERE Id = 18 AND [Description] = 'Mental Health Concerns')
BEGIN
	--	Update any records that may be using the risk category we are about to remove
	UPDATE dbo.SuitabilityCheckRisks SET RiskCategoryId = 17 WHERE RiskCategoryId = 18

	--	Delete the Risk Category
	DELETE FROM dbo.RiskCategories WHERE Id = 18
END
"; }
        }
    }
}
