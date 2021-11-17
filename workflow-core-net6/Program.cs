using workflow_core_net6;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((host, services) =>
    {
        services.AddHostedService<Worker>();

        services.AddWorkflow(x => x
            .UseSqlServer(host.Configuration.GetConnectionString("WorkflowCore"), true, true)
        );
    })
    .Build();

await host.RunAsync();
