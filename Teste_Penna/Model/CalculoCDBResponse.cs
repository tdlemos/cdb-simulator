namespace Teste_Penna.Model;

public class CalculoCDBResponse
{
    public double TB { get; set; }
    public double CDI { get; set; }
    public double ValorFinal { get; set; }
    public double ImpostoAliquota { get; set; }
    public double ImpostoValor { get; set; }

    public List<CalculoCDBMesesResponse> Meses { get; set; } = new List<CalculoCDBMesesResponse>();

    public CalculoCDBResponse(int meses, double valorInicial, double tb, double cdi)
    {
        double valorAtual = valorInicial;
        TB = tb;
        CDI = cdi;
        for (int i = 1; i <= meses; i++)
        {
            double valorFinal = valorAtual * (1 + (cdi * tb));
            var imposto = CalcularImposto(i, valorInicial, valorFinal);
            Meses.Add(new CalculoCDBMesesResponse
            {
                Mes = i,
                ValorFinal = valorFinal,
                ImpostoAliquota = imposto.Item1,
                ImpostoValor = imposto.Item2
            });
            ValorFinal = valorFinal;
            ImpostoValor = imposto.Item2;
            ImpostoAliquota = imposto.Item1;
            valorAtual = valorFinal;
        }
        
    }

    private (double, double) CalcularImposto(int mes, double valorInicial, double valorFinal)
    {
        double aliquota = 0.225;
        if (mes > 6 && mes <= 12)
        {
            aliquota = 0.2;
        }
        else if (mes > 12 && mes <= 24)
        {
            aliquota = 0.175;
        }
        else if (mes > 24)
        {
            aliquota = 0.15;
        }

        double valorImposto = (valorFinal - valorInicial) * aliquota;
        return (aliquota, valorImposto);
    }

}
