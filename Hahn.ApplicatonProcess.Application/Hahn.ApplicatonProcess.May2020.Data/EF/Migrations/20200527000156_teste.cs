using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hahn.ApplicatonProcess.May2020.Data.EF.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    FamilyName = table.Column<string>(type: "varchar(80)", nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "varchar(50)", nullable: true),
                    EmailAdress = table.Column<string>(type: "varchar(200)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Hired = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
