using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mediator.Person.Delete
{
    public class Request : IRequest<Response>
    {
        public long Id { get; set; }
    }
}
