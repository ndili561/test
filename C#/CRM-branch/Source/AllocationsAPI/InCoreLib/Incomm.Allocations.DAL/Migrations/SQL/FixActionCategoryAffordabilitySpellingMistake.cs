namespace Incomm.Allocations.DAL.Migrations.SQL
{
    /// <summary>
    /// </summary>
    public partial class SqlProgrammability
    {
        /// <summary>
        /// </summary>
        public static string FixActionCategoryAffordabilitySpellingMistake
        {
            get
            {
                return @"IF EXISTS(SELECT 1 FROM ActionCategories WHERE [Description] = 'Affordibility')
  UPDATE ActionCategories SET [Description] = 'Affordability' WHERE [Description] = 'Affordibility'";
            }
        }

        /// <summary>
        /// </summary>
        public static string RevertActionCategoryAffordabilitySpellingMistake
        {
            get
            {
                return @"IF EXISTS(SELECT 1 FROM ActionCategories WHERE [Description] = 'Affordability')
  UPDATE ActionCategories SET [Description] = 'Affordibility' WHERE [Description] = 'Affordability'";
            }
        }



    }
}
