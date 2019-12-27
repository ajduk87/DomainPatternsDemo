using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CommercialApplicationQuery
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        [Route("api/healthCheck")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Commercial Application Command Query", "is", "running" };
        }
    }
}
