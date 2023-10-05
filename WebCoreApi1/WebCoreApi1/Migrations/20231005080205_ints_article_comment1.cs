using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCoreApi1.Migrations
{
    public partial class ints_article_comment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Comment",
                newName: "TheArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                newName: "IX_Comment_TheArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_TheArticleId",
                table: "Comment",
                column: "TheArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Article_TheArticleId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "TheArticleId",
                table: "Comment",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_TheArticleId",
                table: "Comment",
                newName: "IX_Comment_ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_ArticleId",
                table: "Comment",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
