using Statements.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Contracts.Interfaces.Repositories
{
  public interface IStatementRepository
  {
    List<StatementModel> GetStatements(); 
    StatementModel GetStatementById(int id);
    List<StatementModel> GetStatementByTitle(string title);
    void DeleteStatement(int id);
    void UpdateStatement(StatementModel statement);
    void CreateStatement(StatementModel statement);
  }
}
