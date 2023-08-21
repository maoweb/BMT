using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BMT_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CompanyName", "Email", "Firstname", "Lastname", "Mobile" },
                values: new object[,]
                {
                    { 1, "ABC Company", "johndoe@abc.com", "John", "Doe", "099824788822" },
                    { 2, "ABC Company", "janedoe@abc.com", "Jane", "Doe", "099924781211" },
                    { 3, "JDC Company", "juandelacruz@jdc.com", "Juan", "Dela Cruz", "099824781111" }
                });

            migrationBuilder.InsertData(
                table: "LocalUsers",
                columns: new[] { "Id", "Name", "Password", "Role", "UserName" },
                values: new object[] { 1, "Admin", "admin123", "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "LocalUsers");
        }
    }
}
