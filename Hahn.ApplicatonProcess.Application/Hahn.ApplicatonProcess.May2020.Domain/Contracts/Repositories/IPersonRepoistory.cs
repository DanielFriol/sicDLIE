using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Infra.Data;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Contracts.Repositories
{
    public interface IPersonReadRepository : IReadRepository<Person>, IPaginationEF<Person>
    {
        Task<Person> GetById(long id);
    }

    public interface IPersonWriteRepository : IWriteRepository<Person>
    {
    }
}
