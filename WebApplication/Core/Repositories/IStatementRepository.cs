using WebApplication.Models;
using WebApplication.DTO;
using System.Collections.Generic;

namespace WebApplication.Core.Repositories
{
    public interface IStatementRepository : IRepository<Statement>
    {
        IEnumerable<Statement> GetAll(int PageNumber, int ItemsPerPage, StatementFilter Filters);
        int Count(StatementFilter Filters);
    }
}
