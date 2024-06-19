global using FastEndpoints;
global using Marten;
global using Subsetsix.Api.Entities;
global using Microsoft.AspNetCore.Authorization;
using Marten.Events.Projections;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Subsetsix.Api.Configuration;

namespace Subsetsix.Api;

public static class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .AddDefaultLogging()
            .CreateBootstrapLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            builder.AddServiceDefaults();
            //builder.AddNpgsqlDataSource("subsetsix");

            builder.Services.AddAuthorization();

            // builder.Services.AddMarten(options =>
            //     {
            //         options.UseSystemTextJsonForSerialization();
            //
            //         options.Projections.Snapshot<Item>(SnapshotLifecycle.Inline);
            //
            //     })
            //     .UseNpgsqlDataSource()
            //     .OptimizeArtifactWorkflow();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddFastEndpoints();

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            app.MapGet("/", () =>
            {
                Log.Information("GET healthcheck");
                return "Healthy";
            });

            app.MapDefaultEndpoints();

            // if (app.Environment.IsDevelopment())
            // {
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseFastEndpoints(i => i.Errors.UseProblemDetails());

            await app.RunAsync();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}
