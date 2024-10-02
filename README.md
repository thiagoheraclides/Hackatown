# Hackatown

## Operadora de Saúde
**A aplicação em .NET que simule um sistema de operadora de saúde que tem como objetivo digitalizar seus processos e operações. O foco será em agendamento de consultas médicas.**


## Arquitetura da Operadora de Saúde
![Hackaton](https://github.com/user-attachments/assets/901bd66e-7540-4bc7-9628-7ff41685a1b8)



## Domain Storytelling da Operadora de Saúde
![Portal de Investimentos_2024-07-25](https://github.com/user-attachments/assets/07b4f111-28b6-4de0-a78a-9203ff59d741)

## Modelo Entidade Relacionamento - Banco de Dados
![image](https://github.com/user-attachments/assets/2c2b1028-4cd2-43db-a0d5-134fa2982073)


## Banco de dados

Este projeto foi criado usando banco de dados MS-SQL Server.
A solução está configurada para criar e gerar o banco de dados ao iniciar a aplicação. Para isto basta apenas alterar no arquivo appsettings.json, a propriedade ConnectionStrings, item Default, com as configurações relativas ao seu ambiente.

"ConnectionStrings": {
  "Default": "Data Source=**servidor ms sql**;Initial Catalog=**banco de dados**;User ID=**usuário**;Password=**senha**;TrustServerCertificate=true;" 
}

## Requisição HTTP
 
Seguimos a estrutura padrão do estilo [RESTful](https://en.wikipedia.org/wiki/Representational_state_transfer)
 
- GET: lista ou consulta dados
- POST: criação de dados
- PUT: atualização de dados
- DELETE: remoção de dados

## API

Projeto criado utilizando .NET 8 com Banco de dados SQL Server, seguindo os princípios da Clean Architecture

## Funcionalidades

![PHOTO-2024-08-25-19-11-11](https://github.com/user-attachments/assets/427d5369-6d61-4ffc-84a5-f0a8f6193be7)


## Testes
Os testes estão disponibilizados na Solution do projeto, em parte apartada aos binários da API.


## Observações Complementares

Utilizamos Swagger para documentação dos métodos disponibilizados na API.
Após instanciar o projeto URL Local: https://localhost:7245/swagger/index.html


## Critérios de aceite

- **Criar a API de cadastro de usuários: Médicos e Pacientes**
- **Criar a API de autenticação do usuário (uma para o médico e outra para o paciente)**
- **Criar a API para agendar consultar médicas**
A API será composta de:
  - **Pesquisar**: Apresentar todos os **médicos** permitir visualizar todos os médicos disponíveis;
  - **Agendar**: Paciente poderá selecionar o horário de preferência e realizar o agendamento.
  - **Notificar**: Após o agendamento realizado pelo usuário paciente, o médico deverá receber um e-mail;
  - **Validar**: O sistema deverá ser capas de suportar múltiplos acessos, garantir que apenas uma marcação seja permitida para um determinado horário e validar a disponibilidade do horário selecionado em tempo real, assegurando que não haja sobreposição de horários para consultar agendadas;
 

## Desenvolvedores
- Henrique Dantas
- Thiago Heraclides
