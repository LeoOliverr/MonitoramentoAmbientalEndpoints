Feature: Validar Json Schema
    Garantir que o contrato Json seja seguido no formato esperado.

    Scenario: Validar que a resposta do endpoint "api/sensor" segue o Json Schema
        Given que o endpoint "api/sensor" está disponível
        When eu faço uma requisição GET
        Then o corpo da resposta deve seguir o Json Schema "SensorSchema.json"