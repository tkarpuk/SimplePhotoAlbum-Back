using SimplePhotoAlbum_Back.Models;

namespace SimplePhotoAlbum_Back.Authorization
{
    public class UserInspector
    {
        private User _user = new User();
        public UserInspector(string email, string password)
        {
            _user.Email = email;
            _user.Password = password;
        }

        public bool ChekUser()
        {
            // simple logic for example
            return (_user.Email.Contains("@") && _user.Password == "1");
        }

        public User GetUser()
        {
            return _user;
        }
    }
}
