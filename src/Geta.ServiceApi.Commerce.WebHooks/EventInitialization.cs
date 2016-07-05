using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace Geta.ServiceApi.Commerce.WebHooks
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class EventInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}