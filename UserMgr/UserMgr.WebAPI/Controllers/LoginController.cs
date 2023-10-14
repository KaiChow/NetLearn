using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMgr.Domain;
using UserMgr.Infrastracture;

namespace UserMgr.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDomainService _userDomainService;
        public LoginController(UserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        [UnitOfWork(typeof(UserDbContext))] // 因为可能有数据的操作
        public async Task<IActionResult> LoginByPhoneAndPassword(LoginByPhoneAndPasswordRequest req)
        {
            if (req.passwosrd.Length <= 3)
            {
                return BadRequest("密码长度必须大于3");
            }
            var result = await _userDomainService.CheckPassword(req.phoneNum, req.passwosrd);

            switch (result)
            {
                case UserAccessResult.OK:
                    return Ok("登录成功");
                case UserAccessResult.PasswordError:
                case UserAccessResult.NoPassword:
                case UserAccessResult.PhoneNumberNotFind:
                    return BadRequest("登录失败");
                case UserAccessResult.Lockout:
                    return BadRequest("账号被锁定");
                default:
                    throw new ApplicationException("未知值");
            }
        }
    }
}
