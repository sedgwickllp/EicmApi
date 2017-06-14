using System;
using System.Collections.Generic;
using System.Linq;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Attributes;
using Eicm.Core.Enums;
using Eicm.Core.Extensions;
using System.Reflection;

namespace Eicm.BusinessLogic
{
    public static class TypeCodesBusinessLogic
    {
        public static List<TypeCodeValue> GetTypeCodeValues<T>()
        {
            return (from object itemType in Enum.GetValues(typeof(T))
                    select new TypeCodeValue()
                    {
                        Name = itemType.GetType().GetTypeInfo().GetDeclaredField(itemType.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                        Id = (int)itemType,
                    }).ToList();
        }

        public static List<TypeCodeValue> GetSubTypeCodeValues<T>()
        {
            return (from object itemType in Enum.GetValues(typeof(T))
                select new TypeCodeValue()
                {
                    Name = itemType.GetType().GetTypeInfo().GetDeclaredField(itemType.ToString()).GetCustomAttribute<DisplayNameAttribute>().Value,
                    Id = (int)itemType,
                    ParentId = itemType.GetType().GetTypeInfo().GetDeclaredField(itemType.ToString()).GetCustomAttribute<ParentIdAttribute>().Value
                }).ToList();
        }
       
        public static ICommonResult<List<TypeCodeValue>> GetTypeCodeValues(string typeCode)
        {
            List<TypeCodeValue> typeCodeList;
            switch (typeCode)
            {
                case @"Category":
                {
                    typeCodeList = GetTypeCodeValues<CategoryType>();
                    break;
                }
                case @"Priority":
                {
                    typeCodeList = GetTypeCodeValues<PriorityType>();
                    break;
                }
                case @"Cause":
                {
                    typeCodeList = GetTypeCodeValues<CauseType>();
                    break;
                }
                case @"Origin":
                {
                    typeCodeList = GetTypeCodeValues<OriginType>();
                    break;
                }
                case @"Status":
                {
                    typeCodeList = GetTypeCodeValues<StatusType>();
                    break;
                }
                case @"SubCategory":
                {
                    typeCodeList = GetSubTypeCodeValues<SubCategoryType>();
                    break;
                }
                default:
                {
                    typeCodeList = null;
                    break;
                }
            }
            return new CommonResult<List<TypeCodeValue>>(typeCodeList, ResultCode.Success);
        }

        public static TypeCodes GetAllTypeCodeValues()
        {
            var allTypeCodes = new TypeCodes
            {
                CategoryTypes = GetTypeCodeValues<CategoryType>(),
                PriorityTypes = GetTypeCodeValues<PriorityType>(),
                CauseTypes = GetTypeCodeValues<CauseType>(),
                OriginTypes = GetTypeCodeValues<OriginType>(),
                StatusTypes = GetTypeCodeValues<StatusType>(),
                SubCategoryTypes = GetSubTypeCodeValues<SubCategoryType>()
            };

            return allTypeCodes;

        }
    }
}
