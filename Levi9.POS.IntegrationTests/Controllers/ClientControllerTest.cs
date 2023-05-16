using Levi9.POS.Domain.Helpers;
using Levi9.POS.Domain.Models;
using Levi9.POS.WebApi.Request.ClientRequests;
using Levi9.POS.WebApi.Response;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Levi9.POS.IntegrationTests.Controllers
{
    [TestFixture]
    public class ClientControllerTest
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _factory;
        string token = "";

        [SetUp]
        public void SetUp()
        {
            token = AuthenticationHelper.GenerateJwtTestCase();
            _factory = new CustomWebAppFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _client.Dispose();
        }

        [Test]
        public async Task AddClient_ValidRequest_ShouldReturnOk()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var clientRequest = new ClientRequest
            {
                Address = "address",
                Email = "email@gmail.com",
                Name = "name",
                Password = "password",
                Phone = "1234567890"
            };

            var response = await _client.PostAsJsonAsync("v1/client/", clientRequest);
            var result = await response.Content.ReadAsStringAsync();
            var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(result);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(clientRequest.Name, Is.EqualTo(clientResponse.Name));
            Assert.That(clientRequest.Email, Is.EqualTo(clientResponse.Email));
        }
        [Test]
        public async Task AddClient_EmailExist_ShouldReturnBadRequest()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var clientRequest = new ClientRequest
            {
                Address = "address",
                Email = "example@gmail.com",
                Name = "name",
                Password = "password",
                Phone = "1234567890"
            };

            var response = await _client.PostAsJsonAsync("v1/client/", clientRequest);
            var result = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(result, Is.EqualTo("Email already exists!"));
        }
        [Test]
        public async Task UpdateClient_ValidRequest_ShouldReturnOk()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var clienUpdate = new ClientUpdate
            {
                Id = 1,
                GlobalId = new Guid("10bc28f5-7042-4736-97ad-1cb3dce98b1c"),
                Address = "address",
                Email = "email123@gmail.com",
                Name = "name",
                Phone = "1234567890"
            };

            var response = await _client.PutAsJsonAsync("v1/client/update", clienUpdate);
            var result = await response.Content.ReadAsStringAsync();
            var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(result);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(clienUpdate.Name, Is.EqualTo(clientResponse.Name));
            Assert.That(clienUpdate.Email, Is.EqualTo(clientResponse.Email));
        }
        [Test]
        public async Task UpdateClient_EmailExist_ShouldReturnBadRequest()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var clienUpdate = new ClientUpdate
            {
                Id = 1,
                GlobalId = new Guid("10bc28f5-7042-4736-97ad-1cb3dce98b1c"),
                Address = "address",
                Email = "example@gmail.com",
                Name = "name",
                Phone = "1234567890"
            };

            var response = await _client.PutAsJsonAsync("v1/client/update", clienUpdate);
            var result = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(result, Is.EqualTo("Email already exists!"));
        }
        [Test]
        public async Task GetClientById_ShouldReturnClientIfExist()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            int id = 1;

            var response = await _client.GetAsync($"v1/client/{id}");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Client>(content);
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(1));
        }
        [Test]
        public async Task GetClientById_InvalidId_ReturnsBadRequest()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            int id = 0;

            var response = await _client.GetAsync($"/v1/client/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public async Task GetClientByNegativeId_ShouldReturnBadRequest()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            int id = -1;

            var response = await _client.GetAsync($"v1/client/{id}");

            var result = await response.Content.ReadAsStringAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(result, Is.EqualTo("Id must be a positive number"));
        }
        [Test]
        public async Task GetClientById_NoClientFound_ReturnsNotFound()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            int id = 100000;

            var response = await _client.GetAsync($"/v1/client/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task GetClientById_Unauthorized_ReturnsUnauthorized()
        {
            int id = 1;

            var response = await _client.GetAsync($"/v1/client/{id}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }
        [Test]
        public async Task GetClientByGlobalId_ShouldReturnClientIfExist()
        {
            var globalId = "10bc28f5-7042-4736-97ad-1cb3dce98b1c";
            string name = "Marko";

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.GetAsync($"v1/client/global/{globalId}");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ClientResponse>(content);
            Assert.NotNull(result);
            Assert.That(name, Is.EqualTo(result.Name));
        }
        [Test]
        public async Task GetClientByGlobalId_NoClientFound_ReturnsNotFound()
        {
            var globalId = new Guid();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"/v1/client/global/{globalId}");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public async Task GetClientByGlobalId_Unauthorized_ReturnsUnauthorized()
        {
            var response = await _client.GetAsync("/v1/client/global/10bc28f5-7042-4736-97ad-1cb3dce98b1c");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

    }
}
