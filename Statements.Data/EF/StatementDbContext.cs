using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Data.EF
{
  public class StatementDbContext : DbContext
  {
    public DbSet<Statement> Statements { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=DESKTOP-8APBVNT\\SQLEXPRESS;Database=StatementDb;Trusted_Connection=True;");
    }
  }
}
