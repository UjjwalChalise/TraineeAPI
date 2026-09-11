using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Exceptions;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentSubmissionsController : ControllerBase
{
    private readonly IAssignmentSubmissionService _submissionService;

    public AssignmentSubmissionsController(IAssignmentSubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpGet("assignment/{assignmentId}")]
    public async Task<ActionResult<IEnumerable<AssignmentSubmissionViewModel>>> GetByAssignment(int assignmentId)
        => Ok(await _submissionService.GetSubmissionsByAssignmentIdAsync(assignmentId));

    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentSubmissionViewModel>> GetById(int id)
    {
        var submission = await _submissionService.GetSubmissionByIdAsync(id);
        return submission is null ? NotFound() : Ok(submission);
    }

    [HttpPost]
    public async Task<ActionResult<AssignmentSubmissionViewModel>> Create(CreateAssignmentSubmissionViewModel model)
    {
        try
        {
            var created = await _submissionService.CreateSubmissionAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (SubmissionLimitExceededException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}