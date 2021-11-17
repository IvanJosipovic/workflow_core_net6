using WorkflowCore.Interface;

namespace workflow_core_net6;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IWorkflowHost workflowHost;

    public Worker(ILogger<Worker> logger, IWorkflowHost workflowHost)
    {
        _logger = logger;
        this.workflowHost = workflowHost;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        workflowHost.PersistenceStore.EnsureStoreExists();

        workflowHost.RegisterWorkflow<TestWf>();

        await workflowHost.StartWorkflow("TestWf");

        await workflowHost.StartAsync(stoppingToken);
    }
}