# 🥋 FIUAPI - Sistema de Gestão de Eventos Esportivos

API desenvolvida como projeto final para a disciplina de **Banco de Dados**. O sistema gerencia atletas, centros de treinamento (CTs), eventos e competições, integrando conceitos avançados de banco de dados relacional com uma arquitetura moderna de backend.

## 🚀 Tecnologias Utilizadas

* **Linguagem:** C# (.NET 8)
* **Banco de Dados:** PostgreSQL
* **ORM:** Entity Framework Core (Code First)
* **Driver:** Npgsql
* **Documentação:** Swagger / OpenAPI

## 🏛️ Arquitetura e Padrões

O projeto foi construído seguindo boas práticas de desenvolvimento e design patterns:

* **Repository Pattern:** Implementação genérica (`Repository<T>`) para operações CRUD padrão e repositórios específicos (`AtletaRepository`, `EventoRepository`) para consultas complexas.
* **DTOs (Data Transfer Objects):** Separação entre as entidades do banco e os dados trafegados na API.
* **Service Layer:** Camada de serviço (`EventoService`, `CTService`) para regras de negócio e controle de transações (Unit of Work).
* **Dependency Injection:** Injeção de dependência para desacoplamento de componentes.

## 💾 Destaques do Banco de Dados (PL/pgSQL)

Como foco da disciplina, foram implementadas diversas rotinas diretamente no banco de dados para performance e integridade:

### ⚡ Procedures
* `registrar_presenca`: Realiza a inscrição de um atleta em um evento, validando duplicidades.
* `agendar_evento`: (Via API Transaction) Garante a atomicidade na criação de Evento + Local.

### 🔍 Functions (Relatórios)
* `calendario_eventos`: Filtra eventos por Dia, Semana ou Mês, com tratamento de Fuso Horário (UTC/Local).
* `historico_atleta`: Retorna a capivara completa de competições de um atleta.
* `avaliacoes_eventos`: Agrega médias de notas e concatena comentários de avaliações.
* `exibir_detalhes_encontro`: Traz um relatório detalhado com múltiplos JOINS (Evento, Local, CT, Atletas).

### 🔫 Triggers
* `trg_delete_avaliacoes_equipe`: Gatilho `BEFORE DELETE` que limpa automaticamente as avaliações de uma equipe antes que ela seja excluída, mantendo a integridade referencial.

## ⚙️ Como Rodar o Projeto

### Pré-requisitos
* .NET SDK 8.0
* PostgreSQL instalado e rodando

### 1. Configurar Conexão
No arquivo `appsettings.json`, ajuste a string de conexão com suas credenciais do Postgres:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=FIUDb;User Id=postgres;Password=SUA_SENHA;"
}
