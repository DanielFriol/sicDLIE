using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mediator.Person.Update
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithMessage("Id must be greater than 0");

            RuleFor(x => x.Name)
               .MinimumLength(5)
               .MaximumLength(50)
               .WithMessage("Name must be greater than 5 and lower than 200");

            RuleFor(x => x.FamilyName)
                .MinimumLength(5)
                .MaximumLength(80)
                .WithMessage("FamilyName must be greater than 5 and lower than 200");

            RuleFor(x => x.Address)
                .MinimumLength(10)
                .MaximumLength(200)
                .WithMessage("Adress must be greater than 10 and lower than 200");


            RuleFor(x => x.Hired)
                .NotNull()
                .WithMessage("Hired can not be null");

            RuleFor(x => x.Age)
                .GreaterThan(20)
                .LessThan(60);
        }
    }
}
