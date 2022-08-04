using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Statements.Contracts.Interfaces.Services;
using Statements.Data.EF;
using Statements.Contracts;

namespace Statements.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatementController : ControllerBase
  {
    private readonly IStatementService _statementService;
    public StatementController(IStatementService statementService)
    {
      _statementService = statementService;
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] StatementModel model)
    {
      _statementService.CreateStatement(model);
      return Ok();
    }
    [HttpDelete("delete")]
    public void Delete(int id)
    {
      _statementService.DeleteStatements(id);
    }
    [HttpGet("GetStatementById")]
    public IActionResult GetStatement(int id)
    {
      return new ObjectResult(_statementService.GetStatementById(id));
    }
    [HttpGet("GetStatementByTitle")]
    public IEnumerable<StatementModel> GetStatementByTitle(string title)
    {
      return _statementService.GetStatementByTitle(title);
    }
    [HttpGet("GetStatements")]
    public IEnumerable<StatementModel> GetStatements()
    {
      return _statementService.GetStatements();
    }
    [HttpPut("Update")]
    public IActionResult UpdateStatements([FromForm] StatementModel model)
    {
      _statementService.UpdateStatement(model);
      return Ok();
    }
  }
}
