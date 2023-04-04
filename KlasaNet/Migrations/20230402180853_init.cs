using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlasaNet.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    IdClass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.IdClass);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    IdParent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.IdParent);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    IdSchool = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.IdSchool);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    IdDirector = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSchool = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.IdDirector);
                    table.ForeignKey(
                        name: "FK_Directors_Schools_IdSchool",
                        column: x => x.IdSchool,
                        principalTable: "Schools",
                        principalColumn: "IdSchool",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    IdSubject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSchool = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.IdSubject);
                    table.ForeignKey(
                        name: "FK_Subjects_Schools_IdSchool",
                        column: x => x.IdSchool,
                        principalTable: "Schools",
                        principalColumn: "IdSchool",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    IdTeacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSchool = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IdTeacher);
                    table.ForeignKey(
                        name: "FK_Teachers_Schools_IdSchool",
                        column: x => x.IdSchool,
                        principalTable: "Schools",
                        principalColumn: "IdSchool",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClass = table.Column<int>(type: "int", nullable: false),
                    IdSchool = table.Column<int>(type: "int", nullable: false),
                    IdHomeroomTeacher = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Students_Classes_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Classes",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Schools_IdSchool",
                        column: x => x.IdSchool,
                        principalTable: "Schools",
                        principalColumn: "IdSchool",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_IdHomeroomTeacher",
                        column: x => x.IdHomeroomTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IdTeacher");
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjectClasses",
                columns: table => new
                {
                    IdTeacher = table.Column<int>(type: "int", nullable: false),
                    IdClass = table.Column<int>(type: "int", nullable: false),
                    IdSubject = table.Column<int>(type: "int", nullable: false),
                    IdTeacherSubjectClass = table.Column<int>(type: "int", nullable: false),
                    IdSchool = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjectClasses", x => new { x.IdTeacher, x.IdClass, x.IdSubject });
                    table.ForeignKey(
                        name: "FK_TeacherSubjectClasses_Classes_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Classes",
                        principalColumn: "IdClass");
                    table.ForeignKey(
                        name: "FK_TeacherSubjectClasses_Schools_IdSchool",
                        column: x => x.IdSchool,
                        principalTable: "Schools",
                        principalColumn: "IdSchool");
                    table.ForeignKey(
                        name: "FK_TeacherSubjectClasses_Subjects_IdSubject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "IdSubject");
                    table.ForeignKey(
                        name: "FK_TeacherSubjectClasses_Teachers_IdTeacher",
                        column: x => x.IdTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IdTeacher");
                });

            migrationBuilder.CreateTable(
                name: "StudentParent",
                columns: table => new
                {
                    ParentsIdParent = table.Column<int>(type: "int", nullable: false),
                    StudentsIdStudent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParent", x => new { x.ParentsIdParent, x.StudentsIdStudent });
                    table.ForeignKey(
                        name: "FK_StudentParent_Parents_ParentsIdParent",
                        column: x => x.ParentsIdParent,
                        principalTable: "Parents",
                        principalColumn: "IdParent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentParent_Students_StudentsIdStudent",
                        column: x => x.StudentsIdStudent,
                        principalTable: "Students",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_IdSchool",
                table: "Directors",
                column: "IdSchool");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParent_StudentsIdStudent",
                table: "StudentParent",
                column: "StudentsIdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdClass",
                table: "Students",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdHomeroomTeacher",
                table: "Students",
                column: "IdHomeroomTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdSchool",
                table: "Students",
                column: "IdSchool");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_IdSchool",
                table: "Subjects",
                column: "IdSchool");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IdSchool",
                table: "Teachers",
                column: "IdSchool");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjectClasses_IdClass",
                table: "TeacherSubjectClasses",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjectClasses_IdSchool",
                table: "TeacherSubjectClasses",
                column: "IdSchool");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjectClasses_IdSubject",
                table: "TeacherSubjectClasses",
                column: "IdSubject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "StudentParent");

            migrationBuilder.DropTable(
                name: "TeacherSubjectClasses");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
