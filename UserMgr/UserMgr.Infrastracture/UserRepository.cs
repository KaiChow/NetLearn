using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain;
using UserMgr.Domain.Entities;
using UserMgr.Domain.Events;
using UserMgr.Domain.ValueObjects;
using Zack.Infrastructure.EFCore;

namespace UserMgr.Infrastracture
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        // 分布式的缓存，有效期的自动处理有效期的问题
        private readonly IDistributedCache distributedCache;
        //事件发布
        private readonly IMediator mediator;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task AddNewLoginHistory(PhoneNumber phoneNumber, string message)
        {
            User? user = await FindOneAsync(phoneNumber);
            Guid? userId = null;
            if (user != null)
            {
                userId = user.Id;
            }
            _userDbContext.UserLoginHistories.Add(new UserLoginHistory(userId, phoneNumber, message));
        }

        public async Task<User?> FindOneAsync(PhoneNumber phoneNumber)
        {
            /**
            return _userDbContext.Users.SingleOrDefault(u => u.PhoneNumber.Number == phoneNumber.Number && u.PhoneNumber.RegionNumber == phoneNumber.RegionNumber);
        */

            User? user = await _userDbContext.Users.SingleOrDefaultAsync(ExpressionHelper.MakeEqual((User c) => c.PhoneNumber, phoneNumber));

            return user;

        }

        public async Task<User?> FindOneAsync(Guid userId)
        {
            User? user = await _userDbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber)
        {
            string Key = $"PhoneNumber_${phoneNumber.RegionNumber}_{phoneNumber.Number}";
            string? code = await distributedCache.GetStringAsync(Key);
            // 取了字后就移除
            distributedCache.Remove(Key);
            return code;
        }

        public Task PublishEventAsync(UserAccessResultEvent enentData)
        {
          return  mediator.Publish(enentData);
        }

        public  Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            string Key = $"PhoneNumber_${phoneNumber.RegionNumber}_{phoneNumber.Number}";
            // 有效期5分钟
            return distributedCache.SetStringAsync(Key, code, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
        }
    }
}
