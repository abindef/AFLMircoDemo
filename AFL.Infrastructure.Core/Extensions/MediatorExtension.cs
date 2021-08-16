using AFL.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFL.Infrastructure.Core.Extensions
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx)
        {
            //从当前的DbContext中跟踪实体对象中获取相关的Event
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            //取出实体中的Event,=
            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
            //然后将Entity中DomainEvent清除
            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());
            //将取出的Event通过中间者逐条发送
            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);//通过MediatR将领域事件发出，然后找到相对应的Handler进行处理
        }
    }
}
