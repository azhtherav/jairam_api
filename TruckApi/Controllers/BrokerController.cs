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

    public class BrokerController : ApiController
    {

        private AdminUserValidation objSdminUserValidation = new AdminUserValidation();
        private BrokerAccess objBrokerAccess = new BrokerAccess();

        [HttpGet]
        [ActionName("getallbroker")]
        public HttpResponseMessage GetBrokerUser()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBrokerAccess.GetAllBroker());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("getbrokerbysearch")]
        public HttpResponseMessage GetBrokerBySearch([FromBody]Broker objBroker)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBrokerAccess.GetBrokerBySearch(objBroker));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("addbroker")]
        public HttpResponseMessage AddBroker([FromBody]Broker objBroker)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBrokerAccess.AddBroker(objBroker));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editbroker")]
        public HttpResponseMessage Editbroker([FromBody]Broker objBroker)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBrokerAccess.EditBroker(objBroker));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("deletebroker")]
        public HttpResponseMessage Deletebroker([FromBody]Broker objBroker)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBrokerAccess.DeleteBroker(objBroker));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

    }
}