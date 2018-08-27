using WebApplication.Core;
using WebApplication.Core.Repositories;
using WebApplication.Models;
using WebApplication.Persistence.Repositories;

namespace WebApplication.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IStatementRepository StatementRepository { get; set; }

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
            StatementRepository = new StatementRepository(_context);
        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}