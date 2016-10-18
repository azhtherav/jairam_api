namespace TruckApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using TruckApi.Core;

    public class FileUploadController : ApiController
    {
        public HttpResponseMessage Post()
        {
            try
            {

                var reponseheader = Request;
                var header = reponseheader.Headers;
                string filename = string.Empty;

                if (header.Contains("filename"))
                {
                    filename = header.GetValues("filename").First();
                }
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                    if (httpPostedFile != null)
                    {
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/"), filename + ".png");
                        FileInfo file = new FileInfo(fileSavePath);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                        httpPostedFile.SaveAs(fileSavePath);
                        string addlogo = filename + ".png";
                        string[] filearray = filename.Split('@');
                        if (filearray[0].Equals("RC"))
                        {
                            DbAccess.DbAInsert("UPDATE lorry SET rc='" + addlogo + "' WHERE lorryno='" + filearray[1] + "'");
                        }
                        else if (filearray[0].Equals("Insurance"))
                        {
                            DbAccess.DbAInsert("UPDATE lorry SET ins='" + addlogo + "' WHERE lorryno='" + filearray[1] + "'");
                        }
                        else if (filearray[0].Equals("LorryImage"))
                        {
                            DbAccess.DbAInsert("UPDATE lorry SET lorryimage='" + addlogo + "' WHERE lorryno='" + filearray[1] + "'");
                        }
                        return Request.CreateResponse(HttpStatusCode.Created, addlogo);
                    }

                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch
            {
                throw;
            }
        }
    }
}
