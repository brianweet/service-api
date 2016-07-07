using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

namespace Geta.ServiceApi.Commerce.WebHooks
{
    public class FilterProvider : IWebHookFilterProvider
    {
        private readonly Collection<WebHookFilter> _filters = new Collection<WebHookFilter>
        {
            new WebHookFilter { Name = "InventoryUpdated", Description = "Event raised when an inventory has been updated."},
            new WebHookFilter { Name = "PriceUpdated", Description = "Event raised when one or many prices have been updated."},
            new WebHookFilter { Name = "OrderGroupUpdated", Description = "Event raised when order group updated."},
            new WebHookFilter { Name = "OrderGroupDeleted", Description = "Event raised when order group deleted."},
        };

        public Task<Collection<WebHookFilter>> GetFiltersAsync()
        {
            return Task.FromResult(_filters);
        }
    }
}