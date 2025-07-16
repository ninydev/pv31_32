using System.Text;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBlog.Controllers.Sse;

[ApiController]
[Route("sse")]
public class SseController : ControllerBase

{
    [HttpGet("public")]
    public async Task PublicStream()
    {
        // Настройка контента как text/event-stream
        Response.ContentType = "text/event-stream";

        for (var i = 0; i < 10; i++)
        {
            await SendEventAsync($"Публичное сообщение {i}", DateTime.UtcNow.ToString());
            await Task.Delay(1000); // Имитация данных (каждую секунду)
        }
    }
    
    private async Task SendEventAsync(string message, string id)
    {
        // Формат отправки данных для SSE:
        // event: <event-name>\ndata: <data>\nid: <id>\n\n
        var eventData = new StringBuilder();
        eventData.AppendLine($"id: {id}");
        eventData.AppendLine($"data: {message}");
        eventData.AppendLine();

        await Response.WriteAsync(eventData.ToString());
        await Response.Body.FlushAsync(); // Принудительная отправка данных каждому клиенту
    }


}