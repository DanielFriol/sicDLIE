using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.EF
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasData
                (
                   new Person(1, "Daniel", "Favaro Friol", "Pedro Chinelatto, 756, Iracemapolis-SP", "Brasil", "danielfriol@gmail.com", 20, true)
                );
        }
    }
}
