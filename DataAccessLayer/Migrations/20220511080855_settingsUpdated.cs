using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class settingsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettingValue",
                table: "Settings");

            migrationBuilder.AddColumn<bool>(
                name: "SettingIsActive",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "58d41b2c-29e9-493a-b638-04defed7c5f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ef45ecc1-d077-46f7-bb54-8e1bed0af24c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ded1c9a4-c1ea-4ca2-ac47-9b8d3f5cf7f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "37561ab4-ad59-4a0d-8498-8888193b09d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "06f52576-167a-4f3d-9d05-5c399d528bc8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                column: "Status",
                value: true);

            migrationBuilder.InsertData(
                table: "DigicellSMSSettings",
                columns: new[] { "ID", "Header", "Password", "Username", "isActive" },
                values: new object[] { 1, "EGEBARKOD", "170c7a13d50048c4497146b0f2c9e0dd", "egebarkod", true });

            migrationBuilder.UpdateData(
                table: "MailSettings",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Mail", "Password", "SMTPServer" },
                values: new object[] { "ajansyonetim@mygrafeg.com", "Ef#bpu^}V!7^", "mail.mygrafeg.com" });

            migrationBuilder.InsertData(
                table: "PeakcellSMSSettings",
                columns: new[] { "ID", "Header", "Password", "Username", "isActive" },
                values: new object[] { 1, "EGEBARKOD", "password", "username", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DigicellSMSSettings",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PeakcellSMSSettings",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SettingIsActive",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "SettingValue",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a2335c01-4859-4dcb-90d9-eb6de1d30e33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e9d2c2c5-0191-4292-ae4d-e6e1e1dc1f03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "86d257e5-0c55-4339-b66b-74108930123f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "ed706e6b-b942-4a6e-9817-e25753c50adb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                column: "ConcurrencyStamp",
                value: "fc1923d2-4d31-4901-8d17-55e34e62a187");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e40406-8a9d-2d82-912c-5d6a640ee696",
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "MailSettings",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Mail", "Password", "SMTPServer" },
                values: new object[] { "companypanel15@gmail.com", "123456Admin.", "smtp.gmail.com" });
        }
    }
}
