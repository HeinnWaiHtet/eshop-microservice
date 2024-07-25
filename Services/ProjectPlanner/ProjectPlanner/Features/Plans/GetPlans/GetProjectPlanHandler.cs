
namespace ProjectPlanner.Features.Plans.GetPlans;

public class GetProjectPlanHandler
    : IQueryHandler<GetProjectPlanQuery, GetProjectPlanResult>
{
    private readonly IProjectPlanRepository repository;
    public GetProjectPlanHandler(IProjectPlanRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetProjectPlanResult> Handle(
        GetProjectPlanQuery request,
        CancellationToken cancellationToken)
    {
        var result = this.repository.GetAll();

        return new GetProjectPlanResult(result);
    }
}

