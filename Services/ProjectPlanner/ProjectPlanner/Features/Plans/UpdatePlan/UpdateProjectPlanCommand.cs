
namespace ProjectPlanner.Features.Plans.UpdatePlan;

public record UpdateProjectPlanCommand(
	Guid Id,
	string Name,
	bool IsDone,
	DateTime StartDate,
	DateTime EndDate): ICommand<UpdateProjectPlanResult>;