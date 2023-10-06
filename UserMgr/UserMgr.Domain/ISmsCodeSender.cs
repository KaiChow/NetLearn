using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain
{
    /// <summary>
    /// 防腐层接口
    /// </summary>
    public interface ISmsCodeSender
    {
        Task SendAsync(PhoneNumber phoneNumber, string code);
    }
}
