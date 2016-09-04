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

    public class UserController : ApiController
    {

        private AdminUserValidation objSdminUserValidation = new AdminUserValidation();
        private UserAccess objUserAccess = new UserAccess();

        [HttpGet]
        [ActionName("getalluser")]
        public HttpResponseMessage GetAllUser()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetAllUser());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("getuserbysearch")]
        public HttpResponseMessage GetUserBySearch([FromBody]User objUser)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetUserBySearch(objUser));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("adduser")]
        public HttpResponseMessage AddUser([FromBody]User objUser)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.AddUser(objUser));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("edituser")]
        public HttpResponseMessage EditUser([FromBody]User objUser)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.EditUser(objUser));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        ////[HttpPost]
        ////[ActionName("deleteuser")]
        ////public HttpResponseMessage DeleteUser([FromBody]User objUser)
        ////{
        ////    if (this.objSdminUserValidation.ValidateUserName(Request))
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.DeleteUser(objUser.UserId));
        ////    }
        ////    else
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.Unauthorized);
        ////    }
        ////}
    }
}