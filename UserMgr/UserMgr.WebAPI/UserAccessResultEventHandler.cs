using MediatR;
using UserMgr.Domain;
using UserMgr.Domain.Events;
using UserMgr.Infrastracture;

namespace UserMgr.WebAPI
{
    public class UserAccessResultEventHandler : INotificationHandler<UserAccessResultEvent>
    {
        /**
        private readonly IUserRepository userRepository;
        private readonly UserDbContext userDbContext;
        public UserAccessResultEventHandler(IUserRepository _userRepository, UserDbContext userDbContext)
        {
            this.userRepository = _userRepository;
            this.userDbContext = userDbContext;
        }
        */
        private readonly IServiceScopeFactory _scopeFactory;

        public UserAccessResultEventHandler(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        
        public async Task Handle(UserAccessResultEvent notification, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            IUserRepository userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            UserDbContext userDbContext  =scope.ServiceProvider.GetRequiredService<UserDbContext>();
            await userRepository.AddNewLoginHistory(notification.PhoneNumber, $"登录结果是${notification.Result}");
            await userDbContext.SaveChangesAsync();
        }
    }
}
