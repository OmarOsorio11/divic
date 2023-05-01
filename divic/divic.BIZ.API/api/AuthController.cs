using COMMON.DTO;
using COMMON.Interfaces;
using divic.COMMON.Modelos;
using divic.DAL.SQLSERVER;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace divic.BIZ.API.api
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IGenericRepository<Delivery> repository;
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repository = FabricRepository.Delivery();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            string v = $"Select * from Delivery where Usuario ='{model.nombreUsuario}' and Password='{model.password}'";
            Delivery d = repository.Query(v).SingleOrDefault();
            if (d != null)
            {
                var secretKey = configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, d.Id.ToString()),
                    new Claim(ClaimTypes.Name, d.Usuario)
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));
            }
            else
            {
                return Forbid();
            }
        }
    }
}
