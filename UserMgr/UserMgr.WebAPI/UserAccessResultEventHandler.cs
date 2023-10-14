using MediatR;
using UserMgr.Domain;
using UserMgr.Domain.Events;
using UserMgr.Infrastracture;

namespace UserMgr.WebAPI
{
    public class UserAccessResultEventHandler : INotificationHandler<UserAccessResultEvent>
    {
        private readonly IUserRepository userRepository;
        private readonly UserDbContext userDbContext;
        public UserAccessResultEventHandler(IUserRepository _userRepository, UserDbContext userDbContext)
        {
            this.userRepository = _userRepository;
            this.userDbContext = userDbContext;
        }
        public async Task Handle(UserAccessResultEvent notification, CancellationToken cancellationToken)
        {
            await userRepository.AddNewLoginHistory(notification.PhoneNumber, $"登录结果是${notification.Result}");
            await userDbContext.SaveChangesAsync();
        }
    }
}
