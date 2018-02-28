using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
  public class ShotReport : IShot
  {
    public bool Hit { get; set; }

    public bool Sunk { get; set; }
    public string Description { get; set; }

    public ShotReport()
    {
      Hit = false;
      Sunk = false;
      Description = String.Empty;
    }

    public string GetReport()
    {
      StringBuilder sb = new StringBuilder();
      if (Hit)
      {
        sb.AppendLine("Hit!");
        if (Sunk)
        {
          sb.AppendLine(Description + " Sunk");
        }
      }
      else
      {
        sb.AppendLine("Missed.");
      }
      return sb.ToString();
    }
  }
}
