using System.Collections.Generic;
using System.Text.Json;
using Vacation.Models;
using Vacation.Repositories;

namespace Vacation.Services
{
  public class SER_Trip
  {
    private readonly REP_Trip _repo;

    public SER_Trip(REP_Trip repo)
    {
      _repo = repo;
    }

    public IEnumerable<Trip> GetAll()
    {
      return _repo.GetAll();
    }

    public Trip GetById(int id)
    {
      return _repo.GetById(id);
    }

    public Trip Create(Trip newTrip)
    {
      return _repo.Create(newTrip);
    }

    public Trip Edit(int id, JsonElement edits)
    {
      Trip editTrip = _repo.GetById(id);
      editTrip.Edit(edits);
      if (edits.TryGetProperty("housing", out JsonElement newHousing)) { editTrip.Housing = newHousing.ToString(); }
      return _repo.Edit(editTrip);
    }

    public int Delete(int id)
    {
      return _repo.Delete(id);
    }
  }
}