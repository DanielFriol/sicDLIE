using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Contracts.Infra.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
