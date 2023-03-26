using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Models;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddDbContext<cron_jobContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


//  config quartz sql server store
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    q.UseSimpleTypeLoader();
    // q.UseInMemoryStore();
    q.UsePersistentStore(x =>
    {
        x.UseProperties = true;
        x.UseClustering();
        x.UseSqlServer(sqlSever =>
        {
            sqlSever.ConnectionString = builder.Configuration.GetConnectionString("SqlConnection");
            sqlSever.TablePrefix = "QRTZ_";
        });
        // this requires Quartz.Serialization.Json NuGet package
        x.UseJsonSerializer();
    });
    q.UseDefaultThreadPool(tp =>
    {
        // Số luồng tối đa
        tp.MaxConcurrency = 10;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.UseSession();
app.MapRazorPages();

app.Run();
