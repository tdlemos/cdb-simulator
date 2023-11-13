using Teste_Penna.Services;

namespace Teste_Penna_Tests;

public class UnitTest1
{

    private readonly ICdbService _dbService;

    public UnitTest1()
    {
        _dbService = new CdbService();
    }

    [Fact(DisplayName ="Calculo CDB #1")]
    public void Teste_CDB_1()
    {
        double num1 = 1000;
        int num2 = 12;
        double valorEsperado = 1123.08;

        var resultado = _dbService.CalcularCDB(new Teste_Penna.Model.CalculoCdbRequest { Meses = num2, ValorInicial = num1});

        Assert.Equal(valorEsperado, resultado.ValorFinal, 0.01);
    }

    [Theory(DisplayName = "Calculo CDB #2")]
    [InlineData(12, 1000, 1123.08)]
    [InlineData(24, 3300, 4162.33)]
    [InlineData(36, 2400, 3399.74)]
    public void Teste_CDB_2(int meses, double valorInicial, double valorEsperado)
    {
        var resultado = _dbService.CalcularCDB(new Teste_Penna.Model.CalculoCdbRequest { Meses = meses, ValorInicial = valorInicial });

        Assert.Equal(valorEsperado, resultado.ValorFinal, 0.01);
    }
}