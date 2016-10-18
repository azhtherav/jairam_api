namespace TruckApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using TruckApi.DataAccess;
    using TruckApi.Helper;
    using TruckApi.Models;

    public class DriverController : ApiController
    {
        private AdminUserValidation objSdminUserValidation = new AdminUserValidation();
        private DriverAccess objDriverAccess = new DriverAccess();

        [HttpGet]
        [ActionName("getalldriver")]
        public HttpResponseMessage GetAllDriver()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objDriverAccess.GetAllDriver());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("getdriverbysearch")]
        public HttpResponseMessage GetDriverBySearch([FromBody]Driver objDriver)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objDriverAccess.GetDriverBySearch(objDriver));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("adddriver")]
        public HttpResponseMessage AddDriver([FromBody]Driver objDriver)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objDriverAccess.AddDriver(objDriver));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editdriver")]
        public HttpResponseMessage EditDriver([FromBody]Driver objDriver)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objDriverAccess.EditDriver(objDriver));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        ////[HttpPost]
        ////[ActionName("deletedriver")]
        ////public HttpResponseMessage DeleteUser([FromBody]Driver objDriver)
        ////{
        ////    if (this.objSdminUserValidation.ValidateUserName(Request))
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.OK, objDriverAccess.DeleteUser(objDriver.driverid));
        ////    }
        ////    else
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.Unauthorized);
        ////    }
        ////}
    }
}
