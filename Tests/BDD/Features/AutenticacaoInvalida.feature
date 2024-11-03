Feature: Autenticação Com Dados Inválidos

    Scenario: Login com credenciais inválidas
        Given que o usuário possui um nome de usuário de "Marcela" e uma senha "senhaInvalida"
        When o usuário faz uma requisição POST
        Then a resposta deve ter um status 401
        And a resposta não deve conter um token