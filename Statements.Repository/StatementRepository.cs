using Statements.Contracts.Interfaces.Repositories;
using Statements.Data.EF;
using Statements.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Statements.Repository
{
  public class StatementRepository : IStatementRepository
  {
    private readonly StatementDbContext _context;
   
    public StatementRepository(StatementDbContext context)
    {
      _context = context;
     
    }

    public void CreateStatement(StatementModel statement)
    {
      var createModel = MapToDbModel(statement);
      createModel.CreateDate = DateTime.Now;
      _context.Add(createModel);
      _context.SaveChanges();
    }

    public void DeleteStatement(int id)
    {
      var statementToRemove = GetStatementById(id);
      _context.Statements.Remove(MapToDbModel(statementToRemove));
      _context.SaveChanges();
    }

    public StatementModel GetStatementById(int id)
    {
      return _context.Statements.AsNoTracking().Where(a => a.StatementID == id).Select(MapToModel).FirstOrDefault();
    }

    public List<StatementModel> GetStatementByTitle(string title)
    {
      return _context.Statements.Where(a => a.Title.Contains(title)).Select(MapToModel).ToList();
    }

    public List<StatementModel> GetStatements()
    {
      return _context.Statements.Select(MapToModel).ToList();
    }

    public void UpdateStatement(StatementModel statement)
    {
      var updateModel = MapToDbModel(statement);
      updateModel.UpdateDate = DateTime.Now;
      _context.Statements.Update(updateModel);
      _context.SaveChanges();
    }
    private StatementModel MapToModel(Statement statement)
    {
      return new StatementModel()
      {
        StatementID = statement.StatementID,
        Title = statement.Title,
        Description = statement.Description,
        ImageURL = statement.Image,
        PhoneNumber = statement.PhoneNumber
      };
    }
    private Statement MapToDbModel(StatementModel statement)
    {
      return new Statement()
      {
        StatementID = statement.StatementID,
        Title = statement.Title,
        Description = statement.Description,
        Image = statement.ImageURL,
        PhoneNumber = statement.PhoneNumber
      };
    }
  }
}
