using System.Collections.Generic;
using System.Linq;
using WebApplication.Core.Repositories;
using WebApplication.DTO;
using WebApplication.Models;

namespace WebApplication.Persistence.Repositories
{
    public class StatementRepository : Repository<Statement>, IStatementRepository
    {
        public StatementRepository(ApplicationDbContext context) : base(context)
        {
        }

        public int Count(StatementFilter Filters)
        {
            if (Filters == null)
                return 0;

            IQueryable<Statement> Statements = _context.Statements;

            if (!string.IsNullOrWhiteSpace(Filters.Title))
            {
                Statements =  Statements.Where(s => s.Title.StartsWith(Filters.Title)
                || s.Title.Contains(Filters.Title)
                || s.Title.EndsWith(Filters.Title));
            }

            return Statements.Count();
        }



        public IEnumerable<Statement> GetAll(int PageNumber, int ItemsPerPage, StatementFilter Filters)
        {
            IQueryable<Statement> Statements = _context.Statements;

            Statements = ApplyFilters(Statements, Filters);

            Statements = Statements.OrderBy(s => s.Id)
                .Skip((--PageNumber) * ItemsPerPage)
                .Take(ItemsPerPage);

            return Statements.ToList();
        }




        private IQueryable<Statement> ApplyFilters(IQueryable<Statement> Statements, StatementFilter Filters)
        {
            if (Filters == null)
                return Statements;

            if (!string.IsNullOrWhiteSpace(Filters.Title))
            {
                Statements = Statements.Where(s => s.Title.StartsWith(Filters.Title)
                || s.Title.Contains(Filters.Title)
                || s.Title.EndsWith(Filters.Title));
            }

            return Statements;
        }
    }
}