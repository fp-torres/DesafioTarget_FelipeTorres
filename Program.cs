using System.Text.Json;
using DesafioTarget.Models;
using DesafioTarget.Services;

class Program
{
    static void Main(string[] args)
    {
        var service = new DesafioService();
        bool executando = true;

        // Carrega os dados iniciais dos arquivos JSON
        DadosVendas dadosVendas;
        DadosEstoque dadosEstoque;

        try
        {
            string jsonVendas = File.ReadAllText("vendas.json");
            string jsonEstoque = File.ReadAllText("estoque.json");

            dadosVendas = JsonSerializer.Deserialize<DadosVendas>(jsonVendas) ?? new DadosVendas();
            dadosEstoque = JsonSerializer.Deserialize<DadosEstoque>(jsonEstoque) ?? new DadosEstoque();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("ERRO CRÍTICO: Arquivos .json não encontrados. Verifique o .csproj.");
            return;
        }

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTÃO - TARGET SISTEMAS ===");
            Console.WriteLine("1. Processar Relatório de Comissões (Desafio 1)");
            Console.WriteLine("2. Lançar Movimentação de Estoque (Desafio 2)");
            Console.WriteLine("3. Calcular Juros de Boleto (Desafio 3)");
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção: ");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    service.ProcessarComissoes(dadosVendas.Vendas);
                    Console.WriteLine("\nPressione qualquer tecla para voltar...");
                    Console.ReadKey();
                    break;

                case "2":
                    RealizarMovimentacao(service, dadosEstoque);
                    break;

                case "3":
                    CalcularJurosInterativo(service);
                    break;

                case "0":
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    // Lógica interativa para o Desafio 2
    static void RealizarMovimentacao(DesafioService service, DadosEstoque dadosEstoque)
    {
        Console.Clear();
        Console.WriteLine("--- LANÇAMENTO DE ESTOQUE ---");
        
        // Mostra produtos disponíveis
        Console.WriteLine("Produtos Disponíveis:");
        foreach(var p in dadosEstoque.Produtos)
        {
            Console.WriteLine($"COD {p.CodigoProduto}: {p.DescricaoProduto} (Atual: {p.Estoque})");
        }

        Console.Write("\nDigite o CÓDIGO do produto: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo)) return;

        Console.Write("Digite a QUANTIDADE (Positivo para entrada, Negativo para saída): ");
        if (!int.TryParse(Console.ReadLine(), out int qtd)) return;

        Console.Write("Digite uma DESCRIÇÃO para a movimentação: ");
        string desc = Console.ReadLine() ?? "Movimentação Avulsa";

        // Gera o ID único pedido no desafio
        Guid idUnico = Guid.NewGuid();

        service.MovimentarEstoque(dadosEstoque.Produtos, codigo, qtd, desc, idUnico);
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    // Lógica interativa para o Desafio 3
    static void CalcularJurosInterativo(DesafioService service)
    {
        Console.Clear();
        Console.WriteLine("--- CÁLCULADORA DE JUROS ---");
        
        Console.Write("Digite o valor do boleto (ex: 1000,00): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            Console.WriteLine("Valor inválido.");
            Console.ReadKey();
            return;
        }

        Console.Write("Digite a data de vencimento (DD/MM/AAAA): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataVencimento))
        {
            Console.WriteLine("Data inválida.");
            Console.ReadKey();
            return;
        }

        service.CalcularJuros(valor, dataVencimento);
        
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
}