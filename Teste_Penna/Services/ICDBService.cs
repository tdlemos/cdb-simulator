using Teste_Penna.Model;

namespace Teste_Penna.Services;
public interface ICdbService
{
    CalculoCdbResponse CalcularCDB(CalculoCdbRequest request);
}