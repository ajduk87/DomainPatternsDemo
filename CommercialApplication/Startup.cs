using Owin;
using System.Web.Http;

namespace CommercialApplicationCommand
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Configure Web Api for self-host
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnableCors();

            app.UseWebApi(config);
        }
    }
}