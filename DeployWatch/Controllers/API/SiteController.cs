using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Security;
using System.Web.Http;



namespace DeployWatch.Controllers.API
{
    public class SiteController : ApiController
    {
        public SiteController()
        {
        }

        [Route("site/{site}/")]
        public HttpResponseMessage Get(string site)
        {
            try
            {
                var client = new RequestClient(site);
                var result = client.GetResult();

                var response = new
                {
                    url = site,
                    headers = result.Headers,
                    certificate = new
                    {
                        expiration = client.CertificateExpiration
                    },
                    status = "OK"
                };
                

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                var response = new
                {
                    url = site,
                    status = "FAIL"
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
