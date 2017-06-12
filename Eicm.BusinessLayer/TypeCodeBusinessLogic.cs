using System;
using System.Collections.Generic;
using System.Linq;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Enums;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public static class TypeCodeBusinessLogic
    {
    //    public static List<TypeCodeValue> GetTypeCodeValues<T>()
    //    {
    //        return (from object itemType in Enum.GetValues(typeof(T))
    //            select new TypeCodeValue()
    //            {
    //                Name = Enum.GetName(typeof(T), itemType),
    //                Id = (int) itemType,
    //                //Active = itemType.GetType().GetTypeInfo().GetDeclaredField(itemType.ToString()).GetCustomAttribute<ActiveAttribute>().Value 
    //            }).ToList();
    //    }
    //            case @"ItComponent":

    //    public static ICommonResult<List<TypeCodeValue>> GetTypeCodeValues(string typeCode)
    //    {
    //        List<TypeCodeValue> typeCodeList;
    //        switch (typeCode)
    //        {
    //            {
    //                typeCodeList = GetTypeCodeValues<ItComponentType>();
    //                break;
    //            }
    //            case @"Priority":
    //            {
    //                typeCodeList = GetTypeCodeValues<PriorityType>();
    //                break;
    //            }
    //            case @"RequestType":
    //            {
    //                typeCodeList = GetTypeCodeValues<RequestType>();
    //                break;
    //            }
    //            case @"Source":
    //            {
    //                typeCodeList = GetTypeCodeValues<SourceType>();
    //                break;
    //            }
    //            case @"Status":
    //            {
    //                typeCodeList = GetTypeCodeValues<StatusType>();
    //                break;
    //            }
    //            case @"SubComponent":
    //            {
    //                typeCodeList = GetTypeCodeValues<SubComponentType>();
    //                break;
    //            } 
    //            default:
    //            {
    //                typeCodeList = null;
    //                break;
    //            }
    //        }
    //        return new CommonResult<List<TypeCodeValue>>(typeCodeList, ResultCode.Success);
    //    }
    //    public static TypeCodes GetAllTypeCodeValues()
    //    {
    //        var allTypeCodes = new TypeCodes
    //        {
    //            ItComponentTypes = GetTypeCodeValues<ItComponentType>(),
    //            PriorityTypes = GetTypeCodeValues<PriorityType>(),
    //            RequestTypes = GetTypeCodeValues<RequestType>(),
    //            SourceTypes = GetTypeCodeValues<SourceType>(),
    //            StatusTypes = GetTypeCodeValues<StatusType>(),
    //            SubComponentTypes = GetTypeCodeValues<SubComponentType>()
    //        };
           
    //        return allTypeCodes;

    //    }
    }
}
