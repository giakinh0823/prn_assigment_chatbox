using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace prn_job_manager.Models
{
    public partial class cron_jobContext : DbContext
    {
        public cron_jobContext()
        {
        }

        public cron_jobContext(DbContextOptions<cron_jobContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<PaymentInfo> PaymentInfos { get; set; } = null!;
        public virtual DbSet<QrtzBlobTrigger> QrtzBlobTriggers { get; set; } = null!;
        public virtual DbSet<QrtzCalendar> QrtzCalendars { get; set; } = null!;
        public virtual DbSet<QrtzCronTrigger> QrtzCronTriggers { get; set; } = null!;
        public virtual DbSet<QrtzFiredTrigger> QrtzFiredTriggers { get; set; } = null!;
        public virtual DbSet<QrtzJobDetail> QrtzJobDetails { get; set; } = null!;
        public virtual DbSet<QrtzLock> QrtzLocks { get; set; } = null!;
        public virtual DbSet<QrtzPausedTriggerGrp> QrtzPausedTriggerGrps { get; set; } = null!;
        public virtual DbSet<QrtzSchedulerState> QrtzSchedulerStates { get; set; } = null!;
        public virtual DbSet<QrtzSimpleTrigger> QrtzSimpleTriggers { get; set; } = null!;
        public virtual DbSet<QrtzSimpropTrigger> QrtzSimpropTriggers { get; set; } = null!;
        public virtual DbSet<QrtzTrigger> QrtzTriggers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HAGIAKINH;database=cron_job;Integrated security=true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Expression)
                    .IsUnicode(false)
                    .HasColumnName("expression");

                entity.Property(e => e.Header)
                    .IsUnicode(false)
                    .HasColumnName("header");

                entity.Property(e => e.Method)
                    .IsUnicode(false)
                    .HasColumnName("method");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Payload)
                    .IsUnicode(false)
                    .HasColumnName("payload");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Webhook)
                    .IsUnicode(false)
                    .HasColumnName("webhook");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.Output)
                    .HasColumnType("text")
                    .HasColumnName("output");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__Log__job_id__2B3F6F97");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Log__user_id__2C3393D0");
            });

            modelBuilder.Entity<PaymentInfo>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__payment___ED1FC9EA73903F71");

                entity.ToTable("payment_info");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("payment_amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<QrtzBlobTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });

                entity.ToTable("QRTZ_BLOB_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.BlobData).HasColumnName("BLOB_DATA");
            });

            modelBuilder.Entity<QrtzCalendar>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.CalendarName });

                entity.ToTable("QRTZ_CALENDARS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.CalendarName)
                    .HasMaxLength(200)
                    .HasColumnName("CALENDAR_NAME");

                entity.Property(e => e.Calendar).HasColumnName("CALENDAR");
            });

            modelBuilder.Entity<QrtzCronTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });

                entity.ToTable("QRTZ_CRON_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.CronExpression)
                    .HasMaxLength(120)
                    .HasColumnName("CRON_EXPRESSION");

                entity.Property(e => e.TimeZoneId)
                    .HasMaxLength(80)
                    .HasColumnName("TIME_ZONE_ID");

                entity.HasOne(d => d.QrtzTrigger)
                    .WithOne(p => p.QrtzCronTrigger)
                    .HasForeignKey<QrtzCronTrigger>(d => new { d.SchedName, d.TriggerName, d.TriggerGroup })
                    .HasConstraintName("FK_QRTZ_CRON_TRIGGERS_QRTZ_TRIGGERS");
            });

            modelBuilder.Entity<QrtzFiredTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.EntryId });

                entity.ToTable("QRTZ_FIRED_TRIGGERS");

                entity.HasIndex(e => new { e.SchedName, e.JobGroup, e.JobName }, "IDX_QRTZ_FT_G_J");

                entity.HasIndex(e => new { e.SchedName, e.TriggerGroup, e.TriggerName }, "IDX_QRTZ_FT_G_T");

                entity.HasIndex(e => new { e.SchedName, e.InstanceName, e.RequestsRecovery }, "IDX_QRTZ_FT_INST_JOB_REQ_RCVRY");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.EntryId)
                    .HasMaxLength(140)
                    .HasColumnName("ENTRY_ID");

                entity.Property(e => e.FiredTime).HasColumnName("FIRED_TIME");

                entity.Property(e => e.InstanceName)
                    .HasMaxLength(200)
                    .HasColumnName("INSTANCE_NAME");

                entity.Property(e => e.IsNonconcurrent).HasColumnName("IS_NONCONCURRENT");

                entity.Property(e => e.JobGroup)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_GROUP");

                entity.Property(e => e.JobName)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_NAME");

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");

                entity.Property(e => e.RequestsRecovery).HasColumnName("REQUESTS_RECOVERY");

                entity.Property(e => e.SchedTime).HasColumnName("SCHED_TIME");

                entity.Property(e => e.State)
                    .HasMaxLength(16)
                    .HasColumnName("STATE");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");
            });

            modelBuilder.Entity<QrtzJobDetail>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.JobName, e.JobGroup });

                entity.ToTable("QRTZ_JOB_DETAILS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.JobName)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_NAME");

                entity.Property(e => e.JobGroup)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_GROUP");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IsDurable).HasColumnName("IS_DURABLE");

                entity.Property(e => e.IsNonconcurrent).HasColumnName("IS_NONCONCURRENT");

                entity.Property(e => e.IsUpdateData).HasColumnName("IS_UPDATE_DATA");

                entity.Property(e => e.JobClassName)
                    .HasMaxLength(250)
                    .HasColumnName("JOB_CLASS_NAME");

                entity.Property(e => e.JobData).HasColumnName("JOB_DATA");

                entity.Property(e => e.RequestsRecovery).HasColumnName("REQUESTS_RECOVERY");
            });

            modelBuilder.Entity<QrtzLock>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.LockName });

                entity.ToTable("QRTZ_LOCKS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.LockName)
                    .HasMaxLength(40)
                    .HasColumnName("LOCK_NAME");
            });

            modelBuilder.Entity<QrtzPausedTriggerGrp>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerGroup });

                entity.ToTable("QRTZ_PAUSED_TRIGGER_GRPS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");
            });

            modelBuilder.Entity<QrtzSchedulerState>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.InstanceName });

                entity.ToTable("QRTZ_SCHEDULER_STATE");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.InstanceName)
                    .HasMaxLength(200)
                    .HasColumnName("INSTANCE_NAME");

                entity.Property(e => e.CheckinInterval).HasColumnName("CHECKIN_INTERVAL");

                entity.Property(e => e.LastCheckinTime).HasColumnName("LAST_CHECKIN_TIME");
            });

            modelBuilder.Entity<QrtzSimpleTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });

                entity.ToTable("QRTZ_SIMPLE_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.RepeatCount).HasColumnName("REPEAT_COUNT");

                entity.Property(e => e.RepeatInterval).HasColumnName("REPEAT_INTERVAL");

                entity.Property(e => e.TimesTriggered).HasColumnName("TIMES_TRIGGERED");

                entity.HasOne(d => d.QrtzTrigger)
                    .WithOne(p => p.QrtzSimpleTrigger)
                    .HasForeignKey<QrtzSimpleTrigger>(d => new { d.SchedName, d.TriggerName, d.TriggerGroup })
                    .HasConstraintName("FK_QRTZ_SIMPLE_TRIGGERS_QRTZ_TRIGGERS");
            });

            modelBuilder.Entity<QrtzSimpropTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });

                entity.ToTable("QRTZ_SIMPROP_TRIGGERS");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.BoolProp1).HasColumnName("BOOL_PROP_1");

                entity.Property(e => e.BoolProp2).HasColumnName("BOOL_PROP_2");

                entity.Property(e => e.DecProp1)
                    .HasColumnType("numeric(13, 4)")
                    .HasColumnName("DEC_PROP_1");

                entity.Property(e => e.DecProp2)
                    .HasColumnType("numeric(13, 4)")
                    .HasColumnName("DEC_PROP_2");

                entity.Property(e => e.IntProp1).HasColumnName("INT_PROP_1");

                entity.Property(e => e.IntProp2).HasColumnName("INT_PROP_2");

                entity.Property(e => e.LongProp1).HasColumnName("LONG_PROP_1");

                entity.Property(e => e.LongProp2).HasColumnName("LONG_PROP_2");

                entity.Property(e => e.StrProp1)
                    .HasMaxLength(512)
                    .HasColumnName("STR_PROP_1");

                entity.Property(e => e.StrProp2)
                    .HasMaxLength(512)
                    .HasColumnName("STR_PROP_2");

                entity.Property(e => e.StrProp3)
                    .HasMaxLength(512)
                    .HasColumnName("STR_PROP_3");

                entity.Property(e => e.TimeZoneId)
                    .HasMaxLength(80)
                    .HasColumnName("TIME_ZONE_ID");

                entity.HasOne(d => d.QrtzTrigger)
                    .WithOne(p => p.QrtzSimpropTrigger)
                    .HasForeignKey<QrtzSimpropTrigger>(d => new { d.SchedName, d.TriggerName, d.TriggerGroup })
                    .HasConstraintName("FK_QRTZ_SIMPROP_TRIGGERS_QRTZ_TRIGGERS");
            });

            modelBuilder.Entity<QrtzTrigger>(entity =>
            {
                entity.HasKey(e => new { e.SchedName, e.TriggerName, e.TriggerGroup });

                entity.ToTable("QRTZ_TRIGGERS");

                entity.HasIndex(e => new { e.SchedName, e.CalendarName }, "IDX_QRTZ_T_C");

                entity.HasIndex(e => new { e.SchedName, e.JobGroup, e.JobName }, "IDX_QRTZ_T_G_J");

                entity.HasIndex(e => new { e.SchedName, e.NextFireTime }, "IDX_QRTZ_T_NEXT_FIRE_TIME");

                entity.HasIndex(e => new { e.SchedName, e.TriggerState, e.NextFireTime }, "IDX_QRTZ_T_NFT_ST");

                entity.HasIndex(e => new { e.SchedName, e.MisfireInstr, e.NextFireTime, e.TriggerState }, "IDX_QRTZ_T_NFT_ST_MISFIRE");

                entity.HasIndex(e => new { e.SchedName, e.MisfireInstr, e.NextFireTime, e.TriggerGroup, e.TriggerState }, "IDX_QRTZ_T_NFT_ST_MISFIRE_GRP");

                entity.HasIndex(e => new { e.SchedName, e.TriggerGroup, e.TriggerState }, "IDX_QRTZ_T_N_G_STATE");

                entity.HasIndex(e => new { e.SchedName, e.TriggerName, e.TriggerGroup, e.TriggerState }, "IDX_QRTZ_T_N_STATE");

                entity.HasIndex(e => new { e.SchedName, e.TriggerState }, "IDX_QRTZ_T_STATE");

                entity.Property(e => e.SchedName)
                    .HasMaxLength(120)
                    .HasColumnName("SCHED_NAME");

                entity.Property(e => e.TriggerName)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_NAME");

                entity.Property(e => e.TriggerGroup)
                    .HasMaxLength(150)
                    .HasColumnName("TRIGGER_GROUP");

                entity.Property(e => e.CalendarName)
                    .HasMaxLength(200)
                    .HasColumnName("CALENDAR_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EndTime).HasColumnName("END_TIME");

                entity.Property(e => e.JobData).HasColumnName("JOB_DATA");

                entity.Property(e => e.JobGroup)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_GROUP");

                entity.Property(e => e.JobName)
                    .HasMaxLength(150)
                    .HasColumnName("JOB_NAME");

                entity.Property(e => e.MisfireInstr).HasColumnName("MISFIRE_INSTR");

                entity.Property(e => e.NextFireTime).HasColumnName("NEXT_FIRE_TIME");

                entity.Property(e => e.PrevFireTime).HasColumnName("PREV_FIRE_TIME");

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");

                entity.Property(e => e.StartTime).HasColumnName("START_TIME");

                entity.Property(e => e.TriggerState)
                    .HasMaxLength(16)
                    .HasColumnName("TRIGGER_STATE");

                entity.Property(e => e.TriggerType)
                    .HasMaxLength(8)
                    .HasColumnName("TRIGGER_TYPE");

                entity.HasOne(d => d.QrtzJobDetail)
                    .WithMany(p => p.QrtzTriggers)
                    .HasForeignKey(d => new { d.SchedName, d.JobName, d.JobGroup })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QRTZ_TRIGGERS_QRTZ_JOB_DETAILS");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
