using UserMgr.Domain.ValueObjects;

namespace UserMgr.WebAPI.Controllers
{
    public record AddUserRequest(PhoneNumber phoneNum, string password);
}
