using AFL.Infrastructure.Core;
using AFL.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFL.Ordering.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order, long>
    {

    }
}
