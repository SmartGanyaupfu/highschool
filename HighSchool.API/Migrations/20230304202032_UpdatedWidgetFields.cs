using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class UpdatedWidgetFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("2745be82-daaa-4538-99d5-df37ead59717"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("a11d51a2-c371-44b6-89fc-f7e2499615a0"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("d72cf363-146b-46c9-a984-1cbbd0a344be"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("68291586-798e-4a2d-9a6b-24a69c8dd492"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("b6dee466-3440-4e23-a406-d1303d09dbfb"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("edf65f98-5258-4e59-aa92-66b440d696a8"));

            migrationBuilder.DropColumn(
                name: "ContactPage",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "FbUrl",
                table: "Widgets");

            migrationBuilder.RenameColumn(
                name: "VissionBlock",
                table: "Widgets",
                newName: "VissionBlockId");

            migrationBuilder.RenameColumn(
                name: "ValuesBlock",
                table: "Widgets",
                newName: "ValuesBlockId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Widgets",
                newName: "SloganText");

            migrationBuilder.RenameColumn(
                name: "SkillBlock",
                table: "Widgets",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Widgets",
                newName: "MissionStatemnetBlockId");

            migrationBuilder.RenameColumn(
                name: "MissionStatemnetBlock",
                table: "Widgets",
                newName: "IntroText");

            migrationBuilder.RenameColumn(
                name: "Intro",
                table: "Widgets",
                newName: "HomePageId");

            migrationBuilder.RenameColumn(
                name: "HomePage",
                table: "Widgets",
                newName: "FooterTwoBlockId");

            migrationBuilder.RenameColumn(
                name: "GitHubUrl",
                table: "Widgets",
                newName: "FooterThreeBlockId");

            migrationBuilder.RenameColumn(
                name: "FooterTwo",
                table: "Widgets",
                newName: "FooterOneBlockId");

            migrationBuilder.RenameColumn(
                name: "FooterThree",
                table: "Widgets",
                newName: "FooterCopyrightBlockId");

            migrationBuilder.RenameColumn(
                name: "FooterOne",
                table: "Widgets",
                newName: "FacebookUrl");

            migrationBuilder.RenameColumn(
                name: "FooterCopyrightBlock",
                table: "Widgets",
                newName: "ContactPageId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "VissionBlockId",
                table: "Widgets",
                newName: "VissionBlock");

            migrationBuilder.RenameColumn(
                name: "ValuesBlockId",
                table: "Widgets",
                newName: "ValuesBlock");

            migrationBuilder.RenameColumn(
                name: "SloganText",
                table: "Widgets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Widgets",
                newName: "SkillBlock");

            migrationBuilder.RenameColumn(
                name: "MissionStatemnetBlockId",
                table: "Widgets",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "IntroText",
                table: "Widgets",
                newName: "MissionStatemnetBlock");

            migrationBuilder.RenameColumn(
                name: "HomePageId",
                table: "Widgets",
                newName: "Intro");

            migrationBuilder.RenameColumn(
                name: "FooterTwoBlockId",
                table: "Widgets",
                newName: "HomePage");

            migrationBuilder.RenameColumn(
                name: "FooterThreeBlockId",
                table: "Widgets",
                newName: "GitHubUrl");

            migrationBuilder.RenameColumn(
                name: "FooterOneBlockId",
                table: "Widgets",
                newName: "FooterTwo");

            migrationBuilder.RenameColumn(
                name: "FooterCopyrightBlockId",
                table: "Widgets",
                newName: "FooterThree");

            migrationBuilder.RenameColumn(
                name: "FacebookUrl",
                table: "Widgets",
                newName: "FooterOne");

            migrationBuilder.RenameColumn(
                name: "ContactPageId",
                table: "Widgets",
                newName: "FooterCopyrightBlock");

            migrationBuilder.AddColumn<string>(
                name: "ContactPage",
                table: "Widgets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FbUrl",
                table: "Widgets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1960), new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1960) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1960), new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1960) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("2745be82-daaa-4538-99d5-df37ead59717"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1480), null, new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1500), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("a11d51a2-c371-44b6-89fc-f7e2499615a0"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1560), null, new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1560), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("d72cf363-146b-46c9-a984-1cbbd0a344be"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1550), null, new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1560), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("68291586-798e-4a2d-9a6b-24a69c8dd492"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1780), null, new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1780), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("b6dee466-3440-4e23-a406-d1303d09dbfb"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1770), null, new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1770), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("edf65f98-5258-4e59-aa92-66b440d696a8"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1790), null, new DateTime(2023, 3, 3, 23, 16, 29, 136, DateTimeKind.Local).AddTicks(1790), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });
        }
    }
}
