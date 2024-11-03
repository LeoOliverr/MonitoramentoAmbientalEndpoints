Feature: Verificar Corpo da Resposta

    Scenario: A resposta Recebida não deve estar vazia
        Given que o usuário possui um nome de usuário de "Marcela" e uma senha "5678"
        When o usuário faz uma requisição POST
        Then a resposta deve ter um status 200
        And a resposta não deve estar vazia
