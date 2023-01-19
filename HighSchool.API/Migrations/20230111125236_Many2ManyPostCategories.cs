using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class Many2ManyPostCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Courses_CourseId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Posts_PostId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CourseId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PostId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("c0a198f0-6b74-4b1e-880e-cf0c34a74ac4"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("d1db8b0d-c52c-4152-94cc-95a5413a8d87"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("df61487e-dd0a-4403-b092-30c13d2a691a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("6b7852ad-db12-46f2-8ecb-3f021e02cbbc"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("d9715091-12b4-4f11-97bf-3157c584935d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("d97fa73c-7777-44e5-8e2f-f28267d51ed4"));

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "PostCats",
                columns: table => new
                {
                    PostCatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    PostId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCats", x => x.PostCatId);
                    table.ForeignKey(
                        name: "FK_PostCats_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_PostCats_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId");
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1400), new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1410), new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1410) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("34eb4b1c-c03d-4522-b791-16af65c11848"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1130), null, new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1130), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("3fdd5df0-c2e8-4617-8a5f-ba1429a07c03"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1050), null, new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1070), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("c7dcbe3d-adab-4c68-8795-fa8ae41fe59b"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1120), null, new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1120), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("17f8e968-520e-4278-8bb7-7bfa2a3dd05c"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1280), null, new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1280), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("26e965b6-d999-457e-bddc-668fb6f7bc8f"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1300), null, new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1300), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("85813ee0-832e-4070-8562-da900be72e5d"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1290), null, new DateTime(2023, 1, 11, 14, 52, 35, 962, DateTimeKind.Local).AddTicks(1290), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.CreateIndex(
                name: "IX_PostCats_CategoryId",
                table: "PostCats",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCats_PostId",
                table: "PostCats",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCats");

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("34eb4b1c-c03d-4522-b791-16af65c11848"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("3fdd5df0-c2e8-4617-8a5f-ba1429a07c03"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("c7dcbe3d-adab-4c68-8795-fa8ae41fe59b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("17f8e968-520e-4278-8bb7-7bfa2a3dd05c"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("26e965b6-d999-457e-bddc-668fb6f7bc8f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("85813ee0-832e-4070-8562-da900be72e5d"));

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Categories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "Categories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520), new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520), new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("c0a198f0-6b74-4b1e-880e-cf0c34a74ac4"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(110), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(130), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("d1db8b0d-c52c-4152-94cc-95a5413a8d87"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(170), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(170), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("df61487e-dd0a-4403-b092-30c13d2a691a"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(180), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(180), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("6b7852ad-db12-46f2-8ecb-3f021e02cbbc"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(370), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(370), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("d9715091-12b4-4f11-97bf-3157c584935d"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(350), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(350), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("d97fa73c-7777-44e5-8e2f-f28267d51ed4"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(360), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(360), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CourseId",
                table: "Categories",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PostId",
                table: "Categories",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Courses_CourseId",
                table: "Categories",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Posts_PostId",
                table: "Categories",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId");
        }
    }
}
