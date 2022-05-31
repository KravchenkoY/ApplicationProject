using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class addPartners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partner_PartnerType_PartnerTypeId",
                table: "Partner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartnerType",
                table: "PartnerType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partner",
                table: "Partner");

            migrationBuilder.RenameTable(
                name: "PartnerType",
                newName: "PartnerTypes");

            migrationBuilder.RenameTable(
                name: "Partner",
                newName: "Partners");

            migrationBuilder.RenameIndex(
                name: "IX_Partner_PartnerTypeId",
                table: "Partners",
                newName: "IX_Partners_PartnerTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartnerTypes",
                table: "PartnerTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partners",
                table: "Partners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners",
                column: "PartnerTypeId",
                principalTable: "PartnerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_PartnerTypes_PartnerTypeId",
                table: "Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartnerTypes",
                table: "PartnerTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partners",
                table: "Partners");

            migrationBuilder.RenameTable(
                name: "PartnerTypes",
                newName: "PartnerType");

            migrationBuilder.RenameTable(
                name: "Partners",
                newName: "Partner");

            migrationBuilder.RenameIndex(
                name: "IX_Partners_PartnerTypeId",
                table: "Partner",
                newName: "IX_Partner_PartnerTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartnerType",
                table: "PartnerType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partner",
                table: "Partner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partner_PartnerType_PartnerTypeId",
                table: "Partner",
                column: "PartnerTypeId",
                principalTable: "PartnerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
