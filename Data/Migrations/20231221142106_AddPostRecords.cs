using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPostRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Dodawanie rekordów do tabeli PostEntity
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Author", "PublicationDate", "Tags", "Comment" },
                values: new object[,]
                {
                    { 1, "przykladowa zawartosc", "Andzej", new DateTime(2000, 10, 10), "Tagi fsafa", "Pierwszy komentarz" },
                    { 2, "przykladowa druga zawartosc", "Maciek", new DateTime(2020, 11, 10), "Tagi dwa", "Drugi komentarz" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Usuwanie rekordów z tabeli PostEntity
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 });
        }
    }
}
