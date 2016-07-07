using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

namespace EPiServer.Reference.Commerce.Site.Features.WebHooks
{
    public class SampleHandler : WebHookHandler
    {
        public SampleHandler()
        {
            Receiver = CustomWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {


            return Task.FromResult(true);
        }
    }
}