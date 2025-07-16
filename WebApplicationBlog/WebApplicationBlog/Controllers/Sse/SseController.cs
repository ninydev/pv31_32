using System.Text;
using Azure;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBlog.Services;

namespace WebApplicationBlog.Controllers.Sse;

[ApiController]
[Route("sse")]
public class SseController : ControllerBase
{
    
    private readonly SsePublicService _ssePublicService;

    public SseController(SsePublicService ssePublicService)
    {
        _ssePublicService = ssePublicService;
    }

    
    [HttpGet("public")]
    public async Task PublicStream()
    {
        // Настройка контента как text/event-stream
        Response.ContentType = "text/event-stream";

        var clientId = Guid.NewGuid();
        var streamWriter = Response.BodyWriter.AsStream();
        
        try
        {
            _ssePublicService.AddClient(clientId, streamWriter);
            
            _ssePublicService.SendMessageToAllAsync("Подключен новый клиент: " + clientId);

            // Ожидание (блокировка) до отключения клиента.
            while (!HttpContext.RequestAborted.IsCancellationRequested)
            {
                await Task.Delay(1000, HttpContext.RequestAborted); // Пауза 1 секунда
            }
        }
        finally
        {
            _ssePublicService.RemoveClient(clientId);
        }
        
    }


}