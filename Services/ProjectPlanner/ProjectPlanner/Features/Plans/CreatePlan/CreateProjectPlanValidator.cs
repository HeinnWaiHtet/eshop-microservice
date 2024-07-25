
namespace ProjectPlanner.Features.Plans.CreatePlan;

public class CreateProjectPlanValidator
    : AbstractValidator<CreateProjectPlanCommand>
{
    public CreateProjectPlanValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name Should Not Be Null");
    }
}

