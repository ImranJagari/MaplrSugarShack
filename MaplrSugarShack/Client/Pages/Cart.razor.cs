using MaplrSugarShack.Client.Core;
using MaplrSugarShack.Shared;
using MudBlazor;

namespace MaplrSugarShack.Client.Pages
{
    public partial class Cart
    {
        private ICollection<CartLineDto> _cartLines = Array.Empty<CartLineDto>();
        protected override async Task OnInitializedAsync()
        {
            Events.CartUpdated -= OnCartUpdated;
            Events.CartUpdated += OnCartUpdated;

            await OnCartUpdated();
        }

        private async Task PlaceOrder()
        {
            var result = await MaplrClient.PlaceOrderAsync(_cartLines.Select(_ => new OrderLineDto
            {
                ProductId = _.ProductId,
                Qty = _.Qty
            }));

            foreach(var error in result.Errors)
            {
                SnackBar.Add(error, Severity.Error);
            }

           await OnCartUpdated();
        }

        public void ChangeQuantity(CartLineDto cartLine, bool isIncreasing)
        {
            if(isIncreasing) 
                cartLine.Qty++;
            else
                cartLine.Qty--;
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