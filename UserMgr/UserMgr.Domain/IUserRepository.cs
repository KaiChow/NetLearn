using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.Entities;
using UserMgr.Domain.Events;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain
{
    public interface IUserRepository
    {
        public Task<User?> FindOneAsync(PhoneNumber phoneNumber);
        public Task<User?> FindOneAsync(Guid userId);

        public Task AddNewLoginHistory(PhoneNumber phoneNumber, string message);

        public Task PublishEventAsync(UserAccessResultEvent enentData);

        public Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code);

        public Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber);

    }
}
