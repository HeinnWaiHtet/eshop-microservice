
namespace ProjectPlanner.Features.Plans.CreatePlan;

public record CreateProjectPlanCommand(
    string Name,
    bool IsDone,
    DateTime StartDate,
    DateTime EndDate) : ICommand<CreateProjectPlanResult>;

