using ProjectPlanner.Exceptions;

namespace ProjectPlanner.Features.Plans.GetPlansByName;

public class GetProjectPlanByNameHandler
	: IQueryHandler<GetProjectPlanByNameQuery, GetProjectPlanByNameResult>
{
    private readonly IProjectPlanRepository repository;
    public GetProjectPlanByNameHandler(IProjectPlanRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetProjectPlanByNameResult> Handle(
        GetProjectPlanByNameQuery query,
        CancellationToken cancellationToken)
    {
        var result = this.repository.GetByName(query.Name);
        if(result is null)
        {
            throw new ProjectPlanNotFoundexception(query.Name);
        }
        return new GetProjectPlanByNameResult(result);
    }
}

