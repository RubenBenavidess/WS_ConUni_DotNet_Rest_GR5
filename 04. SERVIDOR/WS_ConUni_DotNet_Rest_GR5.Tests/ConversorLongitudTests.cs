using WS_ConUni_DotNet_Rest_GR5.Modelos.Utilidades;
using WS_ConUni_DotNet_Rest_GR5.Modelos.Utilidades.Enums;
using Xunit;

namespace WS_ConUni_DotNet_Rest_GR5.Tests;

public class ConversorLongitudTests
{
    private readonly ConversorLongitud _conversor = new();

    [Theory]
    [InlineData(1000, UnidadLongitud.Metro, UnidadLongitud.Kilometro, 1.0)]
    [InlineData(1, UnidadLongitud.Kilometro, UnidadLongitud.Metro, 1000.0)]
    [InlineData(100, UnidadLongitud.Centimetro, UnidadLongitud.Metro, 1.0)]
    public void DeberiaConvertirCorrectamente(double valor, UnidadLongitud origen, UnidadLongitud destino, double esperado)
    {
        var resultado = _conversor.Convertir(valor, origen, destino);

        Assert.Equal(esperado, resultado, 4);
    }
}
