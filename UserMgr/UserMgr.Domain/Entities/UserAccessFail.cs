using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMgr.Domain.Entities
{
    public record UserAccessFail:IAgregateRoot
    {
        public Guid Id { get; init; }

        public User User { get; init; }

        public Guid UserId { get; init; }

        private bool isLockOut;

        public DateTime? LockEnd { get; private set; }

        public int AccessFailCount { get; private set; }

        public UserAccessFail() { }

        public UserAccessFail(User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;
        }

        public void Reset()
        {
            this.AccessFailCount = 0;
            this.LockEnd = null;
            this.isLockOut = false;
        }

        public void Fail()
        {
            this.AccessFailCount++;
            if (this.AccessFailCount >= 3)
            {
                this.LockEnd = DateTime.Now.AddMinutes(5);
                this.isLockOut = true;
            }

        }

        public bool IsLockOut()
        {
            if (this.isLockOut)
            {
                if (DateTime.Now > this.LockEnd) // 超过锁定时间
                {
                    Reset();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
