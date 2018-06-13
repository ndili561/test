DELETE FROM [Allocations].[dbo].[CustomerInterestStatus]
SET IDENTITY_INSERT [dbo].[CustomerInterestStatus] ON
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (1, N'Interested', 1, 1, 1, 1, 0)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (2, N'Not Interested', 1, 3, 1, 0, 1)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (3, N'Rejected', 1, 4, 1, 0, 1)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (4, N'Matched', 1, 6, 1, 1, 0)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (5, N'Canceled', 1, 8, 0, 0, 0)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (6, N'Complete', 1, 9, 0, 1, 0)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (7, N'Accepted', 1, 7, 1, 1, 0)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (8, N'Interest From Other Customer', 1, 2, 1, 1, 0)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (9, N'Rejection From Other Customer', 1, 5, 1, 0, 1)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (10, N'Matched from Waiting List', 1, 10, 1, 1, 0)
INSERT [dbo].[CustomerInterestStatus] ([CustomerInterestStatusID], [Name], [Active], [SortOrder], [StatusIsOpen], [StatusOnlyShowProperty], [StatusHideProperty]) VALUES (11, N'Reconsider', 1, 11, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[CustomerInterestStatus] OFF

GO

DELETE FROM [Allocations].[dbo].[TenancyType]
SET IDENTITY_INSERT [dbo].[TenancyType] ON
INSERT INTO [Allocations].[dbo].[TenancyType]
([TenancyTypeId],[Name],[Active],[SortOrder],[Code],[TenancyTypeAndCategoryCode])
VALUES
(1,'Assured Protected Rights',1,0,'APR','APR-PRO'),
(2,'Assured Shorthold',1,10,'ASH','ASH-TAR'),
(3,'Assured Tenancy',1,15,'ASS','ASS-TAR'),
(4,'Assured Tenancy',0,20,'ASS','ASS-PRO'),
(5,'Don''t Know',1,30,'ASS','ASS-DKW'),
(6,'Other',1,40,'ASS','ASS-OTH'),
(7,'Protected Asylum Contract',0,50,'ASY','ASY-PRO'),
(8,'Bond Scheme',0,60,'BON','BON-BON'),
(9,'Commercial',0,70,'COM','COM-COM'),
(10,'Holding Over Concessionary rental',0,80,'CONH','CONH-COM'),
(11,'Concessionary rental - lease',0,90,'CONL','CONL-COM'),
(12,'Tenancy at Will Concessionary rental',0,100,'CONT','CONT-COM'),
(13,'Assured Shorthold',0,110,'EAS','EAS-EHA'),
(14,'Garage Tenancy',0,120,'GAR','GAR-GAR'),
(15,'Holding Over - Commercial',0,130,'HOL','HOL-COM'),
(16,'Insecure Tenancy',0,140,'INS','INS-PRO'),
(17,'Insecure Tenancy',0,150,'INS','INS-TAR'),
(18,'Leaseholder',0,160,'LEA','LEA-LEA'),
(19,'Leasehold Right To Buy',0,170,'LEA','LEA-PRO'),
(20,'Licenced',0,180,'LIC','LIC-PRO'),
(21,'Licensed',0,190,'LIC','LIC-TAR'),
(22,'Rent to Homebuy',0,200,'RTH','RTH-RTH'),
(23,'Standard Business Lease',0,210,'SBL','SBL-LEA'),
(24,'Secure Tenant',1,220,'SEC','SEC-SEC'),
(25,'Sold Flat Lease',0,230,'SFL','SFL-SFL'),
(26,'Shared Ownership',0,240,'SHA','SHA-SHA'),
(27,'Shared Ownership Flat',0,250,'SHF','SHF-SHA'),
(28,'Secure Legal Action Ongoing',0,260,'SLA','SLA-SEC'),
(29,'Secure Not Returned',0,270,'SNR','SNR-SEC'),
(30,'Secure Refused To Sign',0,280,'SRF','SRF-SEC'),
(31,'Tenancy at Will - Commercial',0,290,'TAW','TAW-COM')

SET IDENTITY_INSERT [dbo].[TenancyType] OFF


DELETE FROM [Allocations].[dbo].[PropertyBlockTypes]
SET IDENTITY_INSERT [dbo].[PropertyBlockTypes] ON
INSERT INTO [Allocations].[dbo].[PropertyBlockTypes]
([PropertyBlockTypeId],[Name],[Active],[SortOrder])
VALUES
 (1,'High Rise',1,10)
,(2,'Low Rise',1,20)
,(3,'Up Down Dent',1,30)
SET IDENTITY_INSERT [dbo].[PropertyBlockTypes] OFF

DELETE FROM [Allocations].[dbo].[PropertyEntranceTypes]
SET IDENTITY_INSERT [dbo].[PropertyEntranceTypes] ON
INSERT INTO [Allocations].[dbo].[PropertyEntranceTypes]
([PropertyEntranceTypeId],[Name],[Active],[SortOrder])
VALUES
(1,'Communal',1,10)
,(2,'Own',1,20)
SET IDENTITY_INSERT [dbo].[PropertyEntranceTypes] OFF

DELETE FROM [Allocations].[dbo].[Title]
SET IDENTITY_INSERT [dbo].[Title] ON
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (0, N'Unknown', 0, 0, 0)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (1, N'Cllr', 0, 9, 0)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (2, N'Dr', 0, 6, 0)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (3, N'Lord', 0, 100, 2)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (4, N'Miss', 1, 50, 4)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (5, N'Mr', 1, 10, 1)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (6, N'Mrs', 1, 20, 2)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (7, N'Rev', 0, 7, 0)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (8, N'Sir', 0, 8, 2)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (9, N'Mstr', 0, 40, 2)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (10, N'Ms', 1, 30, 3)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (11, N'Master', 1, 50, 1)
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder], [DefaultGenderID]) VALUES (12, N'MigrationError', 0, 999, 0)
SET IDENTITY_INSERT [dbo].[Title] OFF

  update [Allocations].[dbo].[VBLContacts] set titleid = 10 where titleid = 7 and genderid = 1
  update [Allocations].[dbo].[VBLContacts] set titleid = 5 where titleid = 7 and genderid = 2
  update [Allocations].[dbo].[VBLContacts] set titleid = 10 where titleid = 2 and genderid = 1
  update [Allocations].[dbo].[VBLContacts] set titleid = 5 where titleid = 2 and genderid = 2
  update [Allocations].[dbo].[VBLContacts] set titleid = 10 where titleid = 1 and genderid = 1
  update [Allocations].[dbo].[VBLContacts] set titleid = 5 where titleid = 1 and genderid = 2
  update [Allocations].[dbo].[VBLContacts] set titleid = 5 where titleid = 3
  update [Allocations].[dbo].[VBLContacts] set titleid = 5 where titleid = 8

