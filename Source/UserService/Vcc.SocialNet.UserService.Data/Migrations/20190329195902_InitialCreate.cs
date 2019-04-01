using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vcc.SocialNet.UserService.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    Position = table.Column<short>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 15, nullable: true),
                    HomePhone = table.Column<string>(maxLength: 15, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    Province = table.Column<string>(maxLength: 2, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "CellPhone", "City", "DateOfBirth", "Email", "FirstName", "Gender", "HomePhone", "LastName", "Position", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "160 Borrows Street", "4168493938", "Toronto", new DateTime(1972, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "joon.choi@gmail.com", "Joon", "Male", "4169026859", "Choi", (short)8, "L3J 2S9", "ON" },
                    { 2, "160 Borrows Street", "4168493938", "Toronto", new DateTime(1972, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "joon.choi@gmail.com", "Joon2", "Male", "4169026859", "Choi", (short)8, "L3J 2S9", "ON" },
                    { 3, "160 Borrows Street", "4168493938", "Toronto", new DateTime(1972, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "joon.choi@gmail.com", "Joon3", "Male", "4169026859", "Choi", (short)8, "L3J 2S9", "ON" },
                    { 4, "160 Borrows Street", "4168493938", "Toronto", new DateTime(1972, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "joon.choi@gmail.com", "Joon4", "Male", "4169026859", "Choi", (short)8, "L3J 2S9", "ON" },
                    { 5, "160 Borrows Street", "4168493938", "Toronto", new DateTime(1972, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "joon.choi@gmail.com", "Joon5", "Male", "4169026859", "Choi", (short)8, "L3J 2S9", "ON" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
