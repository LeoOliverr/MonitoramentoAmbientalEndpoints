using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MonitoramentoAmbientalEndpoints.Steps
{
    [Binding]
    public class SensorSteps
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;
        private JObject _responseBody;

        public SensorSteps(){
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080");
        }

        [Given(@"que o endpoint ""api/sensor"" está disponível")]
        public async Task ValidarEndpoint(string endpoint){
            _response = await _httpClient.GetAsync(endpoint);
            Assert.IsTrue(_response.IsSuccessStatusCode, "Endpoint não disponível");
        }

        [When(@"eu realizo uma requisição GET")]
        public async Task WhenEuRealizoUmaRequisicaoGET(){
            _response = await _httpClient.GetAsync("api/sensor");
            _response.EnsureSuccessStatusCode();
            var responseBodyString = await _response.Content.ReadAsStringAsync();
            _responseBody = JObject.Parse(responseBodyString);
        }

        [Then(@"o status code retornado deve ser 200")]
        public void ThenOStatusCodeRetornadoDeveSer(int expectedStatusCode){
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"o corpo da resposta deve conter ""Id"" e ""Nome""")]
        public void ThenOCorpoDaRespostaDeveConterE(string property1, string property2){
            Assert.IsTrue(_responseBody.ContainsKey(property1), $"A propriedade {property1} não foi encontrada.");
            Assert.IsTrue(_responseBody.ContainsKey(property2), $"A propriedade {property2} não foi encontrada.");
        }

        [Then(@"o corpo da resposta deve seguir o Json Schema ""SensorSchema.json""")]
        public void ThenOCorpoDaRespostaDeveSeguirOJsonSchema(string schemaFileName){
            string schemaPath = Path.Combine(AppContext.BaseDirectory, schemaFileName);
            string schemaJson = File.ReadAllText(schemaPath);
            JSchema schema = JSchema.Parse(schemaJson);

            Assert.IsTrue(_responseBody.IsValid(schema), "O corpo da resposta não segue o JSON Schema.");
        }
    }
}