DELETE FROM [Allocations].[dbo].[VBLDisabilityTypes]
SET IDENTITY_INSERT [dbo].[VBLDisabilityTypes] ON
INSERT [dbo].[VBLDisabilityTypes] ([DisabilityTypeId], [Name], [Active], [SortOrder],[CreatedDate])
 VALUES
 (1, N'Physical impairment', 1, 1,GetDate())
,(2, N'Learning impairment', 1, 2,GetDate())
,(3, N'Long-standing illness or health condition', 1, 3,GetDate())
,(4, N'Mental health condition', 1, 4,GetDate())
,(5, N'Mobility impairment', 1, 5,GetDate())
,(6, N'Other (please write below)', 1, 6,GetDate())
,(7, N'Sensory impairment', 1, 7,GetDate())
,(8, N'Wheel chair user', 1, 8,GetDate())
SET IDENTITY_INSERT [dbo].[VBLDisabilityTypes] OFF 

DELETE FROM [Allocations].[dbo].[IncomeFrequency]
SET IDENTITY_INSERT [dbo].[IncomeFrequency] ON
INSERT [dbo].[IncomeFrequency] ([IncomeFrequencyId], [Name], [Active], [SortOrder]) 
VALUES 
(0, N'Infrequent', 0, 1)
,(1, N'Weekly', 1, 1)
,(2, N'Monthly', 1, 4)
,(3, N'Fortnightly', 1, 2)
,(4, N'4 Weekly', 1, 3)
,(5, N'Annual', 1, 3)
,(6, N'Migration Error', 0, 5)
SET IDENTITY_INSERT [dbo].[IncomeFrequency] OFF

