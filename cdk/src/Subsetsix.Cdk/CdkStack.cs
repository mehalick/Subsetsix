using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Amazon.CDK.AWS.ECS;
using Amazon.CDK.AWS.ECS.Patterns;
using Amazon.CDK.AWS.RDS;
using Constructs;
using InstanceType = Amazon.CDK.AWS.EC2.InstanceType;

namespace Subsetsix.Cdk;

public class CdkStack : Stack
{
    internal CdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
    {
        var vpc = CreateVpc();

        CreateFargateCluster(vpc);
        CreateAuroraDatabase(vpc);
    }

    private Vpc CreateVpc()
    {
        var vpc = new Vpc(this, "SubsetsixVpc", new VpcProps
        {
            IpAddresses = IpAddresses.Cidr("10.0.0.0/16"),
            MaxAzs = 2,
            SubnetConfiguration =
            [
                new SubnetConfiguration
                {
                    CidrMask = 24,
                    SubnetType = SubnetType.PUBLIC,
                    Name = "SubsetsixSubnetPublic"
                },
                new SubnetConfiguration
                {
                    CidrMask = 24,
                    SubnetType = SubnetType.PRIVATE_WITH_EGRESS,
                    Name = "SubsetsixSubnetPrivate"
                }
            ]
        });
        return vpc;
    }

    private void CreateFargateCluster(IVpc vpc)
    {
        var cluster = new Cluster(this, "SubsetsixFargateCluster", new ClusterProps
        {
            Vpc = vpc
        });

        _ = new ApplicationLoadBalancedFargateService(this, "SubsetsixFargateService",
            new ApplicationLoadBalancedFargateServiceProps
            {
                Cluster = cluster,
                DesiredCount = 1,
                TaskImageOptions = new ApplicationLoadBalancedTaskImageOptions
                {
                    Image = ContainerImage.FromRegistry("amazon/amazon-ecs-sample")
                },
                MemoryLimitMiB = 2048,
                PublicLoadBalancer = true
            }
        );
    }

    private BastionHostLinux CreateBastionHost(IVpc vpc)
    {
        var host = new BastionHostLinux(this, "SubsetsixDbBastionHost", new BastionHostLinuxProps
        {
            Vpc = vpc,
            InstanceName = "SubsetsixDbBastionHost"
        });

        return host;
    }

    private void CreateAuroraDatabase(IVpc vpc)
    {
        var bastionHost = CreateBastionHost(vpc);

        var secret = new DatabaseSecret(this, "SubsetsixDbSecret", new DatabaseSecretProps
        {
            Username = "postgres",
            SecretName = "SubsetsixDbSecret"
        });

        var securityGroup = new SecurityGroup(this, "SubsetSixDbSecurityGroup", new SecurityGroupProps
        {
            Vpc = vpc
        });

        var db = new DatabaseInstance(this, "SubsetsixDbInstance", new DatabaseInstanceProps
        {
            Vpc = vpc,
            VpcSubnets = new SubnetSelection{ SubnetType = SubnetType.PRIVATE_WITH_EGRESS },
            Engine = DatabaseInstanceEngine.Postgres(new PostgresInstanceEngineProps { Version = PostgresEngineVersion.VER_16_2 }),
            InstanceType = InstanceType.Of(InstanceClass.T3, InstanceSize.MICRO),
            InstanceIdentifier = "SubsetsixDbInstance",
            BackupRetention = Duration.Seconds(0), //not a good idea in prod, for this sample code it's ok
            RemovalPolicy = RemovalPolicy.DESTROY,
            Credentials = Credentials.FromSecret(secret),
            SecurityGroups = [securityGroup],
            DatabaseName = "subsetsix",
            IamAuthentication = true
        });

        db.Connections.AllowFrom(bastionHost, Port.Tcp(5432), "Allow connections from bastion host");

        db.AddProxy("SubsetsixDbProxy", new DatabaseProxyOptions
        {
            Secrets = [db.Secret],
            SecurityGroups = [securityGroup],
            Vpc = vpc,
            VpcSubnets = new SubnetSelection{ SubnetType = SubnetType.PRIVATE_WITH_EGRESS },
            IamAuth = true,
            RequireTLS = true
        });
    }
}