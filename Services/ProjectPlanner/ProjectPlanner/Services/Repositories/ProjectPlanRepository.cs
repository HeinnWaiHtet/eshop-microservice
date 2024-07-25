
namespace ProjectPlanner.Services.Repositories;

public class ProjectPlanRepository
	: IProjectPlanRepository
{
    private readonly IList<ProjectPlan> plans = new List<ProjectPlan>();
    public ProjectPlanRepository()
    {
        SetProjectPlans();
    }

    public Guid Add(CreateProjectPlanCommand command)
    {
        var model = new ProjectPlan
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            IsDone = command.IsDone,
            StartDate = command.StartDate,
            EndDate = command.EndDate
        };

        this.plans.Add(model);
        return model.Id;
    }

    public bool DeleteById(Guid Id)
    {
        var result = this.plans.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        return result is not null;
    }

    public IEnumerable<ProjectPlan> GetAll()
    {
        return this.plans;
    }

    public ProjectPlan GetById(Guid Id)
    {
        return this.plans.Where(x => x.Id.Equals(Id)).FirstOrDefault() ?? new ProjectPlan();
    }

    public ProjectPlan GetByName(string Name)
    {
        return this.plans.Where(x => x.Name.Equals(Name)).FirstOrDefault() ?? new ProjectPlan();
    }

    public ProjectPlan Update(ProjectPlan plan)
    {
        var result = this.plans.Where(x => x.Id.Equals(plan.Id)).FirstOrDefault();

        return plan;
    }

    private void SetProjectPlans()
    {
        for(var i = 0; i < 5; i++)
        {
            this.plans.Add(CreateNewPlan());
        }
    }

    private ProjectPlan CreateNewPlan()
    {
        var newId = Guid.NewGuid();
        return new ProjectPlan()
        {
            Name = $"Plan{newId}",
            IsDone = false,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(10),
            Id = newId
        };
    }
}

