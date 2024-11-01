Feature: Validar Endpoint Indisponível
    Verificar a resposta da API quando um endpoint não está disponível.

    Scenario: Validar que o endpoint "api/sensors" está indisponível
        Given que o endpoint "api/sensors" está indisponível
        When eu realizo uma requisição GET
        Then o status code retornado deve ser 404