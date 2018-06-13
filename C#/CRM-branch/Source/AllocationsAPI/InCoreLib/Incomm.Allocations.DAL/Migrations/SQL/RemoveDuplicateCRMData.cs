namespace Incomm.Allocations.DAL.Migrations.SQL
{
    /// <summary>
    /// </summary>
    public partial class SqlProgrammability
    {
        /// <summary>
        /// </summary>
        public static string RemoveDuplicateCRMData
        {
            get {
                return @"ALTER TABLE VBLContacts
                        ALTER COLUMN TitleId int NULL
                        ALTER TABLE VBLContacts
                        ALTER COLUMN NationalityTypeId int NULL
                        ALTER TABLE VBLContacts
                        ALTER COLUMN EthnicityId int NULL
                        ALTER TABLE VBLContacts
                        ALTER COLUMN LanguageId int NULL
                        ALTER TABLE VBLContacts
                        ALTER COLUMN GenderId int NULL
                        ALTER TABLE VBLContacts
                        ALTER COLUMN DateOfBirth DateTime NULL

"; }
        }
    }
}
