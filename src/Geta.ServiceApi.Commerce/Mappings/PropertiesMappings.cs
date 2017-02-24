﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EPiServer.Commerce.Storage;
using Geta.ServiceApi.Commerce.Models;
using Mediachase.Commerce.Orders;
using Mediachase.MetaDataPlus.Configurator;

namespace Geta.ServiceApi.Commerce.Mappings
{
    internal static class PropertiesMappings
    {
        public static void MapPropertiesToModel(this IHaveProperties dto, IExtendedProperties model)
        {
            foreach (var property in dto.Properties)
            {
                if (model.Properties.ContainsKey(property.Key))
                {
                    var type = GetMetaFieldType(property.Key);
                    if (type == null) continue;
                    if (property.Value == null && !IsNullable(type)) continue;
                    var converter = TypeDescriptor.GetConverter(type);
                    model.Properties[property.Key] = converter.ConvertFromString(property.Value);
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

        private static bool IsNullable(Type type)
        {
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }

        private static Type GetMetaFieldType(string fieldName)
        {
            var metaContext = OrderContext.MetaDataContext;
            var field = MetaField.GetList(metaContext).FirstOrDefault(x => x.Name == fieldName);
            if(field == null)
            {
                return null;
            }

            var metaDataType = field.DataType;
            switch (metaDataType)
            {
                case MetaDataType.BigInt:
                case MetaDataType.Decimal:
                case MetaDataType.Money:
                case MetaDataType.SmallMoney:
                    return typeof(decimal);
                case MetaDataType.Bit:
                case MetaDataType.Char:
                case MetaDataType.Int:
                case MetaDataType.SmallInt:
                case MetaDataType.TinyInt:
                case MetaDataType.Integer:
                    return typeof(int);
                case MetaDataType.DateTime:
                case MetaDataType.SmallDateTime:
                case MetaDataType.Date:
                    return typeof(DateTime);
                case MetaDataType.Float:
                case MetaDataType.Real:
                    return typeof(double);
                case MetaDataType.NChar:
                case MetaDataType.NText:
                case MetaDataType.NVarChar:
                case MetaDataType.Text:
                case MetaDataType.VarChar:
                case MetaDataType.LongString:
                case MetaDataType.Email:
                case MetaDataType.URL:
                case MetaDataType.ShortString:
                case MetaDataType.LongHtmlString:
                    return typeof(string);
                case MetaDataType.Boolean:
                    return typeof(bool);
                default:
                    return null;
            }
        }
    }
}