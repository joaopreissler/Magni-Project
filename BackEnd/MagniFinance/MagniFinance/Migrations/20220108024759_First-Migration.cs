using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagniFinance.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "college",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_college", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectid = table.Column<int>(type: "int", nullable: false),
                    studentid = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registration = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collegeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_college_Collegeid",
                        column: x => x.Collegeid,
                        principalTable: "college",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacherid = table.Column<int>(type: "int", nullable: true),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.id);
                    table.ForeignKey(
                        name: "FK_subject_course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subject_teacher_teacherid",
                        column: x => x.teacherid,
                        principalTable: "teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSubjects",
                columns: table => new
                {
                    studentsid = table.Column<int>(type: "int", nullable: false),
                    subjectsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubjects", x => new { x.studentsid, x.subjectsid });
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_student_studentsid",
                        column: x => x.studentsid,
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_subject_subjectsid",
                        column: x => x.subjectsid,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_Collegeid",
                table: "course",
                column: "Collegeid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjects_subjectsid",
                table: "StudentsSubjects",
                column: "subjectsid");

            migrationBuilder.CreateIndex(
                name: "IX_subject_CoursesId",
                table: "subject",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_teacherid",
                table: "subject",
                column: "teacherid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grade");

            migrationBuilder.DropTable(
                name: "StudentsSubjects");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "college");
        }
    }
}
