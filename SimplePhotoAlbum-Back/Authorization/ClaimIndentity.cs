using SimplePhotoAlbum_Back.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace SimplePhotoAlbum_Back.Authorization
{
    public class ClaimIndentity
    {
        private UserView _user;
        public ClaimIndentity(UserView user)
        {
            _user = user;
        }

        private List<Claim> CreateClaimList() 
        {
            return new List<Claim> 
            {
               new Claim(ClaimsIdentity.DefaultNameClaimType, _user.Email),
               new Claim(ClaimsIdentity.DefaultRoleClaimType, _user.Id.ToString())
            };
        }

        public ClaimsIdentity ReturnClaims()
        {
            return new ClaimsIdentity(
                CreateClaimList(),
                "Token", 
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
