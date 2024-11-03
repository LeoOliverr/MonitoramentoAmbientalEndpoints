using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Json.Schema;
using System.Text.Json;

namespace MonitoramentoAmbientalEndpoints.Tests.BDD.Steps
{
    [Binding]
    public class AuthSteps
    {
        private readonly HttpClient _httpClient;
        private HttpResponseMessage _response;
        private string _username;
        private string _password;

        public AuthSteps()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:8080/") };
        }

        [Given(@"que o usuário possui um nome de usuário de ""(.*)"" e uma senha ""(.*)""")]
        public void DadoQueOUsuarioPossuiUmNomeDeUsuarioDeEUmaSenha(string username, string password)
        {
            _username = username;
            _password = password;
        }

        [When(@"o usuário faz uma requisição POST")]
        public async Task QuandoOUsuarioFazUmaRequisicaoPOST()
        {
            var content = new StringContent($"{{ \"username\": \"{_username}\", \"password\": \"{_password}\" }}", System.Text.Encoding.UTF8, "application/json");

            _response = await _httpClient.PostAsync("api/auth/login", content);
        }

        [Then(@"a resposta deve ter um status (.*)")]
        public void EntaoARespostaDeveTerUmStatus(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }

        [Then(@"a resposta não deve conter um token")]
        public async Task EntaoARespostaNaoDeveConterUmToken()
        {
            var responseString = await _response.Content.ReadAsStringAsync();
            Assert.IsFalse(responseString.Contains("token"));
        }

        [Then(@"a resposta deve conter um token")]
        public async Task EntaoARespostaDeveConterUmToken()
        {
            var responseString = await _response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseString.Contains("token"));
        }

        [Then(@"a resposta não deve estar vazia")]
        public async Task EntaoARespostaNaoDeveEstarVazia()
        {
            var responseString = await _response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseString), "A resposta está vazia.");
        }

        [Then(@"a resposta deve seguir o padrão definido em ""(.*)""")]
        public async Task EntaoARespostaDeveSeguirOPadraoDefinidoEm(string schemaFile)
        {
            var schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tests", "BDD", "Schemas", schemaFile);

            var schemaContent = await File.ReadAllTextAsync(schemaPath);
            var schema = JsonSchema.FromText(schemaContent);

            var responseContent = await _response.Content.ReadAsStringAsync();
            var jsonResponse = JsonDocument.Parse(responseContent).RootElement;

            var validationResults = schema.Evaluate(jsonResponse);

            Assert.IsTrue(validationResults.IsValid, "A resposta não está de acordo com o schema JSON.");
        }
    }

}