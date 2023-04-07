using MaplrSugarShack.Shared;
using Microsoft.AspNetCore.Components;

namespace MaplrSugarShack.Client.Shared.Components
{
    public partial class CatalogList
    {
        [Parameter]
        public ICollection<CatalogueItemDto> CatalogItems { get; set; } = Array.Empty<CatalogueItemDto>();
    }
}