using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updatedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProducts_CustomerProductsTypes_CustomerProductsTypeID",
                table: "CustomerProducts");

            migrationBuilder.DropTable(
                name: "CustomerProductsTypes");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProducts_CustomerProductsTypeID",
                table: "CustomerProducts");

            migrationBuilder.DropColumn(
                name: "CustomerProductsTypeID",
                table: "CustomerProducts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "534bff3d-6bf0-4dfb-9de9-549dae5c55af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0ee936e1-ae0d-44f9-bcd5-df4d405f0abf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e14328e1-4a26-4b1f-bd09-01a386269d64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "813a9d0a-4002-4f8e-a422-af5732406f72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "173f93b3-5fd1-4aae-b5df-4ee152be122c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerProductsTypeID",
                table: "CustomerProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomerProductsTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProductsTypes", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "348ae170-3124-427d-81ea-d529926cc709");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "aaf9f4e8-537b-4911-aba1-699555d3e6ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "95c7d334-0569-4aa6-8229-2eaf3a7ef6fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "cf2e3b14-eb27-4de1-925b-a121b34b03a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "0ca0ef7d-cd4e-4554-afed-a166d6ef7e4c");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CustomerProductsTypeID",
                table: "CustomerProducts",
                column: "CustomerProductsTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProducts_CustomerProductsTypes_CustomerProductsTypeID",
                table: "CustomerProducts",
                column: "CustomerProductsTypeID",
                principalTable: "CustomerProductsTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
