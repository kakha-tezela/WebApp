using System;
using WebApplication.Core.Repositories;

namespace WebApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStatementRepository StatementRepository { get; set; }
        int Complete();
    }
}
