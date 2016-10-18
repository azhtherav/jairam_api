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
    public class CommissionController : ApiController
    {
        private AdminUserValidation objSdminUserValidation = new AdminUserValidation();
        private CommissionAccess objCommissionAccess = new CommissionAccess();

        [HttpGet]
        [ActionName("getallcommission")]
        public HttpResponseMessage GetAllCommission()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetAllCommission());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getalltoopay")]
        public HttpResponseMessage GetAllTooPay()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetAllTooPay());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getalladvancepay")]
        public HttpResponseMessage GetAllAdvancePay()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetAllAdvancePay());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("getcommissionbysearch")]
        public HttpResponseMessage GetCommissionBySearch([FromBody]Commission objCommission)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetCommissionBySearch(objCommission));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        
        [HttpPost]
        [ActionName("addcommission")]
        public HttpResponseMessage AddCommission([FromBody]Commission objCommission)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.AddCommission(objCommission));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }


        [HttpPost]
        [ActionName("edittoopaycommission")]
        public HttpResponseMessage EditTooPayCommission([FromBody]Commission objCommission)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.EditTooPayCommission(objCommission));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpPost]
        [ActionName("editadvancepaycommission")]
        public HttpResponseMessage EditAdvancePayCommission([FromBody]Commission objCommission)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.EditAdvancePayCommission(objCommission));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }


        [HttpGet] 
        [ActionName("getnotackcommission")]
        public HttpResponseMessage GetNotAckCommission()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetNotAckCommission());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getbalancereceiveddatecommission")]
        public HttpResponseMessage GetBalanceReceivedDateCommission()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetBalanceReceivedDateCommission());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getallopencommission")]
        public HttpResponseMessage GetAllOpenCommission()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetAllOpenCommission());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getbalanceerrorcommission")]
        public HttpResponseMessage GetBalanceErrorCommission()
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetBalanceErrorCommission());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        [HttpGet]
        [ActionName("getsinglecommission")]
        public HttpResponseMessage GetSingleCommission(string commissionid)
        {
            if (this.objSdminUserValidation.ValidateUserName(Request))
            {
                return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.GetSingleCommission(int.Parse(commissionid)));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }


        //[HttpPost]
        //[ActionName("editcommission")]
        //public HttpResponseMessage EditCommission([FromBody]Commission objCommission)
        //{
        //    if (this.objSdminUserValidation.ValidateUserName(Request))
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.EditCommission(objCommission));
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //    }
        //}

        ////[HttpPost]
        ////[ActionName("deletecommission")]
        ////public HttpResponseMessage DeleteUser([FromBody]Commission objCommission)
        ////{
        ////    if (this.objSdminUserValidation.ValidateUserName(Request))
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.OK, objCommissionAccess.DeleteUser(objCommission.commissionid));
        ////    }
        ////    else
        ////    {
        ////        return Request.CreateResponse(HttpStatusCode.Unauthorized);
        ////    }
        ////}
    }
}
