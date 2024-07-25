
namespace ProjectPlanner.Features.Plans.UpdatePlan;

public class UpdateProjectPlanValidator
	: AbstractValidator<UpdateProjectPlanCommand>
{
	public UpdateProjectPlanValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("ID Should not be null");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name Should not be null");
        RuleFor(x => x.StartDate).NotEmpty().WithMessage("StartDate Should not be null");
        RuleFor(x => x.EndDate).NotEmpty().WithMessage("EndDate Should not be null");
    }
}

