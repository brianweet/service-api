﻿using System.Collections.Generic;
using EPiServer.Commerce.Storage;
using Geta.ServiceApi.Commerce.Models;

namespace Geta.ServiceApi.Commerce.Mappings
{
    internal static class PropertiesMappings
    {
        public static void MapPropertiesToModel<T>(this IHaveProperties dto, T model)
            where T : Mediachase.MetaDataPlus.MetaObject, IExtendedProperties
        {
            foreach (var property in dto.Properties)
            {
                IExtendedProperties p = model;
                if (p.Properties.ContainsKey(property.Key))
                {
                    model[property.Key] = property.Value;
                }
            }
        }

        public static void MapPropertiesToDto(this IExtendedProperties model, IHaveProperties dto)
        {
            dto.Properties = model.ToPropertyList();
        }

        public static List<PropertyItem> ToPropertyList(this IExtendedProperties extendedProperties)
        {
            var result = new List<PropertyItem>();
            foreach (var key in extendedProperties.Properties.Keys)
            {
                var k = key.ToString();
                var v = extendedProperties.Properties[key]?.ToString();
                var item = new PropertyItem {Key = k, Value = v};
                result.Add(item);
            }

            return result;
        }
    }
}