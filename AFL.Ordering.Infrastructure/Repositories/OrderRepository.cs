using AFL.Infrastructure.Core;
using AFL.Ordering.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFL.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, long, OrderingContext>, IOrderRepository
    {
        public OrderRepository(OrderingContext context) : base(context)
        {

        }
        //这里可以定义特殊的方法
        public void AddIfExistElesUpdate()
        {
            //比如如果存在就增加，否则更新的逻辑

        }
    }
}
