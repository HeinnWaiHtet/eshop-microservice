
namespace ProjectPlanner.Features.Plans.DeletePlan;

public class DeleteProjectPlanValidator
	: AbstractValidator<DeleteProjectPlanCommand>
{
	public DeleteProjectPlanValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("You need to add your delete Key");
	}
}

