using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Channels;

[ApiController]
[Route("sse/time")]
public class CurrentServerTimeController : ControllerBase
{
    [HttpGet]
    public async Task Get()
    {
        Response.Headers.Add("Content-Type", "text/event-stream");
        while (!HttpContext.RequestAborted.IsCancellationRequested)
        {
            var time = DateTime.UtcNow.ToString("O");
            var json = System.Text.Json.JsonSerializer.Serialize(new { time });
            var data = $"data: {json}\n\n";
            var bytes = Encoding.UTF8.GetBytes(data);
            await Response.Body.WriteAsync(bytes, 0, bytes.Length, HttpContext.RequestAborted);
            await Response.Body.FlushAsync(HttpContext.RequestAborted);
            await Task.Delay(5000, HttpContext.RequestAborted);
        }
    }
}