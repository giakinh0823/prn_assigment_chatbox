using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using prn_job_manager.Models;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.AddDbContext<cron_jobContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("SqlConnection") 
     ?? throw new InvalidOperationException("Connection string 'SqlConnection' not found.")));

builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Auth/Logout";
    options.AccessDeniedPath = "/Auth/AccessDenied";
});

//  config quartz sql server store
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    q.UseSimpleTypeLoader();

    q.UsePersistentStore(x =>
    {
        x.UseProperties = true;
        x.UseClustering();
        // there are other SQL providers supported too 
        x.UseSqlServer(sqlsever =>
        {
            sqlsever.ConnectionString = builder.Configuration.GetConnectionString("SqlConnection");;
            sqlsever.TablePrefix = "QRTZ_";
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

builder.Services.AddQuartzHostedService(options =>
{
    // when shutting down we want jobs to complete gracefully
    options.WaitForJobsToComplete = true;
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

app.UseAuthentication();
app.UseSession();
app.MapRazorPages();
app.MapControllers();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
