using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;

namespace Eicm.BusinessLogic
{
    public interface IContactBusinessLogic
    {
        Task<ICommonResult<ContactDTO>> GetContactByIdAsync(int id);
        Task<ICommonResult<int>> AddContactAsync(ContactDTO contact);
    }
}
