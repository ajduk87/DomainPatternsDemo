using System.Collections.Generic;
using System.Web.Http;

namespace CommercialApplicationCommand
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        [Route("api/healthCheck")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Commercial Application Command Server", "is", "running" };
        }
    }
}