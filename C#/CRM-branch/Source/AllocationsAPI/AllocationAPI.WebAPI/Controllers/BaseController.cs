using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using InCoreLib.DAL;
using InCoreLib.Domain.Allocations.Database;
using InCoreLib.Domain.Allocations.Enumerations;

// Note : Never ever declare any method as public in this class otherwise the Services will fail to respond.

namespace AllocationsAPI.WebAPI.Controllers
{
    public class BaseController : ApiController, IDisposable
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseController() : this(new UnitOfWork())
        {
        }

        protected BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        
        protected new virtual void Dispose()
        {
            base.Dispose();
            UnitOfWork?.Dispose();
        }
    }
}