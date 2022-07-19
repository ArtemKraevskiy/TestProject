using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProject.Migrations
{
    public partial class initbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Имя1 Фамилия1" },
                    { 2, "Имя2 Фамилия2" },
                    { 3, "Имя3 Фамилия3" },
                    { 4, "Имя4 Фамилия4" },
                    { 5, "Имя5 Фамилия5" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseID", "Name", "Specialty", "TeacherID", "Year" },
                values: new object[] { 1, 2, "Название Группы1", "Специальность1", 1, 2020 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseID", "Name", "Specialty", "TeacherID", "Year" },
                values: new object[] { 2, 4, "Название Группы2", "Специальность2", 3, 2018 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "GroupID", "Name", "PhoneNumber", "Photo" },
                values: new object[,]
                {
                    { 1, 1, "Студент1", 77836940, "/img/Студент1.jpg" },
                    { 2, 1, "Студент2", 77840182, "/img/Студент2.jpg" },
                    { 3, 2, "Студент3", 68593027, "/img/Студент3.jpg" },
                    { 4, 2, "Студент5", 77869104, "/img/Студент5.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseID",
                table: "Groups",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherID",
                table: "Groups",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupID",
                table: "Students",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
