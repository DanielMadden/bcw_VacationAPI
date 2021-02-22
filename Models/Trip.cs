using System.Text.Json;

namespace Vacation.Models
{
  public class Trip : Vacation
  {
    public string Housing { get; set; } = "";
    public Trip(int days, float dailyCharge, string location, string housing) : base(days, dailyCharge, location)
    {
      Housing = housing;
    }

    public Trip()
    {
    }
  }
}