DELETE FROM [Allocations].[dbo].[ContactBy]
DBCC CHECKIDENT (ContactBy, reseed, 0)
SET IDENTITY_INSERT [dbo].[ContactBy] ON
INSERT INTO [Allocations].[dbo].[ContactBy]
		   ([ContactById]
		   ,[Code]
		   ,[Description]
		   ,[Active]
		   ,[SortOrder])
	 VALUES
		   (1,'Phone' ,'Phone' ,1 ,1)--0
		   ,(2,'3rdParty' ,'3rd Party' ,1 ,6)--1
		   ,(3,'Mobile' ,'Mobile' ,1 ,3)--2
		   ,(4,'Email' ,'Email' ,1 ,4)--3
		   ,(5,'Mail' ,'Letter' ,1 ,5)--4
		   ,(6,'SecondaryNumber' ,'Phone 2' ,1 ,2)--5
		   ,(7,'Minicom' ,'MINICOM' ,1 ,7)--6
		   ,(8,'Braille' ,'BRAILLE' ,1 ,8)--7
		   ,(9,'MobileText' ,'Mobile Text' ,0 ,9)--8
SET IDENTITY_INSERT [dbo].[ContactBy] OFF

DELETE FROM [Allocations].[dbo].[PropertyType]
DBCC CHECKIDENT (PropertyType, reseed, 0)
SET IDENTITY_INSERT [dbo].[PropertyType] ON
INSERT [dbo].[PropertyType] ([PropertyTypeId], [Name], [Active], [SortOrder]) 
VALUES (0, N'Unknown', 0, 1)
, (1, N'Bedsit', 1, 6)
, (2, N'Bedspace', 0, 7)
, (3, N'Block', 0, 8)
, (4, N'Bungalow', 1, 4)
, (5, N'Comcent', 0, 10)
, (6, N'Flat', 1, 3)
, (7, N'Garage', 0, 12)
, (8, N'Garlnk', 0, 13)
, (9, N'Garsite', 0, 14)
, (10, N'House', 1, 2)
, (11, N'Land', 0, 16)
, (12, N'Maison', 1, 5)
, (13, N'Office', 0, 18)
, (14, N'Rofway', 0, 19)
, (15, N'Shop', 0, 20)
, (16, N'Shophse', 0, 21)
, (17, N'Temp', 0, 100)
, (18, N'Unit', 0, 23)
SET IDENTITY_INSERT [dbo].[PropertyType] OFF

DELETE FROM [Allocations].[dbo].[SubNeighbourhoods]
DBCC CHECKIDENT (SubNeighbourhoods, reseed, 0)

DELETE FROM [dbo].[Scheme]
SET IDENTITY_INSERT [dbo].[Scheme] ON
INSERT [dbo].[Scheme] ([SchemeId], [Name], [Active], [SortOrder])
 VALUES
 (1, N'Ashfield Court', 1, 2)
,(2, N'Farish House', 1, 5)
,(3, N'Forester Court', 1, 6)
,(4, N'George Street', 1, 7)
,(5, N'John Street', 1, 11)
,(6, N'Main Road', 1, 12)
,(7, N'Manor Court', 1, 13)
,(8, N'Maple Court', 1, 14)
,(9, N'Southfield House', 1, 19)
,(10, N'Staincliffe Court', 1, 20)
,(11, N'William Street', 1, 23)
,(12, N'Anvil Court', 1, 1)
,(13, N'Northcliffe View', 1, 15)
,(14, N'Northdean House', 1, 16)
,(15, N'Shuttleworth House', 1, 18)
,(16, N'Ormond House', 1, 17)
,(17, N'Ivy Bank', 1, 10)
,(18, N'Green Bank', 1, 9)
,(19, N'Derby Place', 1, 3)
,(20, N'Wellesley House', 1, 22)
,(21, N'Sycamore Court', 1, 21)
,(22, N'Goodwin House', 1, 8)
,(23, N'Earlswood', 1, 4)
SET IDENTITY_INSERT [dbo].[Scheme] OFF 

DELETE FROM [SchemeBlocks]


INSERT [dbo].[SchemeBlocks] ([SchemeID], [BlockRef], [Active], [SortOrder]) 
VALUES 
 (10, N'291', 1, 1)
