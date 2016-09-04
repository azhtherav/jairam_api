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

    public class LoadController : ApiController
    {
        private AdminUserValidation objSdminUserValidation = new AdminUserValidation();
        private LoadAccess objLoadAccess = new LoadAccess();

        [HttpGet]
        [ActionName("getallload")]
        public HttpResponseMessage GetAllLoad()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLoadAccess.GetAllLoad());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("getloadbysearch")]
        public HttpResponseMessage GetLoadBySearch([FromBody]Load objLoad)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLoadAccess.GetLoadBySearch(objLoad));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }


        [HttpGet]
        [ActionName("getallnotes")]
        public HttpResponseMessage GetAllNotes()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLoadAccess.GetAllNotes());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("addload")]
        public HttpResponseMessage AddLoad([FromBody]Load objLoad)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLoadAccess.AddLoad(objLoad));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("addnotes")]
        public HttpResponseMessage AddNotes([FromBody]LoadNote objNotes)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLoadAccess.AddNotes(objNotes));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editload")]
        public HttpResponseMessage EditLoad([FromBody]Load objLoad)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLoadAccess.EditLoad(objLoad));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        ////[HttpPost]
        ////[ActionName("deleteload")]
        ////public HttpResponseMessage DeleteUser([FromBody]Load objLoad)
        ////{
        ////    if (this.objSdminUserValidation.ValidateUserName(Request))
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.OK, objLoadAccess.DeleteUser(objLoad.loadid));
        ////    }
        ////    else
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.Unauthorized);
        ////    }
        ////}
    }
}
