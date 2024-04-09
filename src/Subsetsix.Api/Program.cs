using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Marten.Services.Json;
using Microsoft.AspNetCore.Mvc;

namespace Subsetsix.Api;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddMarten(options =>
        {
            options.Connection(builder.Configuration.GetConnectionString("DbConnection")!);
            options.UseDefaultSerialization(serializerType: SerializerType.SystemTextJson);

            options.Projections.Snapshot<Project>(SnapshotLifecycle.Inline);

        }).OptimizeArtifactWorkflow();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapPost("/project",
            async (CreateProjectRequest create, [FromServices] IDocumentSession  session) =>
            {
                var projectCreated = new ProjectCreated
                {
                    Name = create.Name
                };

                var id = session.Events.StartStream<Project>(projectCreated).Id;

                await session.SaveChangesAsync();
            });

        app.MapGet("/projects",
            async ([FromServices] IDocumentStore store, CancellationToken ct) =>
            {
                await using var session = store.QuerySession();

                return await session.Query<Project>().ToListAsync(ct);
            });

        await app.RunAsync();
    }
}

public record CreateProjectRequest(string Name);

public class Project
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public required string Name { get; set; }
    public required DateTimeOffset AddedUtc { get; set; }

    public void Apply(IEvent<ProjectCreated> @event)
    {
        AddedUtc = @event.Timestamp;
        Name = @event.Data.Name;
    }

    public void Apply(ProjectRenamed @event)
    {
        Name = @event.Name;
    }
}

public class ProjectCreated
{
    public required string Name { get; set; }
}

public class ProjectRenamed
{
    public required string Name { get; set; }
}