,(2, N'292', 1, 2)
,(4, N'1736', 1, 3)
,(4, N'1737', 1, 4)
,(5, N'1738', 1, 5)
,(3, N'1739', 1, 6)
,(6, N'1740', 1, 7)
,(6, N'1741', 1, 8)
,(6, N'1742', 1, 9)
,( 6, N'1743', 1, 10)
,( 6, N'1744', 1, 11)
,( 6, N'1745', 1, 12)
,( 6, N'1746', 1, 13)
,( 11, N'1747', 1, 14)
,( 11, N'1748', 1, 15)
,( 11, N'1749', 1, 16)
,( 11, N'1750', 1, 17)
,( 11, N'1751', 1, 18)
,( 1, N'1752', 1, 19)
,( 1, N'1753', 1, 20)
,( 8, N'1765', 1, 21)
,( 7, N'1803', 1, 22)
,( 9, N'2073', 1, 23)
,( 5, N'2178', 1, 24)
,( 11, N'2179', 1, 25)
,( 12, N'858', 1, 26)
,( 19, N'336', 1, 27)
,( 23, N'85', 1, 28)
,( 22, N'1087', 1, 29)
,( 17, N'203', 1, 30)
,( 14, N'857', 1, 31)
,( 16, N'992', 1, 32)
,( 15, N'139', 1, 33)
,( 21, N'524', 1, 34)
,( 21, N'525', 1, 35)
,( 20, N'117', 1, 36)
,( 18, N'202', 1, 37)
,( 13, N'1668', 1, 38)


IF (NOT EXISTS(SELECT * FROM MoveReason WHERE MoveReasonId = 33)) 
BEGIN 
SET IDENTITY_INSERT [dbo].[MoveReason] ON
INSERT [dbo].[MoveReason] ([MoveReasonId], [Name], [Active], [SortOrder], [LevelOfNeedID], [ReferToHousingsOptionsOfficer], [ReferToNeighbourhoodOfficer]) 
VALUES (33, N'MigrationError', 0, 999, 99, 0, 0)
SET IDENTITY_INSERT [dbo].[MoveReason] OFF
END
		   IF (NOT EXISTS(SELECT * FROM Title WHERE TitleId = 11)) 
BEGIN 
SET IDENTITY_INSERT [dbo].[Title] ON
INSERT [dbo].[Title] ([TitleId], [Name], [Active], [SortOrder],DefaultGenderID) 
VALUES (11, N'MigrationError', 0, 999, 0)
SET IDENTITY_INSERT [dbo].[Title] OFF
END

IF (NOT EXISTS(SELECT * FROM Gender WHERE GenderId = 3)) 
BEGIN 
SET IDENTITY_INSERT [dbo].Gender ON
INSERT [dbo].Gender (GenderId, [Name], [Active], [SortOrder],Gender) 
VALUES (3, N'MigrationError', 0, 999,'U')
SET IDENTITY_INSERT [dbo].Gender OFF
END

IF (NOT EXISTS(SELECT * FROM NationalityType WHERE NationalityTypeId = 14)) 
BEGIN 
SET IDENTITY_INSERT NationalityType ON
INSERT NationalityType ([NationalityTypeId], [Name], [Active], [SortOrder]) 
VALUES (14, N'MigrationError', 0, 999)
SET IDENTITY_INSERT [dbo].NationalityType OFF
END

IF (NOT EXISTS(SELECT * FROM Ethnicity WHERE EthnicityId = 20)) 
BEGIN 
SET IDENTITY_INSERT [dbo].Ethnicity ON
INSERT [dbo].Ethnicity ([EthnicityId], [Name], [Active], [SortOrder],IBSCode,HOACode) 
VALUES (20, N'MigrationError', 0, 999, 0,'MigrationError')
SET IDENTITY_INSERT [dbo].Ethnicity OFF
END

IF (NOT EXISTS(SELECT * FROM Relationship WHERE RelationshipId = 31)) 
BEGIN 
SET IDENTITY_INSERT [dbo].Relationship ON
INSERT [dbo].Relationship ([RelationshipId], [Name], [Active], [SortOrder]) 
VALUES (31, N'MigrationError', 0, 999)
SET IDENTITY_INSERT [dbo].Relationship OFF
END
UPDATE [dbo].[ApplicationStatus] SET [Name]=N'Open' WHERE [ApplicationStatusID] = 1
UPDATE [dbo].[ApplicationStatus] SET [Name]=N'Closed' WHERE [ApplicationStatusID] = 2
UPDATE [dbo].[ApplicationStatus] SET [Name]=N'Rehoused' WHERE [ApplicationStatusID] = 3
DELETE FROM [dbo].[ApplicationStatus] WHERE [ApplicationStatusID] IN (4,5)
SET IDENTITY_INSERT [dbo].[ApplicationStatus] ON

