using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vcc.SocialNet.UserService.Data.Entities;
using Vcc.SocialNet.UserService.Data.Repository;
using Vcc.SocialNet.UserService.Service.Attributes;
using Vcc.SocialNet.UserService.Service.Configuration;
using Vcc.SocialNet.UserService.Service.ViewModels;

namespace Vcc.SocialNet.UserService.Service.Controllers
{
    /// <summary>
    /// Api controller that provide authentication/authorization related operations
    /// </summary>
    //[Route("auth")]
    public class AuthController : ApiControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private IMemberRepository _repo;
        private IMapper _mapper;
        protected override string ClassName
        {
            get { return "AuthController"; }
        }
        protected override ILogger Logger
        {
            get { return _logger; }
        }
        private readonly IOptions<SecuritySettings> _securitySettings;

        public AuthController(
            IMemberRepository memberRepository,
            IMapper mapper,
            ILogger<AuthController> logger,
            IOptions<SecuritySettings> securitySettings)
        {
            _repo = memberRepository;
            _mapper = mapper;
            _logger = logger;
            _securitySettings = securitySettings;
        }

        /// <summary>
        /// Authenticate user credentials
        /// </summary>
        /// <param name="userId">The id of the user to retrieve</param>
        /// <response code="200">Expected response to a valid request</response>
        /// <response code="0">unexpected error</response>
        [HttpPost]
        [ApiVersion("1.0")]
        [Route("auth/authenticate")]
        [ValidateModelState]
        [SwaggerOperation("Authenticate")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<User>), description: "Expected response to a valid request")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public async virtual Task<ActionResult<AuthResponse>> Login([FromBody][Required]AuthRequest request)
        {
            LogEnter("Login", request.UserName, request.Password);

            ActionResult<AuthResponse> result;
            AuthResponse response = new AuthResponse();
            MemberEntity member = await _repo.GetMemberByEmailAsync(request.UserName);
            if (member != null && member.Password == request.Password)
            {                
                response.Token = generateJwtToken(member);
                response.Success = true;
                result = Ok(response);               
            }
            else
            {
                response.Success = false;
                result = Ok(response);
            }

            LogExit("Login", response.Token, response.Success);
            return result;
        }

        /// <summary>
        /// Generates a Jwt authentication token
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private string generateJwtToken(MemberEntity member)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            // get configured secret to salt the token          
            byte[] key = Encoding.ASCII.GetBytes(_securitySettings.Value.AuthTokenSecret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                // add claims
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, member.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            // a different way to generate a token
            //// get configured secret to salt the token          
            //SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securitySettings.Value.AuthTokenSecret));
            //SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //// prepare claims
            //Claim[] claims = new[] {
            //    new Claim(ClaimTypes.Name, member.Id.ToString())
            //};

            //// create Jwt token
            //JwtSecurityToken token = new JwtSecurityToken(
            //    issuer: "sn.vccc.ca",
            //    audience: "sn.vccc.ca",
            //    claims: claims,
            //    expires: DateTime.Now.AddMinutes(30),
            //    signingCredentials: creds
            //);
            //string tokenString = tokenHandler.WriteToken(tokenDescriptor);
            //return tokenString;
        }
    }
}
