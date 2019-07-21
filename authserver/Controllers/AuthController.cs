using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace netmicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {


        [HttpGet]
        public IActionResult Get(string name, string pwd)
        {
            if (name == "testuser" && pwd == "123456")
            {
                var now = DateTime.UtcNow;

                var claims = new Claim[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
                };

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA=="));
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = "localhost",
                    ValidateAudience = true,
                    ValidAudience = "Abdulkerim Karaman",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,

                };

                var jwt = new JwtSecurityToken(
                    issuer: "localhost",
                    audience: "Abdulkerim Karaman",
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(500)),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var responseJson = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)TimeSpan.FromMinutes(5000).TotalSeconds
                };

                return Json(responseJson);
            }
            else
            {
                return Json("");
            }
        }

        public class Audience
        {
            public string Secret { get; set; }
            public string Iss { get; set; }
            public string Aud { get; set; }
        }
    }
}
