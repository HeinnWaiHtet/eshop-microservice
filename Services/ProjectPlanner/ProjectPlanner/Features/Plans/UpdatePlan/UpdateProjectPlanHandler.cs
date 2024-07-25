

namespace ProjectPlanner.Features.Plans.UpdatePlan;

public class UpdateProjectPlanHandler:
	ICommandHandler<UpdateProjectPlanCommand, UpdateProjectPlanResult>
{
    private readonly IProjectPlanRepository repository;
    public UpdateProjectPlanHandler(IProjectPlanRepository repository)
    {
        this.repository = repository;
    }

    public async Task<UpdateProjectPlanResult> Handle(
        UpdateProjectPlanCommand command,
        CancellationToken cancellationToken)
    {
        var search = this.repository.GetById(command.Id);
        if(search is null)
        {
            throw new ProjectPlanNotFoundexception(command.Id);
        }

        this.repository.Update(command.Adapt<ProjectPlan>());
        return new UpdateProjectPlanResult(true);
    }
}

