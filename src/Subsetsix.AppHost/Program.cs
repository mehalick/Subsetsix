var builder = DistributedApplication.CreateBuilder(args);


const string databaseName = "subsetsix";

var password = builder.AddParameter("postgresql-password", secret: true);

var database = builder.AddPostgres("postgres", password: password, port: 53888)
    .WithEnvironment("POSTGRES_DB", databaseName)
    .WithBindMount("./.data/postgres", "/var/lib/postgresql/data")
    .WithPgAdmin()
    .AddDatabase(databaseName);

builder.AddProject<Projects.Subsetsix_Api>("subsetsix-api")
    .WithReference(database);

builder.Build().Run();
