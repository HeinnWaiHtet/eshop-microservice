

namespace ProjectPlanner.Features.Plans.DeletePlan;

public class DeleteProjectPlanHandler
	: ICommandHandler<DeleteProjectPlanCommand, DeleteProjectPlanQuery>
{
    private readonly IProjectPlanRepository repository;
    public DeleteProjectPlanHandler(IProjectPlanRepository repository)
    {
        this.repository = repository;
    }

    public async Task<DeleteProjectPlanQuery> Handle(
        DeleteProjectPlanCommand command,
        CancellationToken cancellationToken)
    {
        var search = this.repository.GetById(command.Id);
        if(search is null)
        {
            throw new ProjectPlanNotFoundexception(command.Id);
        }

        var result = this.repository.DeleteById(command.Id);
        if(result is false)
        {
            throw new ProjectPlanNotFoundexception($"no record with Id {command.Id}");
        }

        return new DeleteProjectPlanQuery(result);
    }
}

