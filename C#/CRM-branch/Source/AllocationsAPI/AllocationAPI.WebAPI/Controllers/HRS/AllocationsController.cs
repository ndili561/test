using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using InCoreLib.DAL;

namespace AllocationsAPI.WebAPI.Controllers.HRS
{
    /// <summary>
    /// </summary>
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/HRS")]
    public class AllocationsController : ApiController
    {
        /// <summary>
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// </summary>
        public AllocationsController() : this(new UnitOfWork())
        {
        }


        /// <summary>
        /// </summary>
        /// <param name="unitOfWork"></param>
        public AllocationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<GenderDto> Genders()
        {
            var result = _unitOfWork.Genders().Select();
            var result2 = Mapper.Map<List<GenderDto>>(result.ToList());
            return result2;
        }
    }
}