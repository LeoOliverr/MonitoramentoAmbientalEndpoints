Feature: Validar Estrutura do Corpo da Resposta
    Verificar a estrutura da resposta JSON.

    Scenario: Validar que o corpo da resposta do endpoint "api/sensor" segue Json Schema
        Given que o endpoint "api/sensor" está disponível
        When eu realizo uma requisição GET
        Then o corpo da resposta deve seguir o Json Schema "SensorSchema.json"