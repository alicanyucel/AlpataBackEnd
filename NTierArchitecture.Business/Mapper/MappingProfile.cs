using AutoMapper;
using NTierArchitecture.Business.Features.Document.CreateDocuments;
using NTierArchitecture.Business.Features.Meets.CreateMeets;
using NTierArchitecture.Business.Features.Meets.UpdateMeets;
using NTierArchitecture.Business.Features.ProfileImage.CreteProfilImage;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Mapper
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMeetCommand, Meet>().ReverseMap();
            CreateMap<UpdateMeetCommand,Meet>().ReverseMap();
        //    CreateMap<CreateImageCommand,Image>().ReverseMap();
        //    CreateMap<CreatDocumentsCommand,Document>().ReverseMap();

        }
    }
}