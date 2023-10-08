using Microsoft.EntityFrameworkCore;
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

        public Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task PublishEventAsync(UserAccessResultEvent enentData)
        {
            throw new NotImplementedException();
        }

        public Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            throw new NotImplementedException();
        }
    }
}
