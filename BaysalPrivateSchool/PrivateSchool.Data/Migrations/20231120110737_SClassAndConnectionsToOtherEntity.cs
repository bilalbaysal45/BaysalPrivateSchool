using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrivateSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class SClassAndConnectionsToOtherEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SClassId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherClasses",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    SClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClasses", x => new { x.TeacherId, x.SClassId });
                    table.ForeignKey(
                        name: "FK_TeacherClasses_SClasses_SClassId",
                        column: x => x.SClassId,
                        principalTable: "SClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherClasses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SClassId",
                table: "Students",
                column: "SClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClasses_SClassId",
                table: "TeacherClasses",
                column: "SClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SClasses_SClassId",
                table: "Students",
                column: "SClassId",
                principalTable: "SClasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SClasses_SClassId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "TeacherClasses");

            migrationBuilder.DropTable(
                name: "SClasses");

            migrationBuilder.DropIndex(
                name: "IX_Students_SClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SClassId",
                table: "Students");
        }
    }
}
