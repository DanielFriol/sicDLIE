using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Infra.Data;
using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mediator.Person.Delete
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IPersonReadRepository _personReadRepository;
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(IPersonReadRepository personReadRepository, IPersonWriteRepository personWriteRepository, IUnitOfWork uow)
        {
            _personReadRepository = personReadRepository;
            _personWriteRepository = personWriteRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var person = await _personReadRepository.GetById(request.Id);
            if (person == null) return new Response().AddError("Person not found");

            _personWriteRepository.Delete(person);

            await _uow.CommitAsync();

            return new Response();
        
        }
    }
}
