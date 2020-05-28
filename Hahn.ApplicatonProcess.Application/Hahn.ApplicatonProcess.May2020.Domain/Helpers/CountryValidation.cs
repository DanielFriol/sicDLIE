using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Helpers
{
    public class CountryValidation
    {
        private readonly HttpClient _client;

        public CountryValidation(HttpClient client)
        {
            _client = client;
        }

        public bool ValidateCountry(string countryName)
        {
            var url = $"https://restcountries.eu/rest/v2/{countryName}?fullText=true";
            var response =  _client.GetAsync(url).Result;
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
