using WS_ConUni_DotNet_Rest_GR5.Modelos.Utilidades;
using WS_ConUni_DotNet_Rest_GR5.Modelos.Utilidades.Enums;
using Xunit;

namespace WS_ConUni_DotNet_Rest_GR5.Tests;

public class ConversorTemperaturaTests
{
    private readonly ConversorTemperatura _conversor = new();

    [Theory]
    [InlineData(0, UnidadTemperatura.Celsius, UnidadTemperatura.Fahrenheit, 32.0)]
    [InlineData(32, UnidadTemperatura.Fahrenheit, UnidadTemperatura.Celsius, 0.0)]
    [InlineData(0, UnidadTemperatura.Celsius, UnidadTemperatura.Kelvin, 273.15)]
    [InlineData(273.15, UnidadTemperatura.Kelvin, UnidadTemperatura.Celsius, 0.0)]
    [InlineData(0, UnidadTemperatura.Celsius, UnidadTemperatura.Rankine, 491.67)]
    [InlineData(491.67, UnidadTemperatura.Rankine, UnidadTemperatura.Celsius, 0.0)]
    [InlineData(32, UnidadTemperatura.Fahrenheit, UnidadTemperatura.Rankine, 491.67)]
    [InlineData(491.67, UnidadTemperatura.Rankine, UnidadTemperatura.Fahrenheit, 32.0)]
    [InlineData(273.15, UnidadTemperatura.Kelvin, UnidadTemperatura.Rankine, 491.67)]
    [InlineData(491.67, UnidadTemperatura.Rankine, UnidadTemperatura.Kelvin, 273.15)]
    public void DeberiaConvertirTemperatura(double valor, UnidadTemperatura origen, UnidadTemperatura destino, double esperado)
    {
        var resultado = _conversor.Convertir(valor, origen, destino);

        Assert.Equal(esperado, resultado, 2);
    }
}
