using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoCampoGithub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 11, 17, 3, 11, 17, 100, DateTimeKind.Utc).AddTicks(3623),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 11, 17, 3, 1, 28, 134, DateTimeKind.Utc).AddTicks(4600));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 11, 17, 3, 1, 28, 134, DateTimeKind.Utc).AddTicks(4600),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 11, 17, 3, 11, 17, 100, DateTimeKind.Utc).AddTicks(3623));
        }
    }
}
