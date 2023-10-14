using UserMgr.Domain.ValueObjects;

namespace UserMgr.WebAPI.Controllers
{
    public record LoginByPhoneAndPasswordRequest(PhoneNumber phoneNum, string passwosrd)
    {
    }
}
