namespace SimplePhotoAlbum.DAL.Entities
{
    public class PhotoInfo
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }

        public PhotoImage Image { get; set; }
    }
}
