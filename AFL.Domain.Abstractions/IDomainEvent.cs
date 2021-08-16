using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFL.Domain
{
    //标记某个事件是否是领域事件，INotification是MediatR中的接口，用来事件传递
    public interface IDomainEvent : INotification
    {
    }
}
