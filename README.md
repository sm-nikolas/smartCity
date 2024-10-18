# Cidades Inteligentes API

Este projeto é uma API para gerenciar informações sobre cidades, eventos, zonas e sensores em um contexto de Cidades Inteligentes. Ele foi desenvolvido em C# usando ASP.NET Core e Entity Framework Core.

## Requisitos

Antes de iniciar, verifique se você possui as seguintes ferramentas instaladas:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)
- [Git](https://git-scm.com/)
- [PostgreSQL](https://www.postgresql.org/download/)

## Inicialização do Projeto

### 1. Clonar o Repositório

Clone o repositório do GitHub para sua máquina local:

```bash
git clone https://github.com/sm-nikolas/SmartCityApi.git
cd SmartCityApi
```

### 2. Configurar o Banco de Dados

Certifique-se de que o PostgreSQL esteja em execução. Você pode criar um banco de dados chamado SmartCityDb com o seguinte comando:

```bash
CREATE DATABASE SmartCityDb;
```

### 3. Configurar as Variáveis de Ambiente

Antes de executar a aplicação, configure as variáveis de ambiente necessárias. Você pode criar um arquivo .env na raiz do projeto e adicionar as seguintes variáveis:

```bash
ConnectionStrings__DefaultConnection=Host=localhost;Database=SmartCityDb;Username=seu_usuario;Password=sua_senha
```

### 4. Executar as Migrações

Para criar as tabelas no banco de dados, execute as migrações utilizando o seguinte comando:

```bash
dotnet ef database update
```

### 5. Iniciar a Aplicação

Para iniciar a API, utilize o seguinte comando:

```bash
dotnet run
```

## Containerização

Este projeto também pode ser containerizado usando Docker. Para construir e executar o contêiner, utilize os seguintes comandos:

```bash
docker build -t smartcityapi .
docker run -d -p 5000:80 smartcityapi
```

