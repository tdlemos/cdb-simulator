using Teste_Penna.Model;

namespace Teste_Penna.Services;

public class CDBService : ICDBService
{
    const double TB = 1.08;
    const double CDI = 0.009;
    public CalculoCDBResponse CalcularCDB(CalculoCDBRequest request)
    {
        return new CalculoCDBResponse(request.Meses, request.ValorInicial, TB, CDI);
    }
}
