using AutoMapper;
using SimplePhotoAlbum.BLL.ModelsDto;
using SimplePhotoAlbum_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePhotoAlbum_Back.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PhotoInfoView, PhotoInfoDto>().ReverseMap();
            CreateMap<PhotoImageView, PhotoImageDto>().ReverseMap();
        }
    }
}
