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
    public class ActionsController : BaseController
    {
        /// <summary>
        /// </summary>
        private readonly IActionBLL _actionBll;

        /// <summary>
        /// </summary>
        private readonly IActionCategoryBLL _actionCategoryBll;

        /// <summary>
        /// </summary>
        private readonly IActionResponsibilityBLL _actionResponsibilityBll;

        /// <summary>
        /// </summary>
        private readonly IActionTypeBLL _actionTypeBll;

        public ActionsController() : this(new ActionBLL(new UnitOfWork()), new ActionCategoryBLL(new UnitOfWork()), new ActionResponsibilityBLL(new UnitOfWork()), new ActionTypeBLL(new UnitOfWork()))
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="actionBll"></param>
        /// <param name="actionCategoryBll"></param>
        /// <param name="actionResponsibilityBll"></param>
        /// <param name="actionTypeBll"></param>
        public ActionsController(
            IActionBLL actionBll,
            IActionCategoryBLL actionCategoryBll,
            IActionResponsibilityBLL actionResponsibilityBll,
            IActionTypeBLL actionTypeBll)
        {
            _actionBll = actionBll;
            _actionCategoryBll = actionCategoryBll;
            _actionResponsibilityBll = actionResponsibilityBll;
            _actionTypeBll = actionTypeBll;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Actions/GetActionCategories")]
        public HttpResponseMessage GetActionCategories()
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var actionCategories = _actionCategoryBll.GetActionCategories();

            var jsonResult = JsonConvert.SerializeObject(actionCategories);

            message.Content = new StringContent(jsonResult);

            return message;

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Actions/GetActionResponsibilities")]
        public HttpResponseMessage GetActionResponsibilities()
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var actionResponsibilities = _actionResponsibilityBll.GetActionResponsibilities();

            var jsonResult = JsonConvert.SerializeObject(actionResponsibilities);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Actions/GetActionTypes")]
        public HttpResponseMessage GetActionTypes()
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var actionTypes = _actionTypeBll.GetActionTypes();

            var jsonResult = JsonConvert.SerializeObject(actionTypes);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Actions/GetActionsByContactId")]
        public HttpResponseMessage GetActionsByContactId(int contactId)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var actions = _actionBll.GetActionsByContactId(contactId);

            var jsonResult = JsonConvert.SerializeObject(actions);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Actions/GetPageOfActionsByContactIdDisplayTabPage")]
        public HttpResponseMessage GetPageOfActionsByContactIdDisplayTabPage(int contactId, string displayTabPage, int currentPage,int pageSize)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var pageOfActions = _actionBll.GetPageOfActionsByContactIdDisplayTabPage(contactId,displayTabPage, currentPage, pageSize);

            var jsonResult = JsonConvert.SerializeObject(pageOfActions);

            message.Content = new StringContent(jsonResult);

            return message;
        }


        /// <summary>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Actions/GetPageOfActionsByContactId")]
        public HttpResponseMessage GetPageOfActionsByContactId(int contactId, int currentPage, int pageSize)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var pageOfActions = _actionBll.GetPageOfActionsByContactId(contactId, currentPage, pageSize);

            var jsonResult = JsonConvert.SerializeObject(pageOfActions);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Actions/GetAction")]
        public HttpResponseMessage GetAction(int id)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var action = _actionBll.GetAction(id);

            var jsonResult = JsonConvert.SerializeObject(action);

            message.Content = new StringContent(jsonResult);

            return message;
        }

        /// <summary>
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Actions/Post")]
        public HttpResponseMessage Post(SuitabilityCheckActionDTO action)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK);

            var actionToSave = Mapper.Map<SuitabilityCheckAction>(action);

            try
            {
                var result = _actionBll.SaveAction(actionToSave);
                if (result)
                {
                    message.Content = new StringContent("Save Successful");
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
