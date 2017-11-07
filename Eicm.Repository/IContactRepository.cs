using Eicm.Core.Extensions;
using Eicm.DataLayer.Entities.Vendors;
using System.Threading.Tasks;

namespace Eicm.Repository
{
    public interface IContactRepository
    {
        Task<ICommonResult<Contact>> GetContactByIdAsync(int id);
        
       
        Task<ICommonResult<int>> AddContactAsync(Contact contact);
       
    }
}
