using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_AspNetUsers_UserId",
                table: "TodoTasks");

            migrationBuilder.DropIndex(
                name: "IX_TodoTasks_UserId",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TodoTasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TodoTasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_UserId1",
                table: "TodoTasks",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_AspNetUsers_UserId1",
                table: "TodoTasks",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_AspNetUsers_UserId1",
                table: "TodoTasks");

            migrationBuilder.DropIndex(
                name: "IX_TodoTasks_UserId1",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoTasks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TodoTasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_UserId",
                table: "TodoTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_AspNetUsers_UserId",
                table: "TodoTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
