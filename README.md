🎯 Desafio Técnico - Target Sistemas

Este repositório contém a solução para o desafio técnico da vaga de Desenvolvedor C# Jr, focado em lógica de programação, manipulação de dados JSON e regras de negócio.

🚀 Funcionalidades Implementadas

O projeto foi estruturado como uma Console Application interativa, dividida em três módulos principais conforme solicitado no desafio:

1. 💰 Cálculo de Comissões

Processamento de um arquivo vendas.json contendo registros de vendas, aplicando as seguintes regras de negócio:

Valor da Venda

Comissão Aplicada

Abaixo de R$ 100,00

0%

Entre R$ 100,00 e R$ 499,99

1%

A partir de R$ 500,00

5%

2. 📦 Gestão de Estoque

Sistema para lançamento de movimentações (Entrada/Saída) baseado no arquivo estoque.json.

[x] Leitura do saldo atualizado.

[x] Geração de ID único (GUID) para rastreabilidade.

[x] Atualização dinâmica do saldo.

[x] Validação para impedir inserção de letras.

3. 📅 Calculadora de Juros

Cálculo de juros simples para boletos vencidos.

Regra: Multa de 2,5% ao dia sobre o valor original.

Input: Valor do boleto e Data de Vencimento.

Output: Dias de atraso, valor dos juros e total a pagar.

🛡️ Segurança e Validações

Para garantir a robustez da aplicação, foram implementadas as seguintes proteções:

Estrutura de Dados: O sistema verifica automaticamente a existência da pasta data/ e dos arquivos JSON.

Input Seguro: Loops de validação impedem que o usuário digite letras em campos numéricos ou datas inválidas.

Integridade: Antes de movimentar o estoque, o sistema confere se o código do produto realmente existe.

🛠️ Tecnologias Utilizadas

Linguagem: C# (Microsoft .NET SDK)

Formato de Dados: JSON (System.Text.Json)

Arquitetura: Separação de responsabilidades em Models e Services.

Controle de Versão: Git & GitHub.

📂 Estrutura do Projeto

O código foi organizado seguindo boas práticas de "Clean Code" e separação de arquivos de dados:

DesafioTarget_FelipeTorres/
│
├── 📁 data/                  # 💾 Arquivos de dados (JSON)
│   ├── vendas.json
│   └── estoque.json
│
├── 📁 Models/                # 📦 Representação dos objetos (Venda, Produto)
├── 📁 Services/              # ⚙️ Lógica de negócio (Cálculos e Regras)
├── 📄 Program.cs             # 🎮 Menu interativo e execução principal
└── 📄 README.md              # 📖 Documentação do projeto


▶️ Como Executar o Projeto

Pré-requisitos: Ter o .NET SDK instalado.

Clone o repositório:

git clone [https://github.com/fp-torres/DesafioTarget-Sistemas.git](https://github.com/fp-torres/DesafioTarget-Sistemas.git)


Acesse a pasta do projeto:

cd DesafioTarget_FelipeTorres


Execute a aplicação:

dotnet run


Interaja com o Menu:
O terminal exibirá um menu numérico para escolher qual desafio deseja testar.

👨‍💻 Autor

Desenvolvido por Felipe Torres.
Projeto submetido para avaliação técnica na Target Sistemas.