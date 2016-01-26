using Owin;

namespace EPiServer.Reference.Commerce.Site
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            new EPiServer.ServiceApi.Startup().Configuration(app);
            new EPiServer.Reference.Commerce.Site.Infrastructure.Owin.Startup().Configuration(app);
        }
    }
}