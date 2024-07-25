﻿namespace ProjectPlanner.Features.Plans.GetPlans;

public record GetProjectPlanQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProjectPlanResult>;

