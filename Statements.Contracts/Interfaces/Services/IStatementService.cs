using Statements.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Contracts.Interfaces.Services
{
  public interface IStatementService
  {
    List<StatementModel> GetStatements();
    StatementModel GetStatementById(int id);
    List<StatementModel> GetStatementByTitle(string title);
    void DeleteStatements(int id);
    void CreateStatement(StatementModel statement);
    void UpdateStatement(StatementModel statement);
  }
}
