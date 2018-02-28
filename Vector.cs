using System.Collections.Generic;

namespace Battleships
{
  public enum Direction { Left, Right, Up, Down, Default };
  public class Vector
  {
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Dir { get; set; }
    public int Mag { get; set; }
    public int Max { get; set; }

    protected ILocationFormat _locationFormat;
    public Vector(ILocationFormat locationFormat)
    {
      X = 0;
      Y = 0;
      Dir = Direction.Default;
      Mag = 0;
      Max = 0;
      _locationFormat = locationFormat;
    }
    public bool IsValid()
    {
      switch (Dir)
      {
        case Direction.Left:
          if (X - Mag < 0)
          {
            return false;
          }
          break;
        case Direction.Right:
          if (X + Mag > Max)
          {
            return false;
          }
          break;
        case Direction.Down:
          if (Y - Mag < 0)
          {
            return false;
          }
          break;
        case Direction.Up:
          if (Y + Mag > Max)
          {
            return false;
          }
          break;
      }

      return true;
    }

    public List<string> GetKeys()
    {
      int x = X;
      int y = Y;
      List<string> keys = new List<string>();

      switch (Dir)
      {
        case Direction.Left:
          for (int i = 0; i < Mag; i++, x--)
          {
            keys.Add(_locationFormat.Convert2DToKey(x, Y));
          }
          break;
        case Direction.Right:
          for (int i = 0; i < Mag; i++, x++)
          {
            keys.Add(_locationFormat.Convert2DToKey(x, Y));
          }
          break;
        case Direction.Down:
          for (int i = 0; i < Mag; i++, y--)
          {
            keys.Add(_locationFormat.Convert2DToKey(X, y));
          }
          break;
        case Direction.Up:
          for (int i = 0; i < Mag; i++, y++)
          {
            keys.Add(_locationFormat.Convert2DToKey(X, y));
          }
          break;
      }
      return keys;
    }

  }
}
