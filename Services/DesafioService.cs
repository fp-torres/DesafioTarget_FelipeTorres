using DesafioTarget.Models;

namespace DesafioTarget.Services;

public class DesafioService
{
    // 1. Cálculo de Comissões
    public void ProcessarComissoes(List<Venda> vendas)
    {
        Console.WriteLine("\n=== 1. RELATÓRIO DE COMISSÕES ===");
        Console.WriteLine("----------------------------------------------------------------");
        foreach (var venda in vendas)
        {
            decimal porcentagem = 0;
            
            
            if (venda.Valor >= 500)
                porcentagem = 0.05m;
            else if (venda.Valor >= 100)
                porcentagem = 0.01m;

            decimal comissao = venda.Valor * porcentagem;
            
            Console.WriteLine($"Vendedor: {venda.Vendedor.PadRight(15)} | Venda: {venda.Valor.ToString("C").PadLeft(10)} | Comissão: {comissao.ToString("C")}");
        }
        Console.WriteLine("----------------------------------------------------------------");
    }

    // 2. Movimentação de Estoque
    public int MovimentarEstoque(List<Produto> produtos, int codigo, int qtd, string descricao, Guid idMovimentacao)
    {
        var produto = produtos.FirstOrDefault(p => p.CodigoProduto == codigo);
        
        
        if (produto == null)
        {
            Console.WriteLine($"\n[ERRO] Produto com código '{codigo}' não foi encontrado no sistema.");
            return -1;
        }

        Console.WriteLine($"\n------------------------------------------------");
        Console.WriteLine($"   RESULTADO DA MOVIMENTAÇÃO DE ESTOQUE");
        Console.WriteLine($"------------------------------------------------");
        
        // DADOS SOLICITADOS NO RETORNO
        Console.WriteLine($"ID da Transação (Token): {idMovimentacao}");
        Console.WriteLine($"Código do Produto:       {produto.CodigoProduto}");
        Console.WriteLine($"Tipo da Movimentação:    {descricao.ToUpper()}");
        Console.WriteLine($"Produto:                 {produto.DescricaoProduto}");
        Console.WriteLine($"------------------------------------------------");
        
        Console.WriteLine($"Saldo Anterior:          {produto.Estoque}");
        
        // Atualiza o saldo
        produto.Estoque += qtd;

        string operacao = qtd > 0 ? "ENTRADA" : "SAÍDA";
        Console.WriteLine($"Operação Realizada:      {operacao} de {Math.Abs(qtd)} itens");
        Console.WriteLine($"Saldo Final Atualizado:  {produto.Estoque}");
        Console.WriteLine($"------------------------------------------------");
        
        return produto.Estoque;
    }

    // 3. Cálculo de Juros
    public decimal CalcularJuros(decimal valorOriginal, DateTime dataVencimento)
    {
        Console.WriteLine("\n=== 3. CÁLCULO DE JUROS ===");
        var hoje = DateTime.Now;
        var diasAtraso = (hoje - dataVencimento).Days;

        if (diasAtraso <= 0)
        {
            Console.WriteLine($"Boleto em dia (Vence em: {dataVencimento.ToShortDateString()}). Não há juros.");
            return 0;
        }

        
        decimal taxaDiaria = 0.025m; 
        decimal totalJuros = valorOriginal * (taxaDiaria * diasAtraso);
        decimal valorFinal = valorOriginal + totalJuros;

        Console.WriteLine($"Data de Vencimento: {dataVencimento.ToShortDateString()}");
        Console.WriteLine($"Dias de Atraso:     {diasAtraso} dias");
        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"Valor Original:     {valorOriginal:C}");
        Console.WriteLine($"Juros (2,5% a.d.):  {totalJuros:C}");
        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"TOTAL A PAGAR:      {valorFinal:C}");

        return totalJuros;
    }
}