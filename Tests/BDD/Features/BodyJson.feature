Feature: Validar conteúdo Json
    Verificar se o corpo da resposta Json contém os dados esperados.

    Scenario: Validar a resposta do endpoint "api/sensor" para garantir que contém dados corretos
        Given que o endpoint "api/sensor" está disponível
        When eu faço uma requisição GET
        Then o corpo da resposta deve conter "Id" e "Nome"