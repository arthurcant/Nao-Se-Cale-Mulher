using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_SITE_Mulher.Migrations
{
    public partial class alter_proprety_refreshToken_To_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "refresh_token",
                table: "tb_usuario",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_usuario",
                keyColumn: "refresh_token",
                keyValue: null,
                column: "refresh_token",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "refresh_token",
                table: "tb_usuario",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
