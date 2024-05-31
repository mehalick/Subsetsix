var builder = DistributedApplication.CreateBuilder(args);


const string databaseName = "subsetsix";

var database = builder.AddPostgres("postgres")
    .WithEnvironment("POSTGRES_DB", databaseName)
    .WithPgAdmin()
    .AddDatabase(databaseName);

builder.AddProject<Projects.Subsetsix_Api>("subsetsix-api")
    .WithReference(database);

builder.Build().Run();
