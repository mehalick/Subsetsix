using Subsetsix.Api.Common;

namespace Subsetsix.Api.Endpoints.Items;

public class List(IQuerySession session): EndpointWithoutRequest<IReadOnlyList<ItemsListResponseItem>>
{
    public override void Configure()
    {
        Get(EndpointRoutes.ItemsList);
        AllowAnonymous();
        SerializerContext(Serializer.Default);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var items = await session.Query<Item>().ToListAsync(ct);

        var results = items
            .Select(i => new ItemsListResponseItem
            {
                Title = i.Title,
                Description = i.Description,
                Tags = i.Tags
            })
            .ToList();

        await SendAsync(results, cancellation: ct);
    }
}
