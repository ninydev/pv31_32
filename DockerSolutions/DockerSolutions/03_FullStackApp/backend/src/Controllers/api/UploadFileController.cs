using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UploadFileController : ControllerBase
{
    private readonly string _contentRootPath;

    public UploadFileController(Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
    {
        _contentRootPath = env.ContentRootPath;
    }

    /// Загружает файл.
    /// </summary>
    /// <remarks>Отправьте multipart/form-data с полем "file".</remarks>
    /// <response code="201">Файл успешно сохранён</response>
    /// <response code="400">Некорректный запрос</response>
    /// <response code="500">Внутренняя ошибка сервера</response>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UploadFileResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Upload([FromForm] UploadFileRequest request)
    {
        if (request?.File == null || request.File.Length == 0)
        {
            return BadRequest("Файл не передан или пуст.");
        }


        var targetFolder = Environment.GetEnvironmentVariable("UPLOAD_FOLDER");
        if (string.IsNullOrWhiteSpace(targetFolder))
        {
            targetFolder = Path.Combine(_contentRootPath, "uploads");
        }

        try
        {
            Directory.CreateDirectory(targetFolder);

            var safeFileName = Path.GetFileName(request.File.FileName);
            if (string.IsNullOrWhiteSpace(safeFileName))
            {
                safeFileName = $"{Guid.NewGuid():N}.bin";
            }

            var fullPath = Path.Combine(targetFolder, safeFileName);

            await using (var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await request.File.CopyToAsync(stream);
            }


            var result = new UploadFileResponse
            {
                FileName = safeFileName,
                SavedPath = fullPath
            };

            return Created(string.Empty, result);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка при сохранении файла: {ex.Message}");
        }
    }
}

public class UploadFileResponse
{
    public string FileName { get; set; } = default!;
    public string SavedPath { get; set; } = default!;
}

public class UploadFileRequest
{
    /// <summary>
    /// Файл для загрузки.
    /// </summary>
    public IFormFile File { get; set; } = default!;
}
