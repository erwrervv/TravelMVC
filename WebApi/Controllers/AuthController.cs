using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Versioning;
using Travel.WebApi.Models;
using Travel.WebApi.ViewModels;

namespace Travel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly FinalContext _context;

        public AuthController(FinalContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var member = _context.BasicMemberInformations.FirstOrDefault(x => x.Email == model.Username && x.Password == model.Password);
            if(member != null)
            {
                var token = GenerateJwtToken(member.Email, member.MemberuniqueId);
                var info = new 
                {
                    token= token,
                    memberId=member.MemberuniqueId
                };
                return Ok(info);
            }
            return Unauthorized();
        }
        [Authorize]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok(new
            {
                Id=User.Claims.FirstOrDefault(x => x.Type == "Id").Value,
                Name = User.Claims.FirstOrDefault(x=>x.Type== ClaimTypes.NameIdentifier).Value
            });
        }
        [NonAction]
        private string GenerateJwtToken(string userName, int userId)
        {
            var claims = new[]
            {
                new Claim("Id", userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123730a1-1e99-428b-9f6d-9f3ed4021234"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "erwrervv",
                audience: "TravelDemo",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
