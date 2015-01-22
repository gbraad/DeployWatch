using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace DeployWatch.Controllers
{
    public class RequestClient
    {
        private HttpClient httpClient;

        public bool IsSelfSigned;
        public string CertificateExpiration;

        public RequestClient(string hostAddress)
        {
            var clientHandler = new WebRequestHandler();
            clientHandler.ServerCertificateValidationCallback += (ValidateServerCertificate);


            httpClient = new HttpClient(clientHandler);
            httpClient.BaseAddress = new Uri(String.Format("https://{0}", hostAddress));
        }

        public HttpResponseMessage GetResult()
        {
            return httpClient.GetAsync("/").Result;
        }

        private bool ValidateServerCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            IsSelfSigned = (certificate.Subject == certificate.Issuer);
            CertificateExpiration = certificate.GetExpirationDateString();

            return true;
        }


    }
}