﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Infrastracture
{
    public class MockSmsCodeSender : ISmsCodeSender
    {
        public Task SendAsync(PhoneNumber phoneNumber, string code)
        {
            Console.WriteLine($"向{phoneNumber.RegionNumber}-{phoneNumber.Number}发送验证码{code}");
            return Task.CompletedTask;
        }
    }
}
