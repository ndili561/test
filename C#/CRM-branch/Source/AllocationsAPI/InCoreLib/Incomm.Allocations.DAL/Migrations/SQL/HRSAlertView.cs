using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InCoreLib.DAL.Migrations.SQL
{
   public partial class SqlProgrammability    {

       public static string drop_HRSAlertView {
           get { return @"IF  EXISTS (SELECT * FROM sys.views
                                  WHERE object_id = OBJECT_ID(N'dbo.HRSAlerts'))
                                  DROP VIEW dbo.HRSAlerts"; } 
       }


        public static string create_HrsAlertView {
            get { return @"EXEC ('Create View HRSAlerts as SELECT e.CaseEventID, e.CaseRef, e.ActualStartDate AS Date, ha.FirstName + '' '' + ha.LastName AS Name, ''Assessment Needed'' AS Alert, ha.DOB ,ha.Gender
FROM            dbo.tsubHOAEvents AS e INNER JOIN
                         dbo.tblHOAssessment AS ha ON e.CaseRef = ha.CaseRefNumber
WHERE        (e.EventID = (Select EventId from dbo.lstEvent where EventDesc = ''HRSEvent'')) AND (e.AssignedTo IS NULL) ')"; }
        }

   }

}
