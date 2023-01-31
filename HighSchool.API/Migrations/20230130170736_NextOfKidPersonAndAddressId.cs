using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class NextOfKidPersonAndAddressId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCats_Categories_CategoryId",
                table: "PostCats");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCats_Posts_PostId",
                table: "PostCats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCats",
                table: "PostCats");

            migrationBuilder.DropIndex(
                name: "IX_PostCats_PostId",
                table: "PostCats");

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

            migrationBuilder.RenameColumn(
                name: "PhysicalAddressId",
                table: "Students",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "PhysicalAddressId",
                table: "Staff",
                newName: "AddressId");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Staff",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "PostCats",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "PostCats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostCatId",
                table: "PostCats",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "NextOfKins",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "NextOfKins",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeatureImageId",
                table: "NextOfKins",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaidenName",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdentityNumber",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "NextOfKins",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skype",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTube",
                table: "NextOfKins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "ContentBlocks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ContentBlocks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "ContentBlocks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "ContentBlocks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContentBlocks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "ContentBlocks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCats",
                table: "PostCats",
                columns: new[] { "PostId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9290), new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9300), new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9300) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("2beeba5e-b635-46bb-beed-f372759d29cd"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(8930), null, new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(8960), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("328084b0-53ed-41a3-936b-8fd094756e98"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9010), null, new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9010), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("3a1c5975-6c81-439b-b60d-7d239db7ffae"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9010), null, new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9010), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("07c96293-f5d1-4977-af9d-735b3c4f3855"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9180), null, new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9180), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("125dd233-e4e9-41c1-a304-308946056d6c"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9180), null, new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9180), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("660e7e10-e60e-446e-bdce-d40e0044f968"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9170), null, new DateTime(2023, 1, 30, 19, 7, 35, 612, DateTimeKind.Local).AddTicks(9170), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCats_Categories_CategoryId",
                table: "PostCats",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCats_Posts_PostId",
                table: "PostCats",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCats_Categories_CategoryId",
                table: "PostCats");

            migrationBuilder.DropForeignKey(
                name: "FK_PostCats_Posts_PostId",
                table: "PostCats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCats",
                table: "PostCats");

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("2beeba5e-b635-46bb-beed-f372759d29cd"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("328084b0-53ed-41a3-936b-8fd094756e98"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("3a1c5975-6c81-439b-b60d-7d239db7ffae"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("07c96293-f5d1-4977-af9d-735b3c4f3855"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("125dd233-e4e9-41c1-a304-308946056d6c"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("660e7e10-e60e-446e-bdce-d40e0044f968"));

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "FeatureImageId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "MaidenName",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "NationalIdentityNumber",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Skype",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "YouTube",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "ContentBlocks");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Students",
                newName: "PhysicalAddressId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Staff",
                newName: "PhysicalAddressId");

            migrationBuilder.AlterColumn<int>(
                name: "PostCatId",
                table: "PostCats",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "PostCats",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "PostCats",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCats",
                table: "PostCats",
                column: "PostCatId");

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
                name: "IX_PostCats_PostId",
                table: "PostCats",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCats_Categories_CategoryId",
                table: "PostCats",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCats_Posts_PostId",
                table: "PostCats",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId");
        }
    }
}
