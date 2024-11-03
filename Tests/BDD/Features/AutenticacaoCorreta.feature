Feature: Autenticação de Usuário Existente

    Scenario: Login bem-sucedido
        Given que o usuário possui um nome de usuário de "Marcela" e uma senha "5678"
        When o usuário faz uma requisição POST
        Then a resposta deve ter um status 200
        And a resposta deve conter um token