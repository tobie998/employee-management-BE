using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StaffManage.Data;
using StaffManage.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace StaffManage.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly StaffDbContext _context;
        private readonly AppSettings _appSetting;

        public AccountRepository(StaffDbContext context, IOptions<AppSettings> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;

        }


        public ApplicationUser SignInAsync(string account, string password)
        {
            var employee = _context.Users.SingleOrDefault(x => x.Username == account && x.Password == password);
            if (employee == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,employee.Username.ToString()),
                    new Claim(ClaimTypes.Role, employee.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            employee.Token = tokenHandler.WriteToken(token);
            employee.Password = "";

            return employee;

        }
    }
}
