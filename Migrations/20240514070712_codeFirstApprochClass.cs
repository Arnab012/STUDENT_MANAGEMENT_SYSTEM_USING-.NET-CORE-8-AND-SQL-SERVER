using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code_First_Approch.Migrations
{
    /// <inheritdoc />
    public partial class codeFirstApprochClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "standered",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "standered",
                table: "Students");
        }
    }
}
