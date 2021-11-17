using AutoMapper;
using SimplePhotoAlbum.BLL.ModelsDto;
using SimplePhotoAlbum.DAL;
using SimplePhotoAlbum.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<PhotoInfoDto>> GetPhotosInfoAsync(int pageSize, int pageN)
        {
            var listPhotoInfo = await _unitOfWork.PhotoRepository.GetAllAsync(pageSize, pageN);
            return _mapper.Map<IEnumerable<PhotoInfoDto>>(listPhotoInfo);
        }

        public async Task<PhotoInfoDto> GetPhotoInfoByIdAsync(int id)
        {
            var photoInfo = await _unitOfWork.PhotoRepository.GetAsync(id);
            return _mapper.Map<PhotoInfoDto>(photoInfo);
        }

        public async Task<PhotoImageDto> GetImageByInfoIdAsync(int infoId)
        {
            var photoImage = await _unitOfWork.ImageRepository.GetByInfoIdAsync(infoId);
            return _mapper.Map<PhotoImageDto>(photoImage);           
        }

        public async Task<PhotoImageDto> GetImageByIdAsync(int Id)
        {
            var photoImage = await _unitOfWork.ImageRepository.GetAsync(Id);
            return _mapper.Map<PhotoImageDto>(photoImage);
        }

        public async Task SavePhotoAsync(PhotoInfoDto photoInfoDto, PhotoImageDto photoImageDto)
        {
            var photoInfo = _mapper.Map<PhotoInfo>(photoInfoDto);
            var photoImage = _mapper.Map<PhotoImage>(photoImageDto);

            await _unitOfWork.PhotoRepository.CreateAsync(photoInfo);
            photoImage.Info = photoInfo;
            await _unitOfWork.ImageRepository.CreateAsync(photoImage);

            await _unitOfWork.SaveAsync();
        }

        public async Task<int> GetCountPhotosAsync()
        {
            return await _unitOfWork.PhotoRepository.GetConuntAsync();
        }

        public async Task DeletePhotoAsync(int id)
        {
            await _unitOfWork.PhotoRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdatePhotoInfoAsync(PhotoInfoDto photoInfoDto)
        {
            var photoInfo = _mapper.Map<PhotoInfo>(photoInfoDto);
            await _unitOfWork.PhotoRepository.UpdateAsync(photoInfo);
            await _unitOfWork.SaveAsync();
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
