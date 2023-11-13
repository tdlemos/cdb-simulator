using Teste_Penna.Model;

namespace Teste_Penna.Services;
public interface ICDBService
{
    CalculoCDBResponse CalcularCDB(CalculoCDBRequest request);
}