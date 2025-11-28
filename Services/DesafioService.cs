using DesafioTarget.Models;

namespace DesafioTarget.Services;

public class DesafioService
{
    // --- 1. Cálculo de Comissões ---
    public void ProcessarComissoes(List<Venda> vendas)
    {
        Console.WriteLine("\n=== 1. RELATÓRIO DE COMISSÕES ===");
        foreach (var venda in vendas)
        {
            decimal porcentagem = 0;
            
            // Regra: < 100 = 0% | 100 a < 500 = 1% | >= 500 = 5%
            if (venda.Valor >= 500)
                porcentagem = 0.05m;
            else if (venda.Valor >= 100)
                porcentagem = 0.01m;

            decimal comissao = venda.Valor * porcentagem;
            
            Console.WriteLine($"Vendedor: {venda.Vendedor.PadRight(15)} | Venda: {venda.Valor.ToString("C").PadLeft(10)} | Comissão: {comissao.ToString("C")}");
        }
    }

    // --- 2. Movimentação de Estoque ---
    public int MovimentarEstoque(List<Produto> produtos, int codigo, int qtd, string descricao, Guid idMovimentacao)
    {
        var produto = produtos.FirstOrDefault(p => p.CodigoProduto == codigo);
        
        if (produto == null)
        {
            Console.WriteLine($"\n[Erro] Produto código {codigo} não encontrado.");
            return -1;
        }

        Console.WriteLine($"\n=== 2. MOVIMENTAÇÃO DE ESTOQUE (ID: {idMovimentacao}) ===");
        Console.WriteLine($"Motivo: {descricao}");
        Console.WriteLine($"Produto: {produto.DescricaoProduto}");
        Console.WriteLine($"Saldo Anterior: {produto.Estoque}");
        
        // Atualiza o saldo
        produto.Estoque += qtd;

        Console.WriteLine($"Operação: {(qtd > 0 ? "Entrada" : "Saída")} de {Math.Abs(qtd)} itens.");
        Console.WriteLine($"Saldo Atual: {produto.Estoque}");
        
        return produto.Estoque;
    }

    // --- 3. Cálculo de Juros ---
    public decimal CalcularJuros(decimal valorOriginal, DateTime dataVencimento)
    {
        Console.WriteLine("\n=== 3. CÁLCULO DE JUROS ===");
        var hoje = DateTime.Now;
        var diasAtraso = (hoje - dataVencimento).Days;

        if (diasAtraso <= 0)
        {
            Console.WriteLine($"Boleto não vencido (Vence em: {dataVencimento.ToShortDateString()}). Sem juros.");
            return 0;
        }

        // Multa de 2,5% ao dia
        decimal taxaDiaria = 0.025m; 
        decimal totalJuros = valorOriginal * (taxaDiaria * diasAtraso);
        decimal valorFinal = valorOriginal + totalJuros;

        Console.WriteLine($"Vencimento: {dataVencimento.ToShortDateString()} (Atraso de {diasAtraso} dias)");
        Console.WriteLine($"Valor Original: {valorOriginal:C}");
        Console.WriteLine($"Juros ({diasAtraso} dias x 2,5%): {totalJuros:C}");
        Console.WriteLine($"Valor Total a Pagar: {valorFinal:C}");

        return totalJuros;
    }
}