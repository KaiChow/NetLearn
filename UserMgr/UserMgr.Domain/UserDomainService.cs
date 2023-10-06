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
    public class UserDomainService
    {
        private IUserRepository userRepository;
        private ISmsCodeSender smsSender;

        public UserDomainService(IUserRepository userRepository, ISmsCodeSender smsCodeSender)
        {
            this.userRepository = userRepository;
            this.smsSender = smsCodeSender;
        }

        public void ResetAccessFail(User user)
        {
            user.UserAccessFail.Reset();
        }

        public bool IsLockOut(User user)
        {
            return user.UserAccessFail.IsLockOut();
        }

        public void AccessFail(User user)
        {
            user.UserAccessFail.Fail();
        }


        public async Task<UserAccessResult> CheckPassword(PhoneNumber phoneNumber, string password)
        {

            UserAccessResult result = new UserAccessResult();
            var user = await userRepository.FindOneAsync(phoneNumber);
            if (user == null)
            {
                result = UserAccessResult.PhoneNumberNotFind;
            }
            else if (IsLockOut(user))
            {

                result = UserAccessResult.Lockout;
            }
            else if (user.Haspassword() == false)
            {
                result = UserAccessResult.NoPassword;
            }
            else if (user.CheckPassword(password))
            {
                result = UserAccessResult.OK;
            }
            else
            {
                result = UserAccessResult.PasswordError;
            }
            if (user != null)
            {

                if (result == UserAccessResult.OK)
                {
                    ResetAccessFail(user);
                }
                else
                {
                    AccessFail(user);
                }
            }

            await userRepository.PublishEventAsync(new UserAccessResultEvent(phoneNumber, result));

            return result;
        }


        public async Task<CheckCodeResult> CheckPhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            // CheckCodeResult result = new CheckCodeResult();
            User? user = await userRepository.FindOneAsync(phoneNumber);
            if (user == null)
            {
                return CheckCodeResult.PhoneNumberNotFound;
            }
            else if (IsLockOut(user))
            {

                return CheckCodeResult.Lockout;
            }

            string? codeInServer = await userRepository.FindPhoneNumberCodeAsync(phoneNumber);

            if (codeInServer == null)
            {
                return CheckCodeResult.CodeError;

            }
            if (codeInServer == code)
            {
                return CheckCodeResult.OK;
            }
            else
            {
                // 记录一次登录失败
                AccessFail(user);
                return CheckCodeResult.CodeError;
            }

        }
    }
}
