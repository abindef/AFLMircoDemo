using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFL.Ordering.API.Application.IntergrationEvents
{
    public class OrderPaymentSucceededIntegrationEvent
    {
        public OrderPaymentSucceededIntegrationEvent(long orderId) => OrderId = orderId;
        public long OrderId { get; }
    }
}
