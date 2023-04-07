using MaplrSugarShack.Client.Pages;
using MaplrSugarShack.Shared;
using System.Net.Http.Json;
using Type = MaplrSugarShack.Shared.Type;

namespace MaplrSugarShack.Client.Core
{
    public sealed class MaplrClient
    {
        private readonly HttpClient client;

        public MaplrClient(HttpClient client) 
        {
            this.client = client;
        }

        public async Task<ICollection<CatalogueItemDto>> GetCatalogueAsync(Type? type = null)
        {
            return (await client.GetFromJsonAsync<ICollection<CatalogueItemDto>>($"/products?type={type}"))!;
        }

        public async Task<ICollection<CartLineDto>> GetCartAsync()
        {
            return (await client.GetFromJsonAsync<ICollection<CartLineDto>>("/cart"))!;
        }

        public async Task AddToCartAsync(string productId, int quantity)
        {
            await client.PutAsync($"/cart?productId={productId}&quantity={quantity}", new StringContent(string.Empty));
        }

        public async Task RemoveFromCartAsync(string productId)
        {
            await client.DeleteAsync($"/cart?productId={productId}");
        }

        
        public async Task ChangeQtyAsync(string productId, int newQty)
        {
            await client.PatchAsync($"/cart?productId={productId}&newQty={newQty}", new StringContent(string.Empty));
        }

        public async Task<OrderValidationResponseDto> PlaceOrderAsync(IEnumerable<OrderLineDto> body)
        {
            var response = await client.PostAsJsonAsync($"/order", body);
            return (await response.Content.ReadFromJsonAsync<OrderValidationResponseDto>())!;
        }

        public async Task<MapleSyrupDto> GetProductInfoAsync(string productId)
        {
            return (await client.GetFromJsonAsync<MapleSyrupDto>($"/products/{productId}"))!;
        }
    }
}
