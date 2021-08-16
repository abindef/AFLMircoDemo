using AFL.Ordering.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFL.Ordering.Infrastructure.EntityConfigurations
{
    class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("order");
            builder.Property(p => p.UserId).HasMaxLength(20);//设置长度为20
            builder.Property(p => p.UserName).HasMaxLength(30);
            //导航属性
            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
                a.Property(p => p.City).HasMaxLength(20);//生成字段 Address_City,在Order表中
                a.Property(p => p.Street).HasMaxLength(50);
                a.Property(p => p.ZipCode).HasMaxLength(10);
            });
        }
    }
}
