using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirement_jobCategory_JobCategoryId",
                table: "JobRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobCategory",
                table: "jobCategory");

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

            migrationBuilder.RenameTable(
                name: "jobCategory",
                newName: "JobCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategory",
                table: "JobCategory",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirement_JobCategory_JobCategoryId",
                table: "JobRequirement",
                column: "JobCategoryId",
                principalTable: "JobCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirement_JobCategory_JobCategoryId",
                table: "JobRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategory",
                table: "JobCategory");

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

            migrationBuilder.RenameTable(
                name: "JobCategory",
                newName: "jobCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobCategory",
                table: "jobCategory",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirement_jobCategory_JobCategoryId",
                table: "JobRequirement",
                column: "JobCategoryId",
                principalTable: "jobCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
