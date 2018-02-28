using System;
using System.Collections.Generic;

namespace Battleships
{
  class Program
  {
    static void Main()
    {
      List<AShip> ships = new List<AShip>();
      ships.Add(ObjectFactory.CreateShip(typeof(Battleship)));
      ships.Add(ObjectFactory.CreateShip(typeof(Destroyer)));
      ships.Add(ObjectFactory.CreateShip(typeof(Destroyer)));

      StandardGrid grid = new StandardGrid();
      grid.Reset(ships);

      string location;
      Console.WriteLine("Enter locations...");
      do
      {
        location = Console.ReadLine().ToLower();
        if (!grid.LocationFormat.IsValidLocation(location))
        {
          Console.WriteLine("Invalid location.  Please input coordinate in one letter and one digit format [A-J][0-9].  Example A5.");
        }
        else
        {
          Console.WriteLine(grid.Shot(location).GetReport());
        }
      } while (location != null && location.Length > 0 && grid.HasShips());

      Console.WriteLine("Game over.  Press any key to continue...");
      Console.ReadKey();
    }
  }
}