INSERT INTO [dbo].[ApplicationStatus] ([ApplicationStatusID], [Name], [Active], [SortOrder], [StatusIsOpen]) VALUES (4, N'Incomplete', 1, 4, 0)
INSERT INTO [dbo].[ApplicationStatus] ([ApplicationStatusID], [Name], [Active], [SortOrder], [StatusIsOpen]) VALUES (5, N'Expired', 1, 5, 0)
SET IDENTITY_INSERT [dbo].[ApplicationStatus] OFF
DELETE FROM [dbo].PreferredLanguages
SET IDENTITY_INSERT [dbo].[PreferredLanguages] ON
Insert into [dbo].PreferredLanguages(LanguageId, Name, Active) values (1,'Albanian',1)
,(2,'Amharic',1)
,(3,'Arabic',1)
,(4,'Armenian',1)
,(5,'Bengali',1)
,(6,'Bosnian',1)
,(7,'Bulgarian',1)
,(8,'Burmese',1)
,(9,'Cantonese',1)
,(10,'Croatian',1)
,(11,'Czech',1)
,(12,'Farsi Dari',1)
,(13,'Farsi West',1)
,(14,'French',1)
,(15,'German',1)
,(16,'Greek',1)
,(17,'Gujarati',1)
,(18,'Hindi',1)
,(19,'Hungarian',1)
,(20,'Italian',1)
,(21,'Japanese',1)
,(22,'Korean',1)
,(23,'Kurdish Bahdini',1)
,(24,'Kurdish Sorani',1)
,(25,'Latvian',1)
,(26,'Lingala',1)
,(27,'Lithuanian',1)
,(28,'Malayalam',1)
,(29,'Mandarin',1)
,(30,'Mirpuri',1)
,(31,'Nepali',1)
,(32,'OTHER',1)
,(33,'Pashto',1)
,(34,'Polish',1)
,(35,'Portuguese',1)
,(36,'Punjabi',1)
,(37,'Romanian',1)
,(38,'Russian',1)
,(39,'SIGN LANGUAGE',1)
,(40,'Sinhalese',1)
,(41,'Slovak',1)
,(42,'Somali',1)
,(43,'Spanish',1)
,(44,'Swahili',1)
,(45,'Tagalog',1)
,(46,'Tamil',1)
,(47,'Thai',1)
,(48,'Tigrinya',1)
,(49,'Turkish',1)
,(50,'Twi',1)
,(51,'Urdu',1)
,(52,'Vietnamese',1)
,(53,'English',1)
SET IDENTITY_INSERT [dbo].[PreferredLanguages] OFF
DELETE FROM [IncomeType]
SET IDENTITY_INSERT [dbo].[IncomeType] ON
SET IDENTITY_INSERT [dbo].[IncomeType] ON
INSERT [dbo].[IncomeType] ([IncomeTypeId], [Name], [Active], [SortOrder], [AllowMultiple]) 
VALUES 
(1, N'Wage', 1, 1, 1)
,(2, N'Child Benefit', 1, 2, 0)
,(3, N'Working Family Tax Credit', 1, 3, 0)
,(4, N'Disability Living Allowance', 0, 4, 0)
,(5, N'Child Tax Credit', 1, 8, 0)
,(6, N'Pension Credits', 1, 9, 0)
,(7, N'Income Support', 1, 10, 0)
,(8, N'Employment Support Allowance', 1, 11, 0)
,(9, N'Private Pension', 1, 12, 1)
,(10, N'State Pension', 1, 13, 0)
,(11, N'Child Maintenance', 1, 14, 1)
,(12, N'Savings', 1, 15, 1)
,(13, N'Job Seekers Allowance', 1, 16, 0)
,(14, N'Statutory Sick Pay', 1, 17, 0)
,(15, N'Statutory Maternity Pay', 1, 18, 0)
,(16, N'Student Loan', 1, 19, 1)
,(17, N'Student Bursary', 1, 20, 1)
,(18, N'Carers Allowance', 1, 5, 0)
,(19, N'Disability Living Allowance (Care)', 1, 6, 0)
,(20, N'Disability Living Allowance (Mobility)', 1, 7, 0)
,(21, N'Leaving Care Income Maintenance', 1, 21, 0)
,(22, N'Personal Independence Payment', 1, 22, 0)
,(23, N'Hardship Payment', 1, 24, 0)
,(24, N'Attendance Allowance', 1, 23, 0)
,(25, N'War Pension', 1, 25, 0)
,(26, N'Universal Credit',1,26,1)
,(27, N'Severe Disability Premium',1,27,1)
,(28, N'Foster Carers Allowance',1,28,1)
,(29, N'Bereavement Allowance',1,29,1)
,(30, N'Industial Injuries Allowance',1,30,1)

