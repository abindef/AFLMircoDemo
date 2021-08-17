using AFL.Ordering.API.Application.IntergrationEvents;
using AFL.Ordering.Domain.OrderAggregate;
using AFL.Ordering.Infrastructure;
using AFL.Ordering.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFL.Ordering.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(OrderingContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Order).Assembly, typeof(Program).Assembly);
        }


        public static IServiceCollection AddDomainContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            //将OrderContext传入
            return services.AddDbContext<OrderingContext>(optionsAction);
        }

        //public static IServiceCollection AddInMemoryDomainContext(this IServiceCollection services)
        //{
        //    return services.AddDomainContext(builder => builder.UseInMemoryDatabase("domanContextDatabase"));
        //}
        //将连接字符串配置到 DomainContext
        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDomainContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }



        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISubscriberService, SubscriberService>();
            services.AddCap(options =>
            {
                options.UseEntityFramework<OrderingContext>();

                options.UseRabbitMQ(options =>
                {
                    configuration.GetSection("RabbitMQ").Bind(options);
                });
                //options.UseDashboard();
            });

            return services;
        }
    }
}
