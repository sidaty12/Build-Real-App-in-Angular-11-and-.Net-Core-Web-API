using API.Dtos;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly IUnitOfWork uow;

    public AccountController(IUnitOfWork uow)
    {
      this.uow = uow;
    }


    // api/account/login
    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginReqDto loginReq)
    {

      var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

      if(user == null)
      {
        return Unauthorized();
      }

      var loginRes = new LoginResDto();
      loginRes.UserName = user.Username;
      loginRes.Token = "Token to be generated";

      return Ok(loginRes);
    }
  }
}
