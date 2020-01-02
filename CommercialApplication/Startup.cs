using CommercialApplication.DomainLayer.Entities.ValueObjects.TypeHandlers;
using Owin;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CommercialApplicationCommand
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Configure Web Api for self-host
            HttpConfiguration config = new HttpConfiguration();

            EnableCorsAttribute corsAttributes = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(corsAttributes);

            TypeHandlerInitializer.InitializeTypeHandlers();

            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}