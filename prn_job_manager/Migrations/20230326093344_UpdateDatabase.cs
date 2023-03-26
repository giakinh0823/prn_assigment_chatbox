using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prn_job_manager.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    job_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    webhook = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    payload = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    header = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    method = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    expression = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.job_id);
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_CALENDARS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    CALENDAR_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CALENDAR = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_CALENDARS", x => new { x.SCHED_NAME, x.CALENDAR_NAME });
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_FIRED_TRIGGERS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    ENTRY_ID = table.Column<string>(type: "varchar(95)", unicode: false, maxLength: 95, nullable: false),
                    TRIGGER_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TRIGGER_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    INSTANCE_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    FIRED_TIME = table.Column<long>(type: "bigint", nullable: false),
                    SCHED_TIME = table.Column<long>(type: "bigint", nullable: false),
                    PRIORITY = table.Column<int>(type: "int", nullable: false),
                    STATE = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    JOB_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    JOB_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IS_NONCONCURRENT = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    REQUESTS_RECOVERY = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_FIRED_TRIGGERS", x => new { x.SCHED_NAME, x.ENTRY_ID });
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_JOB_DETAILS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    JOB_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    JOB_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    JOB_CLASS_NAME = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IS_DURABLE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    IS_NONCONCURRENT = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    IS_UPDATE_DATA = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    REQUESTS_RECOVERY = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    JOB_DATA = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_JOB_DETAILS", x => new { x.SCHED_NAME, x.JOB_NAME, x.JOB_GROUP });
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_LOCKS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    LOCK_NAME = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_LOCKS", x => new { x.SCHED_NAME, x.LOCK_NAME });
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_PAUSED_TRIGGER_GRPS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    TRIGGER_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_PAUSED_TRIGGER_GRPS", x => new { x.SCHED_NAME, x.TRIGGER_GROUP });
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_SCHEDULER_STATE",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    INSTANCE_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    LAST_CHECKIN_TIME = table.Column<long>(type: "bigint", nullable: false),
                    CHECKIN_INTERVAL = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_SCHEDULER_STATE", x => new { x.SCHED_NAME, x.INSTANCE_NAME });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_TRIGGERS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    TRIGGER_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TRIGGER_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    JOB_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    JOB_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    NEXT_FIRE_TIME = table.Column<long>(type: "bigint", nullable: true),
                    PREV_FIRE_TIME = table.Column<long>(type: "bigint", nullable: true),
                    PRIORITY = table.Column<int>(type: "int", nullable: true),
                    TRIGGER_STATE = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    TRIGGER_TYPE = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    START_TIME = table.Column<long>(type: "bigint", nullable: false),
                    END_TIME = table.Column<long>(type: "bigint", nullable: true),
                    CALENDAR_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    MISFIRE_INSTR = table.Column<short>(type: "smallint", nullable: true),
                    JOB_DATA = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_TRIGGERS", x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP });
                    table.ForeignKey(
                        name: "FK_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS",
                        columns: x => new { x.SCHED_NAME, x.JOB_NAME, x.JOB_GROUP },
                        principalTable: "QRTZ_JOB_DETAILS",
                        principalColumns: new[] { "SCHED_NAME", "JOB_NAME", "JOB_GROUP" });
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    job_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    start_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    output = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.log_id);
                    table.ForeignKey(
                        name: "FK__Log__job_id__2B3F6F97",
                        column: x => x.job_id,
                        principalTable: "Job",
                        principalColumn: "job_id");
                    table.ForeignKey(
                        name: "FK__Log__user_id__2C3393D0",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "User_Job",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: true),
                    job_id = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "QRTZ_BLOB_TRIGGERS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    TRIGGER_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TRIGGER_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    BLOB_DATA = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_QRTZ_BLOB_TRIGGERS_QRTZ_TRIGGERS",
                        columns: x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP },
                        principalTable: "QRTZ_TRIGGERS",
                        principalColumns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_CRON_TRIGGERS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    TRIGGER_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TRIGGER_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    CRON_EXPRESSION = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    TIME_ZONE_ID = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_CRON_TRIGGERS", x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP });
                    table.ForeignKey(
                        name: "FK_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS",
                        columns: x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP },
                        principalTable: "QRTZ_TRIGGERS",
                        principalColumns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_SIMPLE_TRIGGERS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    TRIGGER_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TRIGGER_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    REPEAT_COUNT = table.Column<long>(type: "bigint", nullable: false),
                    REPEAT_INTERVAL = table.Column<long>(type: "bigint", nullable: false),
                    TIMES_TRIGGERED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_SIMPLE_TRIGGERS", x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP });
                    table.ForeignKey(
                        name: "FK_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS",
                        columns: x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP },
                        principalTable: "QRTZ_TRIGGERS",
                        principalColumns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QRTZ_SIMPROP_TRIGGERS",
                columns: table => new
                {
                    SCHED_NAME = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    TRIGGER_NAME = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TRIGGER_GROUP = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    STR_PROP_1 = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    STR_PROP_2 = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    STR_PROP_3 = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    INT_PROP_1 = table.Column<int>(type: "int", nullable: true),
                    INT_PROP_2 = table.Column<int>(type: "int", nullable: true),
                    LONG_PROP_1 = table.Column<long>(type: "bigint", nullable: true),
                    LONG_PROP_2 = table.Column<long>(type: "bigint", nullable: true),
                    DEC_PROP_1 = table.Column<decimal>(type: "numeric(13,4)", nullable: true),
                    DEC_PROP_2 = table.Column<decimal>(type: "numeric(13,4)", nullable: true),
                    BOOL_PROP_1 = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    BOOL_PROP_2 = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTZ_SIMPROP_TRIGGERS", x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP });
                    table.ForeignKey(
                        name: "FK_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS",
                        columns: x => new { x.SCHED_NAME, x.TRIGGER_NAME, x.TRIGGER_GROUP },
                        principalTable: "QRTZ_TRIGGERS",
                        principalColumns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_job_id",
                table: "Log",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Log_user_id",
                table: "Log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_BLOB_TRIGGERS_SCHED_NAME_TRIGGER_NAME_TRIGGER_GROUP",
                table: "QRTZ_BLOB_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_CRON_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_SIMPLE_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS",
                table: "QRTZ_SIMPROP_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_QRTZ_TRIGGERS_SCHED_NAME_JOB_NAME_JOB_GROUP",
                table: "QRTZ_TRIGGERS",
                columns: new[] { "SCHED_NAME", "JOB_NAME", "JOB_GROUP" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Job_job_id",
                table: "User_Job",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Job_user_id",
                table: "User_Job",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "QRTZ_BLOB_TRIGGERS");

            migrationBuilder.DropTable(
                name: "QRTZ_CALENDARS");

            migrationBuilder.DropTable(
                name: "QRTZ_CRON_TRIGGERS");

            migrationBuilder.DropTable(
                name: "QRTZ_FIRED_TRIGGERS");

            migrationBuilder.DropTable(
                name: "QRTZ_LOCKS");

            migrationBuilder.DropTable(
                name: "QRTZ_PAUSED_TRIGGER_GRPS");

            migrationBuilder.DropTable(
                name: "QRTZ_SCHEDULER_STATE");

            migrationBuilder.DropTable(
                name: "QRTZ_SIMPLE_TRIGGERS");

            migrationBuilder.DropTable(
                name: "QRTZ_SIMPROP_TRIGGERS");

            migrationBuilder.DropTable(
                name: "User_Job");

            migrationBuilder.DropTable(
                name: "QRTZ_TRIGGERS");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "QRTZ_JOB_DETAILS");
        }
    }
}
