$instanceId = "i-0b922d2461b0ede08"
$parameters = 'host="subsetsixdbinstance.casb7fp0mfl2.us-east-1.rds.amazonaws.com",portNumber="5432",localPortNumber="5432"'

aws ssm start-session `
    --target $instanceId `
    --document-name AWS-StartPortForwardingSessionToRemoteHost `
    --parameters $parameters `
    --profile isengard
