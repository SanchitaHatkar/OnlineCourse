using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourseRegistration.Migrations
{
    /// <inheritdoc />
    public partial class CreateCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Students",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Students",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "courseID",
                table: "Students",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Students",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "contactno",
                table: "Students",
                newName: "Contactno");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Students",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Students",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseID",
                table: "Students",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseID",
                table: "Students",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Students",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Students",
                newName: "courseID");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Students",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "Contactno",
                table: "Students",
                newName: "contactno");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Students",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "address");
        }
    }
}
