using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimplePhotoAlbum_Back.Authorization
{
    public class JwtCreator
    {
        private string _encodedJwt;
        private ClaimsIdentity _claimsIdentity;

        public JwtCreator(ClaimsIdentity claimsIdentity)
        {
            _claimsIdentity = claimsIdentity;
        }

        private void PrepareEncodedJwt()
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,                
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                claims: _claimsIdentity.Claims,
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            _encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        
        public JwtResponse GetResponse()
        {
            PrepareEncodedJwt();

            return new JwtResponse()
            {
                Token = _encodedJwt,
                Username = _claimsIdentity.Name
            };
        }
    }
}
