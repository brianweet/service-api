using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

namespace EPiServer.Reference.Commerce.Site.Features.WebHooks
{
    public class SampleHandler : WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {


            return Task.FromResult(true);
        }
    }
}