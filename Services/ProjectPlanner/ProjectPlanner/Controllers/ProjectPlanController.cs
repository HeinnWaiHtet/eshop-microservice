
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectPlanner.Controllers;

[Route("api/v1/[controller]")]
public class ProjectPlanController : Controller
{
    private readonly IMediator _mediator;
    public ProjectPlanController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(typeof(CreateProjectPlanResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    [Produces("application/json")]
    [EndpointSummary("Create ProjectPlan")]
    [EndpointDescription("Create ProjectPlan")]
    public async Task<IActionResult> CreateNewPlan([FromBody]CreateProjectPlanCommand request)
    {
        var response = await this._mediator.Send(request);
        return CreatedAtAction(nameof(Get), new { Id = response.Id}, response);
    }

    // GET: api/values
    [HttpGet]
    [ProducesResponseType(typeof(CreateProjectPlanResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    [Produces("application/json")]
    [EndpointSummary("Get ProjectPlan")]
    [EndpointDescription("Get ProjectPlan")]
    public async Task<IActionResult> Get()
    {
        var response = await this._mediator.Send(new GetProjectPlanQuery());
        return Ok(response);
    }

    [HttpGet("{Name}")]
    [ProducesResponseType(typeof(CreateProjectPlanResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    [Produces("application/json")]
    [EndpointSummary("Get ProjectPlan By Name")]
    [EndpointDescription("Get ProjectPlan By Name")]
    public async Task<IActionResult> GetByName(string name)
    {
        var response = await this._mediator.Send(new GetProjectPlanByNameQuery(name));
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(typeof(CreateProjectPlanResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    [Produces("application/json")]
    [EndpointSummary("Update ProjectPlan")]
    [EndpointDescription("Update ProjectPlan")]
    public async Task<IActionResult> Put([FromBody] ProjectPlan value)
    {
        var data = value.Adapt<UpdateProjectPlanCommand>();
        var response = await this._mediator.Send(data);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(CreateProjectPlanResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    [Produces("application/json")]
    [EndpointSummary("Delete ProjectPlan")]
    [EndpointDescription("Delete ProjectPlan")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = id.Adapt<DeleteProjectPlanCommand>();
        var response = await this._mediator.Send(command);
        return Ok(response);
    }
}

