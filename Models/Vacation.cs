using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Vacation.Models
{
  public abstract class Vacation
  {
    public int Id { get; set; }
    [Required]
    public int Days { get; set; }
    [Required]
    public float DailyCharge { get; set; }
    [Required]
    public string Location { get; set; }

    public Vacation() { }

    public Vacation(int days, float dailyCharge, string location)
    {
      Days = days;
      DailyCharge = dailyCharge;
      Location = location;
    }

    public float Cost()
    {
      return Days * DailyCharge;
    }

    public void Edit(JsonElement edits)
    {
      if (edits.TryGetProperty("days", out JsonElement newDays)) { Days = newDays.GetInt32(); }
      if (edits.TryGetProperty("dailyCharge", out JsonElement newCharge)) { DailyCharge = (float)(newCharge.GetDecimal()); }
      if (edits.TryGetProperty("location", out JsonElement newLocation)) { Location = newLocation.ToString(); }
    }
  }
}