# Aplicativo Teste

## Descrição

Este projeto é uma API desenvolvida em .NET 8, utilizando SQL Server como banco de dados. A arquitetura é estruturada em três camadas: **APP**, **BLL** (Business Logic Layer) e **DAL** (Data Access Layer). A aplicação utiliza **Entity Framework** para interagir com o banco de dados, **AutoMapper** para mapeamento de objetos e **Hangfire** para gerenciamento de tarefas em segundo plano.

## Tecnologias Utilizadas

- **Back-end**:
  - .NET 8
  - SQL Server
  - Entity Framework
  - AutoMapper
  - Hangfire

- **Front-end**:
  - React
  - Vite
  - Material-UI
  - Context API
  - React Toastify

## Configuração do Projeto

### Back-end

1. **Configurar a Connection String**:
   - Abra o arquivo `appsettings.json` e configure a string de conexão com o banco de dados SQL Server.

2. **Executar as Migrations**:
   - Execute as migrations existentes para criar o esquema do banco de dados.

   ```bash
   dotnet ef database update
   dotnet run
   
### Front-end
1. **Instalar as Dependências**:
   -Navegue até o diretório do front-end e instale as dependências necessárias:
   ```bash
   npm install

1. **Executar o Projeto**:
   -Após a instalação das dependências, execute o projeto:
   ```bash
   npm run dev
   
