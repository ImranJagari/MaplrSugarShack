using MaplrSugarShack.Shared;

namespace MaplrSugarShack.Client.Pages
{
    public partial class Home
    {
        private static MapleSyrupDtoType[] _syropTypes = Enum.GetValues<MapleSyrupDtoType>();
        private ICollection<CatalogueItemDto> _catalogs = Array.Empty<CatalogueItemDto>();
        protected override async Task OnInitializedAsync()
        {
             _catalogs = await MaplrClient.GetCatalogueAsync();
        }
    }
}