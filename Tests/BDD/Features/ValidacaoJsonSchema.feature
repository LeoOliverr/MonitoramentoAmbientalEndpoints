Feature: Validar se o Corpo da Resposta Segue o JsonSchema Definido Para Autenticação

    Scenario: A resposta recebida deve seguir o JsonSchema definido para autenticação
        Given que o usuário possui um nome de usuário de "Marcela" e uma senha "5678"
        When o usuário faz uma requisição POST
        Then a resposta deve ter um status 200
        And a resposta deve seguir o padrão definido em "authSchema.json"