using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.EF.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasColumnType("varchar(50)");
            builder.Property(p => p.FamilyName).HasColumnType("varchar(80)");
            builder.Property(p => p.Address).HasColumnType("varchar(200)");
            builder.Property(p => p.EmailAdress).HasColumnType("varchar(200)");
            builder.Property(p => p.CountryOfOrigin).HasColumnType("varchar(50)");
            builder.Property(p => p.Age).HasColumnType("int");
            builder.Property(p => p.Hired).HasColumnType("tinyint");




        }
    }
}
