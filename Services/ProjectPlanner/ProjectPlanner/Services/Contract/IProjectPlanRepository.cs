
namespace ProjectPlanner.Services.Contract;

public interface IProjectPlanRepository
{
    Guid Add(CreateProjectPlanCommand command);

    IEnumerable<ProjectPlan> GetAll();

    ProjectPlan GetById(Guid Id);

    ProjectPlan GetByName(string Name);

    bool DeleteById(Guid Id);

    ProjectPlan Update(ProjectPlan plan);
}

