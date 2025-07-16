using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBlog.Services;

namespace WebApplicationBlog.Controllers.Sse;

[ApiController]
[Route("/msg")]
public class SendMessagesController : ControllerBase
{
    private readonly SsePublicService _ssePublicService;

    public SendMessagesController(SsePublicService ssePublicService)
    {
        _ssePublicService = ssePublicService;
    }
    
    [HttpPost ("public")]
    public async Task<IActionResult> SendMessage([FromBody] string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return BadRequest("Сообщение не может быть пустым.");
        }

        try {
        await _ssePublicService.SendMessageToAllAsync(message);
        return Ok("Сообщение отправлено всем клиентам.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка при отправке сообщения: {ex.Message}");
        }
    }
}