using System;
namespace ProjectPlanner.Features.Plans.GetPlans;


public record GetProjectPlanResult(IEnumerable<ProjectPlan> ProjectPlans);


