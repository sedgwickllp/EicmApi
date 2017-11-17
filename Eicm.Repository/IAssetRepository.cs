using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eicm.Core.Extensions;
using Eicm.Core.Models.RequestModels;
using Eicm.DataLayer.Entities.Assets;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Repository
{
    public interface IAssetRepository
    {
        Task<ICommonResult<int>> AddSoftwareAsync(AddSoftwareRequestModel asset);
        //Task<ICommonResult<int>> AddAssetAsync(AssetModel asset);
        Task<ICommonResult<Asset>> GetSoftwareByIdAsync(int softwareId);
    }
}
