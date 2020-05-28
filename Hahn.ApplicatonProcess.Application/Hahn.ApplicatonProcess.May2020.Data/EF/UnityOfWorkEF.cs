using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.EF
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly ApplicationProjectDataContext _ctx;
        public UnitOfWorkEF(ApplicationProjectDataContext ctx) => _ctx = ctx;

        public void Commit() => _ctx.SaveChanges();

        public async Task CommitAsync() => await _ctx.SaveChangesAsync();

        public Task RollBackAsync() => throw new NotImplementedException();
    }
}
