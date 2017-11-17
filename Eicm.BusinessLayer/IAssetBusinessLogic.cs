using System.Collections.Generic;
using System.Threading.Tasks;
using Eicm.BusinessLogic.DataObjects;
using Eicm.Core.Extensions;
using Eicm.Core.Models.RequestModels;
using Eicm.Core.Models.ResponseModels;

namespace Eicm.BusinessLogic
{
    public interface IAssetBusinessLogic
    {
        //Task<ICommonResult<int>> AddAssetAsync(AssetModel asset);
        Task<ICommonResult<int>> AddSoftwareAsync(AddSoftwareRequestModel asset);

        Task<ICommonResult<AddSoftwareResponseModel>> GetSoftwareByIdAsync(int softwareId);
    }
}
