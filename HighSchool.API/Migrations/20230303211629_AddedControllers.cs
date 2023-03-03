using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class AddedControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_Grade_ClassGradeId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_NextOfKins_NextOfKinId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NextOfKinId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_CourseWorkReports_ClassGradeId",
                table: "CourseWorkReports");

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("0486fd60-4d09-410f-993f-7ae492030f78"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("64187c4b-9bcf-453c-9c80-343acb80332d"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "PageId",
                keyValue: new Guid("cdf49db3-c270-4050-9371-b4eea58d8c81"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("84cfb7bf-840a-4b7c-8882-713fc112fc5a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("cbd67c3b-721c-4726-b380-f6bd4637987a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("fd4e1ce1-938d-4449-9cc0-6e249eb0f1d4"));

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassGradeId",
                table: "CourseWorkReports");

            migrationBuilder.RenameColumn(
                name: "HClassId",
                table: "CourseWorkReports",
                newName: "GradeId");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "NextOfKins",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Graduate",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Graduate",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Graduate",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Graduate",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Graduate",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Graduate",
                type: "INTEGER",
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

            migrationBuilder.CreateIndex(
                name: "IX_Staff_EmployeeTypeId",
                table: "Staff",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_StudentId",
                table: "NextOfKins",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseWorkReports_GradeId",
                table: "CourseWorkReports",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_Grade_GradeId",
                table: "CourseWorkReports",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_Students_StudentId",
                table: "NextOfKins",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_EmployeeTypes_EmployeeTypeId",
                table: "Staff",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "EmployeeTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_Grade_GradeId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_Students_StudentId",
                table: "NextOfKins");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_EmployeeTypes_EmployeeTypeId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_EmployeeTypeId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_StudentId",
                table: "NextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_CourseWorkReports_GradeId",
                table: "CourseWorkReports");

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
                name: "CourseId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Graduate");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Graduate");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "CourseWorkReports",
                newName: "HClassId");

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassGradeId",
                table: "CourseWorkReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8670), new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8670), new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("0486fd60-4d09-410f-993f-7ae492030f78"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8030), null, new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8060), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("64187c4b-9bcf-453c-9c80-343acb80332d"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8130), null, new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8130), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("cdf49db3-c270-4050-9371-b4eea58d8c81"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8140), null, new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8140), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("84cfb7bf-840a-4b7c-8882-713fc112fc5a"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8460), null, new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8460), false, null, 1, "The inner was the inner", "test,tets,done", false, "about", "About" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("cbd67c3b-721c-4726-b380-f6bd4637987a"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8470), null, new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8470), false, null, null, "The inner was the inner", "test,tets,done", false, "contact", "Contact" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "Content", "DateCreated", "DatePublished", "DateUpdated", "Deleted", "Excerpt", "FeatureImageId", "MetaDescription", "MetaKeyWords", "Published", "Slug", "Title" },
                values: new object[] { new Guid("fd4e1ce1-938d-4449-9cc0-6e249eb0f1d4"), null, "The innner part of the solar cookker is made of mirroes", new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8440), null, new DateTime(2023, 2, 9, 6, 52, 59, 753, DateTimeKind.Local).AddTicks(8440), false, null, 1, "The inner was the inner", "test,tets,done", false, "home", "Home" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_NextOfKinId",
                table: "Students",
                column: "NextOfKinId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseWorkReports_ClassGradeId",
                table: "CourseWorkReports",
                column: "ClassGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_Grade_ClassGradeId",
                table: "CourseWorkReports",
                column: "ClassGradeId",
                principalTable: "Grade",
                principalColumn: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_NextOfKins_NextOfKinId",
                table: "Students",
                column: "NextOfKinId",
                principalTable: "NextOfKins",
                principalColumn: "NextOfKinId");
        }
    }
}
