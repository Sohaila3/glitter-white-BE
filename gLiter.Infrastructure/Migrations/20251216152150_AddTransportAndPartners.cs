using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gLiter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTransportAndPartners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrivacyPolicyAccepted",
                table: "ContactMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HeroSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuccessPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuccessPartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHandled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportRequestImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportRequestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRequestImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportRequestImages_TransportRequests_TransportRequestId",
                        column: x => x.TransportRequestId,
                        principalTable: "TransportRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 16, 15, 21, 50, 243, DateTimeKind.Utc).AddTicks(1210), new byte[] { 125, 103, 152, 27, 253, 89, 118, 176, 128, 22, 225, 169, 26, 69, 84, 12, 216, 86, 172, 176, 118, 50, 97, 67, 160, 35, 245, 2, 154, 103, 118, 117, 66, 143, 66, 1, 224, 204, 99, 205, 50, 126, 132, 57, 21, 96, 144, 57, 237, 140, 121, 60, 199, 135, 188, 41, 250, 211, 221, 3, 94, 196, 89, 2 }, new byte[] { 231, 166, 10, 134, 180, 135, 224, 68, 147, 105, 238, 96, 1, 29, 255, 253, 150, 166, 227, 221, 219, 61, 104, 163, 27, 27, 80, 231, 155, 213, 45, 183, 94, 215, 197, 40, 182, 81, 7, 34, 239, 129, 89, 228, 129, 174, 151, 90, 170, 181, 126, 20, 105, 45, 146, 204, 79, 178, 230, 218, 5, 82, 152, 22, 126, 91, 143, 140, 41, 180, 218, 79, 196, 48, 120, 211, 94, 189, 25, 34, 42, 125, 207, 114, 41, 74, 189, 0, 126, 143, 115, 84, 176, 77, 6, 27, 149, 86, 196, 90, 165, 152, 249, 134, 194, 241, 209, 160, 42, 115, 128, 249, 99, 137, 175, 223, 143, 251, 210, 152, 253, 211, 55, 22, 141, 47, 159, 166 } });

            migrationBuilder.CreateIndex(
                name: "IX_TransportRequestImages_TransportRequestId",
                table: "TransportRequestImages",
                column: "TransportRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroSections");

            migrationBuilder.DropTable(
                name: "SuccessPartners");

            migrationBuilder.DropTable(
                name: "TransportRequestImages");

            migrationBuilder.DropTable(
                name: "TransportRequests");

            migrationBuilder.DropColumn(
                name: "PrivacyPolicyAccepted",
                table: "ContactMessages");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 12, 9, 38, 25, 6, DateTimeKind.Utc).AddTicks(7310), new byte[] { 129, 54, 177, 38, 15, 168, 70, 205, 83, 79, 237, 137, 57, 125, 105, 185, 117, 104, 35, 87, 27, 150, 192, 61, 58, 143, 72, 211, 4, 137, 229, 50, 130, 140, 70, 191, 233, 103, 170, 82, 7, 123, 13, 144, 88, 240, 95, 202, 106, 244, 225, 62, 63, 70, 105, 254, 38, 194, 89, 78, 98, 12, 28, 113 }, new byte[] { 222, 46, 65, 59, 235, 60, 14, 173, 137, 211, 227, 183, 137, 223, 190, 149, 4, 76, 162, 238, 85, 154, 79, 56, 196, 2, 57, 66, 204, 88, 253, 221, 98, 7, 179, 202, 140, 159, 29, 125, 64, 10, 87, 161, 187, 19, 154, 166, 160, 219, 14, 224, 177, 70, 146, 103, 29, 113, 155, 52, 82, 107, 253, 11, 55, 145, 218, 114, 116, 4, 104, 15, 226, 246, 4, 130, 57, 76, 67, 229, 28, 159, 98, 228, 109, 26, 224, 225, 3, 4, 170, 93, 211, 8, 160, 114, 206, 89, 101, 51, 10, 89, 156, 104, 38, 34, 152, 84, 224, 27, 122, 80, 201, 177, 159, 176, 158, 103, 95, 215, 36, 64, 102, 58, 140, 42, 71, 132 } });
        }
    }
}
