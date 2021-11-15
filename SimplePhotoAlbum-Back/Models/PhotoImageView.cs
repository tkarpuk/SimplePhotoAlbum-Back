namespace SimplePhotoAlbum_Back.Models
{
    public class PhotoImageView
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
        public string ImageType { get; set; }
    }
}
