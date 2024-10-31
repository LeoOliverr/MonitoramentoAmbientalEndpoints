Feature: Validar Status Code
    Ao realizar uma requisição de consulta dentro da API, verificar se ela retorna o status code 200.

    Scenario: Validar que o endpoint de consulta retorne status 200 OK
        Given que o endpoint "api/sensor" está disponível
        When eu realizo uma requisição GET
        Then o status code retornado deve ser 200