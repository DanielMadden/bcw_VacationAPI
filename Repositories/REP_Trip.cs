using System.Collections.Generic;
using System.Data;
using Dapper;
using Vacation.Models;

namespace Vacation.Repositories
{
  public class REP_Trip
  {
    public readonly IDbConnection _db;

    public REP_Trip(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Trip> GetAll()
    {
      string sql = "SELECT * FROM trips";
      return _db.Query<Trip>(sql);
    }

    public Trip GetById(int id)
    {
      string sql = "SELECT * FROM trips WHERE id = @id";
      return _db.QueryFirstOrDefault<Trip>(sql, new { id });
    }

    public Trip Create(Trip newTrip)
    {
      string sql = @"
      INSERT INTO trips
      (days, dailycharge, location, housing)
      VALUES
      (@Days, @DailyCharge, @Location, @Housing);
      SELECT LAST_INSERT_ID()";
      newTrip.Id = _db.ExecuteScalar<int>(sql, newTrip);
      return newTrip;
    }

    public Trip Edit(Trip newTrip)
    {
      string sql = @"
      UPDATE trips
      SET
        days = @Days,
        dailycharge = @DailyCharge,
        location = @Location,
        housing = @Housing
      WHERE id = @Id;
      SELECT * FROM trips WHERE id = @Id";
      return _db.QueryFirstOrDefault<Trip>(sql, newTrip);
    }

    public int Delete(int id)
    {
      string sql = "DELETE FROM trips WHERE id = @id";
      return _db.Execute(sql, new { id });
    }
  }
}