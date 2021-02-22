namespace Vacation.Models
{
  public class Cruise : Vacation
  {
    public Cruise(int days, float dailyCharge, string location) : base(days, dailyCharge, location)
    {
    }

    public Cruise() { }
  }
}