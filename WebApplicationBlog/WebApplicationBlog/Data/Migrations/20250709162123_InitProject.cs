using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(100)", maxLength: 64, nullable: false),
                    about = table.Column<string>(type: "text", nullable: false),
                    telegram_id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    telegram_username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    last_online = table.Column<DateTime>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    author_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    thumbnail = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    category_id = table.Column<int>(type: "INTEGER", nullable: false),
                    view_count = table.Column<int>(type: "INTEGER", nullable: false),
                    comment_count = table.Column<int>(type: "INTEGER", nullable: false),
                    is_published = table.Column<bool>(type: "INTEGER", nullable: false),
                    is_deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_author_id",
                        column: x => x.author_id,
                        principalTable: "Profiles",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    author_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Profiles_author_id",
                        column: x => x.author_id,
                        principalTable: "Profiles",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostModelTagModel",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostModelTagModel", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostModelTagModel_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostModelTagModel_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_slug",
                table: "Categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_author_id",
                table: "Comments",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModelTagModel_TagsId",
                table: "PostModelTagModel",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_author_id",
                table: "Posts",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_category_id",
                table: "Posts",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_created_at",
                table: "Posts",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_is_deleted",
                table: "Posts",
                column: "is_deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_is_published",
                table: "Posts",
                column: "is_published");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_slug",
                table: "Posts",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_slug",
                table: "Tags",
                column: "slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostModelTagModel");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
