using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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

            HttpClient httpsClient = new HttpClient();
            httpsClient.BaseAddress = new Uri(String.Format("https://{0}", site));

            try
            {
                var result = httpsClient.GetAsync("/").Result;

                var response = new
                {
                    url = site,
                    headers = result.Headers,
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
