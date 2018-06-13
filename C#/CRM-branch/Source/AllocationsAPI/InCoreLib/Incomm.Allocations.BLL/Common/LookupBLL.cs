using System.Collections.Generic;
using System.Linq;
using Incomm.Allocations.BLL.CRM.ApiClient;
using Incomm.Allocations.BLL.Interfaces.Common;
using Incomm.Allocations.BLL.Interfaces.CRM.ApiClient;
using Incomm.Allocations.DTO.CRM;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Database.VBL;

namespace Incomm.Allocations.BLL.Common
{
    public class LookupBLL : ILookupBll
    {
        private readonly ILookupApiClient _lookupApiClient;
        private readonly IUnitOfWork _unitOfWork;
        public LookupBLL() : this(new UnitOfWork(),new LookupApiClient())
        {
        }

        public LookupBLL(IUnitOfWork unitOfWork, ILookupApiClient lookupApiClient)
        {
            _unitOfWork = unitOfWork;
            _lookupApiClient = lookupApiClient;
        }

        public CRMLookup GetCRMLookup()
        {
            return _lookupApiClient.GetCRMLookup();
        }

        public Lookup GetLookup(int appId)
        {
            string applicantName = "New Applicant";
            if (appId > 0)
            {
                var mainApplicant = _unitOfWork.VBLContacts().Select().First(x => x.ApplicationId == appId && x.ContactTypeId == 1);
                var person = _unitOfWork.SearchContacts().Select()
                    .FirstOrDefault(x => x.ContactId == mainApplicant.ContactId);
                applicantName = person.Forename + " " + person.Surname;

            }
            var crmLookup = GetCRMLookup();
            var lookup = new Lookup
            {
                CustomerInterestStatus =
                    _unitOfWork.CustomerInterestStatus().Select().Where(x => x.Active).ToList(),
                DisabilityTypes = _unitOfWork.DisabilityTypes().Select().Where(x => x.Active).ToList(),
                // Genders = _unitOfWork.Genders().Select().Where(x => x.Active).ToList(),
                // Titles = _unitOfWork.Titles().Select().Where(x => x.Active).ToList(),
                ContactBys = _unitOfWork.ContactBy().Select().Where(x => x.Active).ToList(),
                // Ethnicities = _unitOfWork.Ethnicities().Select().Where(x => x.Active).ToList(),
                // Languages = _unitOfWork.PreferredLanguages().Select().Where(x => x.Active).ToList(),
                // Nationalities = _unitOfWork.NationalityTypes().Select().Where(x => x.Active).ToList(),
                IncomeTypes = _unitOfWork.IncomeTypes().Select().Where(x => x.Active).ToList(),
                IncomeFrequencies = _unitOfWork.IncomeFrequencies().Select().Where(x => x.Active).ToList(),
                RequiredSupports = _unitOfWork.VBLSupportTypes().Select().Where(x => x.Active).ToList(),
                MainApplicantName = applicantName,
                ResidencyTypes = _unitOfWork.ResidencyTypes().Select().Where(x => x.Active).ToList(),
                Landlords = _unitOfWork.Landlords().Select().Where(x => x.Active).ToList(),
                TenancyTypes = _unitOfWork.TenancyTypes().Select().Where(x => x.Active).ToList(),
                PropertyTypes = _unitOfWork.PropertyTypes().Select().Where(x => x.Active).ToList(),
                MoveReasons = _unitOfWork.MoveReasons().Select().Where(x => x.Active).ToList(),
                LevelOfNeeds = _unitOfWork.LeveOfNeeds().Select().Where(x => x.Active).ToList(),
                PropertySize = _unitOfWork.PropertySize().Select().ToList(),
                PropertyEntrances = _unitOfWork.PropertyEntranceTypes().Select().ToList(),
                BlockTypes = _unitOfWork.PropertyBlockTypes().Select().ToList(),
                AgeRestrictions = _unitOfWork.AgeRestrictions().Select().ToList(),
                Adaptations = _unitOfWork.Adaptations().Select().ToList(),
                HeatingTypes = _unitOfWork.HeatingTypes().Select().ToList(),
                Relationships = _unitOfWork.Relationships().Select().ToList(),
                ApplicationCloseReasons = _unitOfWork.ApplicationCloseReasons().Select().Where(x => x.Active).ToList(),
                NotInterestedReasons = _unitOfWork.NotInterestedReasons().Select().Where(x => x.Active).ToList(),
                Genders = crmLookup.Genders.Where(x => x.IsActive).ToList(),
                Titles = crmLookup.Titles.Where(x => x.IsActive).ToList(),
                Ethnicities = crmLookup.Ethnicities.Where(x => x.IsActive).ToList(),
                Languages = crmLookup.Languages.Where(x => x.IsActive).ToList(),
                Nationalities = crmLookup.Nationalities.Where(x => x.IsActive).ToList()
            };

            return lookup;
        }

        public List<VBLSupportType> GetSupportTypes()
        {
            return _unitOfWork
                .VBLSupportTypes()
                .Select(sp => sp.Active)
                .OrderBy(sp => sp.SortOrder)
                .ToList();
        }

        public List<VBLSupportProvider> GetSupportProviders()
        {
            return _unitOfWork
                .VBLSupportProviders()
                .Select(sp => sp.Active)
                .OrderBy(sp => sp.SortOrder)
                .ToList();
        }

        public List<Title> GetTitles()
        {
            return _unitOfWork
                .Titles()
                .Select(sp => sp.Active)
                .OrderBy(sp => sp.SortOrder)
                .ToList();
        }

        public List<Gender> GetGenders()
        {
            return _unitOfWork
                .Genders()
                .Select(sp => sp.Active)
                .OrderBy(sp => sp.SortOrder)
                .ToList();
        }

        public List<SuitabilityNoteType> GetSuitabilityNoteTypes(bool onlyActive)
        {
            return _unitOfWork
                .SuitabilityNoteTypes()
                .Select(sp => sp.IsActive)
                .ToList();
        }
    }
}