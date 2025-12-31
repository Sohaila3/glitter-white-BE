using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gLiter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new byte[] { 163, 156, 132, 218, 88, 224, 47, 158, 0, 71, 188, 7, 25, 198, 43, 39, 216, 196, 107, 106, 80, 100, 179, 117, 125, 44, 209, 217, 45, 251, 219, 130, 63, 237, 6, 216, 95, 89, 15, 63, 122, 24, 254, 23, 131, 234, 45, 94, 141, 198, 241, 125, 31, 118, 113, 98, 26, 1, 130, 168, 38, 184, 172, 210 }, new byte[] { 95, 56, 239, 211, 56, 115, 125, 202, 54, 137, 126, 99, 97, 3, 148, 183, 114, 192, 53, 166, 177, 236, 220, 179, 132, 123, 202, 184, 154, 55, 45, 208, 95, 112, 253, 60, 193, 113, 189, 226, 197, 183, 34, 105, 44, 61, 100, 234, 220, 241, 13, 105, 113, 253, 176, 5, 112, 205, 73, 17, 123, 31, 185, 88, 28, 112, 200, 206, 174, 178, 112, 225, 126, 68, 76, 99, 255, 4, 227, 172, 45, 31, 80, 8, 81, 139, 81, 225, 216, 84, 40, 132, 190, 181, 86, 255, 166, 128, 215, 17, 177, 162, 8, 88, 232, 18, 164, 239, 155, 141, 90, 244, 99, 66, 83, 235, 81, 153, 214, 44, 235, 17, 5, 195, 12, 126, 35, 11 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new byte[] { 163, 156, 132, 218, 88, 224, 47, 158, 0, 71, 188, 7, 25, 198, 43, 39, 216, 196, 107, 106, 80, 100, 179, 117, 125, 44, 209, 217, 45, 251, 219, 130, 63, 237, 6, 216, 95, 89, 15, 63, 122, 24, 254, 23, 131, 234, 45, 94, 141, 198, 241, 125, 31, 118, 113, 98, 26, 1, 130, 168, 38, 184, 172, 210 }, new byte[] { 95, 56, 239, 211, 56, 115, 125, 202, 54, 137, 126, 99, 97, 3, 148, 183, 114, 192, 53, 166, 177, 236, 220, 179, 132, 123, 202, 184, 154, 55, 45, 208, 95, 112, 253, 60, 193, 113, 189, 226, 197, 183, 34, 105, 44, 61, 100, 234, 220, 241, 13, 105, 113, 253, 176, 5, 112, 205, 73, 17, 123, 31, 185, 88, 28, 112, 200, 206, 174, 178, 112, 225, 126, 68, 76, 99, 255, 4, 227, 172, 45, 31, 80, 8, 81, 139, 81, 225, 216, 84, 40, 132, 190, 181, 86, 255, 166, 128, 215, 17, 177, 162, 8, 88, 232, 18, 164, 239, 155, 141, 90, 244, 99, 66, 83, 235, 81, 153, 214, 44, 235, 17, 5, 195, 12, 126, 35, 11 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new byte[] { 163, 156, 132, 218, 88, 224, 47, 158, 0, 71, 188, 7, 25, 198, 43, 39, 216, 196, 107, 106, 80, 100, 179, 117, 125, 44, 209, 217, 45, 251, 219, 130, 63, 237, 6, 216, 95, 89, 15, 63, 122, 24, 254, 23, 131, 234, 45, 94, 141, 198, 241, 125, 31, 118, 113, 98, 26, 1, 130, 168, 38, 184, 172, 210 }, new byte[] { 95, 56, 239, 211, 56, 115, 125, 202, 54, 137, 126, 99, 97, 3, 148, 183, 114, 192, 53, 166, 177, 236, 220, 179, 132, 123, 202, 184, 154, 55, 45, 208, 95, 112, 253, 60, 193, 113, 189, 226, 197, 183, 34, 105, 44, 61, 100, 234, 220, 241, 13, 105, 113, 253, 176, 5, 112, 205, 73, 17, 123, 31, 185, 88, 28, 112, 200, 206, 174, 178, 112, 225, 126, 68, 76, 99, 255, 4, 227, 172, 45, 31, 80, 8, 81, 139, 81, 225, 216, 84, 40, 132, 190, 181, 86, 255, 166, 128, 215, 17, 177, 162, 8, 88, 232, 18, 164, 239, 155, 141, 90, 244, 99, 66, 83, 235, 81, 153, 214, 44, 235, 17, 5, 195, 12, 126, 35, 11 } });

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "Id", "CreatedAt", "DescriptionAr", "DescriptionEn", "EffectiveDate", "FuelType", "Price", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سعر لتر بنزين 80", "Gasoline 80 price per liter", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gasoline80", 12.25m, "بنزين 80", "Gasoline 80", null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سعر لتر بنزين 92", "Gasoline 92 price per liter", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gasoline92", 13.75m, "بنزين 92", "Gasoline 92", null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سعر لتر بنزين 95", "Gasoline 95 price per liter", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gasoline95", 15.00m, "بنزين 95", "Gasoline 95", null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سعر لتر السولار", "Diesel price per liter", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Diesel", 10.00m, "سولار", "Diesel", null }
                });

            migrationBuilder.InsertData(
                table: "GalleryImages",
                columns: new[] { "Id", "CreatedAt", "DescriptionAr", "DescriptionEn", "ImageUrl", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "صورة لمحطة الوقود الرئيسية في القاهرة", "Photo of the main fuel station in Cairo", "/images/gallery/station-1.jpg", "محطة الوقود الرئيسية", "Main Fuel Station", null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "جزء من أسطول نقل الوقود الحديث", "Part of our modern fuel transport fleet", "/images/gallery/fleet-1.jpg", "أسطول النقل", "Transport Fleet", null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فريق العمل المحترف في جي ليتر", "Professional team at G-Liter", "/images/gallery/team-1.jpg", "فريق العمل", "Our Team", null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أحدث معدات السلامة المستخدمة", "Latest safety equipment in use", "/images/gallery/safety-1.jpg", "معدات السلامة", "Safety Equipment", null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedAt", "DescriptionAr", "DescriptionEn", "ExpiresAt", "IsActive", "Location", "PostedAt", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مطلوب سائق صهريج وقود بخبرة لا تقل عن 3 سنوات. رخصة قيادة مهنية درجة أولى.", "Fuel tanker driver needed with minimum 3 years experience. First class professional driving license required.", new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), true, "Cairo, Egypt", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سائق صهريج وقود", "Fuel Tanker Driver", null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فني صيانة للعمل في محطات الوقود. خبرة في صيانة المعدات الميكانيكية والكهربائية.", "Maintenance technician for fuel stations. Experience in mechanical and electrical equipment maintenance.", new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), true, "Alexandria, Egypt", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فني صيانة محطات", "Station Maintenance Technician", null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محاسب للعمل في المقر الرئيسي. بكالوريوس تجارة وخبرة لا تقل عن سنتين.", "Accountant for head office. Commerce degree with minimum 2 years experience.", new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), true, "Cairo, Egypt", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محاسب", "Accountant", null }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "DescriptionAr", "DescriptionEn", "ImageUrl", "IsPublished", "PublishedAt", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "تم افتتاح محطة وقود جديدة في منطقة التجمع الخامس لخدمة سكان المنطقة بأعلى معايير الجودة.", "A new fuel station has been opened in the Fifth Settlement area to serve residents with the highest quality standards.", "/images/news/new-station.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "افتتاح محطة وقود جديدة", "New Fuel Station Opening", null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "تم تحديث أسعار الوقود وفقاً للأسعار العالمية. الأسعار الجديدة سارية من اليوم.", "Fuel prices have been updated according to global prices. New prices are effective from today.", "/images/news/prices-update.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "تحديث أسعار الوقود", "Fuel Prices Update", null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "توقيع اتفاقية شراكة استراتيجية مع كبرى شركات الطاقة لتوسيع نطاق خدماتنا.", "Signing a strategic partnership agreement with major energy companies to expand our services.", "/images/news/partnership.jpg", true, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شراكة استراتيجية جديدة", "New Strategic Partnership", null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "خدمة نقل الوقود بأعلى معايير الأمان والجودة إلى جميع المحطات", "Fuel transportation service with the highest safety and quality standards to all stations", "/images/services/fuel-transport.svg", "نقل الوقود", "Fuel Transportation", null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إدارة شاملة لمحطات الوقود تشمل الصيانة والتشغيل", "Comprehensive fuel station management including maintenance and operations", "/images/services/station-management.svg", "إدارة المحطات", "Station Management", null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إدارة وصيانة أسطول النقل بأحدث التقنيات", "Fleet management and maintenance with the latest technologies", "/images/services/fleet.svg", "خدمات الأسطول", "Fleet Services", null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "استشارات متخصصة في قطاع الطاقة والوقود", "Specialized consulting in the energy and fuel sector", "/images/services/consulting.svg", "الاستشارات", "Consulting", null }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "24.174776,47.338509", "Riyadh", "KSA", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محطة السديس - خدمات متكاملة", "Al Sudais Station - Full Services", 24.174776, 47.338509, "+966 11 1111111", "محطة السديس", "Al Sudais Station", null },
                    { 2, "25.867285,43.488796", "Al Qassim", "KSA", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محطة الحركاني المتميزة", "Al Harkani Premium Station", 25.867285, 43.488796, "+966 11 2222222", "محطة الحركاني", "Al Harkani Station", null },
                    { 3, "24.142792,47.367218", "Riyadh", "KSA", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محطة النسيم في الرياض", "Al Naseem Station in Riyadh", 24.142792, 47.367218, "+966 11 3333333", "محطة النسيم", "Al Naseem Station", null },
                    { 4, "24.174555,47.338200", "Riyadh", "KSA", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محطة العاليات الحديثة", "Al Aliyat Modern Station", 24.174555, 47.338200, "+966 11 4444444", "محطة العاليات", "Al Aliyat Station", null },
                    { 5, "24.620861,46.845005", "Riyadh", "KSA", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محطة الجوية", "Al Jawiyah Station", 24.620861, 46.845005, "+966 11 5555555", "محطة الجوية", "Al Jawiyah Station", null }
                });

            migrationBuilder.InsertData(
                table: "SuccessPartners",
                columns: new[] { "Id", "CreatedAt", "DescriptionAr", "DescriptionEn", "LogoUrl", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شريك استراتيجي في توريد الوقود", "Strategic partner in fuel supply", "/images/partners/npc-logo.png", "شركة البترول الوطنية", "National Petroleum Company", null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شريك في مشاريع الطاقة المستدامة", "Partner in sustainable energy projects", "/images/partners/rec-logo.png", "شركة الطاقة المتجددة", "Renewable Energy Co", null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شريك مالي واستثماري", "Financial and investment partner", "/images/partners/ib-logo.png", "بنك الاستثمار", "Investment Bank", null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شريك في خدمات النقل واللوجستيات", "Partner in transport and logistics services", "/images/partners/itc-logo.png", "شركة النقل الدولية", "International Transport Co", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GalleryImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SuccessPartners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SuccessPartners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SuccessPartners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SuccessPartners",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReviewed = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                values: new object[] { new DateTime(2025, 12, 26, 18, 10, 55, 622, DateTimeKind.Utc).AddTicks(3410), new byte[] { 205, 32, 151, 239, 36, 96, 74, 239, 221, 83, 196, 25, 85, 162, 153, 231, 215, 6, 142, 208, 201, 23, 33, 213, 252, 163, 251, 25, 179, 72, 24, 42, 168, 224, 181, 189, 186, 229, 12, 229, 209, 111, 165, 177, 113, 72, 61, 137, 130, 95, 151, 135, 136, 235, 170, 214, 198, 216, 255, 34, 220, 78, 147, 255 }, new byte[] { 113, 131, 150, 39, 216, 110, 192, 79, 61, 67, 7, 89, 228, 152, 181, 74, 224, 99, 135, 33, 135, 49, 202, 243, 128, 157, 166, 44, 41, 225, 244, 238, 235, 147, 0, 164, 178, 172, 80, 16, 212, 54, 41, 106, 235, 61, 63, 141, 32, 44, 213, 202, 35, 127, 141, 125, 1, 244, 211, 57, 27, 207, 248, 159, 34, 9, 239, 37, 236, 77, 28, 97, 27, 71, 148, 167, 63, 121, 175, 112, 189, 176, 119, 11, 27, 151, 189, 101, 163, 99, 20, 69, 239, 119, 165, 21, 199, 48, 69, 187, 45, 20, 113, 59, 239, 208, 123, 252, 174, 59, 164, 167, 117, 6, 250, 249, 245, 159, 16, 56, 30, 215, 121, 208, 33, 230, 132, 52 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 18, 10, 55, 622, DateTimeKind.Utc).AddTicks(3420), new byte[] { 205, 32, 151, 239, 36, 96, 74, 239, 221, 83, 196, 25, 85, 162, 153, 231, 215, 6, 142, 208, 201, 23, 33, 213, 252, 163, 251, 25, 179, 72, 24, 42, 168, 224, 181, 189, 186, 229, 12, 229, 209, 111, 165, 177, 113, 72, 61, 137, 130, 95, 151, 135, 136, 235, 170, 214, 198, 216, 255, 34, 220, 78, 147, 255 }, new byte[] { 113, 131, 150, 39, 216, 110, 192, 79, 61, 67, 7, 89, 228, 152, 181, 74, 224, 99, 135, 33, 135, 49, 202, 243, 128, 157, 166, 44, 41, 225, 244, 238, 235, 147, 0, 164, 178, 172, 80, 16, 212, 54, 41, 106, 235, 61, 63, 141, 32, 44, 213, 202, 35, 127, 141, 125, 1, 244, 211, 57, 27, 207, 248, 159, 34, 9, 239, 37, 236, 77, 28, 97, 27, 71, 148, 167, 63, 121, 175, 112, 189, 176, 119, 11, 27, 151, 189, 101, 163, 99, 20, 69, 239, 119, 165, 21, 199, 48, 69, 187, 45, 20, 113, 59, 239, 208, 123, 252, 174, 59, 164, 167, 117, 6, 250, 249, 245, 159, 16, 56, 30, 215, 121, 208, 33, 230, 132, 52 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 12, 26, 18, 10, 55, 622, DateTimeKind.Utc).AddTicks(3420), new byte[] { 205, 32, 151, 239, 36, 96, 74, 239, 221, 83, 196, 25, 85, 162, 153, 231, 215, 6, 142, 208, 201, 23, 33, 213, 252, 163, 251, 25, 179, 72, 24, 42, 168, 224, 181, 189, 186, 229, 12, 229, 209, 111, 165, 177, 113, 72, 61, 137, 130, 95, 151, 135, 136, 235, 170, 214, 198, 216, 255, 34, 220, 78, 147, 255 }, new byte[] { 113, 131, 150, 39, 216, 110, 192, 79, 61, 67, 7, 89, 228, 152, 181, 74, 224, 99, 135, 33, 135, 49, 202, 243, 128, 157, 166, 44, 41, 225, 244, 238, 235, 147, 0, 164, 178, 172, 80, 16, 212, 54, 41, 106, 235, 61, 63, 141, 32, 44, 213, 202, 35, 127, 141, 125, 1, 244, 211, 57, 27, 207, 248, 159, 34, 9, 239, 37, 236, 77, 28, 97, 27, 71, 148, 167, 63, 121, 175, 112, 189, 176, 119, 11, 27, 151, 189, 101, 163, 99, 20, 69, 239, 119, 165, 21, 199, 48, 69, 187, 45, 20, 113, 59, 239, 208, 123, 252, 174, 59, 164, 167, 117, 6, 250, 249, 245, 159, 16, 56, 30, 215, 121, 208, 33, 230, 132, 52 } });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");
        }
    }
}
