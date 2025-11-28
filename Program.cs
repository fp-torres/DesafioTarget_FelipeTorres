using System.Text.Json;
using DesafioTarget.Models;
using DesafioTarget.Services;

class Program
{
    static void Main(string[] args)
    {
        var service = new DesafioService();

        // ------------------------------------------------------------
        // DESAFIO 1: COMISSÕES
        // ------------------------------------------------------------
        string jsonVendas = @"
        {
            ""vendas"": [
                { ""vendedor"": ""João Silva"", ""valor"": 1200.50 },
                { ""vendedor"": ""João Silva"", ""valor"": 250.30 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 90.75 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 500.00 }
            ]
        }";

        // O '?? new()' significa: se der erro na leitura, crie um objeto vazio para não quebrar
        var dadosVendas = JsonSerializer.Deserialize<DadosVendas>(jsonVendas) ?? new DadosVendas();
        service.ProcessarComissoes(dadosVendas.Vendas);

        // ------------------------------------------------------------
        // DESAFIO 2: ESTOQUE
        // ------------------------------------------------------------
        string jsonEstoque = @"
        {
            ""estoque"": [
                { ""codigoProduto"": 101, ""descricaoProduto"": ""Caneta Azul"", ""estoque"": 150 },
                { ""codigoProduto"": 104, ""descricaoProduto"": ""Lápis Preto HB"", ""estoque"": 320 }
            ]
        }";

        var dadosEstoque = JsonSerializer.Deserialize<DadosEstoque>(jsonEstoque) ?? new DadosEstoque();

        service.MovimentarEstoque(dadosEstoque.Produtos, 101, 50, "Compra de Fornecedor A", Guid.NewGuid());
        service.MovimentarEstoque(dadosEstoque.Produtos, 104, -20, "Venda para Escola X", Guid.NewGuid());

        // ------------------------------------------------------------
        // DESAFIO 3: JUROS
        // ------------------------------------------------------------
        DateTime dataVencida = DateTime.Now.AddDays(-15);
        service.CalcularJuros(1000.00m, dataVencida);
    }
}