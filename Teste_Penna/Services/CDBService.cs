using Teste_Penna.Model;

namespace Teste_Penna.Services;

public class CdbService : ICdbService
{
    const double TB = 1.08;
    const double CDI = 0.009;
    public CalculoCdbResponse CalcularCDB(CalculoCdbRequest request)
    {
        return new CalculoCdbResponse(request.Meses, request.ValorInicial, TB, CDI);
    }
}
