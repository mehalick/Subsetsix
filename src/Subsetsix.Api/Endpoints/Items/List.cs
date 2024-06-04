using Subsetsix.Api.Common;

namespace Subsetsix.Api.Endpoints.Items;

[HttpGet("items.list")]
[AllowAnonymous]
public class List: EndpointWithoutRequest<IReadOnlyList<ItemsListResponseItem>>
{
    private readonly IQuerySession _session;

    public List(IQuerySession session)
    {
        _session = session;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var items = await _session.Query<Item>().ToListAsync(ct);

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