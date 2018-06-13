namespace Incomm.Allocations.DAL.Migrations.SQL
{
    public partial class SqlProgrammability
    {
        public static string InsertActionAndRiskLookupData
        {
            get
            {
                return
                    @"DELETE FROM Allocations..ActionCategories
DELETE FROM Allocations..ActionResponsibilities
DELETE FROM Allocations..ActionTypes

SET IDENTITY_INSERT Allocations..ActionCategories ON

INSERT INTO Allocations..ActionCategories(Id, [Description], Active, SortOrder) 
VALUES
(1, 'Affordibility', 1, 1),
(2, 'Health & Wellbeing', 1, 2),
(3, 'ASB', 1, 3),
(4, 'Well-Maintained Home', 1, 4),
(5, 'Engagement', 1, 5),
(6, 'Tenancy History', 1, 6)

SET IDENTITY_INSERT Allocations..ActionCategories OFF

SET IDENTITY_INSERT Allocations..ActionTypes ON

INSERT INTO Allocations..ActionTypes(Id,[ActionCategoryId], [Action], Active, SortOrder)
VALUES(1, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Assistance in liaising with Job Centre', 1, 1),
(2, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Bank Account set up', 1, 2),
(3, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Benefit form completion', 1, 3),
(4, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Budgeting advice', 1, 4),
(5, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Debt advice (inc arrears)', 1, 5),
(6, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Direct Debit set up', 1, 6),
(7, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Discuss tenancy obligations', 1, 7),
(8, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Discussion with support worker', 1, 8),
(9, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'HB advice', 1, 9),
(10, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'HB form completion (inc backdate/letters)', 1, 10),
(11, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Income advice', 1, 11),
(12, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Obtaining ID', 1, 12),
(13, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Openfield referral', 1, 13),
(14, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Register on VBL', 1, 14),
(15, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Repayment assistance (inc. arrears)', 1, 15),
(16, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Support Referrals', 1, 16),
(17, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Affordibility'), 'Utility set up / assistance', 1, 17),

(18, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Health & Wellbeing'), 'Discussion with support worker', 1, 18),
(19, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Health & Wellbeing'), 'Property adaptations', 1, 19),
(20, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Health & Wellbeing'), 'Register on VBL', 1, 20),
(21, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Health & Wellbeing'), 'Support Referrals', 1, 21),

(22, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Address neighbourhood issues', 1, 22),
(23, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Agreement made with alleged Perpetrator', 1, 23),
(24, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Complete ASB Action Plan', 1, 24),
(25, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Discuss with alleged perpetrator', 1, 25),
(26, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Discuss tenancy obligations', 1, 26),
(27, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Discussion with support worker', 1, 27),
(28, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Liaise with police', 1, 28),
(29, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Register on VBL', 1, 29),
(30, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'ASB'), 'Support Referrals', 1, 30),

(31, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Carpets assistance', 1, 31),
(32, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Discuss tenancy obligations', 1, 32),
(33, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Discussion with support worker', 1, 33),
(34, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Garden assistance', 1, 34),
(35, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Furniture assistance', 1, 35),
(36, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Register on VBL', 1, 36),
(37, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Repairs logged', 1, 37),
(38, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Well-Maintained Home'), 'Utility set up / assistance', 1, 38),

(39, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Engagement'), 'Attempt visit for access', 1, 39),
(40, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Engagement'), 'Discuss community engagement opportunities', 1, 40),
(41, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Engagement'), 'Discuss tenancy obligations', 1, 41),
(42, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Engagement'), 'Discussion with support worker', 1, 42),
(43,(SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Engagement'), 'Establish preferred method of contact', 1, 43),
(44, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Engagement'), 'Information given about local amenities', 1, 44),
(45, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Engagement'), 'Support Referrals', 1, 45),

(46, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Tenancy History'), 'Assignment', 1, 46),
(47, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Tenancy History'), 'Discuss tenancy obligations', 1, 47),
(48, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Tenancy History'), 'Discussion with support worker', 1, 48),
(49, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Tenancy History'), 'Succession', 1, 49),
(50, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Tenancy History'), 'Support Referrals', 1, 50),
(51, (SELECT Id FROM Allocations..ActionCategories WHERE [Description] = 'Tenancy History'), 'Update household details', 1, 51)

SET IDENTITY_INSERT Allocations..ActionTypes OFF

SET IDENTITY_INSERT Allocations..ActionResponsibilities ON

INSERT INTO Allocations..ActionResponsibilities(Id, [Description], Active, SortOrder)
VALUES
(1, 'Customer', 1, 1),
(2, 'Employee', 1, 2)

SET IDENTITY_INSERT Allocations..ActionResponsibilities OFF

DELETE FROM Allocations..RiskThemes
DELETE FROM Allocations..RiskCategories

SET IDENTITY_INSERT Allocations..RiskThemes ON

INSERT INTO Allocations..RiskThemes(Id, [Description], Active, SortOrder)
VALUES
(1, 'Affordability',1,1),
(2, 'Health & Well being',1,2),
(3, 'ASB',1,3),
(4, 'Well-Maintained Home',1,4),
(5, 'Tenancy History',1,5),
(6, 'Engagement',1,6)

SET IDENTITY_INSERT Allocations..RiskThemes OFF

SET IDENTITY_INSERT Allocations..RiskCategories ON

INSERT INTO Allocations..RiskCategories(Id, RiskThemeId, [Description], Active, SortOrder)
VALUES
(1, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'Affordability', 1, 1),
(2, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'Debt (none rent)', 1, 2),
(3, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'FTA', 1, 3),
(4, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'Low income', 1, 4),
(5, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'No bank account', 1, 5),
(6, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'No ID', 1, 6),
(7, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'No income', 1, 7),
(8, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'No proof of income', 1, 8),
(9, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'Poor money management', 1, 9),
(10, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'Sanctions', 1, 10),
(11, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Affordability'), 'Unemployed', 1, 11),

(12, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Health & Well being'), 'Alcohol issues', 1, 12),
(13, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Health & Well being'), 'Care leaver', 1, 13),
(14, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Health & Well being'), 'Disabilities', 1, 14),
(15, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Health & Well being'), 'Drug misuse', 1, 15),
(16, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Health & Well being'), 'Isolation', 1, 16),
(17, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Health & Well being'), 'Mental Health Concerns', 1, 17),
(18, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Health & Well being'), 'Mental Health Concerns', 1, 18),

(19, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'ASB'), 'Lack of safe environment', 1, 19),
(20, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'ASB'), 'Perpetrator of ASB', 1, 20),
(21, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'ASB'), 'Victim of ASB', 1, 21),

(22, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'Disrepair', 1, 22),
(23, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'No carpets', 1, 23),
(24, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'No furniture', 1, 24),
(25, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'Poor decoration', 1, 25),
(26, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'Property damage', 1, 26),
(27, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'Unable to maintain communal areas', 1, 27),
(28, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'Unable to maintain garden', 1, 28),
(29, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Well-Maintained Home'), 'Utilities not set up correctly', 1, 29),

(30, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Tenancy History'), 'First tenancy', 1, 30),
(31, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Tenancy History'), 'Occupancy issues', 1, 31),
(32, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Tenancy History'), 'Previous failed tenancies', 1, 32),

(33, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Engagement'), 'Engagement in community activity', 1, 33),
(34, (SELECT Id FROM Allocations..RiskThemes WHERE [Description] = 'Engagement'), 'Lack of Engagement', 1, 34)

SET IDENTITY_INSERT Allocations..RiskCategories OFF";
            }
        }

        public static string DeleteActionAndRiskLookupData
        {
            get
            {
                return @"DELETE FROM Allocations..ActionCategories
DELETE FROM Allocations..ActionResponsibilities
DELETE FROM Allocations..ActionTypes
DELETE FROM Allocations..RiskThemes
DELETE FROM Allocations..RiskCategories";
            }
        }
    }
}
