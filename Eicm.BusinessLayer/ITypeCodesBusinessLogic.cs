using Eicm.BusinessLogic.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eicm.BusinessLogic
{
    public interface ITypeCodesBusinessLogic
    {
        Task<List<TypeCodeValue>> GetTypeCodeValues<T>();      
        Task<List<TypeCodeValue>> GetTypeCodeValues(string typeCode);
        Task<TypeCodes> GetAllTypeCodeValues();
    }
}