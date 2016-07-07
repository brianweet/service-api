using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Mediachase.Commerce.Engine.Events;
using Mediachase.Commerce.Orders;

namespace Geta.ServiceApi.Commerce.WebHooks
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class EventInitialization : IInitializableModule
    {
        public CatalogKeyEventBroadcaster EventBroadcaster => ServiceLocator.Current.GetInstance<CatalogKeyEventBroadcaster>();

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
        }

        private void OnOrderGroupUpdated(object sender, OrderGroupEventArgs orderGroupEventArgs)
        {
        }

        private void OnPriceUpdated(object sender, PriceUpdateEventArgs e)
        {
        }

        private void OnInventoryUpdated(object sender, InventoryUpdateEventArgs e)
        {
        }
    }
}