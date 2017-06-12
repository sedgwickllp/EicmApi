using Eicm.BusinessLogic.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eicm.BusinessLogic
{
    public interface ITypeCodeBusinessLogic
    {
        Task<List<TypeCodeValue>> GetTypeCodeValues<T>();      
        Task<List<TypeCodeValue>> GetTypeCodeValues(string typeCode);
        Task<TypeCodes> GetAllTypeCodeValues();
    }
}