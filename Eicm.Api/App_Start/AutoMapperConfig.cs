using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Eicm.Core.Models.RequestModels;
using Eicm.Core.Models.ResponseModels;
using Eicm.DataLayer.Entities.Vendors;

namespace Eicm.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<GetContractResponseModel, Contract>().ReverseMap();
                config.CreateMap<AddContractRequestModel, Contract>().ReverseMap();
            });
        }
    }
}