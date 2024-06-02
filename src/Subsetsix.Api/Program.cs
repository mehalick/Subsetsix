global using FastEndpoints;
global using Marten;
global using Subsetsix.Api.Entities;
global using Microsoft.AspNetCore.Authorization;
using Marten.Events.Projections;

namespace Subsetsix.Api;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();
        builder.AddNpgsqlDataSource("subsetsix");

        builder.Services.AddAuthorization();

        builder.Services.AddMarten(options =>
            {
                options.UseSystemTextJsonForSerialization();

                options.Projections.Snapshot<Item>(SnapshotLifecycle.Inline);

            })
            .UseNpgsqlDataSource()
            .OptimizeArtifactWorkflow();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddFastEndpoints();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseFastEndpoints(i => i.Errors.UseProblemDetails());

        await app.RunAsync();
    }
}
