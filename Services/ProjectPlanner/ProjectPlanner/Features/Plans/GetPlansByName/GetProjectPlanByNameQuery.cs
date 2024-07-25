
namespace ProjectPlanner.Features.Plans.GetPlansByName;

public record GetProjectPlanByNameQuery(string Name): IQuery<GetProjectPlanByNameResult>;


