using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace AFL.Infrastructure.Core
{
    public interface ITransaction
    {
        //获取当前事务
        IDbContextTransaction GetCurrentTransaction();
        //是否开启事务
        bool HasActiveTransaction { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionAsync(IDbContextTransaction transaction);

        void RollbackTransaction();
    }
}
