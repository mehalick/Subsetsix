using FluentValidation;

namespace Subsetsix.Api.Endpoints.Items;

[HttpPost("items.add")]
[AllowAnonymous]
public class Add: Endpoint<Add.AddRequest, Add.AddResponse>
{
    public class AddRequest
    {
        public required string Title { get; init; }
        public string Description { get; init; } = "";
        public List<string> Tags { get; init; } = [];
    }

    public class AddRequestValidator : Validator<AddRequest>
    {
        public AddRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }

    public class AddResponse(Guid id)
    {
        public Guid Id { get; } = id;
    }

    private readonly IDocumentSession _session;

    public Add(IDocumentSession session)
    {
        _session = session;
    }

    public override async Task HandleAsync(AddRequest request, CancellationToken ct)
    {
        var itemAdded = new ItemAdded
        {
            Title = request.Title,
            Description = request.Description,
            Tags = request.Tags
        };

        var id = _session.Events.StartStream<Item>(itemAdded).Id;

        await _session.SaveChangesAsync(ct);

        await SendAsync(new(id), cancellation: ct);
    }
}
