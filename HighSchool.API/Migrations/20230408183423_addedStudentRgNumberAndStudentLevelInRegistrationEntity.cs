using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class addedStudentRgNumberAndStudentLevelInRegistrationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("58570183-6eb2-46ca-9957-1b6b450f9bf2"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("b2dc4ef4-1caf-4f89-9886-e2428baf9b69"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("da2acfcc-7f33-4789-b830-53e2eefc0aee"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("69226cee-e857-4a69-a1e8-2c679514e20f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("89e49be7-9209-4bd6-8b60-450b95150ad9"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("cd1cc396-93c7-423d-b0a6-e4ea0f9c38e6"));

            migrationBuilder.AddColumn<string>(
                name: "StudentRegNumber",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentLevelId",
                table: "StudentRegistrations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StudentLevelId",
                table: "StudentRegistrations",
                column: "StudentLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_StudentLevels_StudentLevelId",
                table: "StudentRegistrations",
                column: "StudentLevelId",
                principalTable: "StudentLevels",
                principalColumn: "StudentLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_StudentLevels_StudentLevelId",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_StudentLevelId",
                table: "StudentRegistrations");

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

            migrationBuilder.DropColumn(
                name: "StudentRegNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentLevelId",
                table: "StudentRegistrations");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(610), new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(620), new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(500), new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(500), new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(520) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("58570183-6eb2-46ca-9957-1b6b450f9bf2"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local), null, new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("b2dc4ef4-1caf-4f89-9886-e2428baf9b69"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 31, 23, 45, 17, 919, DateTimeKind.Local).AddTicks(9980), null, new DateTime(2023, 3, 31, 23, 45, 17, 919, DateTimeKind.Local).AddTicks(9980), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("da2acfcc-7f33-4789-b830-53e2eefc0aee"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 31, 23, 45, 17, 919, DateTimeKind.Local).AddTicks(9890), null, new DateTime(2023, 3, 31, 23, 45, 17, 919, DateTimeKind.Local).AddTicks(9920), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("69226cee-e857-4a69-a1e8-2c679514e20f"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(360), null, new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(360), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("89e49be7-9209-4bd6-8b60-450b95150ad9"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(380), null, new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(380), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("cd1cc396-93c7-423d-b0a6-e4ea0f9c38e6"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(240), null, new DateTime(2023, 3, 31, 23, 45, 17, 920, DateTimeKind.Local).AddTicks(240), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });
        }
    }
}
