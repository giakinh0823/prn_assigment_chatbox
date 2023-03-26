using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prn_job_manager.Migrations
{
    public partial class UpdateDatabase637 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment_info",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "date", nullable: false),
                    payment_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payment___ED1FC9EA86974A72", x => x.payment_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_info");
        }
    }
}
