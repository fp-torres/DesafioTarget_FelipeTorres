using System.Text.Json;
using DesafioTarget.Models;
using DesafioTarget.Services;

class Program
{
    static void Main(string[] args)
    {
        var service = new DesafioService();
        bool executando = true;

        // Variáveis para armazenar os dados lidos
        DadosVendas dadosVendas;
        DadosEstoque dadosEstoque;

        // 1. Carregamento Seguro dos Arquivos
        try
        {
            // Verifição se a pasta existe antes de tentar ler
            if (!Directory.Exists("data"))
            {
                Console.WriteLine("ERRO CRÍTICO: A pasta 'data' não foi encontrada na raiz do projeto.");
                
                Directory.CreateDirectory("data");
                Console.WriteLine("A pasta 'data' foi criada. Por favor, coloque os arquivos 'vendas.json' e 'estoque.json' dentro dela e reinicie.");
                return;
            }

            string jsonVendas = File.ReadAllText("data/vendas.json");
            string jsonEstoque = File.ReadAllText("data/estoque.json");

            dadosVendas = JsonSerializer.Deserialize<DadosVendas>(jsonVendas) ?? new DadosVendas();
            dadosEstoque = JsonSerializer.Deserialize<DadosEstoque>(jsonEstoque) ?? new DadosEstoque();
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"ERRO: Arquivo não encontrado: {ex.FileName}");
            Console.WriteLine("Verifique se 'vendas.json' e 'estoque.json' estão dentro da pasta 'data'.");
            return;
        }
        catch (JsonException)
        {
            Console.WriteLine("ERRO: O formato do arquivo JSON está inválido ou corrompido.");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO INESPERADO: {ex.Message}");
            return;
        }

        // 2. Loop do Menu Principal
        while (executando)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("    SISTEMA DE GESTÃO - TARGET SISTEMAS   ");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Relatório de Comissões");
            Console.WriteLine("2. Movimentação de Estoque (Entrada/Saída)");
            Console.WriteLine("3. Calculadora de Juros (Boletos)");
            Console.WriteLine("0. Sair");
            Console.WriteLine("==========================================");
            Console.Write("Digite a opção desejada: ");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    service.ProcessarComissoes(dadosVendas.Vendas);
                    Pausar();
                    break;

                case "2":
                    RealizarMovimentacao(service, dadosEstoque);
                    break;

                case "3":
                    CalcularJurosInterativo(service);
                    break;

                case "0":
                    executando = false;
                    Console.WriteLine("Encerrando sistema...");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Por favor, digite 1, 2, 3 ou 0.");
                    Thread.Sleep(1500); 
                    break;
            }
        }
    }

    // Lógica Interativa Desafio 2 (Com Validação de Loop)
    static void RealizarMovimentacao(DesafioService service, DadosEstoque dadosEstoque)
    {
        Console.Clear();
        Console.WriteLine("--- NOVA MOVIMENTAÇÃO DE ESTOQUE ---");
        
        
        Console.WriteLine("\nProdutos no Catálogo:");
        foreach(var p in dadosEstoque.Produtos)
        {
            Console.WriteLine($"[CÓD: {p.CodigoProduto}] - {p.DescricaoProduto} (Saldo: {p.Estoque})");
        }
        Console.WriteLine("-----------------------------------");

        // 1. Validação do Código do Produto
        int codigo;
        while (true)
        {
            Console.Write("Digite o CÓDIGO do produto (apenas números): ");
            string input = Console.ReadLine();
            
            
            if (int.TryParse(input, out codigo))
            {
                if (dadosEstoque.Produtos.Any(p => p.CodigoProduto == codigo))
                    break; 
                else
                    Console.WriteLine("❌ Erro: Produto não encontrado com este código.\n");
            }
            else
            {
                Console.WriteLine("❌ Erro: Digite apenas números.\n");
            }
        }

        // 2. Validação da Quantidade
        int qtd;
        while (true)
        {
            Console.Write("Digite a QUANTIDADE (+ para entrada, - para saída): ");
            string input = Console.ReadLine();
            
            
            if (int.TryParse(input, out qtd) && qtd != 0) break;

            Console.WriteLine("❌ Erro: Digite um número inteiro válido (diferente de zero).\n");
        }

        // 3. Validação da Descrição
        Console.Write("Digite o TIPO DA MOVIMENTAÇÃO (Ex: Venda, Compra): ");
        string descricao = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(descricao))
        {
            descricao = "Movimentação Avulsa";
        }

        Guid idUnico = Guid.NewGuid();

        Console.Clear();
        service.MovimentarEstoque(dadosEstoque.Produtos, codigo, qtd, descricao, idUnico);
        
        Pausar();
    }

    // Lógica Interativa Desafio 3 (Com Validação de Loop) 
    static void CalcularJurosInterativo(DesafioService service)
    {
        Console.Clear();
        Console.WriteLine("--- CALCULADORA FINANCEIRA ---");
        
        // 1. Validação do Valor
        decimal valor;
        while (true)
        {
            Console.Write("Digite o VALOR do boleto (Ex: 1000,00): R$ ");
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out valor) && valor > 0) break;

            Console.WriteLine("❌ Erro: Digite um valor numérico válido e positivo.\n");
        }

        // 2. Validação da Data
        DateTime dataVencimento;
        while (true)
        {
            Console.Write("Digite a DATA de vencimento (DD/MM/AAAA): ");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out dataVencimento)) break;

            Console.WriteLine("❌ Erro: Data inválida. Use o formato Dia/Mês/Ano (ex: 25/11/2025).\n");
        }

        Console.Clear();
        service.CalcularJuros(valor, dataVencimento);
        
        Pausar();
    }

    static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}