using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravisBrownBlog.Data.Migrations
{
    public partial class initial_0009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_AspNetUsers_BlogUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_BlogUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "BlogUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "BlogPosts",
                newName: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CreatorId",
                table: "BlogPosts",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_AspNetUsers_CreatorId",
                table: "BlogPosts",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_AspNetUsers_CreatorId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CreatorId",
                table: "BlogPosts");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "BlogPosts",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "BlogPosts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BlogUserId",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "BlogPosts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "BlogPosts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "BlogPosts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "BlogPosts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "BlogPosts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "BlogPosts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogUserId",
                table: "BlogPosts",
                column: "BlogUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_AspNetUsers_BlogUserId",
                table: "BlogPosts",
                column: "BlogUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
