using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using FluentAssertions.Common;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
       
        IConfiguration _config;
        ILogger log;

        IUserSer _Service;
        public UserController(IUserSer service, IConfiguration config, ILogger<UserController>logger)
        {
            _Service = service;
            _config = config;
            log = logger;
            log.LogInformation("User Added");
        }
        // GET: api/<UserController>
        /*   [HttpGet]
           public IEnumerable<string> Get()
           {
               return new string[] { "value1", "value2" };
           }

           // GET api/<UserController>/5
           [HttpGet("{id}")]
           public string Get(int id)
           {
               return "value";
           }*/

        // POST api/<UserController>

        [HttpPost]
        [Route("Register")]

        public IActionResult AddUser([FromBody] User value)
        {
            if (_Service.AddUser(value))
            {
                string p = GenerateJSONWebToken(value);
                var obj = new Token() { success = true, token = p };
                log.LogInformation("User is added");
                return new OkObjectResult(obj);
            }
            return new NotFoundObjectResult(value.ToString());

            /*return new OkObjectResult(GenerateJSONWebToken(value));
        return new BadRequestObjectResult(value.ToString());*/
        }

        // PUT api/<UserController>/5
        [HttpPost]
        [Route("validate")]
        public IActionResult ValidateUser([FromBody] User value)
        {
            if (_Service.ValidateUser(value))
            {
                string t = GenerateJSONWebToken(value);
                var obj = new Token() { success = true, token = t };
                return new OkObjectResult(obj);
            }
            return new NotFoundObjectResult(value.ToString());
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                  new Claim("email", userInfo.email),
                  // new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                  new Claim("Role", "Admin"),
                  //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
             // null,
             claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      
    }
}
class Token
{
    public string? token { get; set; }
    public bool success { get; set;}
}
