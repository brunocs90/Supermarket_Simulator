using Application.DTOs;
using Newtonsoft.Json;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Supermarket_Simulator.AcceptanceTests.Steps
{
    [Binding]
    public class ProdutoSteps
    {
        private HttpResponseMessage _response;
        private ProductDTO _newProduct;
        private ProductDTO _createdProduct;
        private readonly HttpClient _httpClient;

        public ProdutoSteps()
        {
            var httpClientHandler = new HttpClientHandler();
            _httpClient = new HttpClient(httpClientHandler);
            _httpClient.BaseAddress = new Uri("https://localhost:7180");
        }

        [Given(@"I have a new product with the following details:")]
        public void GivenIHaveANewProductWithTheFollowingDetails(Table table)
        {
            _newProduct = table.CreateInstance<ProductDTO>();
        }

        [When(@"I send a POST request to ""(.*)"" with the product details")]
        public async Task WhenISendAPOSTRequestToWithTheProductDetails(string url)
        {
            var content = new StringContent(JsonConvert.SerializeObject(_newProduct), Encoding.UTF8, "application/json");
            _response = await _httpClient.PostAsync(url, content);
            _response.EnsureSuccessStatusCode();
            var responseContent = await _response.Content.ReadAsStringAsync();
            _createdProduct = JsonConvert.DeserializeObject<ProductDTO>(responseContent);
        }

        [Then(@"the response status code should be (\d+)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
        }

        [Then(@"the response should contain the created product details")]
        public void ThenTheResponseShouldContainTheCreatedProductDetails()
        {
            Assert.NotNull(_createdProduct);
            Assert.AreEqual(_newProduct.Name, _createdProduct.Name);
            Assert.AreEqual(_newProduct.Price, _createdProduct.Price);
        }
    }
}
