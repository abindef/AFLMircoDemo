using AFL.Domain;
using AFL.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFL.Ordering.Domain.Events
{
    public class OrderCreatedDomainEvent : IDomainEvent
    {
        //接收领域事件的处理在应用层 OrderCreatedDomainEventHandler ，OrderCreatedDomainEvent作为入参传给OrderCreatedDomainEventHandler的Handler方法
        public Order Order { get; private set; }
        public OrderCreatedDomainEvent(Order order)
        {
            this.Order = order;
        }
    }
}
