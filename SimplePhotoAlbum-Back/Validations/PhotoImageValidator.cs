using FluentValidation;
using SimplePhotoAlbum_Back.Models;

namespace SimplePhotoAlbum_Back.Validations
{
    public class PhotoImageValidator : AbstractValidator<PhotoImageView>
    {
        public PhotoImageValidator()
        {
            RuleFor(x => x.FileName).NotEmpty();
            RuleFor(x => x.ImageType).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();            
        }
    }
}
