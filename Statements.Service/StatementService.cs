using Statements.Contracts.Interfaces.Repositories;
using Statements.Contracts.Interfaces.Services;
using Statements.Contracts;
using Statements.Data.EF;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Statements.Contracts.Helper;

namespace Statements.Service
{
  public class StatementService : IStatementService
  {
    private readonly IStatementRepository _statementRepository;
    private readonly IWebHostEnvironment _environment;
    public StatementService(IStatementRepository statementRepository, IWebHostEnvironment environment)
    {
      _statementRepository = statementRepository;
      _environment = environment;
    }

    public void CreateStatement(StatementModel statement)
    {
      SaveImage(statement, false);
      _statementRepository.CreateStatement(statement);
    }

    public void DeleteStatements(int id)
    {
      if(id == 0)
      {
        throw new Exception("Id field is required!");
      }
      var imageUrl = _statementRepository.GetStatementById(id).ImageURL;
      if (String.IsNullOrEmpty(imageUrl))
      {
        throw new Exception("Cant find Image for this id");
      }
      var fullUrl = _environment.WebRootPath + imageUrl;
      if (File.Exists(fullUrl))
      {
        File.Delete(fullUrl);
      }
      _statementRepository.DeleteStatement(id);
    }

    public StatementModel GetStatementById(int id)
    {
      var statement = _statementRepository.GetStatementById(id);
      return statement;
    }

    public List<StatementModel> GetStatementByTitle(string title)
    {
      var statements = _statementRepository.GetStatementByTitle(title).ToList();
      return statements;
    }

    public List<StatementModel> GetStatements()
    {
      var statements = _statementRepository.GetStatements();
      return statements;
    }

    public void UpdateStatement(StatementModel statement)
    {
      if (statement.StatementID == 0)
      {
        throw new Exception("StatementID field is required!");
      }
      SaveImage(statement, true);
      _statementRepository.UpdateStatement(statement);
    }
    private void SaveImage(StatementModel model, bool methodIsUpdate)
    {
      var imageUrl = methodIsUpdate ? _statementRepository.GetStatementById(model.StatementID).ImageURL : "";
      try
      {
        if (model.Image.Length > 0)
        {
          if (!Directory.Exists(_environment.WebRootPath + @"\Images\"))
          {
            Directory.CreateDirectory(_environment.WebRootPath + @"\Images\");
          }
          var imageName = Hash.HashImageName(model.Image.FileName);
          using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + @"\Images\" + imageName))
          {
            model.Image.CopyTo(fileStream);
            fileStream.Flush();
            model.ImageURL = @"\Images\" + imageName;

            if (methodIsUpdate)
            {
              var fullUrl = _environment.WebRootPath + imageUrl;
              if (File.Exists(fullUrl))
              {
                File.Delete(fullUrl);
              }
            }
          }
        }
        else
        {
          throw new Exception("Image field is empty!");
        }

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message.ToString());
      }
    }
  }
}
