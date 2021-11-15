using SimplePhotoAlbum_Back.Models;

namespace SimplePhotoAlbum_Back.Authorization
{
    public class UserInspector
    {
        private UserView _user = new UserView();
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

        public UserView GetUser()
        {
            return _user;
        }
    }
}
