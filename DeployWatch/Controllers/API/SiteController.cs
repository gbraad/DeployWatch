using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DeployWatch.Controllers.API
{
    public class SiteController : ApiController
    {
        //private readonly HttpClient httpClient;

        public SiteController()
        {
        }

        [Route("site/{site}/")]
        public HttpResponseMessage Get(string site)
        {
            var response = new
            {
                url = site,
                status = "OK"
            };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
