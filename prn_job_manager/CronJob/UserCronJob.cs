﻿using System.Net.Http.Headers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using prn_job_manager.Constant;
using prn_job_manager.Models;
using Quartz;

namespace prn_job_manager.CronJob;

public class UserCronJob : IJob
{
    private readonly cron_jobContext _context;
    private readonly ILogger<UserCronJob> _logger;

    public UserCronJob(cron_jobContext context, ILogger<UserCronJob> logger)
    {
        _context = context;
        _logger = logger;
    }

    [Obsolete("Obsolete")]
    public async Task Execute(IJobExecutionContext context)
    {
        int jobId = int.Parse(context.JobDetail.Key.Name);
        int userId = int.Parse(context.JobDetail.Key.Group);
        
        var job = await _context.Jobs.FirstOrDefaultAsync(x => x.JobId == jobId);
        if (job is { Webhook: { }, Method: { } })
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            Log log = new Log()
            {
                JobId = job.JobId,
                UserId = user?.UserId ?? null,
                StartTime = DateTime.Now,
            };
            try
            {
                string? response = null;
                switch (job.Method.ToUpper())
                {
                    case "GET":
                        response = await GetApi(job.Webhook, job.Header);
                        break; 
                    case "POST":
                        response = await PostApi(job.Webhook, job.Header, job.Payload);
                        break;
                    case "PUT":
                        response = await PutApi(job.Webhook, job.Header, job.Header);
                        break;
                    case "DELETE":
                        response = await DeleteApi(job.Webhook, job.Header);
                        break;
                }
                log.Status = LogConstant.SUCESSS;
                log.Output = response;
                _logger.LogInformation($"Success call job {job.Name}");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error call job {job.Name}: {e}");
                log.Status = LogConstant.SUCESSS;
                log.Output = e.Message;
            }
            log.EndTime = DateTime.Now;
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }

    private static async Task<string> GetApi(string url, object? headers = null)
    {
        using var client = new HttpClient();
        if (headers != null)
        {
            string jsonHeaders = JsonConvert.SerializeObject(headers);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("headers", jsonHeaders);
        }

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
    
    private static async Task<string> PostApi(string url, object? headers = null, string? payload = null)
    {
        using var client = new HttpClient();
        if (headers != null)
        {
            string jsonHeaders = JsonConvert.SerializeObject(headers);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("headers", jsonHeaders);
        }

        var content = new StringContent(payload ?? "", Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
    
    private static async Task<string> PutApi(string url, object? headers = null, string? payload = null)
    {
        using var client = new HttpClient();
        if (headers != null)
        {
            string jsonHeaders = JsonConvert.SerializeObject(headers);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("headers", jsonHeaders);
        }

        var content = new StringContent(payload ?? "", Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, content);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
    
    private static async Task<string> DeleteApi(string url, object? headers = null)
    {
        using var client = new HttpClient();
        if (headers != null)
        {
            string jsonHeaders = JsonConvert.SerializeObject(headers);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("headers", jsonHeaders);
        }

        HttpResponseMessage response = await client.DeleteAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
}