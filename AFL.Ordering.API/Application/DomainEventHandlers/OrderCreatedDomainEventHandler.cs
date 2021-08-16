using AFL.Domain;
using AFL.Ordering.API.Application.IntergrationEvents;
using AFL.Ordering.Domain.Events;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AFL.Ordering.API.Application.DomainEventHandlers
{
    public class OrderCreatedDomainEventHandler : IDomainEventHandler<OrderCreatedDomainEvent>
    {
        ICapPublisher _capPublisher;
        public OrderCreatedDomainEventHandler(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        public async Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            //创建新的订单时像EventBus发布一条事件，叫OrderCreated
            //保存完订单后，再发布事件，让其它领域进行相关的处理，比如发送通知等
            await _capPublisher.PublishAsync("OrderCreated", new OrderCreatedIntegrationEvent(notification.Order.Id));
        }
    }
}
