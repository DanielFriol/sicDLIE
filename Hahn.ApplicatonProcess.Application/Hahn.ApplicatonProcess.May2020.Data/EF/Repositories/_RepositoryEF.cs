using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.EF.Repositories
{
    public abstract class ReadRepositoryEF<TEntity> : IReadRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ApplicationProjectDataContext _ctx;
        protected readonly DbSet<TEntity> _db;
        public ReadRepositoryEF(ApplicationProjectDataContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _db.AsNoTracking().ToList();
        }

        public TEntity Get(object id)
        {
            return _db.Find(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await _db.FindAsync(id);
        }
    }

    public abstract class WriteRepositoryEF<TEntity> : IWriteRepository<TEntity>
       where TEntity : Entity
    {
        private readonly ApplicationProjectDataContext _ctx;
        protected readonly DbSet<TEntity> _db;
        public WriteRepositoryEF(ApplicationProjectDataContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _db.Update(entity);
        }
    }
}
