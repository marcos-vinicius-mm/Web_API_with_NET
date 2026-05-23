# 🎬 Filmes API
API REST desenvolvida com ASP.NET Core para gerenciamento de catálogo de filmes.

---

## 📌 Sobre o Projeto

A Filmes API é uma aplicação back-end criada para praticar conceitos de desenvolvimento de APIs REST utilizando o ecossistema .NET.

A aplicação permite:

- ✅ Cadastrar filmes
- ✅ Listar filmes
- ✅ Buscar filmes por ID
- ✅ Atualizar filmes
- ✅ Remover filmes
- ✅ Persistência de dados com Entity Framework Core
- ✅ Documentação automática com Swagger

---

# 🚀 Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- MySQL
- Pomelo EntityFramework Provider
- AutoMapper
- Swagger / OpenAPI
- Postman

---

# 📂 Estrutura do Projeto

```bash
Filmes_API/
│
├── Controllers/
├── Data/
├── Dtos/
├── Models/
├── Profiles/
├── Migrations/
├── Postman/
│
├── Program.cs
├── appsettings.json
├── Filmes_API.csproj
└── README.md
```
---

# ⚙️ Configuração do Projeto
## 1️⃣ Clone o repositório
git clone <URL_DO_REPOSITORIO>

## 2️⃣ Acesse a pasta
cd Filmes_API

## 3️⃣ Configure a Connection String
No arquivo appsettings.json:

"ConnectionStrings": {
  "MovieConnection": "server=localhost;database=filmesdb;user=root;password=SUA_SENHA"
}

## 4️⃣ Execute as migrations
dotnet ef database update

## 5️⃣ Rode o projeto
dotnet run

## 📚 Swagger
Ao executar o projeto, acesse:

https://localhost:xxxx/swagger

ou

http://localhost:xxxx/swagger

## 📮 Testes no Postman
As collections do Postman estão disponíveis na pasta:

/Postman

Importe os arquivos no Postman para testar os endpoints da API.

## 📌 Endpoints Principais
Método	  Endpoint	      Descrição
GET	      /movie	        Lista todos os filmes
GET	      /movie/{id}	    Busca filme por ID
POST	    /movie	        Cadastra um filme
PUT	      /movie/{id}	    Atualiza um filme
DELETE	  /movie/{id}     Remove um filme

## 🧠 Conceitos Praticados
Arquitetura REST
Injeção de Dependência
Migrations
DTOs
AutoMapper
CRUD
Persistência de Dados
Documentação de API
Versionamento básico

## 👨‍💻 Autor
Marcos Vinícius de Morais Maniçoba

## 📄 Licença
Projeto desenvolvido para fins de estudo e aprendizado.
