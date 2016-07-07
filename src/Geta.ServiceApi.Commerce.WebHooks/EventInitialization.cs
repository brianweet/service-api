using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Mediachase.Commerce.Engine.Events;
using Mediachase.Commerce.Orders;
using Microsoft.AspNet.WebHooks;

namespace Geta.ServiceApi.Commerce.WebHooks
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class EventInitialization : IInitializableModule
    {
        public CatalogKeyEventBroadcaster EventBroadcaster => ServiceLocator.Current.GetInstance<CatalogKeyEventBroadcaster>();
        public IWebHookManager WebHookManager => ServiceLocator.Current.GetInstance<IWebHookManager>();

        public void Initialize(InitializationEngine context)
        {
            EventBroadcaster.InventoryUpdated += OnInventoryUpdated;
            EventBroadcaster.PriceUpdated += OnPriceUpdated;

            OrderContext.Current.OrderGroupUpdated += OnOrderGroupUpdated;
            OrderContext.Current.OrderGroupDeleted += OnOrderGroupDeleted;
        }

        public void Uninitialize(InitializationEngine context)
        {
            EventBroadcaster.InventoryUpdated -= OnInventoryUpdated;
            EventBroadcaster.PriceUpdated -= OnPriceUpdated;
            OrderContext.Current.OrderGroupUpdated -= OnOrderGroupUpdated;
            OrderContext.Current.OrderGroupDeleted -= OnOrderGroupDeleted;
        }

        private void OnOrderGroupDeleted(object sender, OrderGroupEventArgs e)
        {
            var orderGroup = sender as OrderGroup;
            WebHookManager.NotifyAllAsync(EventNames.OrderGroupDeleted, new { e.OrderGroupId, e.OrderGroupType, OrderGroup = orderGroup });
        }

        private void OnOrderGroupUpdated(object sender, OrderGroupEventArgs e)
        {
            var orderGroup = sender as OrderGroup;
            WebHookManager.NotifyAllAsync(EventNames.OrderGroupUpdated, new { e.OrderGroupId, e.OrderGroupType, OrderGroup = orderGroup });
        }

        private void OnPriceUpdated(object sender, PriceUpdateEventArgs e)
        {
            WebHookManager.NotifyAllAsync(EventNames.PriceUpdated, new { e.CatalogKeys });
        }

        private void OnInventoryUpdated(object sender, InventoryUpdateEventArgs e)
        {
            WebHookManager.NotifyAllAsync(EventNames.InventoryUpdated, new { e.CatalogKeys });
        }
    }
}