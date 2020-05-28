using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Infra.Data;
using Hahn.ApplicatonProcess.May2020.Domain.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mediator.Person.Add
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IUnitOfWork _uow;

        public Handler(IPersonWriteRepository personWriteRepository, IUnitOfWork uow)
        {
            _personWriteRepository = personWriteRepository;
            _uow = uow;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var person = new Entities.Person(request.Name, request.FamilyName, request.Address, request.CountryOfOrigin, request.EmailAdress,request.Age, request.Hired);

            _personWriteRepository.Add(person);

            await _uow.CommitAsync();

            return new Response(person);
        }
    }
}
