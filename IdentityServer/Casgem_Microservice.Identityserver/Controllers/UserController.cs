using Casgem_Microservice.Identityserver.Dtos;
using Casgem_Microservice.Identityserver.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Casgem_Microservice.Identityserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SingUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email,
                City = signUpDto.City 
            };
            var result=await _userManager.CreateAsync(user,signUpDto.Password);
            if(result.Succeeded)
            {
                return Ok("Kullanıcı kayıtı oluştu");
            }
            else
            {
                return Ok("Bir hata oluştu");
            }
        }
    }
}
