namespace Subsetsix.Api.Endpoints.Items;

[HttpGet("items.list")]
[AllowAnonymous]
public class List: EndpointWithoutRequest<IReadOnlyList<Item>>
{
    private readonly IQuerySession _session;

    public List(IQuerySession session)
    {
        _session = session;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var items = await _session.Query<Item>().ToListAsync(ct);

        await SendAsync(items, cancellation: ct);
    }
}