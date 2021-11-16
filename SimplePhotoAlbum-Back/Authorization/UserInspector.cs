using SimplePhotoAlbum_Back.Models;

namespace SimplePhotoAlbum_Back.Authorization
{
    public class UserInspector
    {
        private readonly UserView _user;
        public UserInspector(string email, string password)
        {
            _user = new UserView() { Email = email, Password = password };
        }

        public bool ChekUser()
        {
            // simple logic for example
            return (_user.Email.Contains("@") && _user.Password == "1");
        }

        public UserView GetUser()
        {
            return _user;
        }
    }
}
