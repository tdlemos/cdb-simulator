using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Teste_Penna.Model;
using Teste_Penna.Services;

namespace Teste_Penna.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbController : Controller
{
    private readonly ICdbService _dbService;

    public CdbController(ICdbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet, Route("calcular")]
    public CalculoCdbResponse CalcularCDBGet([FromQuery] CalculoCdbRequest request)
    {
        return _dbService.CalcularCDB(request);
    }

    [HttpPost, Route("calcular")]
    public CalculoCdbResponse CalcularCDBPost([FromBody] CalculoCdbRequest request)
    {
        return _dbService.CalcularCDB(request);
    }
}
