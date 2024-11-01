Feature: Validar Resposta do Endpoint
    Verificar que a API responde corretamente ao acesso ao endpoint.

    Scenario: Validar que a resposta do endpoint "api/sensor" contém dados corretos
        Given que o endpoint "api/sensor" está disponível
        When eu realizo uma requisição GET
        Then o status code retornado deve ser 200
        And o corpo da resposta deve conter "Id" e "Nome"