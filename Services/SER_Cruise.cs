using System.Collections.Generic;
using System.Text.Json;
using Vacation.Models;
using Vacation.Repositories;

namespace Vacation.Services
{
  public class SER_Cruise
  {
    private readonly REP_Cruise _repo;

    public SER_Cruise(REP_Cruise repo)
    {
      _repo = repo;
    }

    public IEnumerable<Cruise> GetAll()
    {
      return _repo.GetAll();
    }

    public Cruise GetById(int id)
    {
      return _repo.GetById(id);
    }

    public Cruise Create(Cruise newCruise)
    {
      return _repo.Create(newCruise);
    }

    public Cruise Edit(int id, JsonElement edits)
    {
      Cruise editCruise = _repo.GetById(id);
      editCruise.Edit(edits);
      return _repo.Edit(editCruise);
    }

    public int Delete(int id)
    {
      return _repo.Delete(id);
    }
  }
}