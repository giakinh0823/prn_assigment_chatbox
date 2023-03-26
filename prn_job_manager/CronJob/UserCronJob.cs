using System.Net.Http.Headers;
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

    public UserCronJob(cron_jobContext context)
    {
        _context = context;
    }

    [Obsolete("Obsolete")]
    public async Task Execute(IJobExecutionContext context)
    {
        int jobId = int.Parse(context.JobDetail.Key.Name);
        var job = await _context.Jobs.FirstOrDefaultAsync(x => x.JobId == jobId);
        if (job is { Webhook: { }, Method: { } })
        {
            string? response = null;
            switch (job.Method.ToUpper())
            {
                case "GET":
                    response = await GetApi(job.Webhook);
                    break; 
                case "POST":
                    response = await PostApi(job.Webhook);
                    break;
                case "PUT":
                    response = await PutApi(job.Webhook);
                    break;
                case "DELETE":
                    response = await DeleteApi(job.Webhook);
                    break;
            }
            Console.WriteLine(response);
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
    
    private static async Task<string> PostApi(string url, object? headers = null, object? payload = null)
    {
        using var client = new HttpClient();
        if (headers != null)
        {
            string jsonHeaders = JsonConvert.SerializeObject(headers);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("headers", jsonHeaders);
        }

        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
    
    private static async Task<string> PutApi(string url, object? headers = null, object? payload = null)
    {
        using var client = new HttpClient();
        if (headers != null)
        {
            string jsonHeaders = JsonConvert.SerializeObject(headers);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("headers", jsonHeaders);
        }

        var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
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