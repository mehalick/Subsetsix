using Microsoft.AspNetCore.Components;
using Subsetsix.Web.Client.Services;

namespace Subsetsix.Web.Client.Pages;

public partial class Home : ComponentBase
{
    [Inject]
    public ApiService ApiService { get; set; } = null!;

    private string? _message;

    protected override async Task OnInitializedAsync()
    {
        _message = await ApiService.Get();
    }
}