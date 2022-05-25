using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class addmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartnerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partner_PartnerType_PartnerTypeId",
                        column: x => x.PartnerTypeId,
                        principalTable: "PartnerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PartnerType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Supplier" });

            migrationBuilder.InsertData(
                table: "PartnerType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Customer" });

            migrationBuilder.CreateIndex(
                name: "IX_Partner_PartnerTypeId",
                table: "Partner",
                column: "PartnerTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "PartnerType");
        }
    }
}
