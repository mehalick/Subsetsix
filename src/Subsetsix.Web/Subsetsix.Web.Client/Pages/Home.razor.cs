using Microsoft.AspNetCore.Components;
using Subsetsix.Api.Common;
using Subsetsix.Web.Client.Services;

namespace Subsetsix.Web.Client.Pages;

public partial class Home : ComponentBase
{
    [Inject]
    public ApiService ApiService { get; set; } = null!;

    private IQueryable<ItemsListResponseItem> _items = Enumerable.Empty<ItemsListResponseItem>().AsQueryable();

    protected override async Task OnInitializedAsync()
    {
        _items = (await ApiService.Get()).AsQueryable();
    }
}