SET IDENTITY_INSERT [dbo].[IncomeType] OFF

DELETE FROM [dbo].[VBLSupportTypes]
SET IDENTITY_INSERT [dbo].[VBLSupportTypes] ON
  INSERT [dbo].[VBLSupportTypes]([SupportTypeId],[Name],[Active],[SortOrder],[CreatedDate]) values
 (1, 'Prison Release / Offender Management',1,12,GETDATE()),
(2, 'Budgeting / Financial',1,1,GETDATE()),
(3, 'Care Leaver',1,2,GETDATE()),
(4, 'Child / Family Services',1,3,GETDATE()),
(5, 'Domestic Abuse Service',1,4,GETDATE()),
(6, 'Employment / Training',1,5,GETDATE()),
(7, 'Furniture',1,6,GETDATE()),
(8, 'Learning Disabilities',1,7,GETDATE()),
(9, 'Literacy / Form Completion',1,8,GETDATE()),
(10, 'MAPPA',1,9,GETDATE()),
(11, 'Mental Health',1,10,GETDATE()),
(12, 'Substance / Alcohol Abuse',1,13,GETDATE()),
(13, 'Sustaining / Managing a Tenancy',1,14,GETDATE()),
(14, 'Tenancy Ready / Independent Living',1,15,GETDATE()),
(15, 'Tenancy Set Up / Utilities',1,16,GETDATE()),
(16, 'Under 18years',1,17,GETDATE()),
(17, 'Vulnerabilities / Disabilities',1,18,GETDATE()),
(18, 'Well Being / General Support',1,19,GETDATE()),
(19, 'Other',1,11,GETDATE())
SET IDENTITY_INSERT [dbo].[VBLSupportTypes] OFF

DELETE FROM [VBLSupportProviders]
SET IDENTITY_INSERT [dbo].[VBLSupportProviders] ON
INSERT [dbo].[VBLSupportProviders]([SupportProviderId],[Name],[Active],[SortOrder],[CreatedDate]) values
(1, 'Family Member',1,1,GETDATE()),
(2, 'Friend',1,2,GETDATE()),
(3, 'Support Provider',1,3,GETDATE())
SET IDENTITY_INSERT [dbo].[VBLSupportProviders] OFF
DELETE FROM [ResidencyType]
/****** Object:  Table [dbo].[ResidencyType]    Script Date: 05/09/2016 14:57:37 ******/
SET IDENTITY_INSERT [dbo].[ResidencyType] ON
INSERT [dbo].[ResidencyType] ([ResidencyTypeId], [Name], [Active], [SortOrder]) 
VALUES 
(1, N'Lodge', 1, 1)
,(2, N'Own', 1, 2)
,(3, N'Rent', 1, 3)
,(4, N'NFA', 1, 4)
,(5, N'Live with family / friends', 1, 5)
,(7, N'Temp Accomodation', 1, 7)
,(8, N'Hostel', 1, 6)
,(9, N'Hospital', 1, 9)
,(10, N'Prison', 1, 10)
SET IDENTITY_INSERT [dbo].[ResidencyType] OFF

