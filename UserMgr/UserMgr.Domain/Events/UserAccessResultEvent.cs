using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.ValueObjects;

namespace UserMgr.Domain.Events
{
    public record class UserAccessResultEvent(PhoneNumber PhoneNumber, UserAccessResult Result) : INotification;

}
