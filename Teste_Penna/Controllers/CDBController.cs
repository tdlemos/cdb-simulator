using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Teste_Penna.Model;
using Teste_Penna.Services;

namespace Teste_Penna.Controllers;

[ApiController]
[Route("[controller]")]
public class CDBController : Controller
{
    private readonly ICDBService _dbService;

    public CDBController(ICDBService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet, Route("calcular")]
    public CalculoCDBResponse CalcularCDBGet([FromQuery] CalculoCDBRequest request)
    {
        return _dbService.CalcularCDB(request);
    }

    [HttpPost, Route("calcular")]
    public CalculoCDBResponse CalcularCDBPost([FromBody] CalculoCDBRequest request)
    {
        return _dbService.CalcularCDB(request);
    }
}
