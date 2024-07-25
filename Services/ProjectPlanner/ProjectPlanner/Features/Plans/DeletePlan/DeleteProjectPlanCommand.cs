
namespace ProjectPlanner.Features.Plans.DeletePlan;

public record DeleteProjectPlanCommand(Guid Id):ICommand<DeleteProjectPlanQuery>;


