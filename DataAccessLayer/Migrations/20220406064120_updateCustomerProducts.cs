using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updateCustomerProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "CustomerProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "CustomerProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ccadf53b-e002-43c5-aa96-454a161b94f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8504743e-d3ec-4dc6-be51-1d45465e9f02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "483aeda8-36ae-4cce-9d48-4ebb3f1f3bba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "48a65f05-72f7-407c-8371-a028416d2482");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "c90c4541-aa66-4485-9c8e-f40380a466cf");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_ServiceID",
                table: "CustomerProducts",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_Services_ServiceID",
                table: "CustomerProducts",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_Services_ServiceID",
                table: "CustomerProducts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProducts_ServiceID",
                table: "CustomerProducts");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "CustomerProducts");

            migrationBuilder.DropColumn(
                name: "description",
                table: "CustomerProducts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c4879ab4-ae4c-4be6-ad3b-6f6d70ebbaba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f736c9fa-7d25-4c4d-b126-4f4a03ad9627");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "650d1f55-63d4-48f0-a1fb-1f4ecbfdba0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "413879f0-4373-4f0d-9a2b-4e86668dd38e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "693a3cac-4475-4c70-be44-10f465afb7d4");
        }
    }
}
