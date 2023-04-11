using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class changedYearDataTypeForSchoolYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("3df2df97-a5a4-4619-9421-bed317bb8bee"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("8c8c881e-1bc4-4aea-8182-7190805327a2"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("ac8cfdf0-3e5b-4eea-8748-053459169fdb"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("03ae1204-d761-48e4-9d40-aeb37f66e4ed"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("c02c84df-8979-4b32-8dc3-11d841d4bf83"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("f21bc001-f172-4fdf-9323-be11e18caeb4"));

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "SchoolYears",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9500), new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9510), new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9440), new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9450), new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9450) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("24865995-5a20-4f57-b62c-9d51f77ae3d9"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(8750), null, new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(8780), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("a53dc23e-0749-42c3-943c-4528424b0d79"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(8830), null, new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(8830), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("ec6f7846-a498-4e6a-8a38-47f5d765c380"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(8840), null, new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(8840), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("6fb3291f-c164-48a0-9755-689425d2714b"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9380), null, new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9380), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("d1106847-5b04-4c66-8898-eea7c87e035f"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9370), null, new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9370), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("f0deb004-7af3-4e0f-bd4c-5fd234406883"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9360), null, new DateTime(2023, 4, 9, 14, 52, 49, 378, DateTimeKind.Local).AddTicks(9360), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolYears_Year",
                table: "SchoolYears",
                column: "Year",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SchoolYears_Year",
                table: "SchoolYears");

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("24865995-5a20-4f57-b62c-9d51f77ae3d9"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("a53dc23e-0749-42c3-943c-4528424b0d79"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("ec6f7846-a498-4e6a-8a38-47f5d765c380"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("6fb3291f-c164-48a0-9755-689425d2714b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("d1106847-5b04-4c66-8898-eea7c87e035f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("f0deb004-7af3-4e0f-bd4c-5fd234406883"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Year",
                table: "SchoolYears",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(700), new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(710), new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(710) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(640), new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(650), new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(650) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("3df2df97-a5a4-4619-9421-bed317bb8bee"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(370), null, new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(370), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("8c8c881e-1bc4-4aea-8182-7190805327a2"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(290), null, new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(310), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("ac8cfdf0-3e5b-4eea-8748-053459169fdb"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(370), null, new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(370), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("03ae1204-d761-48e4-9d40-aeb37f66e4ed"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(560), null, new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(560), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("c02c84df-8979-4b32-8dc3-11d841d4bf83"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(550), null, new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(550), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("f21bc001-f172-4fdf-9323-be11e18caeb4"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(570), null, new DateTime(2023, 4, 8, 20, 34, 22, 528, DateTimeKind.Local).AddTicks(570), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });
        }
    }
}
