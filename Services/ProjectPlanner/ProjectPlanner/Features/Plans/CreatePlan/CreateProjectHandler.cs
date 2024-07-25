

namespace ProjectPlanner.Features.Plans.CreatePlan;

public class CreateProjectHandler
    : ICommandHandler<CreateProjectPlanCommand, CreateProjectPlanResult>
{
    private readonly IProjectPlanRepository repository;
    public CreateProjectHandler(IProjectPlanRepository repository)
    {
        this.repository = repository;
    }

    public async Task<CreateProjectPlanResult> Handle(
        CreateProjectPlanCommand command,
        CancellationToken cancellationToken)
    {
        // Create Obj

        //Save Database
        var result = repository.Add(command);

        // Return New Object
        return new CreateProjectPlanResult(result);
    }
}
