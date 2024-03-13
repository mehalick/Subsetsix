using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Marten.Services.Json;
using Microsoft.AspNetCore.Mvc;

namespace Subsetsix.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddMarten(options =>
        {
            options.Connection(builder.Configuration.GetConnectionString("DbConnection")!);

            options.UseDefaultSerialization(serializerType: SerializerType.SystemTextJson);

            options.Projections.Snapshot<Pet>(SnapshotLifecycle.Inline);
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

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        {
                            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = summaries[Random.Shared.Next(summaries.Length)]
                        })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        app.MapPost("/user",
            async (CreateUserRequest create, [FromServices] IDocumentSession  session) =>
            {
                var petCreated = new PetCreated
                {
                    Name = create.FirstName
                };

                var petRenamed = new PetRenamed
                {
                    Name = create.LastName
                };

                var id = session.Events.StartStream<Pet>(petCreated, petRenamed).Id;

                await session.SaveChangesAsync();
            });

        app.MapGet("/users",
            async ([FromServices] IDocumentStore store, CancellationToken ct) =>
            {
                await using var session = store.QuerySession();

                return await session.Query<Pet>().ToListAsync(ct);
            });

        app.Run();
    }
}

public record CreateUserRequest(string FirstName, string LastName);

public class User
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

public class Pet
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public required string Name { get; set; }
    public required DateTimeOffset Date { get; set; }

    public void Apply(IEvent<PetCreated> @event)
    {
        Date = @event.Timestamp;
        Name = @event.Data.Name;
    }

    public void Apply(PetRenamed @event)
    {
        Name = @event.Name;
    }
}

public class PetCreated
{
    public required string Name { get; set; }
}

public class PetRenamed
{
    public required string Name { get; set; }
}