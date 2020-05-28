using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Entities
{
    public class Person : Entity
    {
        public Person(long id, string name, string familyName, string address, string countryOfOrigin, string emailAdress, int age, bool hired)
        {
            Id = id;
            Name = name;
            FamilyName = familyName;
            Address = address;
            CountryOfOrigin = countryOfOrigin;
            EmailAdress = emailAdress;
            Age = age;
            Hired = hired;
        }

        public Person(string name, string familyName, string address, string countryOfOrigin, string emailAdress, int age, bool hired)
        {
            Name = name;
            FamilyName = familyName;
            Address = address;
            CountryOfOrigin = countryOfOrigin;
            EmailAdress = emailAdress;
            Age = age;
            Hired = hired;
        }

        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAdress { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
        
        public void Update (string name, string familyName, string adress, int age, bool hired)
        {
            Name = name;
            FamilyName = familyName;
            Address = adress;
            Age = age;
            Hired = hired;
        }
    }
}