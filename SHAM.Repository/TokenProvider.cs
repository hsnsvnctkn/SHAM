using Microsoft.IdentityModel.Tokens;
using SHAM.Domain.Entities;
using SHAM.Repository.Contracts;
using SHAM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SHAM.Repository
{
    public class TokenProvider : GenericRepository<Employee>, ITokenProvider
    {
        public TokenProvider(IUnitOfWork uow)
            : base(uow)
        {

        }

        public string LoginUser(string Email, string Password)
        {
            var user = GetUsers().SingleOrDefault(x => x.EMAIL == Email);

            if (user == null)
                return null;

            if (Password == user.PASSWORD)
            {
                var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
                var JWToken = new JwtSecurityToken(
                    issuer: "http://localhost:45092/",
                    audience: "http://localhost:45092/",
                    claims: GetUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }

        private List<UserDto> GetUsers()
        {
            var users = _context.Employees.Select(e => new UserDto
            {
                ID = e.ID.ToString(),
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                EMAIL = e.EMPLOYEE_MAIL,
                PASSWORD = e.PASSWORD,
                ROLE = e.ROLE,
                ADRESS = e.EMPLOYEE_ADRESS
            }).ToList();

            return users;
        }

        private IEnumerable<Claim> GetUserClaims(UserDto user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.NAME);
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Surname, user.SURNAME);
            claims.Add(_claim);
            _claim = new Claim("ID", user.ID);
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Email, user.EMAIL);
            claims.Add(_claim);
            _claim = new Claim("ADRESS", user.ADRESS);
            claims.Add(_claim);
            _claim = new Claim(user.ROLE, user.ROLE);
            claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }

    }
}
