using MaplrSugarShack.Client.Core;
using MaplrSugarShack.Shared;

namespace MaplrSugarShack.Client.Shared.Components
{
    public partial class Header
    {
        private ICollection<CartLineDto> _cartLines = new List<CartLineDto>();
        protected override async Task OnInitializedAsync()
        {
            Events.CartUpdated -= OnCartUpdated;
            Events.CartUpdated += OnCartUpdated;

            await OnCartUpdated();
        }

        public async Task ChangeQuantity(CartLineDto cartLine, bool isIncreasing)
        {
            int quantity = cartLine.Qty;
            if (isIncreasing)
                quantity++;
            else
                quantity--;

            await MaplrClient.ChangeQtyAsync(cartLine.ProductId, quantity);

            if (Events.CartUpdated is not null)
                await Events.CartUpdated.Invoke();
        }

        public async Task RemoveLine(CartLineDto cartLine)
        {
            await MaplrClient.RemoveFromCartAsync(cartLine.ProductId);
            
            if (Events.CartUpdated is not null)
                await Events.CartUpdated.Invoke();
        }

        private async Task OnCartUpdated()
        {
            _cartLines = await MaplrClient.GetCartAsync();
            StateHasChanged();
        }
    }
}