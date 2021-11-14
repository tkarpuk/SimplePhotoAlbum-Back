using FluentValidation;
using SimplePhotoAlbum_Back.Models;

namespace SimplePhotoAlbum_Back.Validations
{
    public class PhotoInfoValidator : AbstractValidator<PhotoInfo>
    {
        public PhotoInfoValidator()
        {
            RuleFor(x => x.Caption).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
