using AutoMapper;
using SimplePhotoAlbum.BLL.ModelsDto;
using SimplePhotoAlbum.DAL;
using SimplePhotoAlbum.DAL.Entities;
using System.Collections.Generic;

namespace SimplePhotoAlbum.BLL
{
    public class PhotoService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PhotoService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<PhotoInfoDto> GetPhotosInfo(int pageSize, int pageN)
        {
            var listPhotoInfo = _unitOfWork.PhotoRepository.GetAll(pageSize, pageN);
            return _mapper.Map<IEnumerable<PhotoInfoDto>>(listPhotoInfo);
        }

        public PhotoInfoDto GetPhotoInfoById(int id)
        {
            var photoInfo = _unitOfWork.PhotoRepository.Get(id);
            return _mapper.Map<PhotoInfoDto>(photoInfo);
        }

        public PhotoImageDto GetImageByInfoId(int infoId)
        {
            var photoImage = _unitOfWork.ImageRepository.GetByInfoId(infoId);
            return _mapper.Map<PhotoImageDto>(photoImage);           
        }

        public PhotoImageDto GetImageById(int Id)
        {
            var photoImage = _unitOfWork.ImageRepository.Get(Id);
            return _mapper.Map<PhotoImageDto>(photoImage);
        }

        public void SavePhoto(PhotoInfoDto photoInfoDto, PhotoImageDto photoImageDto)
        {
            var photoInfo = _mapper.Map<PhotoInfo>(photoInfoDto);
            var photoImage = _mapper.Map<PhotoImage>(photoImageDto);

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

        public void UpdatePhotoInfo(PhotoInfoDto photoInfoDto)
        {
            var photoInfo = _mapper.Map<PhotoInfo>(photoInfoDto);
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
