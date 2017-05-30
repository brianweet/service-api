using System;
using System.Linq;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Mediachase.Commerce.Orders;
using Mediachase.MetaDataPlus.Configurator;

namespace EPiServer.Reference.Commerce.Site.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CommerceMetaDataInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {

            CreateMetaField(new MetaFieldInfo("CustomLineItemProperty", MetaDataType.LongString)
            {
                FriendlyName = "CustomLineItemProperty",
                IsNullable = true
            });

            AddFieldToMetaClass(OrderContext.Current.LineItemMetaClass, GetMetaField("CustomLineItemProperty"));

        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        private void AddFieldToMetaClass(MetaClass metaClass, MetaField metaField)
        {
            if (metaClass.MetaFields.Any(x => x.Name == metaField.Name))
            {
                return;
            }

            metaClass.AddField(metaField);
        }

        private MetaField GetMetaField(string name)
        {
            var metaContext = OrderContext.MetaDataContext;
            return MetaField.GetList(metaContext).FirstOrDefault(x => x.Name == name);
        }

        private void CreateMetaField(MetaFieldInfo fieldInfo)
        {
            var metaContext = OrderContext.MetaDataContext;
            if (MetaField.GetList(metaContext).Any(x => x.Name == fieldInfo.Name))
            {
                return;
            }

            MetaField.Create(
                metaContext,
                fieldInfo.MetaNamespace,
                fieldInfo.Name,
                fieldInfo.FriendlyName,
                fieldInfo.Description,
                fieldInfo.MetaFieldType,
                fieldInfo.Length,
                fieldInfo.IsNullable,
                fieldInfo.IsMultiLanguage,
                fieldInfo.IsSearchable,
                fieldInfo.IsEncrypted);
        }

        private class MetaFieldInfo
        {
            public MetaFieldInfo(string name, MetaDataType metaFieldType)
            {
                if (name == null) throw new ArgumentNullException(nameof(name));
                Name = name;
                MetaFieldType = metaFieldType;
                FriendlyName = name;
            }

            public string Name { get; }
            public string MetaNamespace { get; set; } = string.Empty;
            public string FriendlyName { get; set; }
            public string Description { get; set; } = string.Empty;
            public MetaDataType MetaFieldType { get; }
            public bool IsNullable { get; set; }
            public int Length { get; set; }
            public bool IsMultiLanguage { get; set; }
            public bool IsSearchable { get; set; }
            public bool IsEncrypted { get; set; }
        }

    }
}