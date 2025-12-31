using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gLiter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 17, 49, 17, 184, DateTimeKind.Utc).AddTicks(8760), new byte[] { 6, 124, 67, 159, 245, 139, 182, 233, 177, 65, 96, 135, 121, 44, 39, 188, 2, 78, 128, 60, 41, 153, 49, 57, 227, 219, 116, 84, 32, 145, 46, 218, 168, 247, 218, 200, 145, 22, 254, 121, 108, 106, 208, 26, 215, 139, 150, 159, 58, 201, 134, 148, 197, 108, 220, 22, 137, 145, 6, 44, 183, 210, 237, 201 }, new byte[] { 66, 188, 151, 249, 140, 144, 110, 203, 14, 148, 134, 38, 159, 236, 202, 106, 97, 32, 16, 213, 209, 232, 11, 218, 27, 83, 11, 98, 24, 46, 214, 84, 40, 206, 254, 247, 137, 222, 179, 194, 233, 57, 215, 223, 197, 62, 182, 151, 63, 176, 132, 150, 38, 244, 162, 188, 106, 141, 111, 0, 92, 62, 156, 28, 160, 139, 44, 57, 5, 40, 122, 79, 213, 229, 213, 174, 39, 98, 10, 213, 191, 42, 98, 209, 67, 39, 198, 83, 117, 83, 189, 58, 87, 225, 212, 10, 232, 232, 144, 247, 253, 15, 210, 36, 22, 180, 4, 38, 89, 64, 113, 123, 239, 51, 39, 40, 14, 118, 144, 117, 51, 5, 55, 36, 21, 115, 101, 172 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 17, 49, 17, 184, DateTimeKind.Utc).AddTicks(8760), new byte[] { 6, 124, 67, 159, 245, 139, 182, 233, 177, 65, 96, 135, 121, 44, 39, 188, 2, 78, 128, 60, 41, 153, 49, 57, 227, 219, 116, 84, 32, 145, 46, 218, 168, 247, 218, 200, 145, 22, 254, 121, 108, 106, 208, 26, 215, 139, 150, 159, 58, 201, 134, 148, 197, 108, 220, 22, 137, 145, 6, 44, 183, 210, 237, 201 }, new byte[] { 66, 188, 151, 249, 140, 144, 110, 203, 14, 148, 134, 38, 159, 236, 202, 106, 97, 32, 16, 213, 209, 232, 11, 218, 27, 83, 11, 98, 24, 46, 214, 84, 40, 206, 254, 247, 137, 222, 179, 194, 233, 57, 215, 223, 197, 62, 182, 151, 63, 176, 132, 150, 38, 244, 162, 188, 106, 141, 111, 0, 92, 62, 156, 28, 160, 139, 44, 57, 5, 40, 122, 79, 213, 229, 213, 174, 39, 98, 10, 213, 191, 42, 98, 209, 67, 39, 198, 83, 117, 83, 189, 58, 87, 225, 212, 10, 232, 232, 144, 247, 253, 15, 210, 36, 22, 180, 4, 38, 89, 64, 113, 123, 239, 51, 39, 40, 14, 118, 144, 117, 51, 5, 55, 36, 21, 115, 101, 172 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 17, 49, 17, 184, DateTimeKind.Utc).AddTicks(8760), new byte[] { 6, 124, 67, 159, 245, 139, 182, 233, 177, 65, 96, 135, 121, 44, 39, 188, 2, 78, 128, 60, 41, 153, 49, 57, 227, 219, 116, 84, 32, 145, 46, 218, 168, 247, 218, 200, 145, 22, 254, 121, 108, 106, 208, 26, 215, 139, 150, 159, 58, 201, 134, 148, 197, 108, 220, 22, 137, 145, 6, 44, 183, 210, 237, 201 }, new byte[] { 66, 188, 151, 249, 140, 144, 110, 203, 14, 148, 134, 38, 159, 236, 202, 106, 97, 32, 16, 213, 209, 232, 11, 218, 27, 83, 11, 98, 24, 46, 214, 84, 40, 206, 254, 247, 137, 222, 179, 194, 233, 57, 215, 223, 197, 62, 182, 151, 63, 176, 132, 150, 38, 244, 162, 188, 106, 141, 111, 0, 92, 62, 156, 28, 160, 139, 44, 57, 5, 40, 122, 79, 213, 229, 213, 174, 39, 98, 10, 213, 191, 42, 98, 209, 67, 39, 198, 83, 117, 83, 189, 58, 87, 225, 212, 10, 232, 232, 144, 247, 253, 15, 210, 36, 22, 180, 4, 38, 89, 64, 113, 123, 239, 51, 39, 40, 14, 118, 144, 117, 51, 5, 55, 36, 21, 115, 101, 172 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

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
        }
    }
}