DELETE FROM [Landlord]
SET IDENTITY_INSERT [dbo].[Landlord] ON
INSERT [dbo].[Landlord] ([LandlordId],[LandlordCode], [Name], [Active], [SortOrder]) 
VALUES 
(1, N'Incomm', N'Incommunities', 1, 1)
,(2, N'Accent', N'Accent', 1, 2)
,(3, N'ManHou',N'Manningham Housing Association', 1, 3)
,(4, N'LetAge', N'Letting Agent', 1, 8)
,(5, N'PriLan', N'Private Landlord', 1, 9)
,(6, N'YouHou', N'Your Housing Group', 1, 4)
,(7, N'Horton', N'Horton Housing', 1, 5)
,(8, N'BCCP', N'BCCP', 0, 6)
,(9, N'BraCyr', N'Bradford Cyrenians', 1, 7)
,(10, N'Abbeyfied', N'Abbeyfield', 1,10)
,(11, N'AccFou', N'Accent Foundation', 1, 11)
,(12, N'AnchorHousing', N'Anchor Retirement Housing', 1, 12)
,(13, N'EquityGroup', N'Equity Housing Group', 1, 13)
,(14, N'HabintegHousing', N'Habinteg Housing Group', 1,14)
,(15, N'HanoverHousing', N'Hanover Housing Association', 1, 15)
,(16, N'HomeGroup', N'Home Group', 1, 16)
,(17, N'Housing21', N'Housing 21', 1, 17)
,(18, N'SHHG', N'Stonewater Housing Association Group', 1,18)
,(19, N'LocAuth', N'Local Authority', 1, 19)
,(20, N'Nashayman', N'Nahayman', 0, 20)
,(21, N'OHousAss', N'Other Housing Association', 1, 21)
,(22, N'PlacesPeople', N'Places For People', 1,22)
,(23, N'RiversideGroup', N'Riverside Group', 1, 24)
,(24, N'SanctuaryHousing', N'Sanctuary Housing Association', 1, 25)
,(25, N'WilliamTrust', N'Affinity Sutton Trust (William Sutton)', 1, 26)
,(26, N'YorkshireHousing', N'Yorkshire Housing', 1, 27)
SET IDENTITY_INSERT [dbo].[Landlord] OFF

