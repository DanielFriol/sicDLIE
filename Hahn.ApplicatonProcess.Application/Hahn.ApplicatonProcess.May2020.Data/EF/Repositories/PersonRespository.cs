using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.EF.Repositories
{
    public class PersonReadRespository : ReadRepositoryEF<Person>, IPersonReadRepository
    {
        public PersonReadRespository(ApplicationProjectDataContext ctx) : base(ctx)
        {
        }

        public int Total { get; private set; }

        public async Task<IEnumerable<Person>> GetAsync(int skip, int take, Expression<Func<Person, bool>> filter = null)
        {
            var query = _db.AsQueryable();

            if (filter != null) query = query.Where(filter);

            Total = query.Count();

            if (Total == 0) return null;

            return await query.Skip(skip).Take(take).AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<Person>> GetAsync(int skip, int take, Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, params Expression<Func<Person, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetById(long id)
        {
            return await _db.FirstOrDefaultAsync(x => x.Id == id);
        }
    }


    public class PersonWriteRespository : WriteRepositoryEF<Person>, IPersonWriteRepository
    {
        public PersonWriteRespository(ApplicationProjectDataContext ctx) : base(ctx)
        {
        }
        
    }
}
