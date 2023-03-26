using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prn_job_manager.Migrations
{
    public partial class UpdateDatabasefixjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QRTZ_BLOB_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_BLOB_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IX_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IX_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_SIMPROP_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IX_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_SIMPLE_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IX_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_CRON_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IX_QRTZ_BLOB_TRIGGERS_SCHED_NAME_TRIGGER_NAME_TRIGGER_GROUP",
                table: "QRTZ_BLOB_TRIGGERS");

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_TYPE",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldUnicode: false,
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_STATE",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldUnicode: false,
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<int>(
                name: "MISFIRE_INSTR",
                table: "QRTZ_TRIGGERS",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_NAME",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_GROUP",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CALENDAR_NAME",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_TRIGGERS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "STR_PROP_3",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STR_PROP_2",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STR_PROP_1",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "BOOL_PROP_2",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "BOOL_PROP_1",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AddColumn<string>(
                name: "TIME_ZONE_ID",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TIMES_TRIGGERED",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "REPEAT_COUNT",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "INSTANCE_NAME",
                table: "QRTZ_SCHEDULER_STATE",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_SCHEDULER_STATE",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_PAUSED_TRIGGER_GRPS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_PAUSED_TRIGGER_GRPS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "LOCK_NAME",
                table: "QRTZ_LOCKS",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_LOCKS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<bool>(
                name: "REQUESTS_RECOVERY",
                table: "QRTZ_JOB_DETAILS",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_CLASS_NAME",
                table: "QRTZ_JOB_DETAILS",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_UPDATE_DATA",
                table: "QRTZ_JOB_DETAILS",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_NONCONCURRENT",
                table: "QRTZ_JOB_DETAILS",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_DURABLE",
                table: "QRTZ_JOB_DETAILS",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "QRTZ_JOB_DETAILS",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_GROUP",
                table: "QRTZ_JOB_DETAILS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_NAME",
                table: "QRTZ_JOB_DETAILS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_JOB_DETAILS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "STATE",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldUnicode: false,
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<bool>(
                name: "REQUESTS_RECOVERY",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_GROUP",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_NONCONCURRENT",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INSTANCE_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ENTRY_ID",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(95)",
                oldUnicode: false,
                oldMaxLength: 95);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TIME_ZONE_ID",
                table: "QRTZ_CRON_TRIGGERS",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldUnicode: false,
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRON_EXPRESSION",
                table: "QRTZ_CRON_TRIGGERS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_CRON_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_CRON_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_CRON_TRIGGERS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "CALENDAR_NAME",
                table: "QRTZ_CALENDARS",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_CALENDARS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_BLOB_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_BLOB_TRIGGERS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_BLOB_TRIGGERS",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldUnicode: false,
                oldMaxLength: 120);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QRTZ_BLOB_TRIGGERS",
                table: "QRTZ_BLOB_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

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
                    table.PrimaryKey("PK__payment___ED1FC9EA953B9D88", x => x.payment_id);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_C",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "CALENDAR_NAME" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_G_J",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "JOB_GROUP", "JOB_NAME" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_N_G_STATE",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_GROUP", "TRIGGER_STATE" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_N_STATE",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP", "TRIGGER_STATE" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_NEXT_FIRE_TIME",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "NEXT_FIRE_TIME" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_NFT_ST",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_STATE", "NEXT_FIRE_TIME" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_NFT_ST_MISFIRE",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "MISFIRE_INSTR", "NEXT_FIRE_TIME", "TRIGGER_STATE" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_NFT_ST_MISFIRE_GRP",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "MISFIRE_INSTR", "NEXT_FIRE_TIME", "TRIGGER_GROUP", "TRIGGER_STATE" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_T_STATE",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_STATE" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_FT_G_J",
                table: "QRTZ_FIRED_TRIGGERS",
                columns: new[] { "SCHED_NAME", "JOB_GROUP", "JOB_NAME" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_FT_G_T",
                table: "QRTZ_FIRED_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_GROUP", "TRIGGER_NAME" });

            migrationBuilder.CreateIndex(
                name: "IDX_QRTZ_FT_INST_JOB_REQ_RCVRY",
                table: "QRTZ_FIRED_TRIGGERS",
                columns: new[] { "SCHED_NAME", "INSTANCE_NAME", "REQUESTS_RECOVERY" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_info");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_C",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_G_J",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_N_G_STATE",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_N_STATE",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_NEXT_FIRE_TIME",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_NFT_ST",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_NFT_ST_MISFIRE",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_NFT_ST_MISFIRE_GRP",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_T_STATE",
                table: "QRTZ_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_FT_G_J",
                table: "QRTZ_FIRED_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_FT_G_T",
                table: "QRTZ_FIRED_TRIGGERS");

            migrationBuilder.DropIndex(
                name: "IDX_QRTZ_FT_INST_JOB_REQ_RCVRY",
                table: "QRTZ_FIRED_TRIGGERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QRTZ_BLOB_TRIGGERS",
                table: "QRTZ_BLOB_TRIGGERS");

            migrationBuilder.DropColumn(
                name: "TIME_ZONE_ID",
                table: "QRTZ_SIMPROP_TRIGGERS");

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_TYPE",
                table: "QRTZ_TRIGGERS",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_STATE",
                table: "QRTZ_TRIGGERS",
                type: "varchar(16)",
                unicode: false,
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<short>(
                name: "MISFIRE_INSTR",
                table: "QRTZ_TRIGGERS",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_NAME",
                table: "QRTZ_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_GROUP",
                table: "QRTZ_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "QRTZ_TRIGGERS",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CALENDAR_NAME",
                table: "QRTZ_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_TRIGGERS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "STR_PROP_3",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STR_PROP_2",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STR_PROP_1",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BOOL_PROP_2",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BOOL_PROP_1",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_SIMPROP_TRIGGERS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<long>(
                name: "TIMES_TRIGGERED",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "REPEAT_COUNT",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_SIMPLE_TRIGGERS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "INSTANCE_NAME",
                table: "QRTZ_SCHEDULER_STATE",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_SCHEDULER_STATE",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_PAUSED_TRIGGER_GRPS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_PAUSED_TRIGGER_GRPS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "LOCK_NAME",
                table: "QRTZ_LOCKS",
                type: "varchar(40)",
                unicode: false,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_LOCKS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "REQUESTS_RECOVERY",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "JOB_CLASS_NAME",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "IS_UPDATE_DATA",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IS_NONCONCURRENT",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IS_DURABLE",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_GROUP",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_NAME",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_JOB_DETAILS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "STATE",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(16)",
                unicode: false,
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "REQUESTS_RECOVERY",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JOB_GROUP",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IS_NONCONCURRENT",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INSTANCE_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ENTRY_ID",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(95)",
                unicode: false,
                maxLength: 95,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(140)",
                oldMaxLength: 140);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_FIRED_TRIGGERS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TIME_ZONE_ID",
                table: "QRTZ_CRON_TRIGGERS",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRON_EXPRESSION",
                table: "QRTZ_CRON_TRIGGERS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_CRON_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_CRON_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_CRON_TRIGGERS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "CALENDAR_NAME",
                table: "QRTZ_CALENDARS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_CALENDARS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_GROUP",
                table: "QRTZ_BLOB_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "TRIGGER_NAME",
                table: "QRTZ_BLOB_TRIGGERS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "SCHED_NAME",
                table: "QRTZ_BLOB_TRIGGERS",
                type: "varchar(120)",
                unicode: false,
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_SIMPROP_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_SIMPLE_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_CRON_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_BLOB_TRIGGERS_SCHED_NAME_TRIGGER_NAME_TRIGGER_GROUP",
                table: "QRTZ_BLOB_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.AddForeignKey(
                name: "FK_QRTZ_BLOB_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_BLOB_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" },
                principalTable: "QRTZ_TRIGGERS",
                principalColumns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
