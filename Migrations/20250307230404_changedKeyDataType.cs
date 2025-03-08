using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShinyRockForum.Migrations
{
    /// <inheritdoc />
    public partial class changedKeyDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_ApplicationUserId",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Discussion_ApplicationUserId",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Discussion",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Discussion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Comment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_ApplicationUserId1",
                table: "Discussion",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId1",
                table: "Comment",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId1",
                table: "Comment",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussion_AspNetUsers_ApplicationUserId1",
                table: "Discussion",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_ApplicationUserId1",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Discussion_ApplicationUserId1",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Discussion");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Discussion",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_ApplicationUserId",
                table: "Discussion",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussion_AspNetUsers_ApplicationUserId",
                table: "Discussion",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
