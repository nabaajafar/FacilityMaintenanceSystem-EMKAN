using EMKAN.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMKAN.API5.Model
{
    public class TokenManager
    {
        private static EMKANDbContext _db;
        public TokenManager(EMKANDbContext db)
        {
            TokenManager._db = db;
        }

        private static string Secret =
        "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";

        public string GenerateToken(string username)
        {

            try
            {
                // var roleList = _db.Roles.FromSqlRaw("EXEC UserPrivilege @username", username).ToList();
                var roleList = _db.Roles.FromSqlRaw("EXEC SpUserPrivilege @username = {0}", username).ToList();
                // var roleList = new EMDbContext().UserPrivilege(username).ToList();

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, username));

                string rules = string.Empty;
                foreach (var item in roleList)
                    rules += item.Name + ",";

                claims.Add(new Claim(ClaimTypes.Role, rules));

                byte[] key = Convert.FromBase64String(Secret)
;
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key)
;
                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(securityKey,
                    SecurityAlgorithms.HmacSha256Signature)
                };

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
                return handler.WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Empty;
            }
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret)
;
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)

                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parameters, out securityToken);
                return principal;
            }
            catch (Exception ex)
            {

                return null;

            }
        }

        public static (string, string) ValidateToken(string token)
        {
            string username = null;
            string claimss = null;
            ClaimsPrincipal principal = GetPrincipal(token);

            if (principal == null)
                return (null, null);
            ClaimsIdentity identity = null;
            Claim claims;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException ex)
            {

                return (null, null);

            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            claims = identity.FindFirst(ClaimTypes.Role);
            username = usernameClaim.Value;
            claimss = claims.Value;
            return (username, claimss);
        }
    }
}
