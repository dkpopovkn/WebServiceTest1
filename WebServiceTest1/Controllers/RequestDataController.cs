using Microsoft.AspNetCore.Mvc;
using WebServiceTest1.Data;
using System.Text.Json;

namespace WebServiceTest1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestDataController : ControllerBase
{
    private readonly AppDbContext _context;

    public RequestDataController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Чтение заголовков
        var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
        var headersJson = JsonSerializer.Serialize(headers);

        // Чтение параметров запроса
        var queryParams = Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
        var queryParamsJson = JsonSerializer.Serialize(queryParams);

        // Сохранение в базу данных
        var requestData = new RequestData
        {
            Headers = headersJson,
            QueryParameters = queryParamsJson
        };

        _context.RequestData.Add(requestData);
        await _context.SaveChangesAsync();

        // Возврат данных в формате JSON
        return Ok(new
        {
            Headers = headers,
            QueryParameters = queryParams,
            Timestamp = requestData.Timestamp
        });
    }
}