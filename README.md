# 🎯 Desafio Técnico - Target Sistemas

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Status](https://img.shields.io/badge/Status-Concluído-success?style=for-the-badge)

Este repositório contém a solução para o desafio técnico da vaga de **Desenvolvedor C# Jr**, focado em lógica de programação, manipulação de dados JSON e regras de negócio.

---

## 🚀 Funcionalidades Implementadas

O projeto foi estruturado como uma **Console Application** interativa, dividida em três módulos principais conforme solicitado no desafio:

### 1. 💰 Cálculo de Comissões
Processamento de um arquivo `vendas.json` contendo registros de vendas, aplicando as seguintes regras de negócio:

| Valor da Venda | Comissão Aplicada |
| :--- | :---: |
| Abaixo de R$ 100,00 | **0%** |
| Entre R$ 100,00 e R$ 499,99 | **1%** |
| A partir de R$ 500,00 | **5%** |

### 2. 📦 Gestão de Estoque
Sistema para lançamento de movimentações (Entrada/Saída) baseado no arquivo `estoque.json`.
- [x] Leitura do saldo atualizado.
- [x] Geração de ID único (GUID) para cada transação.
- [x] Atualização dinâmica do saldo.

### 3. 📅 Calculadora de Juros
Cálculo de juros simples para boletos vencidos.
- **Regra:** Multa de **2,5% ao dia** sobre o valor original.
- **Input:** Valor do boleto e Data de Vencimento.
- **Output:** Dias de atraso, valor dos juros e total a pagar.

---

## 🛠️ Tecnologias Utilizadas

* **Linguagem:** C# (Microsoft .NET SDK)
* **Formato de Dados:** JSON (`System.Text.Json`)
* **Arquitetura:** Separação de responsabilidades em *Models* e *Services*.
* **Controle de Versão:** Git & GitHub.

---

## 📂 Estrutura do Projeto

O código foi organizado seguindo boas práticas de "Clean Code" para facilitar a manutenção e escalabilidade:

```text
DesafioTarget_FelipeTorres/
│
├── 📁 Models/           # Representação dos objetos (Venda, Produto)
├── 📁 Services/         # Lógica de negócio (Cálculos e Regras)
├── 📄 Program.cs        # Menu interativo e execução principal
├── 📄 vendas.json       # Base de dados de vendas
├── 📄 estoque.json      # Base de dados de produtos
└── 📄 README.md         # Documentação do projeto

▶️ Como Executar o Projeto
Pré-requisitos: Ter o .NET SDK instalado.

Clone o repositório:

Bash

git clone [https://github.com/fp-torres/DesafioTarget-Sistemas.git](https://github.com/fp-torres/DesafioTarget-Sistemas.git)
Acesse a pasta do projeto:

Bash

cd DesafioTarget_FelipeTorres
Execute a aplicação:

Bash

dotnet run
Interaja com o Menu: O terminal exibirá um menu numérico para escolher qual desafio deseja testar.

👨‍💻 Autor
Desenvolvido por Felipe Torres. Projeto submetido para avaliação técnica na Target Sistemas.


---

### Passo 3: Enviar para o GitHub
Depois de salvar o arquivo, você precisa "comitar" essa mudança para ela aparecer bonita lá no site.

No terminal:
```powershell
git add README.md
git commit -m "docs: adiciona documentacao oficial do projeto"
git push