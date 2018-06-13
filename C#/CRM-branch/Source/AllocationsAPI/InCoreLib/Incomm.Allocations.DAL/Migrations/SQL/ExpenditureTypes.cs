using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incomm.Allocations.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {
        /// <summary>
        /// </summary>
        public static string InsertExpenditureTypeData
        {
            get
            {
                return
                    @"delete from dbo.ExpenditureType

                        set identity_insert ExpenditureType on

                        dbcc checkident('ExpenditureType', reseed, 1)

                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(1,'Rent',1,1,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(2,'Council Tax',1,2,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(3,'Electric',1,3,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(4,'Gas',1,4,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(5,'Water',1,5,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(6,'Food',1,6,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(7,'Household expenses',1,7,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(8,'Child Care',1,8,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(9,'School Meals',1,9,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(10,'Clothing',1,10,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(11,'Car (Petrol, tax, MOT, Insurance)',1,11,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(12,'Public Transport',1,12,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(13,'Other Travel (taxis etc)',1,13,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(14,'Mobile Phones',1,14,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(15,'Phone (landline)',1,15,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(16,'Broadband',1,16,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(17,'Satellite / Cable',1,17,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(18,'Tv Licence',1,18,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(19,'Furniture Hire Purchase',1,19,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(20,'Catalogues',1,20,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(21,'Credit Cards',1,21,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(22,'Loans (banks)',1,22,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(23,'Loans (doorstop lenders)',1,23,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(24,'Loans (payday lenders)',1,24,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(25,'Fines and court orders',1,25,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(26,'Cigarettes',1,26,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(27,'Alcohol',1,27,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(28,'Entertainment eg. Cinema',1,28,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(29,'Holidays / trips',1,29,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(30,'Insurance e.g Household',1,30,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(31,'Maintenance Payments',1,31,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(32,'Pension Contributions',1,32,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(33,'Pets',1,33,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(34,'Other',1,34,0)
                        INSERT INTO dbo.ExpenditureType(ExpenditureTypeId, Name, Active, SortOrder,AllowMultiple) VALUES(35,'Other',1,35,0)


                        set identity_insert ExpenditureType off";
            }
        }

    }
}
