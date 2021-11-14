using SimplePhotoAlbum.BLL.ModelsDto;
using System;
using System.Collections.Generic;
using System.IO;

namespace SimplePhotoAlbum.BLL
{
    public class PhotoService
    {
        public List<PhotoInfoDto> GetPhotosInfo(int pageSize, int pageN)
        {
            PhotoInfoDto photoInfoDto = new PhotoInfoDto() { Id = 1, Caption = "img 1", Description = "img 1 desc" };
            return new List<PhotoInfoDto>() { photoInfoDto }; 
        }

        public PhotoInfoDto GetPhotoInfoById(int id)
        {
            PhotoInfoDto photoInfoDto = new PhotoInfoDto() { Id = 1, Caption = "img 1", Description = "img 1 desc" };
            return photoInfoDto;
        }

        public PhotoImageDto GetImageById(int id)
        {
            PhotoImageDto photoImageDto = new PhotoImageDto() { Id = 1, FileName = "17joke.jpg", ImageType="jpg" };
            photoImageDto.Image = File.ReadAllBytes("C:\\tmp\\17joke.jpg");
            return photoImageDto;

        }

        public PhotoInfoDto SavePhoto(PhotoInfoDto photoInfoDto, PhotoImageDto photoImageDto)
        {
            //if (photoImageDto.Image.Length > 1000) && (photoInfoDto.Caption.Length > 0);
            PhotoInfoDto resultPhotoInfo = new PhotoInfoDto();
            //Save PhotoInfo
            //Save PhotoImage
            return resultPhotoInfo;
        }

        public int GetCountPhotos()
        {
            return 43;
        }

        public bool DeletePhoto(int id)
        {
            return true;
        }
    }
}
