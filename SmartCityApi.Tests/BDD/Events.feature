Feature: Listagem de Cidades
  Como usuário
  Eu quero listar todas as cidades registradas
  Para que eu possa visualizá-las.

  Scenario: Listar cidades com sucesso
    Given a API está em execução
    When eu faço uma requisição GET para "/api/cities"
    Then a resposta deve ter o status code 200
    And o corpo da resposta deve conter uma lista de cidades
    And o JSON schema da resposta deve estar válido

Feature: Criação de Sensor
  Como administrador
  Eu quero criar um sensor
  Para monitorar dados da cidade.

  Scenario: Falha ao criar sensor sem dados obrigatórios
    Given a API está em execução
    When eu faço uma requisição POST para "/api/sensors" sem o campo "Name"
    Then a resposta deve ter o status code 400
    And o corpo da resposta deve conter uma mensagem de erro "O campo 'Name' é obrigatório."
    And o JSON schema da resposta de erro deve estar válido

Feature: Atualização de Evento
  Como administrador
  Eu quero atualizar os dados de um evento
  Para refletir mudanças ocorridas.

  Scenario: Atualizar evento com sucesso
    Given um evento existente com ID 1
    When eu faço uma requisição PUT para "/api/events/1" com um novo "Name" e "Description"
    Then a resposta deve ter o status code 200
    And o corpo da resposta deve conter os dados atualizados
    And o JSON schema da resposta deve estar válido
