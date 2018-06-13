using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http.OData.Query;
using AutoMapper;
using Incomm.Allocations.BLL.DTOs;
using Incomm.Allocations.BLL.Interfaces.VBL;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database.VBL;
using Newtonsoft.Json;

namespace Incomm.Allocations.BLL.VBL
{
    public class PropertyNeighbourhoodBLL : IPropertyNeighbourhoodBLL
    {

        private IUnitOfWork _unitOfWork;
        public PropertyNeighbourhoodBLL() : this(new UnitOfWork())
        {
        }

        public PropertyNeighbourhoodBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<VBLPropertyNeighbourhood> GetPropertyNeighbourhoods(ODataQueryOptions<VBLPropertyNeighbourhood> options)
        {
            var propertyNeighbourhoods =
               options.ApplyTo(_unitOfWork.VBLPropertyNeighbourhoods().Select2(x => true, includeProperties: i =>
                       new
                       {
                           i.PropertyPostcodes,
                           i.PropertyWard
                       })
               .AsNoTracking()
               .AsQueryable());
            return Mapper.Map<List<VBLPropertyNeighbourhood>>(propertyNeighbourhoods);
        }
        public int GetPropertyNeighbourhoodIdForPostcode(string Postcode)
        {
            var neighbourhood = _unitOfWork.VBLPropertyPostCodes().Select().First(x => x.Postcode == Postcode);
            return neighbourhood?.NeighbourhoodId ?? 0;

        }

        public List<decimal> GetLongLatForPostCode(string Postcode)
        {
            string urlPrefix = ConfigurationManager.AppSettings["Gateway_WebApiUrl"];
            var url = urlPrefix + "/PropertyMatch/GetLatLongForPostcode?postCode=" + Postcode;

            using (var httpClient = new HttpClient())
            {
                try
                {

                    var result = httpClient.GetStringAsync(url).Result;
                    var listresult = JsonConvert.DeserializeObject<List<decimal>>(result);
                    
                    return listresult;
                }
                catch (Exception ex)
                {
                    //LogErrorMessage(ex);
                    throw;
                }
            }
        }
    }
}