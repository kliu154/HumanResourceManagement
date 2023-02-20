using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewStatusId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewTypeId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_SubmissionId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeRoleId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeTypeId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewStatusId",
                table: "Interview",
                column: "InterviewStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewTypeId",
                table: "Interview",
                column: "InterviewTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interview_SubmissionId",
                table: "Interview",
                column: "SubmissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeRoleId",
                table: "Employee",
                column: "EmployeeRoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeId",
                table: "Employee",
                column: "EmployeeTypeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewStatusId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewTypeId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_SubmissionId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeRoleId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeTypeId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewStatusId",
                table: "Interview",
                column: "InterviewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewTypeId",
                table: "Interview",
                column: "InterviewTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_SubmissionId",
                table: "Interview",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeRoleId",
                table: "Employee",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeId",
                table: "Employee",
                column: "EmployeeTypeId");
        }
    }
}
