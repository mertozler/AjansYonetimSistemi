using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updateDemandtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerProductsID",
                table: "Demands",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c331617e-aa6a-47e9-94ef-66269470ce2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3023083f-193e-4420-80c0-94905044e7d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "65173d6b-dbcf-440a-ae83-79f36db01703");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "d7f8d24b-c5b6-4b20-9e57-c54f8ab8db13");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "244650c7-dd05-4abb-96ea-b51197dc472b");

            migrationBuilder.CreateIndex(
                name: "IX_Demands_CustomerProductsID",
                table: "Demands",
                column: "CustomerProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Demands_CustomerProducts_CustomerProductsID",
                table: "Demands",
                column: "CustomerProductsID",
                principalTable: "CustomerProducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demands_CustomerProducts_CustomerProductsID",
                table: "Demands");

            migrationBuilder.DropIndex(
                name: "IX_Demands_CustomerProductsID",
                table: "Demands");

            migrationBuilder.DropColumn(
                name: "CustomerProductsID",
                table: "Demands");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c7e7ea19-be0a-4020-8e53-ce4472c8bee6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d6d28f33-487a-4e3e-9f3c-a335047ddc04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f8acd1f0-5b8e-4f8a-b326-aa6ec2fce000");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "b7a3a7e0-c90c-4b45-a895-61656b82df64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "e1f2f34a-b315-413c-bce2-2544d89bc82f");
        }
    }
}
