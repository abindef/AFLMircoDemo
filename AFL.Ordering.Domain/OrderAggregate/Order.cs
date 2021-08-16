using AFL.Domain;
using AFL.Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFL.Ordering.Domain.OrderAggregate
{
    public class Order : Entity<long>, IAggregateRoot
    {
        public string UserId { get; private set; }

        public string UserName { get; private set; }

        public Address Address { get; private set; }

        public int ItemCount { get; private set; }

        protected Order()
        { }

        public Order(string userId, string userName, int itemCount, Address address)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Address = address;
            this.ItemCount = itemCount;
            //定义领域事件，构造函数的入参就是Order
            this.AddDomainEvent(new OrderCreatedDomainEvent(this)); //Tips:领域事件的构造和添加都应该在领域模型的实体内完成，不应该被外部代码调用创建
        }


        public void ChangeAddress(Address address)
        {
            //此处可以增加地址判断逻辑，新地址与旧地址是否相隔太远等逻辑判断
            this.Address = address;
            //this.AddDomainEvent(new OrderAddressChangedDomainEvent(this));
        }



    }
}
