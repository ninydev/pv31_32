using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HiLoadController : ControllerBase
{
    private static readonly string[] Types = { "serverTime", "randomInt", "guid" };

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        // Имитация долгой обработки: случайная задержка 7-10 секунд
        int delayMs = Random.Shared.Next(100, 201); // верхняя граница эксклюзивна
        try
        {
            await Task.Delay(delayMs, cancellationToken);
        }
        catch (TaskCanceledException)
        {
            // Клиент отменил запрос — вернём понятный ответ
            return StatusCode(StatusCodes.Status499ClientClosedRequest, new
            {
                error = "Request was cancelled by the client",
                delayMs
            });
        }

        // Случайный тип ответа
        int idx = Random.Shared.Next(Types.Length);
        var type = Types[idx];
        
        var serverName = Environment.GetEnvironmentVariable("SERVER_NAME") ?? "unknown";


        object value = type switch
        {
            "ServerName" => serverName,
            "serverTime" => DateTimeOffset.UtcNow,                 // текущее время на сервере (UTC)
            "randomInt"  => Random.Shared.Next(int.MinValue, int.MaxValue),
            "guid"       => Guid.NewGuid(),
            _            => "ok"
        };

        return Ok(new
        {
            serverName,
            delayMs
        });
    }
}