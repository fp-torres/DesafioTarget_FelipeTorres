using System.Text.Json.Serialization;

namespace DesafioTarget.Models;

public class Venda
{
    [JsonPropertyName("vendedor")]
    public string Vendedor { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

public class DadosVendas
{
    [JsonPropertyName("vendas")]
    public List<Venda> Vendas { get; set; } = new();
}