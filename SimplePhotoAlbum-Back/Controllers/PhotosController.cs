using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimplePhotoAlbum.BLL;
using SimplePhotoAlbum_Back.Models;
using System.Collections.Generic;
using SimplePhotoAlbum_Back.Extensions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using SimplePhotoAlbum.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SimplePhotoAlbum_Back.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        #region Private
        private readonly PhotoService _photoSevice;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private PhotoImageView ExtractPhotoImage(IFormCollection formCollection)
        {
            var file = formCollection.Files[0];
            BinaryReader br = new BinaryReader(file.OpenReadStream());
            PhotoImageView photoImage = new PhotoImageView()
            {
                FileName = file.FileName,
                ImageType = file.ContentType,
                Image = br.ReadBytes((Int32)file.Length)
            };

            return photoImage;
        }

        private PhotoInfoView ExtractPhotoInfo(IFormCollection formCollection)
        {
            PhotoInfoView photoInfo = new PhotoInfoView()
            {
                Id = 0,
                Caption = formCollection["caption"].ToString(),
                Description = formCollection["description"].ToString()
            };

            return photoInfo;
        }
        #endregion

        public PhotosController(ILogger<PhotosController> logger, PhotoService photoService, IMapper mapper)
        {
            _photoSevice = photoService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhotoInfoView>> GetAll()
        {
            int pageSize = Request.Query["pageSize"].ToString().StrToIntDefault(10);
            int pageN = Request.Query["pageN"].ToString().StrToIntDefault(1);

            var photoInfoItems = _mapper.Map<IEnumerable<PhotoInfoView>>(_photoSevice.GetPhotosInfo(pageSize, pageN));

            return Ok(photoInfoItems);
        }

        [HttpGet("count")]
        public ActionResult<int> GetCountPhotos()
        {
            int countPhotos = _photoSevice.GetCountPhotos();

            return Ok(countPhotos);
        }

        [HttpGet("{id}")]
        public ActionResult<PhotoInfoView> GetPhotoById(int id)
        {
            var photoInfo = _mapper.Map<PhotoInfoView>(_photoSevice.GetPhotoInfoById(id));

            return Ok(photoInfo);
        }

        [HttpGet("{id}/image")]
        public ActionResult<PhotoImageView> GetImageById(int id)
        {
            var photoImage = _mapper.Map<PhotoImageView>(_photoSevice.GetImageByInfoId(id));

            return Ok(photoImage);
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<PhotoInfoView>> CreatePhotoWithImage()
        {
            var formCollection = await Request.ReadFormAsync();

            try
            {
                PhotoInfoView photoInfo = ExtractPhotoInfo(formCollection);
                PhotoImageView photoImage = ExtractPhotoImage(formCollection);

                _photoSevice.SavePhoto(
                        _mapper.Map<PhotoInfo>(photoInfo),
                        _mapper.Map<PhotoImage>(photoImage)
                        );
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't create new Photo. Error message: {e.Message}");
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePhoto(int id, PhotoInfoView photoInfo)
        {
            if (id != photoInfo.Id)
            {
                return BadRequest();
            }

            _photoSevice.UpdatePhotoInfo(_mapper.Map<PhotoInfo>(photoInfo));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhoto(int id)
        {
            _photoSevice.DeletePhoto(id);
            return NoContent();
        }        
    }
}
