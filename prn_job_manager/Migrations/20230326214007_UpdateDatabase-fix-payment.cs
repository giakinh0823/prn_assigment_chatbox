using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prn_job_manager.Migrations
{
    public partial class UpdateDatabasefixpayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK__payment___ED1FC9EA953B9D88",
                table: "payment_info");

            migrationBuilder.AlterColumn<int>(
                name: "payment_id",
                table: "payment_info",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Job",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__payment___ED1FC9EA73903F71",
                table: "payment_info",
                column: "payment_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__payment___ED1FC9EA73903F71",
                table: "payment_info");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Job");

            migrationBuilder.AlterColumn<int>(
                name: "payment_id",
                table: "payment_info",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__payment___ED1FC9EA953B9D88",
                table: "payment_info",
                column: "payment_id");

            migrationBuilder.CreateTable(
                name: "User_Job",
                columns: table => new
                {
                    job_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__User_Job__job_id__286302EC",
                        column: x => x.job_id,
                        principalTable: "Job",
                        principalColumn: "job_id");
                    table.ForeignKey(
                        name: "FK__User_Job__user_i__276EDEB3",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Job_job_id",
                table: "User_Job",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Job_user_id",
                table: "User_Job",
                column: "user_id");
        }
    }
}
