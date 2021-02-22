using System.Collections.Generic;
using System.Data;
using Dapper;
using Vacation.Models;

namespace Vacation.Repositories
{
  public class REP_Cruise
  {
    public readonly IDbConnection _db;

    public REP_Cruise(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Cruise> GetAll()
    {
      string sql = "SELECT * FROM cruises";
      return _db.Query<Cruise>(sql);
    }

    public Cruise GetById(int id)
    {
      string sql = "SELECT * FROM cruises WHERE id = @id";
      return _db.QueryFirstOrDefault<Cruise>(sql, new { id });
    }

    public Cruise Create(Cruise newCruise)
    {
      string sql = @"
      INSERT INTO cruises
      (days, dailycharge, location)
      VALUES
      (@Days, @DailyCharge, @Location);
      SELECT LAST_INSERT_ID()";
      newCruise.Id = _db.ExecuteScalar<int>(sql, newCruise);
      return newCruise;
    }

    public Cruise Edit(Cruise newCruise)
    {
      string sql = @"
      UPDATE cruises
      SET
        days = @Days,
        dailycharge = @DailyCharge,
        location = @Location
      WHERE id = @Id;
      SELECT * FROM cruises WHERE id = @Id";
      return _db.QueryFirstOrDefault<Cruise>(sql, newCruise);
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM cruises WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}