using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class updatedImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("3a034dc9-7c2e-4910-9ee0-26a1b96b7d61"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("ce17d7e2-c80d-4210-9373-b1126fcb62fa"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("ea7ca375-d275-4e19-9d8d-24a1ba85e6b5"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("39268f84-b8ef-4caa-993c-b18ec20e8763"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("b0afa5ef-c5cd-4680-9087-ce8984878392"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("d79bf3f9-dc9b-43aa-9bff-2bf119c21d5c"));

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Images",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Images",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Images",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Images",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Images",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Images",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5200), new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5210), new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated", "Deleted", "Published" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5090), new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5100), false, false });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated", "Deleted", "Published" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5100), new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5100), false, false });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("1d673a84-b373-445f-bbe4-27dcf8357383"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(4780), null, new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(4780), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("ab5cbd15-5da9-45ea-9de7-ad16133a1dcd"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(4780), null, new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(4780), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("cb89c656-617a-41b2-a887-6abdb3584635"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(4690), null, new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(4720), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("04332c6f-98f9-4bf4-b2bc-f98d45fa114c"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(4990), null, new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5000), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("1fefa252-fe24-4c2b-8910-1e3bff897370"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5010), null, new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5010), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("281c953c-4c2a-4d8d-87e2-422073264941"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5020), null, new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5020), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("1d673a84-b373-445f-bbe4-27dcf8357383"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("ab5cbd15-5da9-45ea-9de7-ad16133a1dcd"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("cb89c656-617a-41b2-a887-6abdb3584635"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("04332c6f-98f9-4bf4-b2bc-f98d45fa114c"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("1fefa252-fe24-4c2b-8910-1e3bff897370"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("281c953c-4c2a-4d8d-87e2-422073264941"));

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8210), new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8210) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8220), new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8220) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("3a034dc9-7c2e-4910-9ee0-26a1b96b7d61"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(7740), null, new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(7760), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("ce17d7e2-c80d-4210-9373-b1126fcb62fa"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(7830), null, new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(7830), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("ea7ca375-d275-4e19-9d8d-24a1ba85e6b5"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(7820), null, new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(7830), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("39268f84-b8ef-4caa-993c-b18ec20e8763"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8040), null, new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8040), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("b0afa5ef-c5cd-4680-9087-ce8984878392"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8060), null, new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8060), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("d79bf3f9-dc9b-43aa-9bff-2bf119c21d5c"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8060), null, new DateTime(2023, 3, 4, 22, 20, 31, 957, DateTimeKind.Local).AddTicks(8060), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });
        }
    }
}
