using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class categoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("53b14ffc-a269-4c92-9394-72f08794ccc8"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("a694608a-53cc-4b08-8865-293f243064ac"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("dc44859d-75db-4406-babe-c9dbdc3c575b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("93d407e8-b028-4ff2-8e09-4bf9f83033fd"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("fe45fdbe-b8ce-4b23-b03b-1e4438e51ce0"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("fef194b3-39d0-42e4-801f-c9aad0b2c9eb"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Slug = table.Column<string>(type: "TEXT", nullable: true),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PostId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_Categories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "AuthorId", "CourseId", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Name", "PostId", "Published", "Slug" },
                values: new object[] { 1, null, null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520), false, "Mobile", null, false, "mobile-app" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "AuthorId", "CourseId", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Name", "PostId", "Published", "Slug" },
                values: new object[] { 2, null, null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520), null, new DateTime(2023, 1, 8, 18, 3, 19, 875, DateTimeKind.Local).AddTicks(520), false, "Web", null, false, "web" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

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

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("53b14ffc-a269-4c92-9394-72f08794ccc8"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6300), null, new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6300), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("a694608a-53cc-4b08-8865-293f243064ac"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6300), null, new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6300), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("dc44859d-75db-4406-babe-c9dbdc3c575b"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6220), null, new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6240), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("93d407e8-b028-4ff2-8e09-4bf9f83033fd"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6530), null, new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6530), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("fe45fdbe-b8ce-4b23-b03b-1e4438e51ce0"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6510), null, new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6510), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("fef194b3-39d0-42e4-801f-c9aad0b2c9eb"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6530), null, new DateTime(2023, 1, 5, 17, 3, 22, 128, DateTimeKind.Local).AddTicks(6530), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });
        }
    }
}
