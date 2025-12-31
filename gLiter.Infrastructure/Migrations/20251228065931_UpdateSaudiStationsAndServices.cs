using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gLiter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaudiStationsAndServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 184, 199, 98, 33, 46, 122, 128, 39, 148, 234, 18, 151, 188, 131, 85, 117, 225, 116, 10, 211, 45, 78, 189, 36, 172, 137, 87, 235, 228, 61, 77, 37, 14, 110, 80, 65, 32, 247, 220, 22, 24, 25, 53, 226, 199, 2, 231, 57, 146, 131, 223, 82, 119, 124, 107, 29, 62, 234, 57, 4, 12, 150, 142, 167 }, new byte[] { 42, 75, 159, 104, 99, 209, 99, 110, 185, 201, 193, 79, 172, 226, 31, 18, 103, 108, 109, 193, 230, 214, 120, 169, 170, 60, 22, 254, 119, 241, 126, 94, 134, 211, 54, 64, 123, 3, 122, 193, 87, 131, 184, 190, 139, 206, 163, 236, 242, 12, 124, 118, 241, 51, 28, 170, 51, 104, 203, 121, 180, 214, 99, 178, 216, 219, 6, 163, 233, 69, 64, 19, 147, 123, 30, 18, 191, 47, 62, 163, 128, 97, 66, 45, 25, 2, 91, 40, 185, 232, 100, 249, 26, 186, 249, 209, 197, 110, 65, 158, 154, 54, 188, 55, 19, 97, 2, 10, 172, 188, 78, 223, 43, 218, 206, 238, 88, 174, 63, 232, 111, 31, 157, 73, 176, 228, 161, 103 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 184, 199, 98, 33, 46, 122, 128, 39, 148, 234, 18, 151, 188, 131, 85, 117, 225, 116, 10, 211, 45, 78, 189, 36, 172, 137, 87, 235, 228, 61, 77, 37, 14, 110, 80, 65, 32, 247, 220, 22, 24, 25, 53, 226, 199, 2, 231, 57, 146, 131, 223, 82, 119, 124, 107, 29, 62, 234, 57, 4, 12, 150, 142, 167 }, new byte[] { 42, 75, 159, 104, 99, 209, 99, 110, 185, 201, 193, 79, 172, 226, 31, 18, 103, 108, 109, 193, 230, 214, 120, 169, 170, 60, 22, 254, 119, 241, 126, 94, 134, 211, 54, 64, 123, 3, 122, 193, 87, 131, 184, 190, 139, 206, 163, 236, 242, 12, 124, 118, 241, 51, 28, 170, 51, 104, 203, 121, 180, 214, 99, 178, 216, 219, 6, 163, 233, 69, 64, 19, 147, 123, 30, 18, 191, 47, 62, 163, 128, 97, 66, 45, 25, 2, 91, 40, 185, 232, 100, 249, 26, 186, 249, 209, 197, 110, 65, 158, 154, 54, 188, 55, 19, 97, 2, 10, 172, 188, 78, 223, 43, 218, 206, 238, 88, 174, 63, 232, 111, 31, 157, 73, 176, 228, 161, 103 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 184, 199, 98, 33, 46, 122, 128, 39, 148, 234, 18, 151, 188, 131, 85, 117, 225, 116, 10, 211, 45, 78, 189, 36, 172, 137, 87, 235, 228, 61, 77, 37, 14, 110, 80, 65, 32, 247, 220, 22, 24, 25, 53, 226, 199, 2, 231, 57, 146, 131, 223, 82, 119, 124, 107, 29, 62, 234, 57, 4, 12, 150, 142, 167 }, new byte[] { 42, 75, 159, 104, 99, 209, 99, 110, 185, 201, 193, 79, 172, 226, 31, 18, 103, 108, 109, 193, 230, 214, 120, 169, 170, 60, 22, 254, 119, 241, 126, 94, 134, 211, 54, 64, 123, 3, 122, 193, 87, 131, 184, 190, 139, 206, 163, 236, 242, 12, 124, 118, 241, 51, 28, 170, 51, 104, 203, 121, 180, 214, 99, 178, 216, 219, 6, 163, 233, 69, 64, 19, 147, 123, 30, 18, 191, 47, 62, 163, 128, 97, 66, 45, 25, 2, 91, 40, 185, 232, 100, 249, 26, 186, 249, 209, 197, 110, 65, 158, 154, 54, 188, 55, 19, 97, 2, 10, 172, 188, 78, 223, 43, 218, 206, 238, 88, 174, 63, 232, 111, 31, 157, 73, 176, 228, 161, 103 } });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "وقود عالي الجودة بمعايير عالمية لجميع أنواع المركبات", "High-quality fuel with international standards for all vehicle types", "/images/services/premium-fuel.svg", "وقود ممتاز", "Premium Fuel" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "خدمة غسيل سيارات احترافية بأحدث المعدات والتقنيات", "Professional car wash service with the latest equipment and technologies", "/images/services/car-wash.svg", "غسيل السيارات", "Car Wash" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "مصلى نظيف ومكيف للرجال والنساء مع مرافق وضوء", "Clean air-conditioned prayer room for men and women with ablution facilities", "/images/services/prayer-room.svg", "مصلى", "Prayer Room" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "متجر متكامل يوفر جميع احتياجاتك من المشروبات والوجبات الخفيفة", "Convenience store offering all your beverage and snack needs", "/images/services/mini-market.svg", "ميني ماركت", "Mini Market" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قهوة طازجة ومشروبات ساخنة وباردة لراحتك أثناء الرحلة", "Fresh coffee and hot/cold beverages for your comfort during the journey", "/images/services/coffee-shop.svg", "كوفي شوب", "Coffee Shop", null },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "حمامات نظيفة ومعقمة على مدار الساعة مع خدمات صيانة مستمرة", "Clean and sanitized restrooms 24/7 with continuous maintenance services", "/images/services/restrooms.svg", "دورات مياه نظيفة", "Clean Restrooms", null },
                    { 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أسعار ثابتة وشفافة معتمدة من الجهات الرسمية", "Fixed and transparent prices approved by official authorities", "/images/services/fixed-prices.svg", "أسعار ثابتة", "Fixed Prices", null },
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طرق دفع متعددة وآمنة: نقدي، بطاقات ائتمان، مدى، Apple Pay", "Multiple secure payment methods: Cash, Credit Cards, Mada, Apple Pay", "/images/services/secure-payment.svg", "خيارات دفع آمنة", "Secure Payment Options", null },
                    { 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أعلى معايير الأمان والسلامة مع شهادات جودة معتمدة", "Highest safety standards with certified quality assurance", "/images/services/safety-quality.svg", "الأمان والجودة", "Safety & Quality", null },
                    { 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فريق خدمة عملاء محترف متاح على مدار الساعة لخدمتكم", "Professional customer service team available 24/7 to serve you", "/images/services/customer-service.svg", "خدمة العملاء", "Customer Service", null },
                    { 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "خدمة نفخ الإطارات مجاناً مع فحص ضغط الهواء", "Free tire inflation service with air pressure check", "/images/services/tire-air.svg", "هواء للإطارات", "Tire Air Service", null },
                    { 12, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "خدمة تغيير زيت المحرك بزيوت أصلية عالية الجودة", "Engine oil change service with genuine high-quality oils", "/images/services/oil-change.svg", "تغيير زيت", "Oil Change", null },
                    { 13, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "صراف آلي متاح على مدار الساعة لسحب النقود", "ATM machine available 24/7 for cash withdrawal", "/images/services/atm.svg", "صراف آلي ATM", "ATM Machine", null },
                    { 14, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إنترنت لاسلكي مجاني عالي السرعة لجميع الزوار", "Free high-speed wireless internet for all visitors", "/images/services/wifi.svg", "واي فاي مجاني", "Free WiFi", null }
                });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "طريق الملك فهد، الرياض", "Riyadh", "Saudi Arabia", "محطة وقود متكاملة الخدمات مع مصلى وميني ماركت وكوفي شوب", "Full-service fuel station with prayer room, mini market, and coffee shop", 24.7136, 46.6753, "+966 11 1234567", "محطة السديس", "Al-Sudais Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "طريق الملك عبدالعزيز، جدة", "Jeddah", "Saudi Arabia", "محطة حديثة مع جميع الخدمات المتميزة وغسيل سيارات", "Modern station with all premium services and car wash", 21.485800000000001, 39.192500000000003, "+966 12 2345678", "محطة الحركاني", "Al-Harkani Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "حي النسيم، الرياض", "Riyadh", "Saudi Arabia", "محطة وقود في حي النسيم مع كافة الخدمات", "Fuel station in Al-Naseem district with all services", 24.6877, 46.756999999999998, "+966 11 3456789", "محطة النسيم", "Al-Naseem Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "حي العاليات، المدينة المنورة", "Madinah", "Saudi Arabia", "محطة متكاملة في منطقة العاليات مع مصلى ومتجر", "Integrated station in Al-Aliyat area with prayer room and store", 24.467199999999998, 39.602400000000003, "+966 14 4567890", "محطة العاليات", "Al-Aliyat Station" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, "طريق المطار، الدمام", "Dammam", "Saudi Arabia", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محطة وقود بالقرب من المطار مع خدمات سريعة", "Fuel station near the airport with quick services", 26.4207, 50.088799999999999, "+966 13 5678901", "محطة الجوية", "Al-Jawiya Station", null },
                    { 6, "طريق الملك سعود، الرس", "Al-Rass", "Saudi Arabia", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محطة وقود رئيسية في مدينة الرس مع جميع الخدمات", "Main fuel station in Al-Rass city with all services", 25.866700000000002, 43.5, "+966 16 6789012", "محطة الرس", "Al-Rass Station", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 163, 156, 132, 218, 88, 224, 47, 158, 0, 71, 188, 7, 25, 198, 43, 39, 216, 196, 107, 106, 80, 100, 179, 117, 125, 44, 209, 217, 45, 251, 219, 130, 63, 237, 6, 216, 95, 89, 15, 63, 122, 24, 254, 23, 131, 234, 45, 94, 141, 198, 241, 125, 31, 118, 113, 98, 26, 1, 130, 168, 38, 184, 172, 210 }, new byte[] { 95, 56, 239, 211, 56, 115, 125, 202, 54, 137, 126, 99, 97, 3, 148, 183, 114, 192, 53, 166, 177, 236, 220, 179, 132, 123, 202, 184, 154, 55, 45, 208, 95, 112, 253, 60, 193, 113, 189, 226, 197, 183, 34, 105, 44, 61, 100, 234, 220, 241, 13, 105, 113, 253, 176, 5, 112, 205, 73, 17, 123, 31, 185, 88, 28, 112, 200, 206, 174, 178, 112, 225, 126, 68, 76, 99, 255, 4, 227, 172, 45, 31, 80, 8, 81, 139, 81, 225, 216, 84, 40, 132, 190, 181, 86, 255, 166, 128, 215, 17, 177, 162, 8, 88, 232, 18, 164, 239, 155, 141, 90, 244, 99, 66, 83, 235, 81, 153, 214, 44, 235, 17, 5, 195, 12, 126, 35, 11 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 163, 156, 132, 218, 88, 224, 47, 158, 0, 71, 188, 7, 25, 198, 43, 39, 216, 196, 107, 106, 80, 100, 179, 117, 125, 44, 209, 217, 45, 251, 219, 130, 63, 237, 6, 216, 95, 89, 15, 63, 122, 24, 254, 23, 131, 234, 45, 94, 141, 198, 241, 125, 31, 118, 113, 98, 26, 1, 130, 168, 38, 184, 172, 210 }, new byte[] { 95, 56, 239, 211, 56, 115, 125, 202, 54, 137, 126, 99, 97, 3, 148, 183, 114, 192, 53, 166, 177, 236, 220, 179, 132, 123, 202, 184, 154, 55, 45, 208, 95, 112, 253, 60, 193, 113, 189, 226, 197, 183, 34, 105, 44, 61, 100, 234, 220, 241, 13, 105, 113, 253, 176, 5, 112, 205, 73, 17, 123, 31, 185, 88, 28, 112, 200, 206, 174, 178, 112, 225, 126, 68, 76, 99, 255, 4, 227, 172, 45, 31, 80, 8, 81, 139, 81, 225, 216, 84, 40, 132, 190, 181, 86, 255, 166, 128, 215, 17, 177, 162, 8, 88, 232, 18, 164, 239, 155, 141, 90, 244, 99, 66, 83, 235, 81, 153, 214, 44, 235, 17, 5, 195, 12, 126, 35, 11 } });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 163, 156, 132, 218, 88, 224, 47, 158, 0, 71, 188, 7, 25, 198, 43, 39, 216, 196, 107, 106, 80, 100, 179, 117, 125, 44, 209, 217, 45, 251, 219, 130, 63, 237, 6, 216, 95, 89, 15, 63, 122, 24, 254, 23, 131, 234, 45, 94, 141, 198, 241, 125, 31, 118, 113, 98, 26, 1, 130, 168, 38, 184, 172, 210 }, new byte[] { 95, 56, 239, 211, 56, 115, 125, 202, 54, 137, 126, 99, 97, 3, 148, 183, 114, 192, 53, 166, 177, 236, 220, 179, 132, 123, 202, 184, 154, 55, 45, 208, 95, 112, 253, 60, 193, 113, 189, 226, 197, 183, 34, 105, 44, 61, 100, 234, 220, 241, 13, 105, 113, 253, 176, 5, 112, 205, 73, 17, 123, 31, 185, 88, 28, 112, 200, 206, 174, 178, 112, 225, 126, 68, 76, 99, 255, 4, 227, 172, 45, 31, 80, 8, 81, 139, 81, 225, 216, 84, 40, 132, 190, 181, 86, 255, 166, 128, 215, 17, 177, 162, 8, 88, 232, 18, 164, 239, 155, 141, 90, 244, 99, 66, 83, 235, 81, 153, 214, 44, 235, 17, 5, 195, 12, 126, 35, 11 } });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "خدمة نقل الوقود بأعلى معايير الأمان والجودة إلى جميع المحطات", "Fuel transportation service with the highest safety and quality standards to all stations", "/images/services/fuel-transport.svg", "نقل الوقود", "Fuel Transportation" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "إدارة شاملة لمحطات الوقود تشمل الصيانة والتشغيل", "Comprehensive fuel station management including maintenance and operations", "/images/services/station-management.svg", "إدارة المحطات", "Station Management" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "إدارة وصيانة أسطول النقل بأحدث التقنيات", "Fleet management and maintenance with the latest technologies", "/images/services/fleet.svg", "خدمات الأسطول", "Fleet Services" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DescriptionAr", "DescriptionEn", "IconUrl", "TitleAr", "TitleEn" },
                values: new object[] { "استشارات متخصصة في قطاع الطاقة والوقود", "Specialized consulting in the energy and fuel sector", "/images/services/consulting.svg", "الاستشارات", "Consulting" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "شارع عباس العقاد، مدينة نصر", "Cairo", "Egypt", "محطة وقود متكاملة الخدمات في قلب مدينة نصر", "Full-service fuel station in the heart of Nasr City", 30.0626, 31.345600000000001, "+20 2 1234567", "محطة مدينة نصر", "Nasr City Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "شارع التسعين، التجمع الخامس", "Cairo", "Egypt", "محطة حديثة في التجمع الخامس مع خدمات متميزة", "Modern station in Fifth Settlement with premium services", 30.007400000000001, 31.491299999999999, "+20 2 2345678", "محطة التجمع الخامس", "Fifth Settlement Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "طريق الكورنيش، الإسكندرية", "Alexandria", "Egypt", "محطة وقود رئيسية في الإسكندرية", "Main fuel station in Alexandria", 31.200099999999999, 29.918700000000001, "+20 3 3456789", "محطة الإسكندرية", "Alexandria Station" });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "City", "Country", "DescriptionAr", "DescriptionEn", "Latitude", "Longitude", "Phone", "TitleAr", "TitleEn" },
                values: new object[] { "المحور المركزي، 6 أكتوبر", "Giza", "Egypt", "محطة متكاملة في مدينة 6 أكتوبر", "Integrated station in 6th October City", 29.9285, 30.918800000000001, "+20 2 4567890", "محطة 6 أكتوبر", "6th October Station" });
        }
    }
}
