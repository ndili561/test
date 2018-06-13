using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Incomm.Allocations.BLL.Interfaces.VBL;
using Incomm.Allocations.BLL.VBL;
using Incomm.Allocations.DTO;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using Newtonsoft.Json;

namespace AllocationsAPI.WebAPI.Controllers.VBL
{
    /// <summary>
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/VBL")]
    public class RisksController : BaseController
    {
        /// <summary>
        /// </summary>
        private readonly IRiskBLL _riskBll;

        /// <summary>
        /// </summary>
        private readonly IRiskCategoryBLL _riskCategoryBll;

        /// <summary>
        /// </summary>
        private readonly IRiskThemeBLL _riskThemeBll;


        public RisksController() : this(new RiskBLL(new UnitOfWork()), new RiskCategoryBLL(new UnitOfWork()), new RiskThemeBLL(new UnitOfWork()))
        {

        }


        /// <summary>
        /// </summary>
        /// <param name="riskBll"></param>
        /// <param name="riskCategoryBll"></param>
        /// <param name="riskThemeBll"></param>
        public RisksController(
            IRiskBLL riskBll,
            IRiskCategoryBLL riskCategoryBll,
            IRiskThemeBLL riskThemeBll)
        {
            _riskBll = riskBll;
            _riskCategoryBll = riskCategoryBll;
            _riskThemeBll = riskThemeBll;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Risks/GetRiskCategories")]
        public HttpResponseMessage GetRiskCategories()
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var riskCategories = _riskCategoryBll.GetRiskCategories();

            var jsonResult = JsonConvert.SerializeObject(riskCategories);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Risks/GetRiskThemes")]
        public HttpResponseMessage GetRiskThemes()
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var riskThemes = _riskThemeBll.GetRiskThemes();

            var jsonResult = JsonConvert.SerializeObject(riskThemes);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Risks/GetRisksByContactId")]
        public HttpResponseMessage GetRisksByContactId(int contactId)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var risks = _riskBll.GetRisksByContactId(contactId);

            var jsonResult = JsonConvert.SerializeObject(risks);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Risks/GetPageOfRisksByContactId")]
        public HttpResponseMessage GetPageOfRisksByContactId(int contactId, int currentPage, int pageSize)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var risks = _riskBll.GetPageOfRisksByContactId(contactId, currentPage, pageSize);

            var jsonResult = JsonConvert.SerializeObject(risks);

            message.Content = new StringContent(jsonResult);

            return message;
        }
        


        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Risks/GetPageOfRisksByContactIdDisplayTabName")]
        public HttpResponseMessage GetPageOfRisksByContactIdDisplayTabName(int contactId,string displayTabName ,int currentPage, int pageSize)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var risks = _riskBll.GetPageOfRisksByContactIdDisplayTabName(contactId, displayTabName, currentPage, pageSize);

            var jsonResult = JsonConvert.SerializeObject(risks);

            message.Content = new StringContent(jsonResult);

            return message;
        }
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Risks/GetRisk")]
        public HttpResponseMessage GetRisk(int id)
        {
            var message = new HttpResponseMessage();

            var risk = _riskBll.GetRisk(id);

            var jsonResult = JsonConvert.SerializeObject(risk);

            message.Content = new StringContent(jsonResult);

            return message;
        }



        /// <summary>
        /// </summary>
        /// <param name="risk"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Risks/Post")]
        public HttpResponseMessage Post(SuitabilityCheckRiskDTO risk)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var riskToSave = Mapper.Map<SuitabilityCheckRisk>(risk);

            try
            {
                var result = _riskBll.SaveRisk(riskToSave);
                if (result)
                {
                    message.Content = new StringContent("Save successful");
                }
                else
                {
                    message.StatusCode = HttpStatusCode.BadRequest;
                    message.Content = new StringContent("Save unsuccessful, please see underlying messages.");
                }
            }
            catch (Exception ex)
            {
                message.StatusCode = HttpStatusCode.ExpectationFailed;
                message.Content = new StringContent(ex.Message);
            }

            return message;
        }
    }
}
