using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gLiter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJobApplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReviewed = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppliedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 16, 26, 15, 396, DateTimeKind.Utc).AddTicks(5060), new byte[] { 136, 33, 228, 170, 54, 135, 221, 200, 5, 191, 115, 182, 171, 125, 94, 235, 5, 159, 208, 86, 41, 109, 154, 14, 61, 195, 8, 34, 73, 184, 20, 67, 121, 167, 58, 90, 121, 59, 30, 95, 212, 220, 210, 123, 139, 139, 65, 66, 45, 182, 9, 75, 81, 27, 84, 231, 8, 17, 169, 110, 111, 16, 240, 152 }, new byte[] { 165, 228, 70, 109, 102, 107, 175, 42, 243, 107, 172, 167, 179, 7, 19, 158, 118, 238, 121, 0, 212, 81, 12, 140, 83, 132, 115, 146, 18, 211, 68, 101, 91, 218, 61, 225, 248, 76, 124, 75, 153, 212, 26, 192, 93, 77, 92, 9, 44, 35, 0, 121, 178, 175, 159, 21, 210, 249, 11, 186, 54, 212, 226, 141, 38, 225, 186, 6, 219, 211, 212, 214, 73, 47, 8, 115, 163, 177, 56, 180, 212, 84, 244, 50, 168, 196, 232, 132, 68, 236, 200, 8, 147, 194, 168, 29, 54, 85, 161, 185, 213, 112, 157, 169, 87, 141, 218, 111, 40, 23, 117, 84, 41, 138, 115, 16, 64, 96, 238, 95, 162, 34, 224, 97, 39, 25, 111, 57 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 16, 26, 15, 396, DateTimeKind.Utc).AddTicks(5060), new byte[] { 136, 33, 228, 170, 54, 135, 221, 200, 5, 191, 115, 182, 171, 125, 94, 235, 5, 159, 208, 86, 41, 109, 154, 14, 61, 195, 8, 34, 73, 184, 20, 67, 121, 167, 58, 90, 121, 59, 30, 95, 212, 220, 210, 123, 139, 139, 65, 66, 45, 182, 9, 75, 81, 27, 84, 231, 8, 17, 169, 110, 111, 16, 240, 152 }, new byte[] { 165, 228, 70, 109, 102, 107, 175, 42, 243, 107, 172, 167, 179, 7, 19, 158, 118, 238, 121, 0, 212, 81, 12, 140, 83, 132, 115, 146, 18, 211, 68, 101, 91, 218, 61, 225, 248, 76, 124, 75, 153, 212, 26, 192, 93, 77, 92, 9, 44, 35, 0, 121, 178, 175, 159, 21, 210, 249, 11, 186, 54, 212, 226, 141, 38, 225, 186, 6, 219, 211, 212, 214, 73, 47, 8, 115, 163, 177, 56, 180, 212, 84, 244, 50, 168, 196, 232, 132, 68, 236, 200, 8, 147, 194, 168, 29, 54, 85, 161, 185, 213, 112, 157, 169, 87, 141, 218, 111, 40, 23, 117, 84, 41, 138, 115, 16, 64, 96, 238, 95, 162, 34, 224, 97, 39, 25, 111, 57 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 16, 26, 15, 396, DateTimeKind.Utc).AddTicks(5060), new byte[] { 136, 33, 228, 170, 54, 135, 221, 200, 5, 191, 115, 182, 171, 125, 94, 235, 5, 159, 208, 86, 41, 109, 154, 14, 61, 195, 8, 34, 73, 184, 20, 67, 121, 167, 58, 90, 121, 59, 30, 95, 212, 220, 210, 123, 139, 139, 65, 66, 45, 182, 9, 75, 81, 27, 84, 231, 8, 17, 169, 110, 111, 16, 240, 152 }, new byte[] { 165, 228, 70, 109, 102, 107, 175, 42, 243, 107, 172, 167, 179, 7, 19, 158, 118, 238, 121, 0, 212, 81, 12, 140, 83, 132, 115, 146, 18, 211, 68, 101, 91, 218, 61, 225, 248, 76, 124, 75, 153, 212, 26, 192, 93, 77, 92, 9, 44, 35, 0, 121, 178, 175, 159, 21, 210, 249, 11, 186, 54, 212, 226, 141, 38, 225, 186, 6, 219, 211, 212, 214, 73, 47, 8, 115, 163, 177, 56, 180, 212, 84, 244, 50, 168, 196, 232, 132, 68, 236, 200, 8, 147, 194, 168, 29, 54, 85, 161, 185, 213, 112, 157, 169, 87, 141, 218, 111, 40, 23, 117, 84, 41, 138, 115, 16, 64, 96, 238, 95, 162, 34, 224, 97, 39, 25, 111, 57 } });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 25, 12, 16, 31, 506, DateTimeKind.Utc).AddTicks(7660), new byte[] { 254, 3, 206, 106, 234, 7, 28, 99, 29, 44, 193, 201, 183, 183, 24, 32, 150, 227, 173, 145, 249, 130, 232, 39, 35, 63, 18, 156, 246, 126, 249, 193, 27, 71, 3, 72, 62, 149, 59, 101, 131, 161, 64, 215, 153, 2, 62, 76, 17, 136, 37, 194, 34, 88, 237, 12, 129, 66, 64, 4, 206, 218, 207, 86 }, new byte[] { 64, 13, 224, 114, 42, 4, 62, 252, 100, 213, 183, 55, 144, 73, 218, 55, 198, 53, 189, 59, 204, 205, 138, 83, 186, 10, 234, 59, 19, 30, 158, 241, 214, 35, 152, 84, 140, 112, 116, 64, 176, 155, 6, 52, 147, 165, 201, 94, 12, 186, 240, 103, 69, 226, 230, 231, 234, 90, 177, 179, 153, 25, 43, 221, 44, 129, 113, 31, 239, 40, 74, 85, 25, 221, 103, 114, 44, 93, 223, 205, 218, 72, 188, 45, 158, 165, 112, 187, 195, 147, 195, 37, 172, 228, 123, 82, 95, 46, 72, 139, 97, 20, 19, 138, 0, 168, 225, 33, 209, 122, 100, 50, 16, 156, 111, 183, 35, 171, 169, 108, 196, 135, 5, 101, 114, 98, 75, 25 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 25, 12, 16, 31, 506, DateTimeKind.Utc).AddTicks(7660), new byte[] { 254, 3, 206, 106, 234, 7, 28, 99, 29, 44, 193, 201, 183, 183, 24, 32, 150, 227, 173, 145, 249, 130, 232, 39, 35, 63, 18, 156, 246, 126, 249, 193, 27, 71, 3, 72, 62, 149, 59, 101, 131, 161, 64, 215, 153, 2, 62, 76, 17, 136, 37, 194, 34, 88, 237, 12, 129, 66, 64, 4, 206, 218, 207, 86 }, new byte[] { 64, 13, 224, 114, 42, 4, 62, 252, 100, 213, 183, 55, 144, 73, 218, 55, 198, 53, 189, 59, 204, 205, 138, 83, 186, 10, 234, 59, 19, 30, 158, 241, 214, 35, 152, 84, 140, 112, 116, 64, 176, 155, 6, 52, 147, 165, 201, 94, 12, 186, 240, 103, 69, 226, 230, 231, 234, 90, 177, 179, 153, 25, 43, 221, 44, 129, 113, 31, 239, 40, 74, 85, 25, 221, 103, 114, 44, 93, 223, 205, 218, 72, 188, 45, 158, 165, 112, 187, 195, 147, 195, 37, 172, 228, 123, 82, 95, 46, 72, 139, 97, 20, 19, 138, 0, 168, 225, 33, 209, 122, 100, 50, 16, 156, 111, 183, 35, 171, 169, 108, 196, 135, 5, 101, 114, 98, 75, 25 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 25, 12, 16, 31, 506, DateTimeKind.Utc).AddTicks(7660), new byte[] { 254, 3, 206, 106, 234, 7, 28, 99, 29, 44, 193, 201, 183, 183, 24, 32, 150, 227, 173, 145, 249, 130, 232, 39, 35, 63, 18, 156, 246, 126, 249, 193, 27, 71, 3, 72, 62, 149, 59, 101, 131, 161, 64, 215, 153, 2, 62, 76, 17, 136, 37, 194, 34, 88, 237, 12, 129, 66, 64, 4, 206, 218, 207, 86 }, new byte[] { 64, 13, 224, 114, 42, 4, 62, 252, 100, 213, 183, 55, 144, 73, 218, 55, 198, 53, 189, 59, 204, 205, 138, 83, 186, 10, 234, 59, 19, 30, 158, 241, 214, 35, 152, 84, 140, 112, 116, 64, 176, 155, 6, 52, 147, 165, 201, 94, 12, 186, 240, 103, 69, 226, 230, 231, 234, 90, 177, 179, 153, 25, 43, 221, 44, 129, 113, 31, 239, 40, 74, 85, 25, 221, 103, 114, 44, 93, 223, 205, 218, 72, 188, 45, 158, 165, 112, 187, 195, 147, 195, 37, 172, 228, 123, 82, 95, 46, 72, 139, 97, 20, 19, 138, 0, 168, 225, 33, 209, 122, 100, 50, 16, 156, 111, 183, 35, 171, 169, 108, 196, 135, 5, 101, 114, 98, 75, 25 } });
        }
    }
}
