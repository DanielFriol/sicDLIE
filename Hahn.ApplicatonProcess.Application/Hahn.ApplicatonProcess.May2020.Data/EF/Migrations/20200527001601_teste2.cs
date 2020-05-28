using Microsoft.EntityFrameworkCore.Migrations;

namespace Hahn.ApplicatonProcess.May2020.Data.EF.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "Age", "CountryOfOrigin", "EmailAdress", "FamilyName", "Hired", "Name" },
                values: new object[] { 1L, "Pedro Chinelatto, 756, Iracemapolis-SP", 20, "Brasil", "danielfriol@gmail.com", "Favaro Friol", (sbyte)1, "Daniel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
