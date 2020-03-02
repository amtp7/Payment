using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Infrastructure.Migrations
{
    public partial class PaymentsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<float>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CardNumber = table.Column<long>(nullable: false),
                    CardName = table.Column<string>(nullable: true),
                    CardExpiryYear = table.Column<int>(nullable: false),
                    CardExpiryMonth = table.Column<int>(nullable: false),
                    CardCvv = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
