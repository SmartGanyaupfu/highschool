using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.API.Migrations
{
    public partial class MajorChangesMoreEntitiesAddedM2Mrelatiops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocatedResources_Students_StudentId",
                table: "AllocatedResources");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_Students_StudentId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceID",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Students_StudentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPlans_Staff_StaffId",
                table: "LessonPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Students_StudentId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Courses_CourseId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_EmployeeTypes_EmployeeTypeId",
                table: "Staff");

            migrationBuilder.DropTable(
                name: "ProgressReports");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Staff_CourseId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_EmployeeTypeId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuizId",
                table: "Questions");

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
                name: "CvUrl",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "EducationBlock",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "HireMeBlock",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "InterestBlock",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "WorkBlock",
                table: "Widgets",
                newName: "VissionBlock");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Widgets",
                newName: "ValuesBlock");

            migrationBuilder.RenameColumn(
                name: "LearnToCode",
                table: "Widgets",
                newName: "MissionStatemnetBlock");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeTypeId",
                table: "Staff",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Questions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "LessonPlans",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "LessonPlans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LessonPlans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "LessonPlans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "LessonPlans",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LessonPlans",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "LessonPlans",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "InvoiceItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassGradeId",
                table: "CourseWorkReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "CourseWorkReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HClassId",
                table: "CourseWorkReports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MarkObtained",
                table: "CourseWorkReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PossibleMark",
                table: "CourseWorkReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "CourseWorkReports",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Term",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Year",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "AllocatedResources",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StaffId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true)
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
                name: "StffCourses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StaffId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StaffCourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StffCourses", x => new { x.StaffId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StffCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StffCourses_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Graduate",
                columns: table => new
                {
                    GraduateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduate", x => x.GraduateId);
                    table.ForeignKey(
                        name: "FK_Graduate_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "StudentGraduates",
                columns: table => new
                {
                    GraduateId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                name: "IX_CourseWorkReports_ClassGradeId",
                table: "CourseWorkReports",
                column: "ClassGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseWorkReports_CourseId",
                table: "CourseWorkReports",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StaffId",
                table: "Grade",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduate_GradeId",
                table: "Graduate",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StffCourses_CourseId",
                table: "StffCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_GradeId",
                table: "StudentGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGraduates_GraduateId",
                table: "StudentGraduates",
                column: "GraduateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocatedResources_Students_StudentId",
                table: "AllocatedResources",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_Courses_CourseId",
                table: "CourseWorkReports",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_Grade_ClassGradeId",
                table: "CourseWorkReports",
                column: "ClassGradeId",
                principalTable: "Grade",
                principalColumn: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_Students_StudentId",
                table: "CourseWorkReports",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceID",
                table: "InvoiceItem",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Students_StudentId",
                table: "Invoices",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPlans_Staff_StaffId",
                table: "LessonPlans",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Students_StudentId",
                table: "Notes",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceID",
                table: "Payments",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocatedResources_Students_StudentId",
                table: "AllocatedResources");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_Courses_CourseId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_Grade_ClassGradeId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseWorkReports_Students_StudentId",
                table: "CourseWorkReports");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceID",
                table: "InvoiceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Students_StudentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonPlans_Staff_StaffId",
                table: "LessonPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Students_StudentId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceID",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "StffCourses");

            migrationBuilder.DropTable(
                name: "StudentGrades");

            migrationBuilder.DropTable(
                name: "StudentGraduates");

            migrationBuilder.DropTable(
                name: "Graduate");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_CourseWorkReports_ClassGradeId",
                table: "CourseWorkReports");

            migrationBuilder.DropIndex(
                name: "IX_CourseWorkReports_CourseId",
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
                name: "Description",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "LessonPlans");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "ClassGradeId",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "HClassId",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "MarkObtained",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "PossibleMark",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "CourseWorkReports");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "CourseWorkReports");

            migrationBuilder.RenameColumn(
                name: "VissionBlock",
                table: "Widgets",
                newName: "WorkBlock");

            migrationBuilder.RenameColumn(
                name: "ValuesBlock",
                table: "Widgets",
                newName: "ProfilePicture");

            migrationBuilder.RenameColumn(
                name: "MissionStatemnetBlock",
                table: "Widgets",
                newName: "LearnToCode");

            migrationBuilder.AddColumn<string>(
                name: "CvUrl",
                table: "Widgets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationBlock",
                table: "Widgets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HireMeBlock",
                table: "Widgets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterestBlock",
                table: "Widgets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeTypeId",
                table: "Staff",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Staff",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Questions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "Payments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Notes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "LessonPlans",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Invoices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "InvoiceItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "CourseWorkReports",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "AllocatedResources",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "ProgressReports",
                columns: table => new
                {
                    ProgressReportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    ClassTeacher = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Term = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressReports", x => x.ProgressReportId);
                    table.ForeignKey(
                        name: "FK_ProgressReports_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatePublished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: true),
                    Published = table.Column<bool>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QuizId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Staff_CourseId",
                table: "Staff",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_EmployeeTypeId",
                table: "Staff",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReports_StudentId",
                table: "ProgressReports",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocatedResources_Students_StudentId",
                table: "AllocatedResources",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseWorkReports_Students_StudentId",
                table: "CourseWorkReports",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Invoices_InvoiceID",
                table: "InvoiceItem",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Students_StudentId",
                table: "Invoices",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonPlans_Staff_StaffId",
                table: "LessonPlans",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Students_StudentId",
                table: "Notes",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceID",
                table: "Payments",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Courses_CourseId",
                table: "Staff",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_EmployeeTypes_EmployeeTypeId",
                table: "Staff",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "EmployeeTypeId");
        }
    }
}
