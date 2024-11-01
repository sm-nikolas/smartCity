using System.Collections.Generic; // Para List<T>
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Schema;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using SmartCityApi.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace SmartCityApi.Tests
{
    public class ApiTests : IClassFixture<WebApplicationFactory<SmartCityApi.Startup>>
    {
        private readonly WebApplicationFactory<SmartCityApi.Startup> _factory;

        public ApiTests(WebApplicationFactory<SmartCityApi.Startup> factory)
        {
            _factory = factory;
        }

        private async Task ValidateJsonSchema(HttpResponseMessage response, string schemaJson)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonSchema = JSchema.Parse(schemaJson);
            var jsonResponse = JObject.Parse(responseContent);

            jsonResponse.IsValid(jsonSchema).Should().BeTrue("O JSON não está no formato esperado.");
        }

        [Fact]
        public async Task ListCities_ReturnsStatusCode200AndValidJsonSchema()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/cities");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var cities = await response.Content.ReadFromJsonAsync<List<Cidade>>();
            cities.Should().NotBeNullOrEmpty();

            // Schema JSON esperado
            string schemaJson = @"{
                'type': 'array',
                'items': { 
                    'type': 'object', 
                    'properties': { 
                        'id': {'type': 'integer'}, 
                        'name': {'type': 'string'} 
                    }, 
                    'required': ['id', 'name']
                }
            }";

            await ValidateJsonSchema(response, schemaJson);
        }

        [Fact]
        public async Task CreateSensor_MissingNameField_ReturnsStatusCode400AndValidErrorJsonSchema()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newSensor = new { Type = "Temperature", CityId = 1 }; // Faltando o campo "Name"

            // Act
            var response = await client.PostAsJsonAsync("/api/sensors", newSensor);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Schema JSON esperado para erro
            string schemaJson = @"{
                'type': 'object',
                'properties': {
                    'error': {'type': 'string'}
                },
                'required': ['error']
            }";

            var errorResponse = await response.Content.ReadFromJsonAsync<JObject>(); // Lê a resposta de erro como JObject
            errorResponse.Should().NotBeNull();

            if (errorResponse != null){
            errorResponse["error"].Should().Contain("O campo 'Name' é obrigatório."); // Verifica se a mensagem de erro está presente
            }

            await ValidateJsonSchema(response, schemaJson);
        }

        [Fact]
        public async Task UpdateEvent_ReturnsStatusCode200AndValidJsonSchema()
        {
            // Arrange
            var client = _factory.CreateClient();
            var updatedEvent = new { Name = "Updated Event", Description = "New description" };

            // Act
            var response = await client.PutAsJsonAsync("/api/events/1", updatedEvent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Schema JSON esperado
            string schemaJson = @"{
                'type': 'object',
                'properties': {
                    'id': {'type': 'integer'},
                    'name': {'type': 'string'},
                    'description': {'type': 'string'}
                },
                'required': ['id', 'name', 'description']
            }";

            var updatedResponse = await response.Content.ReadFromJsonAsync<JObject>(); // Lê a resposta como JObject
            updatedResponse.Should().NotBeNull();
           updatedResponse.Should().NotBeNull();
           updatedResponse.Should().BeEquivalentTo(new { name = "Updated Event", description = "New description" });


            await ValidateJsonSchema(response, schemaJson);
        }
    }
}
