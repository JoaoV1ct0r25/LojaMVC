# 🛍️ LojaMVC

> Projeto acadêmico desenvolvido com **ASP.NET Core MVC**, **C#** e **SQL Server** — uma loja virtual completa com área pública e painel administrativo.

---

## 📸 Visão Geral

A LojaMVC é uma aplicação web que simula uma loja de produtos com estrutura completa: vitrine pública para clientes, área administrativa protegida por login, e um CRUD completo de produtos. O projeto foi desenvolvido como trabalho final da disciplina, aplicando na prática o padrão arquitetural **MVC (Model-View-Controller)**.

---

## ✨ Funcionalidades

### Área Pública
- 🏠 **Página Inicial** — apresentação da loja com destaque visual
- ℹ️ **Sobre** — missão, visão e informações da loja
- 📦 **Vitrine de Produtos** — catálogo com cards, busca por nome e categoria
- 📞 **Contato** — informações de contato da loja

### Área Administrativa (requer login)
- 🔐 **Login e Cadastro** — autenticação segura com ASP.NET Core Identity
- ➕ **Cadastrar Produtos** — formulário completo com validação
- ✏️ **Editar Produtos** — atualização de informações
- 🗑️ **Excluir Produtos** — remoção com confirmação
- 🔍 **Pesquisar Produtos** — busca por nome e categoria em tempo real

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Uso |
|---|---|
| **C# / .NET 10** | Linguagem e framework principal |
| **ASP.NET Core MVC** | Padrão arquitetural da aplicação |
| **Entity Framework Core** | ORM para acesso ao banco de dados |
| **SQL Server (LocalDB)** | Banco de dados relacional |
| **ASP.NET Core Identity** | Autenticação e autorização |
| **Bootstrap 5** | Estilização e responsividade |
| **HTML / CSS** | Interface personalizada com tema azul |

---

## 📁 Estrutura do Projeto

LojaMVC/
├── Controllers/
│   ├── HomeController.cs        # Páginas públicas (Início, Sobre, Contato)
│   ├── ProdutosController.cs    # CRUD de produtos + vitrine pública
│   └── ContaController.cs       # Login, cadastro e logout
├── Models/
│   ├── Produto.cs               # Model de produto com validações
│   └── ApplicationUser.cs       # Usuário personalizado (Identity)
├── Views/
│   ├── Home/                    # Início, Sobre, Contato
│   ├── Produtos/                # Index, Create, Edit, Delete, Details, Vitrine
│   ├── Conta/                   # Login, Cadastro
│   └── Shared/                  # Layout e partials
├── Data/
│   └── ApplicationDbContext.cs  # Contexto do banco de dados
└── wwwroot/
└── css/site.css             # Estilos personalizados

---

## 🚀 Como Rodar o Projeto

### Pré-requisitos
- [Visual Studio Community](https://visualstudio.microsoft.com/pt-br/vs/community/) com workload **ASP.NET e desenvolvimento Web**
- **.NET 10 SDK**
- **SQL Server LocalDB** (já vem com o Visual Studio)

### Passo a passo

1. **Clone o repositório**
```bash
   git clone https://github.com/seu-usuario/loja-mvc.git
```

2. **Abra a solução no Visual Studio**

3. **Restaure os pacotes NuGet**
   > O Visual Studio faz isso automaticamente ao abrir o projeto.

4. **Aplique as migrations para criar o banco**

*(no Console do Gerenciador de Pacotes: Ferramentas → Gerenciador de Pacotes NuGet → Console)*

5. **Rode o projeto**

6. **Crie sua conta de administrador**
   > Clique em 🔐 **Login** → **Criar conta** e cadastre-se para acessar o painel admin.

---

## 🗄️ Banco de Dados

O projeto usa **SQL Server LocalDB** com as seguintes tabelas principais:

- `Produtos` — catálogo de produtos da loja
- `AspNetUsers` — usuários cadastrados (Identity)
- `AspNetRoles` — perfis de acesso

As tabelas são criadas automaticamente via **Entity Framework Core Migrations**.

---

## 📌 Padrão MVC Aplicado

Requisição HTTP
↓
Controller          ← recebe a requisição e decide o que fazer
↓
Model              ← busca/salva dados no banco via EF Core
↓
View               ← renderiza o HTML e retorna ao usuário
↓
Resposta HTTP

---

## 👨‍💻 Desenvolvido por

Feito com dedicação como projeto final da disciplina de Desenvolvimento Web.

**Tecnologia:** ASP.NET Core MVC | **Banco:** SQL Server | **Linguagem:** C#

---

> *"Todo grande projeto começa com um primeiro commit."* 🚀

