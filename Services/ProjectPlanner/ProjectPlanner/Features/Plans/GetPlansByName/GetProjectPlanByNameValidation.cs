namespace ProjectPlanner.Features.Plans.GetPlansByName;

public class GetProjectPlanByNameValidation:
	AbstractValidator<GetProjectPlanByNameQuery>
{
	public GetProjectPlanByNameValidation()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Search Name Shouldn't be empty");
	}
}

