using AutoMapper;
using SimplePhotoAlbum.BLL.ModelsDto;
using SimplePhotoAlbum_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplePhotoAlbum.DAL.Entities;

namespace SimplePhotoAlbum_Back.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PhotoInfo, PhotoInfoDto>().ReverseMap();
            CreateMap<PhotoImage, PhotoImageDto>().ReverseMap();

            CreateMap<PhotoInfoView, PhotoInfoDto>().ReverseMap();
            CreateMap<PhotoImageView, PhotoImageDto>().ReverseMap();

            // TODO: is it needed?
            CreateMap<PhotoInfoView, PhotoInfo>().ReverseMap();
            CreateMap<PhotoImageView, PhotoImage>().ReverseMap();
        }
    }
}