DELETE FROM [MoveReason]
/****** Object:  Table [dbo].[MoveReason]    Script Date: 05/09/2016 15:46:53 ******/
SET IDENTITY_INSERT [dbo].[MoveReason] ON
INSERT [dbo].[MoveReason] ([MoveReasonId], [Name], [Active], [SortOrder], [LevelOfNeedID], [ReferToHousingsOptionsOfficer], [ReferToNeighbourhoodOfficer]) 
VALUES 
(1, N'Emergency - Fire, Flood, Crime Scene etc.', 1, 1, 1, 1, 1)
,(2, N'Violence - Inside Home', 1, 2, 2, 1, 1)
,(3, N'Violence - Outside Home', 1, 3, 2, 1, 1)
,(4, N'Sale of Property by other person / landlord', 1, 4, 2, 1, 0)
,(5, N'Decants ', 1, 5, 1, 0, 1)
,(6, N'Roofless', 1, 6, 2, 1, 0)
,(7, N'Released Prisoner Inc. MAPPA', 1, 7, 3, 1, 0)
,(8, N'Relationship Breakdown', 1, 8, 3, 1, 1)
,(9, N'Racial Harassment', 1, 9, 2, 1, 1)
,(10, N'Possession Order', 1, 10, 2, 1, 0)
,(11, N'Overcrowded', 1, 11, 2, 1, 1)
,(12, N'Nuisance / Harassment', 1, 12, 2, 1, 1)
,(13, N'NTQ (inc. Abandoned Notice)', 1, 99, 2, 1, 1)
,(14, N'Mortgage Arrears / Possession Order', 1, 0, 2, 1, 0)
,(15, N'Loss or Eviction from Supported Accommodation, TA', 1, 0, 2, 1, 0)
,(16, N'Independent Living', 1, 0, 2, 1, 0)
,(17, N'Illegal Eviction', 1, 0, 2, 1, 0)
,(18, N'Hospital Discharge', 1, 0, 2, 1, 1)
,(19, N'HM Forces Release', 1, 0, 1, 1, 0)
,(20, N'Family / Friends Breakdown', 1, 0, 3, 1, 1)
,(21, N'Medical - Able Living', 1, 0, 3, 1, 1)
,(22, N'Disrepair', 1, 0, 3, 1, 0)
,(23, N'Bankruptcy', 1, 0, 2, 1, 1)
,(24, N'Asylum / Habitual Residency', 1, 0, 3, 1, 0)
,(25, N'Underoccupancy', 1, 0, 1, 1, 1)
,(26, N'Affordability', 1, 0, 2, 1, 1)
,(27, N'Death of owner / tenant and no right to succeed', 1, 0, 2, 1, 1)
,(28, N'Referral from other LA - S.198 & S. 213', 1, 0, 2, 1, 0)
,(29, N'Living in a Caravan with no pitch', 1, 0, 3, 1, 0)
,(30, N'Living in a Tent', 1, 0, 3, 1, 0)
,(31, N'Want to move only', 1, 0, 3, 0, 1)
,(32, N'Employment', 1, 0, 3, 0, 1)
,(33, N'MigrationError', 0, 999, 99, 0, 0)
,(34, N'To move nearer family / friends', 1, 0, 3, 0, 1)
,(35, N'Care Leaver',1,0,3,0,1)
SET IDENTITY_INSERT [dbo].[MoveReason] OFF
DELETE FROM [AgeRestrictions]
SET IDENTITY_INSERT [dbo].[AgeRestrictions] ON
INSERT [dbo].[AgeRestrictions]([AgeRestrictionId],[Name],[Active],[SortOrder]) values
(1, '18+',0,1),
(2, '55+',1,2),
(3, '65+',1,3)
SET IDENTITY_INSERT [dbo].[AgeRestrictions] OFF
DELETE FROM [Adaptations]
SET IDENTITY_INSERT [dbo].[Adaptations] ON
INSERT [dbo].[Adaptations]([AdaptationId],[Name],[Active],[SortOrder]) values
(1, 'Wheelchair Adapted',1,1),
(2, 'Partially Adapted',1,2)
SET IDENTITY_INSERT [dbo].[Adaptations] OFF


  DELETE FROM [Allocations].[dbo].[NotInterestedReasons]
  SET IDENTITY_INSERT [Allocations].[dbo].[NotInterestedReasons] ON 
  INSERT INTO [Allocations].[dbo].[NotInterestedReasons]([NotInterestedReasonId]
      ,[Name]
      ,[Active]
      ,[SortOrder]) VALUES(1
      ,'Area'
      ,1
      ,1),(2
      ,'Matched in Error'
      ,1
      ,2),(3
      ,'Floor Level'
      ,1
      ,3),(4
      ,'Garden'
      ,1
      ,4),(5
      ,'Has a pet and unwilling to rehome'
      ,1
      ,5),(6
      ,'Location - ASB'
      ,1
      ,6),(7
      ,'Location - Environmental Appearance'
      ,1
      ,7),(8
      ,'Location- Facilities'
      ,1
      ,8),(9
      ,'Location - Wants area but not this street'
      ,1
      ,9),(10
      ,'Lack of Adaptations'
      ,1
      ,10),(11
      ,'Property Size'
      ,1
      ,11),(12
      ,'Property Type'
      ,1
      ,12),(13
      ,'Room sizes'
      ,1
      ,13),(14
      ,'Steps - External Access'
      ,1
      ,14),(15
      ,'Steps - Within the property'
      ,1
      ,15),(16
      ,'Don''t want this landlord'
      ,1
      ,16),(17
      ,'Entrance Type'
      ,1
      ,17)


  
  SET IDENTITY_INSERT [Allocations].[dbo].[NotInterestedReasons] OFF
   DELETE FROM [Allocations].[dbo].[ApplicationCloseReasons]
SET IDENTITY_INSERT [dbo].[ApplicationCloseReasons] ON
 INSERT INTO [Allocations].[dbo].[ApplicationCloseReasons]([ApplicationCloseReasonId],[Name],[Active],[SortOrder]) VALUES
 (1,'Applicant Deceased',1,1),
 (2,'Customer has found other accomodation - other RSL',1,2),
 (3,'Customer has found other accomodation - Private Landlord',1,3),
 (4,'Duplicate Application ',1,4),
 (5,'Mutual Exchange',1,5),
 (6,'No Contact - Notification sent to customer',1,6),
 (7,'No longer wants to be rehoused',1,7),
 (8,'Other',1,8)
SET IDENTITY_INSERT [dbo].[ApplicationCloseReasons] OFF
