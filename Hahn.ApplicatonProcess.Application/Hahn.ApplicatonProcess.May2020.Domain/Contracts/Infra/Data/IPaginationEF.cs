using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Contracts.Infra.Data
{
    public interface IPaginationEF<TEntity> where TEntity : Entity
    {
        int Total { get; }
        Task<IEnumerable<TEntity>> GetAsync(int skip, int take, Expression<Func<TEntity, bool>> filter = null);

        Task<IEnumerable<TEntity>> GetAsync(int skip, int take,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
