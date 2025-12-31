using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gLiter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetPrimaryAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Set the first admin of each role as primary (cannot be deleted or deactivated)
            migrationBuilder.Sql(@"
                -- Mark the first SuperAdmin as primary
                UPDATE AdminUsers SET IsPrimary = 1 WHERE Id = (
                    SELECT TOP 1 Id FROM AdminUsers WHERE Role = 'SuperAdmin' ORDER BY Id
                );
                
                -- Mark the first HR as primary
                UPDATE AdminUsers SET IsPrimary = 1 WHERE Id = (
                    SELECT TOP 1 Id FROM AdminUsers WHERE Role = 'HR' ORDER BY Id
                );
                
                -- Mark the first CustomerService as primary
                UPDATE AdminUsers SET IsPrimary = 1 WHERE Id = (
                    SELECT TOP 1 Id FROM AdminUsers WHERE Role = 'CustomerService' ORDER BY Id
                );
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reset all IsPrimary flags
            migrationBuilder.Sql("UPDATE AdminUsers SET IsPrimary = 0;");
        }
    }
}
