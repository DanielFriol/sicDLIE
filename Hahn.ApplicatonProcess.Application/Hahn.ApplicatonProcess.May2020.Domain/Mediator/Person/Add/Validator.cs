using FluentValidation;
using Hahn.ApplicatonProcess.May2020.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Mediator.Person.Add
{
    public class Validator : AbstractValidator<Request>
    {
      
        public Validator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(5)
                .MaximumLength(50)
                .WithMessage("Name must be greater than 5 and lower than 50");

            RuleFor(x => x.FamilyName)
                .MinimumLength(5)
                .MaximumLength(80)
                .WithMessage("FamilyName must be greater than 5 and lower than 80");

            RuleFor(x => x.Address)
                .MinimumLength(10)
                .MaximumLength(200)
                .WithMessage("Adress must be greater than 10 and lower than 200");

            RuleFor(x => x.CountryOfOrigin).Must(countryOfOrigin => ValidateCountry(countryOfOrigin))
                .WithMessage("Country not Valid");

            RuleFor(x => x.EmailAdress)
                .EmailAddress()
                .WithMessage("Email must be valid")
                .NotEmpty()
                .WithMessage("Email must not be empty");

            RuleFor(x => x.Hired)
                .NotNull()
                .WithMessage("Hired can not be null");

            RuleFor(x => x.Age)
                .GreaterThan(19)
                .LessThan(61);

        }

        public bool ValidateCountry (string countryName)
        {
            var _client = new HttpClient();
            var url = $"https://restcountries.eu/rest/v2/name/{countryName}?fullText=true";
            var response = _client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
   
}
