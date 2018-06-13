namespace Incomm.Allocations.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_SearchContactView
        {
           get { return @"IF  EXISTS (SELECT * FROM sys.views
                                  WHERE object_id = OBJECT_ID(N'dbo.SearchContacts'))
                                  DROP VIEW dbo.SearchContacts"; } 
       }


        public static string create_SearchContactView
        {
            get { return $@"EXEC ('
                    Create View [dbo].[SearchContacts]  AS 
                    SELECT  c.ContactId,
                            c.GlobalIdentityKey,
		                    va.ApplicationId,
                            vas.Name AS ApplicationStatus,
		                    p.Forename,
		                    p.Surname,
                            p.NationalInsuranceNumber,
		                    p.DateOfBirth,
		                    ct.Name  AS ContactTypeName,
                            a.Id As AddressId,
                            (a.AddressLine1 +''  ''+ ISNULL(a.AddressLine2,'''') +''  ''+ISNULL(a.AddressLine3,'''')  +''  ''+ISNULL(a.AddressLine4,'''')  +''  ''+ISNULL(a.PostCode,'''') ) AS Address,
                            g.Name AS Gender,
                            e.Name AS Ethnicity,
                            l.Name AS Language,
                            t.Name AS Title,
                            nt.Name AS Nationality
                      FROM [dbo].[VBLContacts] c
                      INNER JOIN CRM.dbo.Persons p
                      ON c.GlobalIdentityKey = p.GlobalIdentityKey
                      LEFT JOIN CRM.dbo.Genders g
                      ON p.GenderId = g.Id
                      LEFT JOIN CRM.dbo.Ethnicities e
                      ON p.EthnicityId = e.Id
                      LEFT JOIN CRM.dbo.Languages l
                      ON p.PreferredLanguageId = l.Id
                      LEFT JOIN CRM.dbo.NationalityTypes nt
                      ON p.NationalityTypeId = nt.Id
                      LEFT JOIN CRM.dbo.Titles t
                      ON p.TitleId = t.Id
                      LEFT JOIN CRM.dbo.PersonAddresses pa
                      ON p.Id = pa.PersonId
                      AND pa.AddressTypeId = 1
                      LEFT JOIN CRM.dbo.Addresses a
                      ON pa.AddressId = a.Id
                      INNER JOIN dbo.VBLApplications va
                      ON c.ApplicationId = va.ApplicationId
                      LEFT JOIN dbo.ContactType ct
                      ON c.ContactTypeId = ct.ContactTypeId
                      LEFT JOIN dbo.ApplicationStatus vas
                      ON va.ApplicationStatusID = vas.ApplicationStatusID

                    ')"; }
        }

   }

}
