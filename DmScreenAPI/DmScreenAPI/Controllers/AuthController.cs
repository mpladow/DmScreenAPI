using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using DmScreenAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DmScreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _config;

        public AuthController(IAccountRepository accountService, IConfiguration config)
        {
            _accountRepository = accountService;
            _config = config;
        }
        [HttpPost("register")]
        public IActionResult Register(AccountForRegisterDto model)
        {
            // hash the password
            if (!ModelState.IsValid)
                return BadRequest("An error has occurred.");
            model.Email = model.Email.ToLower();
            if (_accountRepository.AccountExists(model.Email))
            {
                return BadRequest("Account already exists.");
            }
            var accountToCreate = new Account
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateCreated = DateTime.Now
            };
            var createdAccount = _accountRepository.Register(accountToCreate, model.Password);
            return StatusCode(201);

        }
        [HttpPost("login")]
        public IActionResult Login(AccountForLoginDto accountForLoginDto)
        {
            // first we check that we have this user in the database
            var accountFromRepo = _accountRepository.Login(accountForLoginDto.Email.ToLower(), accountForLoginDto.Password);

            if (accountFromRepo == null)
                return Unauthorized();

            // The below code will create a token for the client.
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, accountFromRepo.AccountId.ToString()),
                new Claim(ClaimTypes.Name, accountFromRepo.Email)
            };
            //We create a key
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config. GetSection("AppSettings:Token").Value));
            //We sign then encrypt the key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            // now we create our token wiht the data
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            // We create a handler which will allow us to create a token based on the token descriptor provided
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            //This will contain our jwt that we return to our client
            var sessionDto = new SessionDto();
            sessionDto.Token = tokenHandler.WriteToken(token);

            return Ok(sessionDto);
        }
    }
    
}