using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFL.Ordering.API.Application.IntergrationEvents
{
    public interface ISubscriberService
    {
        void OrderPaymentSucceeded(OrderPaymentSucceededIntegrationEvent @event);
    }
}
