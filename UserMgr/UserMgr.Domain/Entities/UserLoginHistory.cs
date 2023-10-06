using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain.Entities
{
    public class UserLoginHistory : IAgregateRoot
    {
        public long Id { get; init; }
        /// <summary>
        /// 跨聚合 独立的微服务 为了方便拆分
        /// </summary>
        public Guid? UserId { get; init; }

        public PhoneNumber PhoneNumber { get; init; }

        public DateTime CreatedDate { get; init; }

        public string Message { get; init; }

        public UserLoginHistory() { }
        public UserLoginHistory(Guid? userId, PhoneNumber phoneNumber, string message)
        {
            this.UserId = userId;
            this.PhoneNumber = phoneNumber;
            this.Message = message;
            this.CreatedDate = DateTime.Now;

        }
    }
}
