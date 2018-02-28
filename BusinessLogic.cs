using System;
using System.Collections.Generic;

namespace Battleships
{

  public static class BusinessLogic
    {
    public static void ResetShipLocations(List<AShip> ships, Grid grid)
    {
      Random randomGenerator = new Random();

      foreach (AShip ship in ships)
      {
        Vector vector;
        vector = new Vector();
        vector.Mag = ship.Size;
        vector.Max = grid.Size - 1;
        do
        {
          vector.X = randomGenerator.Next(0, grid.Size);
          vector.Y = randomGenerator.Next(0, grid.Size);
          vector.Dir = (Direction)randomGenerator.Next(0, 3);
        } while (!vector.IsValid() && !grid.IsOccupied(vector));

        grid.AddShip(ship, vector);
      }
    }
  }
}
