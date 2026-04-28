using WS_ConUni_DotNet_Rest_GR5.Modelos.Utilidades;
using WS_ConUni_DotNet_Rest_GR5.Modelos.Utilidades.Enums;
using Xunit;

namespace WS_ConUni_DotNet_Rest_GR5.Tests;

public class ConversorMasaTests
{
    private readonly ConversorMasa _conversor = new();

    [Theory]
    [InlineData(1000, UnidadMasa.Gramo, UnidadMasa.Kilogramo, 1.0)]
    [InlineData(1, UnidadMasa.Kilogramo, UnidadMasa.Gramo, 1000.0)]
    [InlineData(500, UnidadMasa.Gramo, UnidadMasa.Kilogramo, 0.5)]
    public void DeberiaConvertirCorrectamente(double valor, UnidadMasa origen, UnidadMasa destino, double esperado)
    {
        var resultado = _conversor.Convertir(valor, origen, destino);

        Assert.Equal(esperado, resultado, 4);
    }
}
