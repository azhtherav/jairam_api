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
    public class AssignController : ApiController
    {
        private AdminUserValidation objSdminUserValidation = new AdminUserValidation();
        private AssignAccess objAssignAccess = new AssignAccess();

        [HttpGet]
        [ActionName("getallassign")]
        public HttpResponseMessage GetAllAssign()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objAssignAccess.GetAllAssign());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("getassignbysearch")]
        public HttpResponseMessage GetAssignBySearch([FromBody]Assign objAssign)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objAssignAccess.GetAssignBySearch(objAssign));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("addassign")]
        public HttpResponseMessage AddAssign([FromBody]Assign objAssign)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objAssignAccess.AddAssign(objAssign));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editassign")]
        public HttpResponseMessage EditAssign([FromBody]Assign objAssign)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objAssignAccess.EditAssign(objAssign));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        ////[HttpPost]
        ////[ActionName("deleteassign")]
        ////public HttpResponseMessage DeleteUser([FromBody]Assign objAssign)
        ////{
        ////    if (this.objSdminUserValidation.ValidateUserName(Request))
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.OK, objAssignAccess.DeleteUser(objAssign.assignid));
        ////    }
        ////    else
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.Unauthorized);
        ////    }
        ////}
    }
}
