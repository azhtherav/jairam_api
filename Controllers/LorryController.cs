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

    public class LorryController : ApiController
    {
        private AdminUserValidation objSdminUserValidation = new AdminUserValidation();
        private LorryAccess objLorryAccess = new LorryAccess();

        [HttpGet]
        [ActionName("getalllorry")]
        public HttpResponseMessage GetAllLorry()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.GetAllLorry());
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
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.GetAllNotes());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getallloadnotes")]
        public HttpResponseMessage GetAllLoadNotes()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.GetAllLoadNotes());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getalltodaynotes")]
        public HttpResponseMessage GetAllTodayNotes()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.GetAllTodayNotes());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getalltodayloadnotes")]
        public HttpResponseMessage GetAllTodayLoadNotes()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.GetAllTodayLoadNotes());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("getlorrybysearch")]
        public HttpResponseMessage GetLorryBySearch([FromBody]Lorry objLorry)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.GetLorryBySearch(objLorry));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }


        [HttpPost]
        [ActionName("addnotes")]
        public HttpResponseMessage AddNotes([FromBody]Notes objNotes)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.AddNotes(objNotes));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("addloadnotes")]
        public HttpResponseMessage AddLoadNotes([FromBody]LoadNote objLoadNotes)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.AddLoadNotes(objLoadNotes));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }




        [HttpPost]
        [ActionName("addlorry")]
        public HttpResponseMessage AddLorry([FromBody]Lorry objLorry)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.AddLorry(objLorry));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editlorry")]
        public HttpResponseMessage EditLorry([FromBody]Lorry objLorry)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.EditLorry(objLorry));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editrclorry")]
        public HttpResponseMessage EditRcLorry([FromBody]Lorry objLorry)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.RcLorry(objLorry));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editinslorry")]
        public HttpResponseMessage EditIncLorry([FromBody]Lorry objLorry)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.InsLorry(objLorry));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editimagelorry")]
        public HttpResponseMessage EditImageLorry([FromBody]Lorry objLorry)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.imageLorry(objLorry));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("deletelorry")]
        public HttpResponseMessage DeleteUser([FromBody]Lorry objLorry)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objLorryAccess.DeleteUser(objLorry.lorryno));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}
