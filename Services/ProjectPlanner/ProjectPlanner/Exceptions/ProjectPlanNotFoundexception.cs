
using BuildingBlocks.Exceptions;

namespace ProjectPlanner.Exceptions
{
	public class ProjectPlanNotFoundexception: NotFoundException
	{
		public ProjectPlanNotFoundexception(string message): base("Project Plan", message)
		{
		}

        public ProjectPlanNotFoundexception(Guid Id) : base("Project Plan", Id)
        {
        }
    }
}

