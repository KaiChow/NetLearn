using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.ValueObjects;
using Zack.Commons;

namespace UserMgr.Domain.Entities
{
    public class User : IAgregateRoot
    {
        public Guid Id { get; set; }

        public PhoneNumber PhoneNumber { get; private set; }

        private string? PasswordHash;

        public UserAccessFail UserAccessFail { get; private set; }

        private User() { }

        public User(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
            this.Id = Guid.NewGuid();
            this.UserAccessFail = new UserAccessFail(this);
        }

        public bool Haspassword()
        {
            return !string.IsNullOrEmpty(this.PasswordHash);
        }

        public void ChangePassword(string password)
        {
            if (password.Length <= 3)
            {
                throw new ArgumentOutOfRangeException("密码长度必须大于3");
            }
            this.PasswordHash = HashHelper.ComputeMd5Hash(password);
        }

        public bool CheckPassword(string password)
        {
            return this.PasswordHash == HashHelper.ComputeMd5Hash(password);
        }

        public void ChangePhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

    }
}
