# README - Testes Automatizados BDD

Este projeto contém testes automatizados para validação de um endpoint específico de uma API utilizando BDD (Behavior-Driven Development) com a sintaxe Gherkin. Os testes verificam o conteúdo JSON retornado, o schema JSON, e o status code da resposta do endpoint.

## Pré-requisitos

Antes de iniciar, certifique-se de que possui os seguintes itens instalados:

- [.NET SDK](https://dotnet.microsoft.com/download) - Necessário para compilar e executar o projeto
- [NUnit](https://nunit.org/) - Estrutura de testes unitários utilizada
- [SpecFlow](https://specflow.org/) - Ferramenta de BDD para integrar testes escritos em Gherkin
- *Biblioteca de JSON Schema* - Como [Newtonsoft.Json.Schema](https://www.newtonsoft.com/jsonschema) para validação do JSON Schema

## Estrutura do Projeto

- *Features*: Contém os arquivos .feature escritos em Gherkin, que descrevem os cenários de teste.
- *Schemas*: Inclui o arquivo SensorSchema.json, que define o contrato JSON a ser validado.
- *Steps*: Contém as implementações dos passos dos testes (SensorSteps.cs) associadas aos cenários descritos em Gherkin.

## Configuração

1. Clone o repositório para sua máquina local:
   ```bash
   git clone https://github.com/LeoOliverr/MonitoramentoAmbientalEndpoints.git