using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrivateSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentClubWithDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentClubId",
                table: "Teachers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentClubId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentClubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClubs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StudentClubId",
                table: "Teachers",
                column: "StudentClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentClubId",
                table: "Students",
                column: "StudentClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClubs_StudentClubId",
                table: "Students",
                column: "StudentClubId",
                principalTable: "StudentClubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_StudentClubs_StudentClubId",
                table: "Teachers",
                column: "StudentClubId",
                principalTable: "StudentClubs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClubs_StudentClubId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_StudentClubs_StudentClubId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "StudentClubs");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_StudentClubId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentClubId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentClubId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudentClubId",
                table: "Students");
        }
    }
}
