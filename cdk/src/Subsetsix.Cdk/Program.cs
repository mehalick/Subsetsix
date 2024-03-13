using Amazon.CDK;
using Microsoft.Extensions.Configuration;

namespace Subsetsix.Cdk;

internal sealed class Program
{
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        builder.AddUserSecrets<Program>();

        var configuration = builder.Build();

        var app = new App();
        _ = new CdkStack(app, "SubsetsixStack", new StackProps
        {
            Env = new Environment
            {
                Account = configuration["CdkAccount"],
                Region = configuration["CdkRegion"]
            }
        });
        app.Synth();
    }
}