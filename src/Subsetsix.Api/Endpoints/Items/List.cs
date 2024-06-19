using Subsetsix.Api.Common;

namespace Subsetsix.Api.Endpoints.Items;

public class List: EndpointWithoutRequest<IReadOnlyList<ItemsListResponseItem>>
{
    public override void Configure()
    {
        Get(EndpointRoutes.ItemsList);
        AllowAnonymous();
        SerializerContext(Serializer.Default);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var results = new List<ItemsListResponseItem>
        {
            new ItemsListResponseItem()
            {
                Title = "test",
                Description = "description"
            }
        };

        await SendAsync(results, cancellation: ct);
    }
}