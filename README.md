# 🎯 Desafio Técnico - Target Sistemas

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![JSON](https://img.shields.io/badge/JSON-000000?style=for-the-badge&logo=json&logoColor=white)

Este repositório contém a solução desenvolvida para o desafio técnico da vaga de **Desenvolvedor C# Jr**. O projeto foca em lógica de programação, manipulação de dados, POO e estruturação de código limpo.

---

## 🚀 Funcionalidades Implementadas

O projeto foi estruturado como uma **Console Application** interativa, dividida em três módulos principais:

### 1. 💰 Cálculo de Comissões
Processamento de vendas via arquivo `vendas.json`. O sistema lê os registros e aplica a regra de comissão baseada no valor da venda:

| Valor da Venda | Comissão Aplicada |
| :--- | :---: |
| Abaixo de R$ 100,00 | **0%** |
| Entre R$ 100,00 e R$ 499,99 | **1%** |
| A partir de R$ 500,00 | **5%** |

### 2. 📦 Gestão de Estoque
Sistema para lançamento de movimentações (Entrada/Saída) baseado no arquivo `estoque.json`.
- [x] Leitura do saldo atualizado.
- [x] Geração automática de ID único (**GUID**) para rastreabilidade.
- [x] Atualização dinâmica do saldo no arquivo JSON.
- [x] Validação de input (impede inserção de caracteres não numéricos).

### 3. 📅 Calculadora de Juros (Boletos)
Cálculo de juros simples para boletos vencidos.
- **Regra:** Multa de R$ 2,5% ao dia sobre o valor original.
- **Input:** Valor do boleto e Data de Vencimento.
- **Output:** Dias de atraso, valor dos juros e total a pagar.

---

## 🛡️ Robustez e Validações

Para garantir a estabilidade da aplicação, foram implementadas as seguintes proteções:

* **Verificação de Arquivos:** O sistema verifica automaticamente a existência da pasta `data/` e cria os arquivos JSON caso não existam (ou alerta o usuário).
* **Input Seguro:** Loops de validação (`TryParse`) impedem que a aplicação quebre se o usuário digitar letras em campos numéricos ou datas inválidas.
* **Integridade de Dados:** Antes de movimentar o estoque, o sistema confere se o código do produto informado realmente existe na base de dados.

---

## 🛠️ Tecnologias e Arquitetura

* **Linguagem:** C# (Microsoft .NET SDK)
* **Persistência:** JSON (`System.Text.Json` para serialização/deserialização)
* **Arquitetura:** Separação de responsabilidades (SoC):
    * **Models:** Representação dos objetos (DTOs).
    * **Services:** Regras de negócio e cálculos puros.
    * **Repository (Simulado):** Manipulação direta dos arquivos JSON.

### 📂 Estrutura do Projeto

```bash
DesafioTarget_FelipeTorres/
│
├── 📁 data/                  # Persistência de dados
│   ├── vendas.json           # Base de vendas
│   └── estoque.json          # Base de produtos
│
├── 📁 Models/                # Definição de Classes
│   ├── Venda.cs
│   └── Produto.cs
│
├── 📁 Services/              # Lógica de Negócio
│   ├── ComissaoService.cs
│   ├── EstoqueService.cs
│   └── JurosService.cs
│
├── 📄 Program.cs             # Ponto de entrada (Menu)
└── 📄 README.md              # Documentação

▶️ Como Executar o Projeto
Pré-requisitos
Certifique-se de ter o .NET SDK instalado em sua máquina.

Passo a Passo
Clone o repositório:

Bash

git clone [https://github.com/fp-torres/DesafioTarget-Sistemas.git](https://github.com/fp-torres/DesafioTarget-Sistemas.git)
Acesse a pasta do projeto:

Bash

cd DesafioTarget_FelipeTorres
Execute a aplicação:

Bash

dotnet run
Interaja com o Menu: O terminal exibirá um menu numérico. Digite o número correspondente ao desafio que deseja testar.

👨‍💻 Autor
Desenvolvido por Felipe Torres. Projeto submetido para avaliação técnica na Target Sistemas.

Linkedin: https://www.linkedin.com/in/felipe-torres-id/