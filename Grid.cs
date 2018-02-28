using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Battleships
{
  public class Grid : IGrid
  {
    #region Variables
    public Dictionary<string, Coord> Map { get; set; }
    public int Size { get; set; }

    public ILocationFormat LocationFormat { get; set; }

    #endregion

    #region Constructor

    public Grid(int size, ILocationFormat locationFormat)
    {
      Map = new Dictionary<string, Coord>();
      Size = size;
      LocationFormat = locationFormat;
    }

    #endregion

    #region Methods
    public ShotReport Shot(string location)
    {
      ShotReport shotReport = new ShotReport();

      if (Map.ContainsKey(location))
      {
        Coord coord = Map[location];
        coord.Hit = true;
        shotReport.Hit = true;
        shotReport.Sunk = Map.Where(a => a.Value.Ship == coord.Ship).Where(b => b.Value.Hit == false).Count() == 0;
        shotReport.Description = coord.Ship.Description;
        if (shotReport.Sunk)
        {
          foreach (string key in Map.Where(a => a.Value.Ship == coord.Ship).Select(b => b.Key).ToList())
          {
            Map.Remove(key);
          }
        }
        return shotReport;
      }
      else
      {
        return shotReport;
      }
    }
    public bool HasShips()
    {
      return Map.Where(a => a.Value.Hit == false).Count() > 0;
    }

    public void Reset(List<AShip> ships)
    {
      Random randomGenerator = new Random();

      foreach (AShip ship in ships)
      {
        Vector vector;
        vector = new Vector(LocationFormat);
        vector.Mag = ship.Size;
        vector.Max = Size - 1;
        do
        {
          vector.X = randomGenerator.Next(0, vector.Max);
          vector.Y = randomGenerator.Next(0, vector.Max);
          vector.Dir = (Direction)randomGenerator.Next(0, 3);
          //vector.X = 2;
          //vector.Y = 0;
          //vector.Dir = (Direction) 3;
        } while (!vector.IsValid() || IsOccupied(vector));

        AddShip(ship, vector);
      }
    }

    protected bool IsOccupied(Vector vector)
    {
      return vector.GetKeys().Where(a => Map.ContainsKey(a)).Count() > 0;
    }

    protected void AddShip(AShip ship, Vector vector)
    {
      foreach (string key in vector.GetKeys())
      {
        // comment out to hide where ships are located
        Console.WriteLine(key + " " + ship.Description);
        Map.Add(key, new Coord(ship));
      }
      Console.WriteLine(String.Empty);
    }

    #endregion
  }
}
