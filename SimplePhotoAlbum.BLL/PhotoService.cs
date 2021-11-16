using SimplePhotoAlbum.DAL;
using SimplePhotoAlbum.DAL.Entities;
using System.Collections.Generic;

namespace SimplePhotoAlbum.BLL
{
    public class PhotoService
    {
        private readonly UnitOfWork _unitOfWork;
        public PhotoService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PhotoInfo> GetPhotosInfo(int pageSize, int pageN)
        {
            return _unitOfWork.PhotoRepository.GetAll(pageSize, pageN);
        }

        public PhotoInfo GetPhotoInfoById(int id)
        {
            return _unitOfWork.PhotoRepository.Get(id);
        }

        public PhotoImage GetImageByInfoId(int infoId)
        {
            return _unitOfWork.ImageRepository.GetByInfoId(infoId);
        }

        public PhotoImage GetImageById(int Id)
        {
            return _unitOfWork.ImageRepository.Get(Id);
        }

        public void SavePhoto(PhotoInfo photoInfo, PhotoImage photoImage)
        {
            _unitOfWork.PhotoRepository.Create(photoInfo);
            photoImage.Info = photoInfo;
            _unitOfWork.ImageRepository.Create(photoImage);
            _unitOfWork.SaveAll();
        }

        public int GetCountPhotos()
        {
            return _unitOfWork.PhotoRepository.GetConunt();
        }

        public void DeletePhoto(int id)
        {
            _unitOfWork.PhotoRepository.Delete(id);
            _unitOfWork.SaveAll();
        }

        public void UpdatePhotoInfo(PhotoInfo photoInfo)
        {
            _unitOfWork.PhotoRepository.Update(photoInfo);
            _unitOfWork.SaveAll();
        }
        /*
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
        */
    }
}
