using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApplication.Core.Repositories;
using WebApplication.Models;

namespace WebApplication.Persistence.Repositories
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tentity GetById(int Id)
        {
            return _context.Set<Tentity>().Find(Id);
        }

        public IEnumerable<Tentity> GetAll()
        {
            return _context.Set<Tentity>().ToList();
        }

        public void Add(Tentity Entity)
        {
            _context.Set<Tentity>().Add(Entity);
        }

        public void AddRange(IEnumerable<Tentity> Entities)
        {
            _context.Set<Tentity>().AddRange(Entities);
        }

        public void Remove(Tentity Entity)
        {
            _context.Set<Tentity>().Remove(Entity);
        }

        public void RemoveRange(IEnumerable<Tentity> Entities)
        {
            _context.Set<Tentity>().RemoveRange(Entities);
        }

        public IEnumerable<Tentity> Find(Expression<Func<Tentity, bool>> Predicate)
        {
            return _context.Set<Tentity>().Where(Predicate);
        }

        public Tentity SingleOrDefault(Expression<Func<Tentity, bool>> Predicate)
        {
            return _context.Set<Tentity>().FirstOrDefault(Predicate);
        }
    }
}