using WorkflowCore.Interface;

namespace workflow_core_net6
{
    public class TestWf : IWorkflow
    {
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith(_ => { })
                    .Name("Starting")
                .Then(_ => { })
                    .Name("Completed");
        }

        public string Id => "TestWf";

        public int Version => 1;
    }
}