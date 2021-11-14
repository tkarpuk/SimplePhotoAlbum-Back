namespace SimplePhotoAlbum.BLL.ModelsDto
{
    public class PhotoImageDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
        public string ImageType { get; set; }
    }
}
