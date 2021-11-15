namespace SimplePhotoAlbum.DAL.Entities
{
    public class PhotoImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
        public string ImageType { get; set; }

        public int InfoId { get; set; }
        public PhotoInfo Info { get; set; }
    }
}
