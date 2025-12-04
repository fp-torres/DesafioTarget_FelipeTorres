using System.Text.Json.Serialization;

namespace DesafioTarget.Models;

public class Produto
{
    [JsonPropertyName("codigoProduto")]
    public int CodigoProduto { get; set; }

    [JsonPropertyName("descricaoProduto")]
    public string DescricaoProduto { get; set; } = string.Empty;

    [JsonPropertyName("estoque")]
    public int Estoque { get; set; }
}

public class DadosEstoque
{
    [JsonPropertyName("estoque")]
    public List<Produto> Produtos { get; set; } = new();
}