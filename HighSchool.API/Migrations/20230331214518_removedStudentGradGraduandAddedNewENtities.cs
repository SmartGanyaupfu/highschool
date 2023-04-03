using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class removedStudentGradGraduandAddedNewENtities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_Grade_GradeId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Graduate_Grade_GradeId",
                table: "Graduate");

            migrationBuilder.DropTable(
                name: "StudentGrades");

            migrationBuilder.DropTable(
                name: "StudentGraduates");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Graduate",
                table: "Graduate");

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
                name: "GradeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Graduate");

            migrationBuilder.RenameTable(
                name: "Graduate",
                newName: "Graduates");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "CourseWorkReports",
                newName: "StudentClassId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseWorkReports_GradeId",
                table: "CourseWorkReports",
                newName: "IX_CourseWorkReports_StudentClassId");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "Graduates",
                newName: "StudentClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Graduate_GradeId",
                table: "Graduates",
                newName: "IX_Graduates_StudentClassId");

            migrationBuilder.AddColumn<int>(
                name: "StudentLevelId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolYearId",
                table: "Graduates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Graduates",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Graduates",
                table: "Graduates",
                column: "GraduateId");

            migrationBuilder.CreateTable(
                name: "FeeCategories",
                columns: table => new
                {
                    FeeCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeCategories", x => x.FeeCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTerms",
                columns: table => new
                {
                    SchoolTermId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTerms", x => x.SchoolTermId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.SchoolYearId);
                });

            migrationBuilder.CreateTable(
                name: "StudentLevels",
                columns: table => new
                {
                    StudentLevelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLevels", x => x.StudentLevelId);
                });

            migrationBuilder.CreateTable(
                name: "StudentSession",
                columns: table => new
                {
                    StudentSessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSession", x => x.StudentSessionId);
                });

            migrationBuilder.CreateTable(
                name: "FeeCategoryAmounts",
                columns: table => new
                {
                    FeeCategoryAmountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<double>(type: "REAL", nullable: true),
                    StudentLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    FeeCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeCategoryAmounts", x => x.FeeCategoryAmountId);
                    table.ForeignKey(
                        name: "FK_FeeCategoryAmounts_FeeCategories_FeeCategoryId",
                        column: x => x.FeeCategoryId,
                        principalTable: "FeeCategories",
                        principalColumn: "FeeCategoryId");
                    table.ForeignKey(
                        name: "FK_FeeCategoryAmounts_StudentLevels_StudentLevelId",
                        column: x => x.StudentLevelId,
                        principalTable: "StudentLevels",
                        principalColumn: "StudentLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    StudentClassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StudentLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => x.StudentClassId);
                    table.ForeignKey(
                        name: "FK_StudentClasses_StudentLevels_StudentLevelId",
                        column: x => x.StudentLevelId,
                        principalTable: "StudentLevels",
                        principalColumn: "StudentLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRegistrations",
                columns: table => new
                {
                    StudentRegistrationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentSessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolTermId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegistrations", x => x.StudentRegistrationId);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_SchoolTerms_SchoolTermId",
                        column: x => x.SchoolTermId,
                        principalTable: "SchoolTerms",
                        principalColumn: "SchoolTermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_SchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYears",
                        principalColumn: "SchoolYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_StudentClasses_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "StudentClasses",
                        principalColumn: "StudentClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegistrations_StudentSession_StudentSessionId",
                        column: x => x.StudentSessionId,
                        principalTable: "StudentSession",
                        principalColumn: "StudentSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentLevelId",
                table: "Courses",
                column: "StudentLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_SchoolYearId",
                table: "Graduates",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_StudentId",
                table: "Graduates",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeCategoryAmounts_FeeCategoryId",
                table: "FeeCategoryAmounts",
                column: "FeeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeCategoryAmounts_StudentLevelId",
                table: "FeeCategoryAmounts",
                column: "StudentLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentLevelId",
                table: "StudentClasses",
                column: "StudentLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_SchoolTermId",
                table: "StudentRegistrations",
                column: "SchoolTermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_SchoolYearId",
                table: "StudentRegistrations",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StudentClassId",
                table: "StudentRegistrations",
                column: "StudentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistrations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StudentSessionId",
                table: "StudentRegistrations",
                column: "StudentSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentLevels_StudentLevelId",
                table: "Courses",
                column: "StudentLevelId",
                principalTable: "StudentLevels",
                principalColumn: "StudentLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_StudentClasses_StudentClassId",
                table: "CourseWorkReports",
                column: "StudentClassId",
                principalTable: "StudentClasses",
                principalColumn: "StudentClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graduates_SchoolYears_SchoolYearId",
                table: "Graduates",
                column: "SchoolYearId",
                principalTable: "SchoolYears",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graduates_StudentClasses_StudentClassId",
                table: "Graduates",
                column: "StudentClassId",
                principalTable: "StudentClasses",
                principalColumn: "StudentClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graduates_Students_StudentId",
                table: "Graduates",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentLevels_StudentLevelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_StudentClasses_StudentClassId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Graduates_SchoolYears_SchoolYearId",
                table: "Graduates");

            migrationBuilder.DropForeignKey(
                name: "FK_Graduates_StudentClasses_StudentClassId",
                table: "Graduates");

            migrationBuilder.DropForeignKey(
                name: "FK_Graduates_Students_StudentId",
                table: "Graduates");

            migrationBuilder.DropTable(
                name: "FeeCategoryAmounts");

            migrationBuilder.DropTable(
                name: "StudentRegistrations");

            migrationBuilder.DropTable(
                name: "FeeCategories");

            migrationBuilder.DropTable(
                name: "SchoolTerms");

            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "StudentSession");

            migrationBuilder.DropTable(
                name: "StudentLevels");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentLevelId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Graduates",
                table: "Graduates");

            migrationBuilder.DropIndex(
                name: "IX_Graduates_SchoolYearId",
                table: "Graduates");

            migrationBuilder.DropIndex(
                name: "IX_Graduates_StudentId",
                table: "Graduates");

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

            migrationBuilder.DropColumn(
                name: "StudentLevelId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SchoolYearId",
                table: "Graduates");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Graduates");

            migrationBuilder.RenameTable(
                name: "Graduates",
                newName: "Graduate");

            migrationBuilder.RenameColumn(
                name: "StudentClassId",
                table: "CourseWorkReports",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseWorkReports_StudentClassId",
                table: "CourseWorkReports",
                newName: "IX_CourseWorkReports_GradeId");

            migrationBuilder.RenameColumn(
                name: "StudentClassId",
                table: "Graduate",
                newName: "GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Graduates_StudentClassId",
                table: "Graduate",
                newName: "IX_Graduate_GradeId");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Images",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Year",
                table: "Graduate",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Graduate",
                table: "Graduate",
                column: "GraduateId");

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    Level = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grade_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGraduates",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GraduateId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentGraduateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGraduates", x => new { x.StudentId, x.GraduateId });
                    table.ForeignKey(
                        name: "FK_StudentGraduates_Graduate_GraduateId",
                        column: x => x.GraduateId,
                        principalTable: "Graduate",
                        principalColumn: "GraduateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGraduates_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentGradeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrades", x => new { x.StudentId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_StudentGrades_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGrades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5090), new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5100) });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5100), new DateTime(2023, 3, 5, 0, 55, 24, 401, DateTimeKind.Local).AddTicks(5100) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StaffId",
                table: "Grade",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_GradeId",
                table: "StudentGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGraduates_GraduateId",
                table: "StudentGraduates",
                column: "GraduateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_Grade_GradeId",
                table: "CourseWorkReports",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graduate_Grade_GradeId",
                table: "Graduate",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
