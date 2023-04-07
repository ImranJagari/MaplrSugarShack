using MaplrSugarShack.Client.Core;
using MaplrSugarShack.Shared;
using Microsoft.AspNetCore.Components;
using SyrupType = MaplrSugarShack.Shared.Type;

namespace MaplrSugarShack.Client.Pages
{
    public partial class Product
    {
        private MapleSyrupDto _syrup = new MapleSyrupDto();
        private ICollection<CatalogueItemDto> _sameTypeSyrups = Array.Empty<CatalogueItemDto>();
        private int _quantity;
        [Parameter]
        public string? ProductId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductId == null)
            {
                NavigationManager.NavigateTo(uri: "/", forceLoad: true);
                return;
            }

            _syrup = await MaplrClient.GetProductInfoAsync(ProductId ?? string.Empty);

            if (_syrup is null || string.IsNullOrWhiteSpace(_syrup.Id))
            {
                NavigationManager.NavigateTo(uri: "/", forceLoad: true);
                return;
            }

            _sameTypeSyrups = await MaplrClient.GetCatalogueAsync((SyrupType)_syrup.Type);
        }

        private void ChangeQuantity(bool isIncreasing)
        {
            if (isIncreasing)
                _quantity++;
            else
                _quantity--;
        }

        private async Task AddToCartAsync()
        {
            await MaplrClient.AddToCartAsync(ProductId!, _quantity);
            Events.CartUpdated?.Invoke();
        }
    }
}