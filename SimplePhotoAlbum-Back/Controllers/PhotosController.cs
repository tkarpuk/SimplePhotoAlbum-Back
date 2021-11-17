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
using Microsoft.AspNetCore.Authorization;
using SimplePhotoAlbum.BLL.ModelsDto;

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

        private static async Task<PhotoImageView> ExtractPhotoImageAsync(IFormCollection formCollection)
        {
            var file = formCollection.Files[0];            

            var photoImageView = new PhotoImageView()
            {
                FileName = file.FileName,
                ImageType = file.ContentType                
            };

            var br = new BinaryReader(file.OpenReadStream());
            photoImageView.Image = await Task.FromResult(br.ReadBytes((Int32)file.Length));

            return photoImageView;
        }

        private static PhotoInfoView ExtractPhotoInfo(IFormCollection formCollection)
        {
            return new PhotoInfoView()
            {
                Id = 0,
                Caption = formCollection["caption"].ToString(),
                Description = formCollection["description"].ToString()
            };
        }
        #endregion

        public PhotosController(ILogger<PhotosController> logger, PhotoService photoService, IMapper mapper)
        {
            _photoSevice = photoService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoInfoView>>> GetAll()
        {
            int pageSize = Request.Query["pageSize"].ToString().StrToIntDefault(10);
            int pageN = Request.Query["pageN"].ToString().StrToIntDefault(1);

            var photoInfoItems = _mapper.Map<IEnumerable<PhotoInfoView>>(await _photoSevice.GetPhotosInfoAsync(pageSize, pageN));

            return Ok(photoInfoItems);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCountPhotos()
        {
            int countPhotos = await _photoSevice.GetCountPhotosAsync();

            return Ok(countPhotos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoInfoView>> GetPhotoById(int id)
        {
            var photoInfo = _mapper.Map<PhotoInfoView>(await _photoSevice.GetPhotoInfoByIdAsync(id));

            return Ok(photoInfo);
        }

        [HttpGet("{id}/image")]
        public async Task<ActionResult<PhotoImageView>> GetImageById(int id)
        {
            var photoImage = _mapper.Map<PhotoImageView>(await _photoSevice.GetImageByInfoIdAsync(id));

            return Ok(photoImage);
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<PhotoInfoView>> CreatePhotoWithImage()
        {
            var formCollection = await Request.ReadFormAsync();

            try
            {
                PhotoInfoView photoInfo = ExtractPhotoInfo(formCollection);
                PhotoImageView photoImage = await ExtractPhotoImageAsync(formCollection);

                await _photoSevice.SavePhotoAsync(
                        _mapper.Map<PhotoInfoDto>(photoInfo),
                        _mapper.Map<PhotoImageDto>(photoImage)
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
        public async Task<IActionResult> UpdatePhoto(int id, PhotoInfoView photoInfo)
        {
            if (id != photoInfo.Id)
            {
                return BadRequest();
            }

            await _photoSevice.UpdatePhotoInfoAsync(_mapper.Map<PhotoInfoDto>(photoInfo));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            await _photoSevice.DeletePhotoAsync(id);
            return NoContent();
        }        
    }
}
